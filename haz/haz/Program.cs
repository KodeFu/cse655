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

			public Instruction()
			{
				instruction = String.Empty;
				dest = String.Empty;
				src = String.Empty;
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

			Queue<Instruction> m_fetchQueue = new Queue<Instruction>();
			Queue<Instruction> m_decodeQueue = new Queue<Instruction>();
			Queue<Instruction> m_executeQueue = new Queue<Instruction>();
			Queue<Instruction> m_memoryQueue = new Queue<Instruction>();
			Queue<Instruction> m_writebackQueue = new Queue<Instruction>();

			Dictionary<string, bool> regAvail = new Dictionary<string, bool>(); // contains availability of r0-r1
			Dictionary<string, int> regValues = new Dictionary<string, int>(); // contains register values
			Dictionary<string, int>  regInternal = new Dictionary<string, int>(); // contains internal saved regs

			public Pipeline(List<Instruction> instructions)
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

				regValues.Add("r0", 0);
				regValues.Add("r1", 0);
				regValues.Add("r2", 0);
				regValues.Add("r3", 0);
				regValues.Add("r4", 0);
				regValues.Add("r5", 0);
				regValues.Add("r6", 0);
				regValues.Add("r7", 0);

				regInternal.Add("r0", 0);
				regInternal.Add("r1", 0);
				regInternal.Add("r2", 0);
				regInternal.Add("r3", 0);
				regInternal.Add("r4", 0);
				regInternal.Add("r5", 0);
				regInternal.Add("r6", 0);
				regInternal.Add("r7", 0);
			}

			public void fetch()
			{
				// fetch only if the queue is empty; we only have one fetch unit, 
				// so we are not going to queue more than one fetched instruction
				if (m_fetchQueue.Count == 0)
				{
					if (m_programCounter < m_instructions.Count)
					{
						Instruction instruction = m_instructions[m_programCounter];

						// queue the instruction; the m_fetchQueue contains the instruction to be
						// processed by the next stage -- decode
						m_fetchQueue.Enqueue(instruction);

						// increment the program counter to point to the next instruction
						m_programCounter++;
					}
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
						// we are stalled because execute hasn't dequeued this yet
						return;
					}

					// free up the fetch queue
					Instruction instruction = m_fetchQueue.Dequeue();

					// do some instruction processing
					bool registersAreClear = true;
					// if reigstersAreClear is false, that means that we have to stall for
					// another stage to complete

					if (registersAreClear)
					{ 
						// enqueue the insturction into decode queue, this contains decoded items 
						// for the next stage -- execute
						m_decodeQueue.Enqueue(instruction);
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
						// we are stalled because memory stage hasn't dequeued this yet
						return;
					}

					// free up the decode queue
					Instruction instruction = m_decodeQueue.Dequeue();

					// do some instruction processing
					bool registersAreClear = true;
					// if reigstersAreClear is false, that means that we have to stall for
					// another stage to complete

					if (registersAreClear)
					{
						// enqueue the insturction into decode queue, this contains decoded items 
						// for the next stage -- memory
						m_executeQueue.Enqueue(instruction);
					}
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
						// we are stalled because memory stage hasn't dequeued this yet
						return;
					}

					// free up the execute queue
					Instruction instruction = m_executeQueue.Dequeue();

					// do some instruction processing
					bool registersAreClear = true;
					// if reigstersAreClear is false, that means that we have to stall for
					// another stage to complete

					if (registersAreClear)
					{
						// enqueue the insturction into decode queue, this contains decoded items 
						// for the next stage -- memory
						m_memoryQueue.Enqueue(instruction);
					}
				}
			}
			public void writeback()
			{
				if (m_memoryQueue.Count > 0)
				{
					// we have something we should dequeue and work with, but we can't 
					// work with it if we already have an item in the execute queue
					if (m_writebackQueue.Count > 0)
					{
						// we are stalled because memory stage hasn't dequeued this yet
						return;
					}

					// free up the decode queue
					Instruction instruction = m_memoryQueue.Dequeue();

					// do some instruction processing
					bool registersAreClear = true;
					// if reigstersAreClear is false, that means that we have to stall for
					// another stage to complete

					if (registersAreClear)
					{
						// enqueue the insturction into decode queue, this contains decoded items 
						// for the next stage -- memory
						m_writebackQueue.Enqueue(instruction);
					}
				}
			}

			public void doPipeline()
			{
				
				while (m_cycles < 10)
				{
					writeback();
					memory();
					execute();
					decode();
					fetch();

					Display();

					// Hack to drop wb queue else it'll always show empty
					if (m_writebackQueue.Count > 0)
					{
						m_writebackQueue.Dequeue();
					}

					m_cycles++;
				}
			}

			public void Display()
			{
				StringBuilder sb = new StringBuilder();

				sb.Append("cycle " + m_cycles + ": ");
				sb.Append("F" + m_fetchQueue.Count + " ");
				sb.Append("D" + m_decodeQueue.Count + " ");
				sb.Append("E" + m_executeQueue.Count + " ");
				sb.Append("M" + m_memoryQueue.Count + " ");
				sb.Append("W" + m_writebackQueue.Count + " ");
				Console.WriteLine(sb.ToString());
			}
		}

		static void Main(string[] args)
		{
			Console.WriteLine("file: " + args[0]);

			// Read file
			string file = File.ReadAllText(args[0]);
			string[] lines = file.Split('\n');

			// Parse instruction lines and get valie instructions
			Parser parser = new Parser();
			List<Instruction> validInstructions = new List<Instruction>();
			foreach (string s in lines)
			{
				Instruction i = new Instruction();
				parser.Parse(s, ref i);
				if (i.instruction != string.Empty)
				{
					validInstructions.Add(i);
				}
			}

			// Run through pipeline
			Pipeline pipeline = new Pipeline(validInstructions);
			pipeline.doPipeline();
		}

		
	}
}
