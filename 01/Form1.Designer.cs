namespace CDP1802Simulator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.controlGroup = new System.Windows.Forms.GroupBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.dumpRamButton = new System.Windows.Forms.Button();
            this.testMemoryButton = new System.Windows.Forms.Button();
            this.verifyProgramButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.debugLabel = new System.Windows.Forms.Label();
            this.clockSpeedLabel = new System.Windows.Forms.Label();
            this.clockSpeedNumeric = new System.Windows.Forms.NumericUpDown();
            this.realTimeRadio = new System.Windows.Forms.RadioButton();
            this.stepModeRadio = new System.Windows.Forms.RadioButton();
            this.cycleCountLabel = new System.Windows.Forms.Label();
            this.cycleCountTextBox = new System.Windows.Forms.TextBox();
            this.runCyclesButton = new System.Windows.Forms.Button();
            this.statusLedPanel = new System.Windows.Forms.Panel();
            this.programControlGroup = new System.Windows.Forms.GroupBox();
            this.opcodeComboBox = new System.Windows.Forms.ComboBox();
            this.operandTextBox = new System.Windows.Forms.TextBox();
            this.addInstructionButton = new System.Windows.Forms.Button();
            this.programListBox = new System.Windows.Forms.ListBox();
            this.clearProgramButton = new System.Windows.Forms.Button();
            this.loadProgramButton = new System.Windows.Forms.Button();
            this.memoryGroup = new System.Windows.Forms.GroupBox();
            this.memoryPictureBox = new System.Windows.Forms.PictureBox();
            this.registerGroup = new System.Windows.Forms.GroupBox();
            this.registerPictureBox = new System.Windows.Forms.PictureBox();
            this.ioGroup = new System.Windows.Forms.GroupBox();
            this.keypadPanel = new System.Windows.Forms.Panel();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.controlGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clockSpeedNumeric)).BeginInit();
            this.programControlGroup.SuspendLayout();
            this.memoryGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryPictureBox)).BeginInit();
            this.registerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registerPictureBox)).BeginInit();
            this.ioGroup.SuspendLayout();
            this.SuspendLayout();

            /// UI styling
            System.Drawing.Font deviceFont = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font displayFont = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular);

            /// Form1
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 696);
            this.Controls.Add(this.controlGroup);
            this.Controls.Add(this.programControlGroup);
            this.Controls.Add(this.memoryGroup);
            this.Controls.Add(this.registerGroup);
            this.Controls.Add(this.ioGroup);
            this.Name = "Form1";
            this.Text = "COSMAC CDP1802 Board";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = deviceFont;
            this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64); 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

            /// control group
            this.controlGroup.Controls.Add(this.loadButton);
            this.controlGroup.Controls.Add(this.runButton);
            this.controlGroup.Controls.Add(this.stepButton);
            this.controlGroup.Controls.Add(this.stopButton);
            this.controlGroup.Controls.Add(this.resetButton);
            this.controlGroup.Controls.Add(this.refreshButton);
            this.controlGroup.Controls.Add(this.dumpRamButton);
            this.controlGroup.Controls.Add(this.testMemoryButton);
            this.controlGroup.Controls.Add(this.verifyProgramButton);
            this.controlGroup.Controls.Add(this.statusLabel);
            this.controlGroup.Controls.Add(this.debugLabel);
            this.controlGroup.Controls.Add(this.clockSpeedLabel);
            this.controlGroup.Controls.Add(this.clockSpeedNumeric);
            this.controlGroup.Controls.Add(this.realTimeRadio);
            this.controlGroup.Controls.Add(this.stepModeRadio);
            this.controlGroup.Controls.Add(this.cycleCountLabel);
            this.controlGroup.Controls.Add(this.cycleCountTextBox);
            this.controlGroup.Controls.Add(this.runCyclesButton);
            this.controlGroup.Controls.Add(this.statusLedPanel);
            this.controlGroup.Location = new System.Drawing.Point(12, 12);
            this.controlGroup.Name = "controlGroup";
            this.controlGroup.Size = new System.Drawing.Size(960, 100);
            this.controlGroup.TabIndex = 0;
            this.controlGroup.TabStop = false;
            this.controlGroup.Text = "Control Panel";
            this.controlGroup.Font = deviceFont;
            this.controlGroup.BackColor = System.Drawing.Color.FromArgb(169, 169, 169); 
            this.controlGroup.ForeColor = System.Drawing.Color.Black;

            /// load button
            this.loadButton.Location = new System.Drawing.Point(10, 30);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.Text = "&Load";
            this.loadButton.Font = deviceFont;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.BackColor = System.Drawing.Color.FromArgb(0, 128, 255);
            this.loadButton.ForeColor = System.Drawing.Color.White;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            this.loadButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.loadButton, "Load program to memory");

            /// run button
            this.runButton.Location = new System.Drawing.Point(90, 30);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.Text = "&Run";
            this.runButton.Font = deviceFont;
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.BackColor = System.Drawing.Color.FromArgb(0, 255, 0); 
            this.runButton.ForeColor = System.Drawing.Color.Black;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            this.runButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.runButton, "Run program");

            /// step button
            this.stepButton.Location = new System.Drawing.Point(170, 30);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(75, 23);
            this.stepButton.Text = "&Step";
            this.stepButton.Font = deviceFont;
            this.stepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stepButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 0); 
            this.stepButton.ForeColor = System.Drawing.Color.Black;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            this.stepButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.stepButton, "Execute one instruction");

            /// stop button
            this.stopButton.Location = new System.Drawing.Point(250, 30);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.Text = "S&top";
            this.stopButton.Font = deviceFont;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(255, 0, 0); // Red button
            this.stopButton.ForeColor = System.Drawing.Color.White;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            this.stopButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.stopButton, "Stop execution");

            /// reset button
            this.resetButton.Location = new System.Drawing.Point(330, 30);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.Text = "R&eset";
            this.resetButton.Font = deviceFont;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.BackColor = System.Drawing.Color.FromArgb(128, 128, 128); // Gray button
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            this.resetButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.resetButton, "Reset CPU state");

            /// refresh button
            this.refreshButton.Location = new System.Drawing.Point(410, 30);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.Text = "Re&fresh";
            this.refreshButton.Font = deviceFont;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            this.refreshButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.refreshButton, "Refresh output log");

            /// dump RAM button
            this.dumpRamButton.Location = new System.Drawing.Point(490, 30);
            this.dumpRamButton.Name = "dumpRamButton";
            this.dumpRamButton.Size = new System.Drawing.Size(75, 23);
            this.dumpRamButton.Text = "&Dump RAM";
            this.dumpRamButton.Font = deviceFont;
            this.dumpRamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dumpRamButton.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.dumpRamButton.ForeColor = System.Drawing.Color.White;
            this.dumpRamButton.Click += new System.EventHandler(this.dumpRamButton_Click);
            this.dumpRamButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.dumpRamButton, "Dump first 16 bytes of RAM");

            /// test memory button
            this.testMemoryButton.Location = new System.Drawing.Point(570, 30);
            this.testMemoryButton.Name = "testMemoryButton";
            this.testMemoryButton.Size = new System.Drawing.Size(75, 23);
            this.testMemoryButton.Text = "&Test Mem";
            this.testMemoryButton.Font = deviceFont;
            this.testMemoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testMemoryButton.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.testMemoryButton.ForeColor = System.Drawing.Color.White;
            this.testMemoryButton.Click += new System.EventHandler(this.testMemoryButton_Click);
            this.testMemoryButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.testMemoryButton, "Test memory read/write");

            /// verify program button
            this.verifyProgramButton.Location = new System.Drawing.Point(650, 30);
            this.verifyProgramButton.Name = "verifyProgramButton";
            this.verifyProgramButton.Size = new System.Drawing.Size(75, 23);
            this.verifyProgramButton.Text = "&Verify Prog";
            this.verifyProgramButton.Font = deviceFont;
            this.verifyProgramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyProgramButton.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.verifyProgramButton.ForeColor = System.Drawing.Color.White;
            this.verifyProgramButton.Click += new System.EventHandler(this.verifyProgramButton_Click);
            this.verifyProgramButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.verifyProgramButton, "Verify program in memory");

            /// status label
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(730, 34);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.Text = "Ready";
            this.statusLabel.Font = displayFont;
            this.statusLabel.BackColor = System.Drawing.Color.Black;
            this.statusLabel.ForeColor = System.Drawing.Color.Lime;

            /// debug label
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(730, 54);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(50, 13);
            this.debugLabel.Text = "Debug";
            this.debugLabel.Font = displayFont;
            this.debugLabel.BackColor = System.Drawing.Color.Black;
            this.debugLabel.ForeColor = System.Drawing.Color.Lime;

            /// clock speed label
            this.clockSpeedLabel.AutoSize = true;
            this.clockSpeedLabel.Location = new System.Drawing.Point(10, 70);
            this.clockSpeedLabel.Name = "clockSpeedLabel";
            this.clockSpeedLabel.Size = new System.Drawing.Size(70, 13);
            this.clockSpeedLabel.Text = "Clock Speed:";
            this.clockSpeedLabel.Font = deviceFont;
            this.clockSpeedLabel.ForeColor = System.Drawing.Color.Black;

            /// clock speed numeric
            this.clockSpeedNumeric.Location = new System.Drawing.Point(80, 68);
            this.clockSpeedNumeric.Minimum = 1;
            this.clockSpeedNumeric.Maximum = 1000;
            this.clockSpeedNumeric.Value = 100;
            this.clockSpeedNumeric.Name = "clockSpeedNumeric";
            this.clockSpeedNumeric.Size = new System.Drawing.Size(60, 20);
            this.clockSpeedNumeric.Font = displayFont;
            this.clockSpeedNumeric.BackColor = System.Drawing.Color.Black;
            this.clockSpeedNumeric.ForeColor = System.Drawing.Color.Lime;

            /// real time radio
            this.realTimeRadio.Location = new System.Drawing.Point(150, 68);
            this.realTimeRadio.Name = "realTimeRadio";
            this.realTimeRadio.Size = new System.Drawing.Size(80, 20);
            this.realTimeRadio.Text = "&Real-Time";
            this.realTimeRadio.Checked = true;
            this.realTimeRadio.Font = deviceFont;
            this.realTimeRadio.ForeColor = System.Drawing.Color.Black;

            /// step mode radio
            this.stepModeRadio.Location = new System.Drawing.Point(240, 68);
            this.stepModeRadio.Name = "stepModeRadio";
            this.stepModeRadio.Size = new System.Drawing.Size(80, 20);
            this.stepModeRadio.Text = "&Step Mode";
            this.stepModeRadio.Font = deviceFont;
            this.stepModeRadio.ForeColor = System.Drawing.Color.Black;

            /// cycle count label
            this.cycleCountLabel.AutoSize = true;
            this.cycleCountLabel.Location = new System.Drawing.Point(330, 70);
            this.cycleCountLabel.Name = "cycleCountLabel";
            this.cycleCountLabel.Size = new System.Drawing.Size(60, 13);
            this.cycleCountLabel.Text = "Cycle Count:";
            this.cycleCountLabel.Font = deviceFont;
            this.cycleCountLabel.ForeColor = System.Drawing.Color.Black;

            /// cycle count textbox
            this.cycleCountTextBox.Location = new System.Drawing.Point(390, 68);
            this.cycleCountTextBox.Name = "cycleCountTextBox";
            this.cycleCountTextBox.Size = new System.Drawing.Size(60, 20);
            this.cycleCountTextBox.Text = "100";
            this.cycleCountTextBox.Font = displayFont;
            this.cycleCountTextBox.BackColor = System.Drawing.Color.Black;
            this.cycleCountTextBox.ForeColor = System.Drawing.Color.Lime;

            /// run cycles button
            this.runCyclesButton.Location = new System.Drawing.Point(460, 68);
            this.runCyclesButton.Name = "runCyclesButton";
            this.runCyclesButton.Size = new System.Drawing.Size(75, 20);
            this.runCyclesButton.Text = "Run &Cycles";
            this.runCyclesButton.Font = deviceFont;
            this.runCyclesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runCyclesButton.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.runCyclesButton.ForeColor = System.Drawing.Color.White;
            this.runCyclesButton.Click += new System.EventHandler(this.runCyclesButton_Click);
            this.runCyclesButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.runCyclesButton, "Run specified number of cycles");

            /// status led panel
            this.statusLedPanel.Location = new System.Drawing.Point(540, 68);
            this.statusLedPanel.Name = "statusLedPanel";
            this.statusLedPanel.Size = new System.Drawing.Size(40, 20);
            this.statusLedPanel.BackColor = System.Drawing.Color.Black;
            this.statusLedPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.statusLedPanel_Paint);

            /// program control group
            this.programControlGroup.Controls.Add(this.opcodeComboBox);
            this.programControlGroup.Controls.Add(this.operandTextBox);
            this.programControlGroup.Controls.Add(this.addInstructionButton);
            this.programControlGroup.Controls.Add(this.programListBox);
            this.programControlGroup.Controls.Add(this.clearProgramButton);
            this.programControlGroup.Controls.Add(this.loadProgramButton);
            this.programControlGroup.Location = new System.Drawing.Point(12, 118);
            this.programControlGroup.Name = "programControlGroup";
            this.programControlGroup.Size = new System.Drawing.Size(480, 150);
            this.programControlGroup.TabIndex = 1;
            this.programControlGroup.TabStop = false;
            this.programControlGroup.Text = "Program Entry";
            this.programControlGroup.Font = deviceFont;
            this.programControlGroup.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.programControlGroup.ForeColor = System.Drawing.Color.Black;

            /// opcode combo box
            this.opcodeComboBox.Location = new System.Drawing.Point(10, 20);
            this.opcodeComboBox.Name = "opcodeComboBox";
            this.opcodeComboBox.Size = new System.Drawing.Size(120, 21);
            this.opcodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.opcodeComboBox.Items.AddRange(new object[] { "ADD", "LDA", "STR", "BR", "INP 1", "OUT 1" });
            this.opcodeComboBox.SelectedIndex = 0;
            this.opcodeComboBox.Font = displayFont;
            this.opcodeComboBox.BackColor = System.Drawing.Color.Black;
            this.opcodeComboBox.ForeColor = System.Drawing.Color.Lime;
            this.toolTip.SetToolTip(this.opcodeComboBox, "Select instruction opcode");

            /// operand textbox
            this.operandTextBox.Location = new System.Drawing.Point(140, 20);
            this.operandTextBox.Name = "operandTextBox";
            this.operandTextBox.Size = new System.Drawing.Size(100, 20);
            this.operandTextBox.Font = displayFont;
            this.operandTextBox.BackColor = System.Drawing.Color.Black;
            this.operandTextBox.ForeColor = System.Drawing.Color.Lime;
            this.toolTip.SetToolTip(this.operandTextBox, "Enter operand (e.g., 0-F for registers, 00-FF for address)");

            /// add instruction button
            this.addInstructionButton.Location = new System.Drawing.Point(250, 20);
            this.addInstructionButton.Name = "addInstructionButton";
            this.addInstructionButton.Size = new System.Drawing.Size(75, 23);
            this.addInstructionButton.Text = "&Add";
            this.addInstructionButton.Font = deviceFont;
            this.addInstructionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addInstructionButton.BackColor = System.Drawing.Color.FromArgb(0, 128, 255);
            this.addInstructionButton.ForeColor = System.Drawing.Color.White;
            this.addInstructionButton.Click += new System.EventHandler(this.addInstructionButton_Click);
            this.addInstructionButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.addInstructionButton, "Add instruction to program");

            /// program list box
            this.programListBox.Location = new System.Drawing.Point(10, 50);
            this.programListBox.Name = "programListBox";
            this.programListBox.Size = new System.Drawing.Size(460, 69);
            this.programListBox.Font = displayFont;
            this.programListBox.BackColor = System.Drawing.Color.Black;
            this.programListBox.ForeColor = System.Drawing.Color.Lime;
            this.programListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolTip.SetToolTip(this.programListBox, "Program instructions");

            /// clear program button
            this.clearProgramButton.Location = new System.Drawing.Point(330, 125);
            this.clearProgramButton.Name = "clearProgramButton";
            this.clearProgramButton.Size = new System.Drawing.Size(75, 23);
            this.clearProgramButton.Text = "&Clear";
            this.clearProgramButton.Font = deviceFont;
            this.clearProgramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearProgramButton.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.clearProgramButton.ForeColor = System.Drawing.Color.White;
            this.clearProgramButton.Click += new System.EventHandler(this.clearProgramButton_Click);
            this.clearProgramButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.clearProgramButton, "Clear program list");

            /// load program button
            this.loadProgramButton.Location = new System.Drawing.Point(410, 125);
            this.loadProgramButton.Name = "loadProgramButton";
            this.loadProgramButton.Size = new System.Drawing.Size(75, 23);
            this.loadProgramButton.Text = "&Load Prog";
            this.loadProgramButton.Font = deviceFont;
            this.loadProgramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadProgramButton.BackColor = System.Drawing.Color.FromArgb(0, 128, 255);
            this.loadProgramButton.ForeColor = System.Drawing.Color.White;
            this.loadProgramButton.Click += new System.EventHandler(this.loadProgramButton_Click);
            this.loadProgramButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.toolTip.SetToolTip(this.loadProgramButton, "Load program to memory");

            /// memory group
            this.memoryGroup.Controls.Add(this.memoryPictureBox);
            this.memoryGroup.Location = new System.Drawing.Point(12, 274);
            this.memoryGroup.Name = "memoryGroup";
            this.memoryGroup.Size = new System.Drawing.Size(480, 410);
            this.memoryGroup.TabIndex = 2;
            this.memoryGroup.TabStop = false;
            this.memoryGroup.Text = "Memory Display";
            this.memoryGroup.Font = deviceFont;
            this.memoryGroup.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.memoryGroup.ForeColor = System.Drawing.Color.Black;

            /// memory picture box
            this.memoryPictureBox.Location = new System.Drawing.Point(10, 20);
            this.memoryPictureBox.Name = "memoryPictureBox";
            this.memoryPictureBox.Size = new System.Drawing.Size(460, 380);
            this.memoryPictureBox.BackColor = System.Drawing.Color.Black;
            this.memoryPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.memoryPictureBox_Paint);

            /// register group
            this.registerGroup.Controls.Add(this.registerPictureBox);
            this.registerGroup.Location = new System.Drawing.Point(498, 118);
            this.registerGroup.Name = "registerGroup";
            this.registerGroup.Size = new System.Drawing.Size(474, 290);
            this.registerGroup.TabIndex = 3;
            this.registerGroup.TabStop = false;
            this.registerGroup.Text = "Registers";
            this.registerGroup.Font = deviceFont;
            this.registerGroup.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.registerGroup.ForeColor = System.Drawing.Color.Black;

            /// register picture box
            this.registerPictureBox.Location = new System.Drawing.Point(10, 20);
            this.registerPictureBox.Name = "registerPictureBox";
            this.registerPictureBox.Size = new System.Drawing.Size(454, 260);
            this.registerPictureBox.BackColor = System.Drawing.Color.Black;
            this.registerPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.registerPictureBox_Paint);

            /// IO group
            this.ioGroup.Controls.Add(this.keypadPanel);
            this.ioGroup.Controls.Add(this.logTextBox);
            this.ioGroup.Location = new System.Drawing.Point(498, 414);
            this.ioGroup.Name = "ioGroup";
            this.ioGroup.Size = new System.Drawing.Size(474, 270);
            this.ioGroup.TabIndex = 4;
            this.ioGroup.TabStop = false;
            this.ioGroup.Text = "I/O Devices";
            this.ioGroup.Font = deviceFont;
            this.ioGroup.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.ioGroup.ForeColor = System.Drawing.Color.Black;

            /// keypad
            this.keypadPanel.Location = new System.Drawing.Point(10, 20);
            this.keypadPanel.Name = "keypadPanel";
            this.keypadPanel.Size = new System.Drawing.Size(160, 160);
            this.keypadPanel.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            /// Keypad buttons (4x4)
            string[] keys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            for (int i = 0; i < 16; i++)
            {
                var btn = new System.Windows.Forms.Button
                {
                    Text = keys[i],
                    Location = new System.Drawing.Point(10 + (i % 4) * 40, 10 + (i / 4) * 40),
                    Size = new System.Drawing.Size(30, 30),
                    Tag = i.ToString("X"),
                    Font = deviceFont,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    BackColor = System.Drawing.Color.FromArgb(32, 32, 32), // Dark gray keys
                    ForeColor = System.Drawing.Color.White
                };
                btn.Click += new System.EventHandler(this.keypadButton_Click);
                btn.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
                this.keypadPanel.Controls.Add(btn);
            }

            /// log textbox
            this.logTextBox.Location = new System.Drawing.Point(180, 20);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Multiline = true;
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(280, 230);
            this.logTextBox.Font = displayFont;
            this.logTextBox.BackColor = System.Drawing.Color.Black;
            this.logTextBox.ForeColor = System.Drawing.Color.Lime;
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // finalize Form1
            this.controlGroup.ResumeLayout(false);
            this.controlGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clockSpeedNumeric)).EndInit();
            this.programControlGroup.ResumeLayout(false);
            this.programControlGroup.PerformLayout();
            this.memoryGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoryPictureBox)).EndInit();
            this.registerGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.registerPictureBox)).EndInit();
            this.ioGroup.ResumeLayout(false);
            this.ioGroup.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox controlGroup;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button dumpRamButton;
        private System.Windows.Forms.Button testMemoryButton;
        private System.Windows.Forms.Button verifyProgramButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label debugLabel;
        private System.Windows.Forms.Label clockSpeedLabel;
        private System.Windows.Forms.NumericUpDown clockSpeedNumeric;
        private System.Windows.Forms.RadioButton realTimeRadio;
        private System.Windows.Forms.RadioButton stepModeRadio;
        private System.Windows.Forms.Label cycleCountLabel;
        private System.Windows.Forms.TextBox cycleCountTextBox;
        private System.Windows.Forms.Button runCyclesButton;
        private System.Windows.Forms.Panel statusLedPanel;
        private System.Windows.Forms.GroupBox programControlGroup;
        private System.Windows.Forms.ComboBox opcodeComboBox;
        private System.Windows.Forms.TextBox operandTextBox;
        private System.Windows.Forms.Button addInstructionButton;
        private System.Windows.Forms.ListBox programListBox;
        private System.Windows.Forms.Button clearProgramButton;
        private System.Windows.Forms.Button loadProgramButton;
        private System.Windows.Forms.GroupBox memoryGroup;
        private System.Windows.Forms.PictureBox memoryPictureBox;
        private System.Windows.Forms.GroupBox registerGroup;
        private System.Windows.Forms.PictureBox registerPictureBox;
        private System.Windows.Forms.GroupBox ioGroup;
        private System.Windows.Forms.Panel keypadPanel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ToolTip toolTip;
    }
}