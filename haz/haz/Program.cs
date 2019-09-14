//
// Hazard Detector
//
//   Description:
//     Hazard Detector reads in a program, detects hazards and output two
//     timing diagrams. First it outputs the timing diagram with flushes. This
//     implies there is no hazard mitigation, so the pipeline is flushed. The
//     second timing diagram is with the mitigation which is inserting stalls
//     into the pipeline stages.
//
//   Author: 
//     Mudit Vats (mpvats@syr.edu)
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace haz
{
	class Program
	{ 
		public class Instruction
		{
			public string instruction;
			public string dest;
			public string src;
			public int instructionNum;
			public bool hazardPresent;

			public Instruction()
			{
				instruction = String.Empty;
				dest = String.Empty;
				src = String.Empty;
				instructionNum = 0;
				hazardPresent = false;
			}

			public void Display()
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(instruction);
				sb.Append(" " + dest);
				sb.Append(" " + src);

				Console.WriteLine(sb.ToString());
			}
		}

		public class Parser
		{
			public void Parse(string line, ref Instruction instruction)
			{
				string[] splitter;
				string tmpLine = line.Trim();

				// Empty line: ""
				if (tmpLine.Length == 0)
				{
					return;
				}

				// Comment line: "# comment"
				if (tmpLine[0].Equals('#'))
				{
					return;
				}

				// Program line: "instruction oper1, oper2, oper3	# comment"
				// Split out trailing comment #
				if (tmpLine.Contains('#'))
				{
					splitter = tmpLine.Split('#');
					tmpLine = splitter[0].Trim();
				}

				// instruction oper1, oper2
				// Split out instruction oper1, oper2
				splitter = tmpLine.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
				instruction.instruction = splitter[0].Trim();

				// At this point, splitter should contain: instruction oper1, oper2.
				// We only want to extract "oper1, oper2"
				if (splitter.Count() > 1)
				{
					string tempOperand = splitter[1];
					string[] operandSplitter = tempOperand.Split(',');

					instruction.dest = operandSplitter[0].Trim();
				}

				if (splitter.Count() > 2)
				{
					string tempOperand = splitter[2];
					string[] operandSplitter = tempOperand.Split(',');

					instruction.src = operandSplitter[0].Trim();
				}
			}
		}

		public class Pipeline
		{
			// Valid instruction to execute
			List<Instruction> m_instructions = null;

			// Instruction state per cycle per instruction
			List<InstructionState> m_instState = new List<InstructionState>();

			// Pipeline stages queues
			Queue<Instruction> m_fetchQueue = new Queue<Instruction>();
			Queue<Instruction> m_decodeQueue = new Queue<Instruction>();
			Queue<Instruction> m_executeQueue = new Queue<Instruction>();
			Queue<Instruction> m_memoryQueue = new Queue<Instruction>();
			Queue<Instruction> m_writebackQueue = new Queue<Instruction>();

			// Register availability status for r0-r7
			Dictionary<string, int> regAvail = new Dictionary<string, int>(); 

			int m_programCounter = 0;           // program counter
			int m_cycles = 0;                   // current cycle
			bool m_doStall = false;             // do stalls if true
			bool m_flushPipeline = false;       // currently in flushing state
			int m_flushInstructionNumber = 0;   // flush up to and including this instruction
			int m_maxCycles = 30;    	        // holds max cycles passed in

			public class InstructionState
			{
				// each element is stage FDEMW
				public List<string> stage = new List<string>();

				public void InstructionStateInitialize(int maxCycles)
				{
					for (int i=0; i< maxCycles; i++)
					{
						stage.Add(".");
					}
				}
			}

			public Pipeline(List<Instruction> instructions, bool doStall, int maxCycles)
			{
				m_instructions = instructions;

				regAvail.Add("r0", 0);
				regAvail.Add("r1", 0);
				regAvail.Add("r2", 0);
				regAvail.Add("r3", 0);
				regAvail.Add("r4", 0);
				regAvail.Add("r5", 0);
				regAvail.Add("r6", 0);
				regAvail.Add("r7", 0);

				m_doStall = doStall;
				m_maxCycles = maxCycles;
			}

			public void fetch()
			{
				if (!m_doStall)
				{
					if (m_flushPipeline)
					{
						// check that instruction previous to flush is in writeback stage
						if (m_instState[m_flushInstructionNumber].stage[m_cycles] == "W")
						{
							// get out of flush
							m_flushPipeline = false;
							m_flushInstructionNumber = 0;
						}

						// return so we get the new instruction on the next iteration;
						// we will then be past the writeback stage
						return;
					}
				}

				// fetch only if the queue is empty; we only have one fetch unit, 
				// so we are not going to queue more than one fetched instruction
				if (m_fetchQueue.Count == 0)
				{
					if (m_programCounter < m_instructions.Count)
					{
						Instruction instruction = m_instructions[m_programCounter];

						if (!m_doStall)
						{
							// Data hazard detector
							string dest = instruction.dest;
							string src = instruction.src;
							if (regAvail.ContainsKey(src))
							{
								if (regAvail[src] > 0)
								{
									// hazard detected
									instruction.hazardPresent = true;

									// don't enqueue, since we have a data hazard
									m_flushPipeline = true;
									m_flushInstructionNumber = m_programCounter - 1;
									return;
								}
							}

							if ((regAvail[dest] > 0) && 
								((instruction.instruction != "regi") && 
								(instruction.instruction != "regr")  && 
								(instruction.instruction != "rand") &&
								(instruction.instruction != "memr")
								))
							{
								// hazard detected
								instruction.hazardPresent = true;

								// don't enqueue, since we have a data hazard
								m_flushPipeline = true;
								m_flushInstructionNumber = m_programCounter - 1;
								return;
							}
						}

						// queue the instruction; the m_fetchQueue contains the instruction to be
						// processed by the next stage -- decode
						m_fetchQueue.Enqueue(instruction);

						// increment the program counter to point to the next instruction
						m_programCounter++;

						m_instState[instruction.instructionNum].stage[m_cycles] = "F";
					}
				}
				else
				{
					m_instState[m_fetchQueue.Peek().instructionNum].stage[m_cycles] = "S";
				}
			}

			// this code will dequeue the fetch queue to grab an instruction
			// if fetchQueue > 0, then dequeue the instruction, enque it for decode operation.
			// decode it, save register info
			// there is only one decode running at a time as well
			public void decode()
			{
				if (m_fetchQueue.Count > 0)
				{
					// we have something we should dequeue and work with, but we can't 
					// work with it if we already have an item in the decode queue
					if (m_decodeQueue.Count > 0)
					{
						m_instState[m_decodeQueue.Peek().instructionNum].stage[m_cycles] = "S";

						// we are stalled because execute hasn't dequeued this yet
						return;
					}

					// do some instruction processing
					Instruction peek = m_fetchQueue.Peek();
					string dest = peek.dest;
					string src = peek.src;

					if (regAvail.ContainsKey(src))
					{
						if (regAvail[src] > 0)
						{
							// src not available so we are stalling...
							m_instState[m_fetchQueue.Peek().instructionNum].stage[m_cycles] = "S";
							return;
						}
					}

					if ((regAvail[dest] == 0) || 
						(peek.instruction == "regi") || 
						(peek.instruction == "regr") || 
						(peek.instruction == "rand") ||
						(peek.instruction == "memr"))
					{
						// registers are clear, so we can dequeue fetchQueue and encode the 
						// instruction for the next stage
						Instruction current = m_fetchQueue.Dequeue();

						// memm write memory, so once we decode, we don't need to writeback,
						// so, don't hold onto the register
						if (current.instruction != "memm")
						{
							regAvail[dest] = regAvail[dest] + 1;
							//Console.WriteLine("c " + peek.instruction + " " + dest + ": " + regAvail[dest]);
						}

						m_instState[current.instructionNum].stage[m_cycles] = "D";

						// enqueue the insturction into decode queue, this contains decoded items 
						// for the next stage -- execute
						m_decodeQueue.Enqueue(current);
					}
				}
			}
			public void execute()
			{
				if (m_decodeQueue.Count > 0)
				{
					// we have something we should dequeue and work with, but we can't 
					// work with it if we already have an item in the execute queue
					if (m_executeQueue.Count > 0)
					{
						m_instState[m_executeQueue.Peek().instructionNum].stage[m_cycles] = "S";

						// we are stalled because memory stage hasn't dequeued this yet
						return;
					}

					// do some instruction processing
					// ALU just does some operation, we don't care about the actual operation.
					// the actual operations are performed on internal registers, so we just
					// enque what we have to the next stage
					
					// registers are clear, so we can dequeue fetchQueue and encode the 
					// instruction for the next stage
					Instruction current = m_decodeQueue.Dequeue();

					m_instState[current.instructionNum].stage[m_cycles] = "E";

					// enqueue the insturction into decode queue, this contains decoded items 
					// for the next stage -- execute
					m_executeQueue.Enqueue(current);
				}
			}
			public void memory()
			{
				if (m_executeQueue.Count > 0)
				{
					// we have something we should dequeue and work with, but we can't 
					// work with it if we already have an item in the execute queue
					if (m_memoryQueue.Count > 0)
					{
						m_instState[m_memoryQueue.Peek().instructionNum].stage[m_cycles] = "S";

						// we are stalled because memory stage hasn't dequeued this yet
						return;
					}

					// registers are clear, so we can dequeue fetchQueue and encode the 
					// instruction for the next stage
					Instruction current = m_executeQueue.Dequeue();

					m_instState[current.instructionNum].stage[m_cycles] = "M";

					// enqueue the insturction into decode queue, this contains decoded items 
					// for the next stage -- execute
					m_memoryQueue.Enqueue(current);
				}
			}
			public void writeback()
			{
				if (m_memoryQueue.Count > 0)
				{
					// do some instruction processing
					Instruction peek = m_memoryQueue.Peek();
					string dest = peek.dest;

					// registers are clear, so we can dequeue fetchQueue and encode the 
					// instruction for the next stage
					Instruction current = m_memoryQueue.Dequeue();
					if (current.instruction != "memm")
					{
						regAvail[dest] = regAvail[dest] - 1;
					}
					//Console.WriteLine("wb " + peek.instruction + " " + dest + ": " + regAvail[dest]);

					m_instState[current.instructionNum].stage[m_cycles] = "W";
				}
			}

			public void doPipeline()
			{
				// Add instruction state for each intruction
				for (int i = 0; i < m_instructions.Count; i++)
				{
					InstructionState newInstructionState = new InstructionState();
					newInstructionState.InstructionStateInitialize(m_maxCycles);
					m_instState.Add(newInstructionState);
				}

				// Run through pipeline
				while (m_cycles < m_maxCycles)
				{
					writeback();
					memory();
					execute();
					decode();
					fetch();

					m_cycles++;
				}

				// Done, show output
				Display();
			}

			public void Display()
			{
				if (!m_doStall)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Detect: Pipeline w/Flushes");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Solution: Pipeline w/Stalls");
				}
				Console.ResetColor();

				for (int i = 0; i < m_instructions.Count; i++)
				{
					if (m_instructions[i].hazardPresent)
					{
						if (!m_doStall)
						{
							Console.ForegroundColor = ConsoleColor.Red;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Green;
						}
					}
					Console.Write(m_instructions[i].instruction + " ");
					Console.Write(m_instructions[i].dest);
					if (m_instructions[i].src != String.Empty)
					{
						Console.Write(", " + m_instructions[i].src + "\t");
					}
					else
					{
						Console.Write("    \t");
					}

					for (int j = 0; j < m_maxCycles; j++)
					{
						Console.Write(m_instState[i].stage[j] + " ");
					}
					Console.WriteLine();
					Console.ResetColor();
				}

				for (int j = 0; j < m_maxCycles; j++)
				{
					if (m_instState[m_instructions.Count - 1].stage[j] == "W")
					{
						Console.Write("Total Cycles: " + (j + 1));
						Console.WriteLine();
						break;
					}
				}
			}
		}

		static void Main(string[] args)
		{
			int maxCycles = 30;
			string filename = String.Empty;

			if (args.Count() == 0)
			{
				Console.WriteLine("Hazard Detector");
				Console.WriteLine("haz filename <maxCycles>");
				Console.WriteLine("  filename      filenames");
				Console.WriteLine("  <maxCycles>   maximum pipeline cycles (optional)");
				return;
			}

			if (args.Count() > 0)
			{
				filename = args[0];
			}

			if (args.Count() > 1)
			{
				if (!int.TryParse(args[1], out maxCycles))
				{
					maxCycles = 30;
				}
			}
			
			Console.WriteLine("Hazard Detector");
			Console.WriteLine("Filename:  " + filename);
			Console.WriteLine("MaxCycles: " + maxCycles);
			Console.WriteLine();
			Console.WriteLine("Available Instructions (regs r0-r7):");
			Console.WriteLine("  regr rX, rY   # reg to reg move");
			Console.WriteLine("  regi rX, 777  # imm to reg move");
			Console.WriteLine("  memr rX, rY   # mem to reg move, rX = *rY");
			Console.WriteLine("  memm rX, rY   # reg to mem move, *rX = rY");
			Console.WriteLine("  addr rX, rY   # rX = rY + rX");
			Console.WriteLine("  subr rX, rY   # rX = rY - rX");
			Console.WriteLine("  mulr rX, rY   # rX = rY * rX");
			Console.WriteLine("  divr rX, rY   # rX = rY / rX");
			Console.WriteLine("  modr rX, rY   # rX = rX % rY");
			Console.WriteLine("  rand rX       # random number");
			Console.WriteLine();

			// Read file
			string file = String.Empty;
			try
			{
				file = File.ReadAllText(filename);
			}
			catch (Exception e)
			{
				Console.WriteLine("Couldn't open file {0}, bailing!", filename);
				return;
			};

			string[] lines = file.Split('\n');

			// Parse instruction lines and get valie instructions
			Parser parser = new Parser();
			List<Instruction> validInstructions = new List<Instruction>();
			int instNum = 0;
			foreach (string s in lines)
			{
				Instruction i = new Instruction();
				parser.Parse(s, ref i);
				if (i.instruction != string.Empty)
				{
					i.instructionNum = instNum++;
					validInstructions.Add(i);
				}
			}

			// Run through pipeline w/flushes on data hazard
			Pipeline pipeline = new Pipeline(validInstructions, false, maxCycles);
			pipeline.doPipeline();
			Console.WriteLine();

			// Run through pipeline w/stalls on data hazard
			pipeline = new Pipeline(validInstructions, true, maxCycles);
			pipeline.doPipeline();
		}
	}
}
