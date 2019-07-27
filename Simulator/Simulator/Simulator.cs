using System;
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
        string[] sourceLines;

        public Simulator()
        {
            InitializeComponent();

            mach = new Machine();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Assembly files (*.asm, *.txt) | *.asm; *.txt;";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sourceLines = System.IO.File.ReadAllLines(dlg.FileName);
                lFilename.Text = dlg.FileName;

                tbEdit.Text = System.IO.File.ReadAllText(dlg.FileName);
                lEditFilename.Text = dlg.FileName;
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Assembly files (*.asm, *.txt) | *.asm; *.txt;";
            dlg.FileName = lEditFilename.Text;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dlg.FileName, tbEdit.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
			Instruction instruction = new Instruction();

            string sourceLine = lbExecute.SelectedItem.ToString();
            mach.Parse(sourceLine, ref instruction);

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
				lbMemory.Items.Add("0x" + i.ToString("X8") + "    " + "0x" + mach.GetMemoryAtAddress(i).ToString("X8"));
			}
		}

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 0)
            {
                //MessageBox.Show("First!");
            }
            else
            {
                //MessageBox.Show("Second!");
            }
        }

		private void executeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lbExecute.CustomTabOffsets.Add(16);
			lbExecute.UseCustomTabOffsets = true;
			foreach (string s in sourceLines)
			{
				lbExecute.Items.Add(s);
			}

			lbExecute.SetSelected(0, true);

			tabMain.SelectedIndex = 1;
			lbExecute.SelectedIndex = 0;
		}

		private void btnStep_Click(object sender, EventArgs e)
		{
			int currentlySelected = lbExecute.SelectedIndex;

			if (currentlySelected+1<lbExecute.Items.Count)
			{
				lbExecute.SelectedIndex = currentlySelected + 1;
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			lbExecute.SelectedIndex = 0;
		}
	}
}
