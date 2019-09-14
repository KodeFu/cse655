﻿using System;
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

			public Instruction()
			{
				instruction = String.Empty;
				dest = String.Empty;
				src = String.Empty;
				instructionNum = 0;
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
			List<Instruction> m_instructions = null;
			int m_programCounter = 0;
			int m_cycles = 0;
			bool m_stall = false;

			public class instructionState
			{
				// 100 is number of cycles
				// each element is stage FDEMW
				public List<string> stage = new List<string>();

				public instructionState()
				{
					for (int i=0; i<100; i++)
					{
						stage.Add(".");
					}
				}
			}
			public List<instructionState> m_instState = new List<instructionState>();

			Queue<Instruction> m_fetchQueue = new Queue<Instruction>();
			Queue<Instruction> m_decodeQueue = new Queue<Instruction>();
			Queue<Instruction> m_executeQueue = new Queue<Instruction>();
			Queue<Instruction> m_memoryQueue = new Queue<Instruction>();
			Queue<Instruction> m_writebackQueue = new Queue<Instruction>();

			Dictionary<string, bool> regAvail = new Dictionary<string, bool>(); // contains availability of r0-r1

			const int MAX_CYCLES = 30;

			public Pipeline(List<Instruction> instructions, bool stall)
			{
				m_instructions = instructions;

				regAvail.Add("r0", true);
				regAvail.Add("r1", true);
				regAvail.Add("r2", true);
				regAvail.Add("r3", true);
				regAvail.Add("r4", true);
				regAvail.Add("r5", true);
				regAvail.Add("r6", true);
				regAvail.Add("r7", true);

				m_stall = stall;
			}

			bool flushYo = false;
			int flushCounter = 0;
			public void fetch()
			{
				if (!m_stall)
				{
					if (flushYo)
					{
						// check that instruction previous to flush is in writeback stage
						if (m_instState[flushCounter].stage[m_cycles] == "W")
						{
							// get out of flush
							flushYo = false;
							flushCounter = 0;
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

						if (!m_stall)
						{
							// Data hazard detector
							string dest = instruction.dest;
							string src = instruction.src;
							if (regAvail.ContainsKey(src))
							{
								if (!regAvail[src])
								{
									// don't enqueue, since we have a data hazard
									flushYo = true;
									flushCounter = m_programCounter - 1;
									return;
								}
							}

							if (!regAvail[dest])
							{
								// don't enqueue, since we have a data hazard
								flushYo = true;
								flushCounter = m_programCounter - 1;
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
					//Console.WriteLine("fetch stalled");
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
						//Console.WriteLine("decode stalled");
						return;
					}

					// do some instruction processing
					Instruction peek = m_fetchQueue.Peek();
					string dest = peek.dest;
					string src = peek.src;

					if (regAvail.ContainsKey(src))
					{
						if (!regAvail[src])
						{
							// src not available so we are stalling...
							m_instState[m_fetchQueue.Peek().instructionNum].stage[m_cycles] = "S";
							return;
						}
					}

					if (regAvail[dest])
					{
						// registers are clear, so we can dequeue fetchQueue and encode the 
						// instruction for the next stage
						Instruction current = m_fetchQueue.Dequeue();
						regAvail[dest] = false;
						//regInternal[dest] = regValues[dest];

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
						//Console.WriteLine("execute stalled");
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
						//Console.WriteLine("memory stalled");
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
					//if (regAvail[dest])
					{
						// registers are clear, so we can dequeue fetchQueue and encode the 
						// instruction for the next stage
						Instruction current = m_memoryQueue.Dequeue();
						regAvail[dest] = true;
						//regInternal[dest] = regValues[dest];

						m_instState[current.instructionNum].stage[m_cycles] = "W";

						//Console.WriteLine(current.instruction);
					}
				}
			}

			public void doPipeline()
			{

				for (int i = 0; i < m_instructions.Count; i++)
				{
					instructionState newInstructionState = new instructionState();
					m_instState.Add(newInstructionState);
				}


				while (m_cycles < MAX_CYCLES)
				{
					writeback();
					memory();
					execute();
					decode();
					fetch();

					m_cycles++;
				}

				Display();
			}

			public void Display()
			{
				if (!m_stall)
				{
					Console.WriteLine("Detect: Pipeline w/Flushes");
				}
				else
				{
					Console.WriteLine("Solution: Pipeline w/Stalls");
				}

				for (int i = 0; i < m_instructions.Count; i++)
				{
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

					for (int j = 0; j < MAX_CYCLES; j++)
					{
						Console.Write(m_instState[i].stage[j] + " ");
					}
					Console.WriteLine();
				}

			}
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Hazard Detector");
			Console.WriteLine("file: " + args[0] + "\n");

			// Read file
			string file = File.ReadAllText(args[0]);
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
			Pipeline pipeline = new Pipeline(validInstructions, false);
			pipeline.doPipeline();
			Console.WriteLine();

			// Run through pipeline w/stalls on data hazard
			pipeline = new Pipeline(validInstructions, true);
			pipeline.doPipeline();
		}

		
	}
}
