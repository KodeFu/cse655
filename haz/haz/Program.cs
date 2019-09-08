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

			List<bool> regAvail = new List<bool>(); // contains availability of r0-r1
			List<int>  regInternal = new List<int>(); // contains internal saved regs

			public Pipeline(List<Instruction> instructions)
			{
				m_instructions = instructions;

				for (int i = 0; i < 8; i++)
				{
					regAvail.Add(true);
					regInternal.Add(0);
				}
			}

			public void fetch()
			{
				if (m_programCounter < m_instructions.Count)
				{
					Instruction instruction = m_instructions[m_programCounter];
					m_fetchQueue.Enqueue(instruction);
					m_programCounter++;

					instruction.Display();
				}
			}
			public void decode()
			{
				if (m_decodeQueue.Count > 0)
				{
					Instruction peek = m_decodeQueue.Peek();

					//if (pe)

					// Decode instruction
					Instruction current = m_decodeQueue.Dequeue();
					Console.WriteLine(current.instruction);
					//Console.WriteLine(current.instruction);
					//Console.WriteLine(current.instruction);
				}

				if (m_fetchQueue.Count > 0)
				{
					Instruction instruction = m_fetchQueue.Dequeue();
					m_decodeQueue.Enqueue(instruction);
				}
			}
			public void execute()
			{
				if (m_decodeQueue.Count > 0)
				{
					Instruction instruction = m_decodeQueue.Dequeue();
					m_executeQueue.Enqueue(instruction);
				}

			}
			public void memory()
			{
				if (m_executeQueue.Count > 0)
				{
					Instruction instruction = m_executeQueue.Dequeue();
					m_memoryQueue.Enqueue(instruction);
				}
			}
			public void writeback()
			{
				if (m_memoryQueue.Count > 0)
				{
					Instruction instruction = m_memoryQueue.Dequeue();
					m_writebackQueue.Enqueue(instruction);
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
