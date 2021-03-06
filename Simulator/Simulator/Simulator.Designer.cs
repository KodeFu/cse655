﻿namespace Simulator
{
    partial class Simulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.lbExecute = new System.Windows.Forms.ListBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lExecuteFilename = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbInstructionFormat = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.tbEncoding = new System.Windows.Forms.TextBox();
			this.tbOperandThree = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.tbOperandTwo = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.tbOperandOne = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.tbOpcode = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbComment = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbFieldThree = new System.Windows.Forms.TextBox();
			this.tbLabel = new System.Windows.Forms.TextBox();
			this.tbFieldTwo = new System.Windows.Forms.TextBox();
			this.tbFieldOne = new System.Windows.Forms.TextBox();
			this.tbInstruction = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbCmp = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.lbMemory = new System.Windows.Forms.ListBox();
			this.tbVol = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.tbDing = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.tbHalt = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.tbBeac = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.tbClr = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.tbErr = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.tbIP = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.tbR7 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbR6 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbR1 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tbR2 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbR3 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbR4 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbR5 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbR0 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnStep = new System.Windows.Forms.Button();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lEditFilename = new System.Windows.Forms.Label();
			this.tbEdit = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tbCredits = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbExecute
			// 
			this.lbExecute.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbExecute.FormattingEnabled = true;
			this.lbExecute.ItemHeight = 14;
			this.lbExecute.Location = new System.Drawing.Point(6, 29);
			this.lbExecute.Name = "lbExecute";
			this.lbExecute.Size = new System.Drawing.Size(568, 620);
			this.lbExecute.TabIndex = 0;
			this.lbExecute.SelectedIndexChanged += new System.EventHandler(this.lbCode_SelectedIndexChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.resetToolStripMenuItem});
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.runToolStripMenuItem.Text = "&Run";
			// 
			// executeToolStripMenuItem
			// 
			this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
			this.executeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.executeToolStripMenuItem.Text = "E&xecute";
			this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
			// 
			// stepToolStripMenuItem
			// 
			this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
			this.stepToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.stepToolStripMenuItem.Text = "&Step";
			this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepToolStripMenuItem_Click);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.resetToolStripMenuItem.Text = "&Reset";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// lExecuteFilename
			// 
			this.lExecuteFilename.AutoSize = true;
			this.lExecuteFilename.Location = new System.Drawing.Point(6, 6);
			this.lExecuteFilename.Name = "lExecuteFilename";
			this.lExecuteFilename.Size = new System.Drawing.Size(167, 13);
			this.lExecuteFilename.TabIndex = 2;
			this.lExecuteFilename.Text = "Use File Open to open source file.";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Label";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbInstructionFormat);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.tbEncoding);
			this.groupBox1.Controls.Add(this.tbOperandThree);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.tbOperandTwo);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.tbOperandOne);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.tbOpcode);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbComment);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbFieldThree);
			this.groupBox1.Controls.Add(this.tbLabel);
			this.groupBox1.Controls.Add(this.tbFieldTwo);
			this.groupBox1.Controls.Add(this.tbFieldOne);
			this.groupBox1.Controls.Add(this.tbInstruction);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(580, 29);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(389, 225);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Instruction";
			// 
			// lbInstructionFormat
			// 
			this.lbInstructionFormat.AutoSize = true;
			this.lbInstructionFormat.Location = new System.Drawing.Point(144, 176);
			this.lbInstructionFormat.Name = "lbInstructionFormat";
			this.lbInstructionFormat.Size = new System.Drawing.Size(0, 13);
			this.lbInstructionFormat.TabIndex = 26;
			this.lbInstructionFormat.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(6, 176);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(77, 13);
			this.label22.TabIndex = 25;
			this.label22.Text = "Final Encoding";
			// 
			// tbEncoding
			// 
			this.tbEncoding.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbEncoding.Location = new System.Drawing.Point(6, 194);
			this.tbEncoding.Name = "tbEncoding";
			this.tbEncoding.ReadOnly = true;
			this.tbEncoding.Size = new System.Drawing.Size(374, 20);
			this.tbEncoding.TabIndex = 24;
			// 
			// tbOperandThree
			// 
			this.tbOperandThree.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOperandThree.Location = new System.Drawing.Point(297, 147);
			this.tbOperandThree.Name = "tbOperandThree";
			this.tbOperandThree.ReadOnly = true;
			this.tbOperandThree.Size = new System.Drawing.Size(83, 20);
			this.tbOperandThree.TabIndex = 23;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(288, 129);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(48, 13);
			this.label21.TabIndex = 22;
			this.label21.Text = "Operand";
			// 
			// tbOperandTwo
			// 
			this.tbOperandTwo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOperandTwo.Location = new System.Drawing.Point(199, 147);
			this.tbOperandTwo.Name = "tbOperandTwo";
			this.tbOperandTwo.ReadOnly = true;
			this.tbOperandTwo.Size = new System.Drawing.Size(90, 20);
			this.tbOperandTwo.TabIndex = 21;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(196, 129);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(48, 13);
			this.label20.TabIndex = 20;
			this.label20.Text = "Operand";
			// 
			// tbOperandOne
			// 
			this.tbOperandOne.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOperandOne.Location = new System.Drawing.Point(103, 147);
			this.tbOperandOne.Name = "tbOperandOne";
			this.tbOperandOne.ReadOnly = true;
			this.tbOperandOne.Size = new System.Drawing.Size(90, 20);
			this.tbOperandOne.TabIndex = 19;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(100, 131);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(48, 13);
			this.label19.TabIndex = 18;
			this.label19.Text = "Operand";
			// 
			// tbOpcode
			// 
			this.tbOpcode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOpcode.Location = new System.Drawing.Point(6, 147);
			this.tbOpcode.Name = "tbOpcode";
			this.tbOpcode.ReadOnly = true;
			this.tbOpcode.Size = new System.Drawing.Size(91, 20);
			this.tbOpcode.TabIndex = 17;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(6, 129);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(45, 13);
			this.label18.TabIndex = 16;
			this.label18.Text = "Opcode";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(6, 109);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(60, 13);
			this.label15.TabIndex = 15;
			this.label15.Text = "Encoding";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 62);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Comment";
			// 
			// tbComment
			// 
			this.tbComment.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbComment.Location = new System.Drawing.Point(6, 80);
			this.tbComment.Name = "tbComment";
			this.tbComment.ReadOnly = true;
			this.tbComment.Size = new System.Drawing.Size(374, 20);
			this.tbComment.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(79, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Mnemonic";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(307, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Field";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(231, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Field";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(155, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Field";
			// 
			// tbFieldThree
			// 
			this.tbFieldThree.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbFieldThree.Location = new System.Drawing.Point(310, 36);
			this.tbFieldThree.Name = "tbFieldThree";
			this.tbFieldThree.ReadOnly = true;
			this.tbFieldThree.Size = new System.Drawing.Size(70, 20);
			this.tbFieldThree.TabIndex = 8;
			// 
			// tbLabel
			// 
			this.tbLabel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbLabel.Location = new System.Drawing.Point(6, 36);
			this.tbLabel.Name = "tbLabel";
			this.tbLabel.ReadOnly = true;
			this.tbLabel.Size = new System.Drawing.Size(70, 20);
			this.tbLabel.TabIndex = 7;
			// 
			// tbFieldTwo
			// 
			this.tbFieldTwo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbFieldTwo.Location = new System.Drawing.Point(234, 36);
			this.tbFieldTwo.Name = "tbFieldTwo";
			this.tbFieldTwo.ReadOnly = true;
			this.tbFieldTwo.Size = new System.Drawing.Size(70, 20);
			this.tbFieldTwo.TabIndex = 6;
			// 
			// tbFieldOne
			// 
			this.tbFieldOne.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbFieldOne.Location = new System.Drawing.Point(158, 36);
			this.tbFieldOne.Name = "tbFieldOne";
			this.tbFieldOne.ReadOnly = true;
			this.tbFieldOne.Size = new System.Drawing.Size(70, 20);
			this.tbFieldOne.TabIndex = 5;
			// 
			// tbInstruction
			// 
			this.tbInstruction.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbInstruction.Location = new System.Drawing.Point(82, 36);
			this.tbInstruction.Name = "tbInstruction";
			this.tbInstruction.ReadOnly = true;
			this.tbInstruction.Size = new System.Drawing.Size(70, 20);
			this.tbInstruction.TabIndex = 4;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbCredits);
			this.groupBox2.Controls.Add(this.label33);
			this.groupBox2.Controls.Add(this.tbCmp);
			this.groupBox2.Controls.Add(this.label31);
			this.groupBox2.Controls.Add(this.label24);
			this.groupBox2.Controls.Add(this.label23);
			this.groupBox2.Controls.Add(this.lbMemory);
			this.groupBox2.Controls.Add(this.tbVol);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.label25);
			this.groupBox2.Controls.Add(this.tbDing);
			this.groupBox2.Controls.Add(this.label26);
			this.groupBox2.Controls.Add(this.tbHalt);
			this.groupBox2.Controls.Add(this.label27);
			this.groupBox2.Controls.Add(this.tbBeac);
			this.groupBox2.Controls.Add(this.label28);
			this.groupBox2.Controls.Add(this.tbClr);
			this.groupBox2.Controls.Add(this.label29);
			this.groupBox2.Controls.Add(this.tbErr);
			this.groupBox2.Controls.Add(this.label30);
			this.groupBox2.Controls.Add(this.tbIP);
			this.groupBox2.Controls.Add(this.label32);
			this.groupBox2.Controls.Add(this.tbR7);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.tbR6);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.tbR1);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.tbR2);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.tbR3);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.tbR4);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.tbR5);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.tbR0);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.btnReset);
			this.groupBox2.Controls.Add(this.btnStep);
			this.groupBox2.Location = new System.Drawing.Point(580, 260);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(389, 389);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Execution";
			// 
			// tbCmp
			// 
			this.tbCmp.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbCmp.Location = new System.Drawing.Point(43, 118);
			this.tbCmp.Name = "tbCmp";
			this.tbCmp.ReadOnly = true;
			this.tbCmp.Size = new System.Drawing.Size(70, 20);
			this.tbCmp.TabIndex = 59;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(3, 121);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(27, 13);
			this.label31.TabIndex = 58;
			this.label31.Text = "cmp";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(13, 19);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(84, 13);
			this.label24.TabIndex = 57;
			this.label24.Text = "Status Registers";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(13, 154);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(121, 13);
			this.label23.TabIndex = 56;
			this.label23.Text = "Programmable Registers";
			// 
			// lbMemory
			// 
			this.lbMemory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMemory.FormattingEnabled = true;
			this.lbMemory.ItemHeight = 14;
			this.lbMemory.Location = new System.Drawing.Point(151, 176);
			this.lbMemory.Name = "lbMemory";
			this.lbMemory.Size = new System.Drawing.Size(226, 200);
			this.lbMemory.TabIndex = 19;
			// 
			// tbVol
			// 
			this.tbVol.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbVol.Location = new System.Drawing.Point(177, 40);
			this.tbVol.Name = "tbVol";
			this.tbVol.ReadOnly = true;
			this.tbVol.Size = new System.Drawing.Size(70, 20);
			this.tbVol.TabIndex = 55;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(264, 154);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(34, 13);
			this.label17.TabIndex = 22;
			this.label17.Text = "Value";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(149, 154);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(44, 13);
			this.label16.TabIndex = 21;
			this.label16.Text = "Memory";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(146, 39);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(21, 13);
			this.label25.TabIndex = 54;
			this.label25.Text = "vol";
			// 
			// tbDing
			// 
			this.tbDing.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDing.Location = new System.Drawing.Point(177, 118);
			this.tbDing.Name = "tbDing";
			this.tbDing.ReadOnly = true;
			this.tbDing.Size = new System.Drawing.Size(70, 20);
			this.tbDing.TabIndex = 53;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(140, 118);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(27, 13);
			this.label26.TabIndex = 52;
			this.label26.Text = "ding";
			// 
			// tbHalt
			// 
			this.tbHalt.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbHalt.Location = new System.Drawing.Point(43, 66);
			this.tbHalt.Name = "tbHalt";
			this.tbHalt.ReadOnly = true;
			this.tbHalt.Size = new System.Drawing.Size(70, 20);
			this.tbHalt.TabIndex = 51;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(6, 69);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(22, 13);
			this.label27.TabIndex = 50;
			this.label27.Text = "run";
			// 
			// tbBeac
			// 
			this.tbBeac.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbBeac.Location = new System.Drawing.Point(177, 66);
			this.tbBeac.Name = "tbBeac";
			this.tbBeac.ReadOnly = true;
			this.tbBeac.Size = new System.Drawing.Size(70, 20);
			this.tbBeac.TabIndex = 49;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(136, 65);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(31, 13);
			this.label28.TabIndex = 48;
			this.label28.Text = "beac";
			// 
			// tbClr
			// 
			this.tbClr.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbClr.Location = new System.Drawing.Point(177, 92);
			this.tbClr.Name = "tbClr";
			this.tbClr.ReadOnly = true;
			this.tbClr.Size = new System.Drawing.Size(70, 20);
			this.tbClr.TabIndex = 47;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(143, 95);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(24, 13);
			this.label29.TabIndex = 46;
			this.label29.Text = "bclr";
			// 
			// tbErr
			// 
			this.tbErr.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbErr.Location = new System.Drawing.Point(43, 92);
			this.tbErr.Name = "tbErr";
			this.tbErr.ReadOnly = true;
			this.tbErr.Size = new System.Drawing.Size(70, 20);
			this.tbErr.TabIndex = 45;
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(11, 95);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(19, 13);
			this.label30.TabIndex = 44;
			this.label30.Text = "err";
			// 
			// tbIP
			// 
			this.tbIP.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbIP.Location = new System.Drawing.Point(43, 40);
			this.tbIP.Name = "tbIP";
			this.tbIP.ReadOnly = true;
			this.tbIP.Size = new System.Drawing.Size(70, 20);
			this.tbIP.TabIndex = 41;
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(15, 43);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(15, 13);
			this.label32.TabIndex = 40;
			this.label32.Text = "ip";
			// 
			// tbR7
			// 
			this.tbR7.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR7.Location = new System.Drawing.Point(43, 358);
			this.tbR7.Name = "tbR7";
			this.tbR7.ReadOnly = true;
			this.tbR7.Size = new System.Drawing.Size(70, 20);
			this.tbR7.TabIndex = 18;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(15, 361);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(16, 13);
			this.label14.TabIndex = 17;
			this.label14.Text = "r7";
			// 
			// tbR6
			// 
			this.tbR6.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR6.Location = new System.Drawing.Point(43, 332);
			this.tbR6.Name = "tbR6";
			this.tbR6.ReadOnly = true;
			this.tbR6.Size = new System.Drawing.Size(70, 20);
			this.tbR6.TabIndex = 16;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(15, 335);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(16, 13);
			this.label13.TabIndex = 15;
			this.label13.Text = "r6";
			// 
			// tbR1
			// 
			this.tbR1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR1.Location = new System.Drawing.Point(43, 202);
			this.tbR1.Name = "tbR1";
			this.tbR1.ReadOnly = true;
			this.tbR1.Size = new System.Drawing.Size(70, 20);
			this.tbR1.TabIndex = 14;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(15, 205);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(16, 13);
			this.label12.TabIndex = 13;
			this.label12.Text = "r1";
			// 
			// tbR2
			// 
			this.tbR2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR2.Location = new System.Drawing.Point(43, 228);
			this.tbR2.Name = "tbR2";
			this.tbR2.ReadOnly = true;
			this.tbR2.Size = new System.Drawing.Size(70, 20);
			this.tbR2.TabIndex = 12;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(15, 231);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(16, 13);
			this.label11.TabIndex = 11;
			this.label11.Text = "r2";
			// 
			// tbR3
			// 
			this.tbR3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR3.Location = new System.Drawing.Point(43, 254);
			this.tbR3.Name = "tbR3";
			this.tbR3.ReadOnly = true;
			this.tbR3.Size = new System.Drawing.Size(70, 20);
			this.tbR3.TabIndex = 10;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(15, 257);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(16, 13);
			this.label10.TabIndex = 9;
			this.label10.Text = "r3";
			// 
			// tbR4
			// 
			this.tbR4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR4.Location = new System.Drawing.Point(43, 280);
			this.tbR4.Name = "tbR4";
			this.tbR4.ReadOnly = true;
			this.tbR4.Size = new System.Drawing.Size(70, 20);
			this.tbR4.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(15, 283);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(16, 13);
			this.label9.TabIndex = 7;
			this.label9.Text = "r4";
			// 
			// tbR5
			// 
			this.tbR5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR5.Location = new System.Drawing.Point(43, 306);
			this.tbR5.Name = "tbR5";
			this.tbR5.ReadOnly = true;
			this.tbR5.Size = new System.Drawing.Size(70, 20);
			this.tbR5.TabIndex = 6;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(15, 309);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(16, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "r5";
			// 
			// tbR0
			// 
			this.tbR0.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR0.Location = new System.Drawing.Point(43, 176);
			this.tbR0.Name = "tbR0";
			this.tbR0.ReadOnly = true;
			this.tbR0.Size = new System.Drawing.Size(70, 20);
			this.tbR0.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 179);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "r0";
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(307, 121);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(70, 24);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnStep
			// 
			this.btnStep.Location = new System.Drawing.Point(307, 87);
			this.btnStep.Name = "btnStep";
			this.btnStep.Size = new System.Drawing.Size(70, 25);
			this.btnStep.TabIndex = 1;
			this.btnStep.Text = "Step";
			this.btnStep.UseVisualStyleBackColor = true;
			this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tabPage1);
			this.tabMain.Controls.Add(this.tabPage2);
			this.tabMain.Location = new System.Drawing.Point(13, 28);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(983, 689);
			this.tabMain.TabIndex = 6;
			this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lEditFilename);
			this.tabPage1.Controls.Add(this.tbEdit);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(975, 663);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Source Editor";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// lEditFilename
			// 
			this.lEditFilename.AutoSize = true;
			this.lEditFilename.Location = new System.Drawing.Point(6, 6);
			this.lEditFilename.Name = "lEditFilename";
			this.lEditFilename.Size = new System.Drawing.Size(167, 13);
			this.lEditFilename.TabIndex = 3;
			this.lEditFilename.Text = "Use File Open to open source file.";
			// 
			// tbEdit
			// 
			this.tbEdit.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbEdit.Location = new System.Drawing.Point(7, 28);
			this.tbEdit.Multiline = true;
			this.tbEdit.Name = "tbEdit";
			this.tbEdit.Size = new System.Drawing.Size(962, 629);
			this.tbEdit.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.lbExecute);
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Controls.Add(this.lExecuteFilename);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(975, 663);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Code Execution";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tbCredits
			// 
			this.tbCredits.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbCredits.Location = new System.Drawing.Point(307, 40);
			this.tbCredits.Name = "tbCredits";
			this.tbCredits.ReadOnly = true;
			this.tbCredits.Size = new System.Drawing.Size(70, 20);
			this.tbCredits.TabIndex = 61;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(264, 43);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(38, 13);
			this.label33.TabIndex = 60;
			this.label33.Text = "credits";
			// 
			// Simulator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1024, 768);
			this.MinimumSize = new System.Drawing.Size(1024, 768);
			this.Name = "Simulator";
			this.Text = "Simulator";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabMain.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbExecute;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lExecuteFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbLabel;
        private System.Windows.Forms.TextBox tbFieldTwo;
        private System.Windows.Forms.TextBox tbFieldOne;
        private System.Windows.Forms.TextBox tbInstruction;
        private System.Windows.Forms.TextBox tbFieldThree;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.ListBox lbMemory;
        private System.Windows.Forms.TextBox tbR7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbR6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbR1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbR2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbR3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbR4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbR5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbR0;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbEdit;
        private System.Windows.Forms.Label lEditFilename;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
		private System.Windows.Forms.TextBox tbVol;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox tbDing;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox tbHalt;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tbBeac;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox tbClr;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox tbErr;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox tbIP;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.TextBox tbOpcode;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox tbEncoding;
		private System.Windows.Forms.TextBox tbOperandThree;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox tbOperandTwo;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tbOperandOne;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox tbCmp;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label lbInstructionFormat;
		private System.Windows.Forms.TextBox tbCredits;
		private System.Windows.Forms.Label label33;
	}
}

