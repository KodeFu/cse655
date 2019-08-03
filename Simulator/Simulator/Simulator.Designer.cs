namespace Simulator
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
			this.tbErrX = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
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
			this.label1.Location = new System.Drawing.Point(6, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Label";
			// 
			// groupBox1
			// 
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
			this.groupBox1.Size = new System.Drawing.Size(389, 126);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Description";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Comment";
			// 
			// tbComment
			// 
			this.tbComment.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbComment.Location = new System.Drawing.Point(6, 86);
			this.tbComment.Name = "tbComment";
			this.tbComment.ReadOnly = true;
			this.tbComment.Size = new System.Drawing.Size(374, 20);
			this.tbComment.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(79, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Instruction";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(307, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Field";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(231, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Field";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(155, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Field";
			// 
			// tbFieldThree
			// 
			this.tbFieldThree.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbFieldThree.Location = new System.Drawing.Point(310, 38);
			this.tbFieldThree.Name = "tbFieldThree";
			this.tbFieldThree.ReadOnly = true;
			this.tbFieldThree.Size = new System.Drawing.Size(70, 20);
			this.tbFieldThree.TabIndex = 8;
			// 
			// tbLabel
			// 
			this.tbLabel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbLabel.Location = new System.Drawing.Point(6, 38);
			this.tbLabel.Name = "tbLabel";
			this.tbLabel.ReadOnly = true;
			this.tbLabel.Size = new System.Drawing.Size(70, 20);
			this.tbLabel.TabIndex = 7;
			// 
			// tbFieldTwo
			// 
			this.tbFieldTwo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbFieldTwo.Location = new System.Drawing.Point(234, 38);
			this.tbFieldTwo.Name = "tbFieldTwo";
			this.tbFieldTwo.ReadOnly = true;
			this.tbFieldTwo.Size = new System.Drawing.Size(70, 20);
			this.tbFieldTwo.TabIndex = 6;
			// 
			// tbFieldOne
			// 
			this.tbFieldOne.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbFieldOne.Location = new System.Drawing.Point(158, 38);
			this.tbFieldOne.Name = "tbFieldOne";
			this.tbFieldOne.ReadOnly = true;
			this.tbFieldOne.Size = new System.Drawing.Size(70, 20);
			this.tbFieldOne.TabIndex = 5;
			// 
			// tbInstruction
			// 
			this.tbInstruction.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbInstruction.Location = new System.Drawing.Point(82, 38);
			this.tbInstruction.Name = "tbInstruction";
			this.tbInstruction.ReadOnly = true;
			this.tbInstruction.Size = new System.Drawing.Size(70, 20);
			this.tbInstruction.TabIndex = 4;
			// 
			// groupBox2
			// 
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
			this.groupBox2.Controls.Add(this.tbErrX);
			this.groupBox2.Controls.Add(this.label31);
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
			this.groupBox2.Location = new System.Drawing.Point(580, 167);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(389, 482);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Execution";
			// 
			// lbMemory
			// 
			this.lbMemory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMemory.FormattingEnabled = true;
			this.lbMemory.ItemHeight = 14;
			this.lbMemory.Location = new System.Drawing.Point(14, 268);
			this.lbMemory.Name = "lbMemory";
			this.lbMemory.Size = new System.Drawing.Size(226, 200);
			this.lbMemory.TabIndex = 19;
			// 
			// tbVol
			// 
			this.tbVol.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbVol.Location = new System.Drawing.Point(308, 209);
			this.tbVol.Name = "tbVol";
			this.tbVol.ReadOnly = true;
			this.tbVol.Size = new System.Drawing.Size(70, 20);
			this.tbVol.TabIndex = 55;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(127, 246);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(34, 13);
			this.label17.TabIndex = 22;
			this.label17.Text = "Value";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(12, 246);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(45, 13);
			this.label16.TabIndex = 21;
			this.label16.Text = "Address";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(274, 209);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(21, 13);
			this.label25.TabIndex = 54;
			this.label25.Text = "vol";
			// 
			// tbDing
			// 
			this.tbDing.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDing.Location = new System.Drawing.Point(308, 183);
			this.tbDing.Name = "tbDing";
			this.tbDing.ReadOnly = true;
			this.tbDing.Size = new System.Drawing.Size(70, 20);
			this.tbDing.TabIndex = 53;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(268, 186);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(27, 13);
			this.label26.TabIndex = 52;
			this.label26.Text = "ding";
			// 
			// tbHalt
			// 
			this.tbHalt.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbHalt.Location = new System.Drawing.Point(308, 53);
			this.tbHalt.Name = "tbHalt";
			this.tbHalt.ReadOnly = true;
			this.tbHalt.Size = new System.Drawing.Size(70, 20);
			this.tbHalt.TabIndex = 51;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(271, 56);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(24, 13);
			this.label27.TabIndex = 50;
			this.label27.Text = "halt";
			// 
			// tbBeac
			// 
			this.tbBeac.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbBeac.Location = new System.Drawing.Point(308, 79);
			this.tbBeac.Name = "tbBeac";
			this.tbBeac.ReadOnly = true;
			this.tbBeac.Size = new System.Drawing.Size(70, 20);
			this.tbBeac.TabIndex = 49;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(264, 82);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(31, 13);
			this.label28.TabIndex = 48;
			this.label28.Text = "beac";
			// 
			// tbClr
			// 
			this.tbClr.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbClr.Location = new System.Drawing.Point(308, 105);
			this.tbClr.Name = "tbClr";
			this.tbClr.ReadOnly = true;
			this.tbClr.Size = new System.Drawing.Size(70, 20);
			this.tbClr.TabIndex = 47;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(271, 108);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(24, 13);
			this.label29.TabIndex = 46;
			this.label29.Text = "bclr";
			// 
			// tbErr
			// 
			this.tbErr.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbErr.Location = new System.Drawing.Point(308, 131);
			this.tbErr.Name = "tbErr";
			this.tbErr.ReadOnly = true;
			this.tbErr.Size = new System.Drawing.Size(70, 20);
			this.tbErr.TabIndex = 45;
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(276, 134);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(19, 13);
			this.label30.TabIndex = 44;
			this.label30.Text = "err";
			// 
			// tbErrX
			// 
			this.tbErrX.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbErrX.Location = new System.Drawing.Point(308, 157);
			this.tbErrX.Name = "tbErrX";
			this.tbErrX.ReadOnly = true;
			this.tbErrX.Size = new System.Drawing.Size(70, 20);
			this.tbErrX.TabIndex = 43;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(269, 160);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(26, 13);
			this.label31.TabIndex = 42;
			this.label31.Text = "errX";
			// 
			// tbIP
			// 
			this.tbIP.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbIP.Location = new System.Drawing.Point(308, 27);
			this.tbIP.Name = "tbIP";
			this.tbIP.ReadOnly = true;
			this.tbIP.Size = new System.Drawing.Size(70, 20);
			this.tbIP.TabIndex = 41;
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(280, 30);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(15, 13);
			this.label32.TabIndex = 40;
			this.label32.Text = "ip";
			// 
			// tbR7
			// 
			this.tbR7.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR7.Location = new System.Drawing.Point(37, 209);
			this.tbR7.Name = "tbR7";
			this.tbR7.ReadOnly = true;
			this.tbR7.Size = new System.Drawing.Size(70, 20);
			this.tbR7.TabIndex = 18;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(9, 212);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(16, 13);
			this.label14.TabIndex = 17;
			this.label14.Text = "r7";
			// 
			// tbR6
			// 
			this.tbR6.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR6.Location = new System.Drawing.Point(37, 183);
			this.tbR6.Name = "tbR6";
			this.tbR6.ReadOnly = true;
			this.tbR6.Size = new System.Drawing.Size(70, 20);
			this.tbR6.TabIndex = 16;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(9, 186);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(16, 13);
			this.label13.TabIndex = 15;
			this.label13.Text = "r6";
			// 
			// tbR1
			// 
			this.tbR1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR1.Location = new System.Drawing.Point(37, 53);
			this.tbR1.Name = "tbR1";
			this.tbR1.ReadOnly = true;
			this.tbR1.Size = new System.Drawing.Size(70, 20);
			this.tbR1.TabIndex = 14;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(9, 56);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(16, 13);
			this.label12.TabIndex = 13;
			this.label12.Text = "r1";
			// 
			// tbR2
			// 
			this.tbR2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR2.Location = new System.Drawing.Point(37, 79);
			this.tbR2.Name = "tbR2";
			this.tbR2.ReadOnly = true;
			this.tbR2.Size = new System.Drawing.Size(70, 20);
			this.tbR2.TabIndex = 12;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(9, 82);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(16, 13);
			this.label11.TabIndex = 11;
			this.label11.Text = "r2";
			// 
			// tbR3
			// 
			this.tbR3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR3.Location = new System.Drawing.Point(37, 105);
			this.tbR3.Name = "tbR3";
			this.tbR3.ReadOnly = true;
			this.tbR3.Size = new System.Drawing.Size(70, 20);
			this.tbR3.TabIndex = 10;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(9, 108);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(16, 13);
			this.label10.TabIndex = 9;
			this.label10.Text = "r3";
			// 
			// tbR4
			// 
			this.tbR4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR4.Location = new System.Drawing.Point(37, 131);
			this.tbR4.Name = "tbR4";
			this.tbR4.ReadOnly = true;
			this.tbR4.Size = new System.Drawing.Size(70, 20);
			this.tbR4.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(9, 134);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(16, 13);
			this.label9.TabIndex = 7;
			this.label9.Text = "r4";
			// 
			// tbR5
			// 
			this.tbR5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR5.Location = new System.Drawing.Point(37, 157);
			this.tbR5.Name = "tbR5";
			this.tbR5.ReadOnly = true;
			this.tbR5.Size = new System.Drawing.Size(70, 20);
			this.tbR5.TabIndex = 6;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 160);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(16, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "r5";
			// 
			// tbR0
			// 
			this.tbR0.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbR0.Location = new System.Drawing.Point(37, 27);
			this.tbR0.Name = "tbR0";
			this.tbR0.ReadOnly = true;
			this.tbR0.Size = new System.Drawing.Size(70, 20);
			this.tbR0.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 30);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "r0";
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(303, 297);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnStep
			// 
			this.btnStep.Location = new System.Drawing.Point(303, 268);
			this.btnStep.Name = "btnStep";
			this.btnStep.Size = new System.Drawing.Size(75, 23);
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
		private System.Windows.Forms.TextBox tbErrX;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox tbIP;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
	}
}

