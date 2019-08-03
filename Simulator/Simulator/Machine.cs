using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
	public class Instruction
	{

		public string comment;
		public string label;
		public string instruction;
		public List<string> field;

		public Instruction()
		{
			comment = String.Empty;
			label = String.Empty;
			instruction = String.Empty;
			field = new List<string>();
		}
	}

	public class Machine
	{
		public Dictionary<string, int> regs;		// General registers
		public List<int> mem;                       // Memory
		public int ip;                              // Instruction pointer
		public int compare;
		public int credits;                         // Machine credits
		public int halt;							// Halt status
		public int beacon;							// Beacon status
		public int beaconColor;						// Beacon color
		public int error;                           // Error
		public int ding;                            // Ding! Ding!
		public int volume;                          // Ding volume
		public string display;                      // Display text
		
		int maxMem;

		public Dictionary<string, int> labels;


		public Machine()
		{
			Initialize();
			labels = new Dictionary<string, int>();
		}

		public void Initialize()
		{
			maxMem = 1024;

			// General Registers
			regs = new Dictionary<string, int>();
			regs.Add("r0", 0);
			regs.Add("r1", 0);
			regs.Add("r2", 0);
			regs.Add("r3", 0);
			regs.Add("r4", 0);
			regs.Add("r5", 0);
			regs.Add("r6", 0);
			regs.Add("r7", 0);

			// Memory
			mem = new List<int>();
			for (int i = 0; i < maxMem; i++)
			{
				mem.Add(i*2); // putting some default value in there
			}

			ip = 0;
			compare = 0;
			credits = 0;
			halt = 0;
			beacon = 0;
			beaconColor = 0;
			error = 0;
		}

		public int getMaxMem()
		{
			return maxMem;
		}

		List<int> GetMemoryRange(int address, int length)
		{
			List<int> bytes = new List<int>();

			if (address < 0 || address >= maxMem)
			{
				return bytes;
			}

			for (int i = address; i < (address + length); i++)
			{
				bytes.Add(mem[i]);
			}

			return bytes;
		}

		public int GetMemoryAtAddress(int address)
		{ 
			if (address < 0 || address >= maxMem)
			{
				return 0;
			}

			return mem[address];
		}

		void SetMemoryAtAddress(int address, int value)
		{
			if (address < 0 || address >= maxMem)
			{
				return;
			}

			mem[address] = value;
		}

		void DisplayMemory()
		{
			for (int i = 0; i < maxMem; i++)
			{
				Console.Write(mem[i] + " ");
			}
		}

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
				splitter = tmpLine.Split('#');
				instruction.comment = splitter[1].Trim();
				return;
			}

			// Program line: "label: instruction oper1, oper2, oper3	# comment"
			// Split out trailing comment #
			if (tmpLine.Contains('#'))
			{
				splitter = tmpLine.Split('#');
				tmpLine = splitter[0].Trim();
				instruction.comment = splitter[1].Trim();
			}

			// label: instruction oper1, oper2, oper3
			// Split out label:
			if (tmpLine.Contains(':'))
			{
				splitter = tmpLine.Split(':');
				instruction.label = splitter[0].Trim();
				tmpLine = splitter[1].Trim();

				if (tmpLine.Length==0)
				{
					// stop parsing since this is a label: only line
					return;
				}
			}

			// instruction oper1, oper2, oper3
			// Split out instruction oper1, oper2, oper3
			splitter = tmpLine.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			instruction.instruction = splitter[0].Trim();

			// At this point, splitter should contain: instruction oper1, oper2, oper3.
			// We only want to extract "oper1, oper2, oper3"
			if (splitter.Count() > 1)
			{
				for (int i = 1; i < splitter.Count(); i++)
				{
					string tempOperand = splitter[i];
					string[] operandSplitter = tempOperand.Split(',');

					instruction.field.Add(operandSplitter[0].Trim());
				}
			}
		}
	}
}
