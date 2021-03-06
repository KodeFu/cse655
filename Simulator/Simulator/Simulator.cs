﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
    public partial class Simulator : Form
    {
        Machine mach;
		Execution exec;

        public Simulator()
        {
            InitializeComponent();

            mach = new Machine();
			exec = new Execution();

			for (int i = 0; i < mach.getMaxMem(); i++)
			{
				lbMemory.Items.Add("0x" + i.ToString("X8") + "    " + "0x" + mach.GetMemoryAtAddress(i).ToString("X8"));
			}
		}

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Assembly files (*.asm, *.txt) | *.asm; *.txt;";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbEdit.Text = System.IO.File.ReadAllText(dlg.FileName);
                lEditFilename.Text = dlg.FileName;
			}

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.IO.File.WriteAllText(lEditFilename.Text, tbEdit.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbCode_SelectedIndexChanged(object sender, EventArgs e)
        {

		}

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		private void executeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lbExecute.Items.Clear();

			lbExecute.CustomTabOffsets.Add(16);
			lbExecute.UseCustomTabOffsets = true;

			lExecuteFilename.Text = lEditFilename.Text;
			string[] sourceLines = System.IO.File.ReadAllLines(lExecuteFilename.Text);
			int lineNum = 0;
			mach.labels.Clear();
			foreach (string s in sourceLines)
			{
				// Create label table
				Instruction i = new Instruction();
				mach.Parse(s, ref i);
				if (i.label.Length>0)
				{
					mach.labels[i.label] = lineNum;
				}

				// Add to the list
				lbExecute.Items.Add(lineNum.ToString("D2") + ": " + s);

				lineNum++;
			}

			lbExecute.SetSelected(0, true);

			tabMain.SelectedIndex = 1;
			lbExecute.SelectedIndex = 0;
		}

		private void btnStep_Click(object sender, EventArgs e)
		{
			Instruction instruction = new Instruction();

			// Adjust IP
			if (mach.ip < lbExecute.Items.Count)
			{ 
				lbExecute.SelectedIndex = mach.ip;
			}

			// Parse instruction
			string sourceLine = lbExecute.SelectedItem.ToString().Substring(4);
			mach.Parse(sourceLine, ref instruction);

			// Execute instruction
			exec.Process(instruction, ref mach);

			// Copy to controls
			tbComment.Text = instruction.comment;
			tbInstruction.Text = instruction.instruction;
			tbLabel.Text = instruction.label;

			tbFieldOne.Text = String.Empty;
			tbFieldTwo.Text = String.Empty;
			tbFieldThree.Text = String.Empty;

			if (instruction.field.Count >= 1) tbFieldOne.Text = instruction.field[0];
			if (instruction.field.Count >= 2) tbFieldTwo.Text = instruction.field[1];
			if (instruction.field.Count == 3) tbFieldThree.Text = instruction.field[2];

			for (int i = 0; i < mach.getMaxMem(); i++)
			{
				lbMemory.Items[i] = "0x" + i.ToString("X8") + "    " + "0x" + mach.GetMemoryAtAddress(i).ToString("X8");
			}

			tbR0.Text = mach.regs["r0"].ToString();
			tbR1.Text = mach.regs["r1"].ToString();
			tbR2.Text = mach.regs["r2"].ToString();
			tbR3.Text = mach.regs["r3"].ToString();
			tbR4.Text = mach.regs["r4"].ToString();
			tbR5.Text = mach.regs["r5"].ToString();
			tbR6.Text = mach.regs["r6"].ToString();
			tbR7.Text = mach.regs["r7"].ToString();

			tbIP.Text = mach.ip.ToString();
			tbHalt.Text = mach.runstate.ToString();
			tbErr.Text = mach.error.ToString();
			tbBeac.Text = mach.beacon.ToString();
			tbClr.Text = mach.beaconColor.ToString();
			tbDing.Text = mach.ding.ToString();
			tbVol.Text = mach.volume.ToString();
			tbCmp.Text = mach.compare.ToString();
			tbCredits.Text = mach.credits.ToString();

			// Update encoding
			tbOpcode.Text = String.Empty;
			tbOperandOne.Text = String.Empty;
			tbOperandTwo.Text = String.Empty;
			tbOperandThree.Text = String.Empty;
			tbEncoding.Text = String.Empty;
			lbInstructionFormat.Text = String.Empty;

			// Update opcode
			string opcode = exec.GetOpcode(instruction.instruction).ToString();
			if (opcode.Equals("0")) return;
			tbOpcode.Text = opcode +
					" (" +
					Convert.ToString(int.Parse(opcode), 2)
					+ ")";

			// Update operands
			if (instruction.field.Count>0 && mach.labels.ContainsKey(instruction.field[0]))
			{
				// Branch instruction, resolve label
				tbOperandOne.Text = mach.labels[instruction.field[0]].ToString() + 
					" (" +
					Convert.ToString(mach.labels[instruction.field[0]], 2)
					+ ")";
			}
			else
			{
				// Non-branch instructions
				if (instruction.field.Count >= 1)
				{
					tbOperandOne.Text = exec.GetRegisterEncoding(instruction.field[0]).ToString() +
						" (" +
						Convert.ToString(int.Parse(exec.GetRegisterEncoding(instruction.field[0])), 2)
						+ ")";
				}
				if (instruction.field.Count >= 2)
				{
					tbOperandTwo.Text = exec.GetRegisterEncoding(instruction.field[1]).ToString() +
						" (" +
						Convert.ToString(int.Parse(exec.GetRegisterEncoding(instruction.field[1])), 2)
						+ ")";
				}
				if (instruction.field.Count >= 3)
				{
					tbOperandThree.Text = exec.GetRegisterEncoding(instruction.field[2]).ToString() +
						" (" +
						Convert.ToString(int.Parse(exec.GetRegisterEncoding(instruction.field[2])), 2)
						+ ")";
				}
			}

			// Update final encoding
			lbInstructionFormat.Text = exec.Is32BitType(instruction.instruction) ? 
				"Type: 32-bit [ opcode:6 | reg:4 | value:22 ]" :
				"Type: 16-bit [ opcode:6 | reg:4 | reg:4 | mode:2 ]";
			tbEncoding.Text = exec.EncodeInstruction(instruction, mach);
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			lbExecute.SelectedIndex = 0;
			mach.Initialize();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{			
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.AddExtension = true;
			dlg.Filter = "Assembly files (*.asm, *.txt) | *.asm; *.txt;";
			dlg.FileName = lEditFilename.Text;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				System.IO.File.WriteAllText(dlg.FileName, tbEdit.Text);
				lEditFilename.Text = dlg.FileName;
			}
		}

		private void stepToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnStep_Click(null, null);
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnReset_Click(null, null);
		}

	}
}
