using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CDP1802Simulator
{
    public partial class Form1 : Form
    {
        private readonly CDP1802 cpu;
        private readonly Memory memory;
        private readonly Timer executionTimer;
        private readonly List<byte> programBytes;
        private bool programLoaded;

        public Form1()
        {
            InitializeComponent();
            memory = new Memory(this);
            cpu = new CDP1802(memory, this);
            executionTimer = new Timer { Interval = 1000 }; 
            executionTimer.Tick += ExecutionTimer_Tick;
            programBytes = new List<byte>();
            programLoaded = false;
            UpdateUI();
            StatusLog("Emulator initialized");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Rectangle(0, 0, ClientSize.Width, ClientSize.Height),
                Color.FromArgb(64, 64, 64), 
                Color.FromArgb(100, 100, 100), 
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(gradientBrush, ClientRectangle);
            }

            /// faux panel edges
            using (Pen borderPen = new Pen(Color.FromArgb(32, 32, 32), 4))
            {
                g.DrawRectangle(borderPen, 2, 2, ClientSize.Width - 4, ClientSize.Height - 4);
            }

            /// faux screws
            using (Brush screwBrush = new SolidBrush(Color.FromArgb(50, 50, 50)))
            {
                g.FillEllipse(screwBrush, 10, 10, 8, 8); // Top-left
                g.FillEllipse(screwBrush, ClientSize.Width - 18, 10, 8, 8); // Top-right
                g.FillEllipse(screwBrush, 10, ClientSize.Height - 18, 8, 8); // Bottom-left
                g.FillEllipse(screwBrush, ClientSize.Width - 18, ClientSize.Height - 18, 8, 8); // Bottom-right
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            ControlPaint.DrawBorder3D(e.Graphics, btn.ClientRectangle, Border3DStyle.Raised);
        }

        private void statusLedPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color ledColor = executionTimer.Enabled ? Color.Lime : Color.Red;
            for (int i = 8; i >= 4; i--)
            {
                using (Brush glowBrush = new SolidBrush(Color.FromArgb(50 - i * 5, ledColor)))
                {
                    g.FillEllipse(glowBrush, 12 - i, 4 - i, 16 + 2 * i, 16 + 2 * i);
                }
            }
            using (Brush ledBrush = new SolidBrush(ledColor))
            {
                g.FillEllipse(ledBrush, 12, 4, 16, 16);
            }
        }

        private void memoryPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Font displayFont = new Font("Courier New", 10F))
            using (Brush textBrush = new SolidBrush(Color.Lime))
            using (Brush pcBrush = new SolidBrush(Color.Yellow)) 
            using (Pen gridPen = new Pen(Color.FromArgb(50, 50, 50)))
            {
                for (int x = 0; x < 460; x += 50)
                    g.DrawLine(gridPen, x, 0, x, 380);
                for (int gridY = 0; gridY < 380; gridY += 22)
                    g.DrawLine(gridPen, 0, gridY, 460, gridY);
                /// headers
                g.DrawString("Addr", displayFont, textBrush, 0, 0);
                for (int i = 1; i < 9; i++)
                    g.DrawString($"+{i - 1:X}", displayFont, textBrush, 60 + (i - 1) * 50, 0);
                /// memory
                ushort startAddr = (ushort)memoryStartNumeric.Value;
                ushort pc = cpu.Registers[cpu.P];
                for (int row = 0; row < 16; row++)
                {
                    ushort rowAddr = (ushort)(startAddr + row * 8);
                    g.DrawString($"{rowAddr:X4}", displayFont, textBrush, 0, 20 + row * 22);
                    for (int col = 1; col < 9; col++)
                    {
                        ushort addr = (ushort)(rowAddr + col - 1);
                        string value = $"{memory.Read(addr):X2}";
                        Brush brush = addr == pc ? pcBrush : textBrush;
                        g.DrawString(value, displayFont, brush, 60 + (col - 1) * 50, 20 + row * 22);
                    }
                }
            }
        }

        private void registerPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Font displayFont = new Font("Courier New", 10F))
            using (Brush textBrush = new SolidBrush(Color.Lime))
            using (Pen gridPen = new Pen(Color.FromArgb(50, 50, 50)))
            {
                for (int gridY = 0; gridY < 310; gridY += 25)
                    g.DrawLine(gridPen, 0, gridY, 454, gridY);
                /// registers
                int yPos = 0;
                for (int i = 0; i < 16; i++)
                {
                    g.DrawString($"R{i:X}: 0x{cpu.Registers[i]:X4}", displayFont, textBrush, 10, yPos);
                    yPos += 25;
                }
                g.DrawString($"D: 0x{cpu.D:X2}", displayFont, textBrush, 10, yPos); yPos += 25;
                g.DrawString($"P: 0x{cpu.P:X}", displayFont, textBrush, 10, yPos); yPos += 25;
                g.DrawString($"X: 0x{cpu.X:X}", displayFont, textBrush, 10, yPos); yPos += 25;
                g.DrawString($"T: 0x{cpu.T:X2}", displayFont, textBrush, 10, yPos); yPos += 25;
                g.DrawString($"Q: {(cpu.Q ? 1 : 0)}", displayFont, textBrush, 10, yPos); yPos += 25;
                g.DrawString($"IE: {(cpu.IE ? 1 : 0)}", displayFont, textBrush, 10, yPos); yPos += 25;
                g.DrawString($"DF: {(cpu.DF ? 1 : 0)}", displayFont, textBrush, 10, yPos);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (programBytes.Count == 0)
                {
                    statusLabel.Text = "Error: No program defined";
                    StatusLog("Error: Program is empty");
                    return;
                }
                string programLog = "Loading program: " + string.Join(" ", programBytes.Select(b => $"0x{b:X2}"));
                StatusLog(programLog);
                int bytesLoaded = memory.LoadProgram(programBytes.ToArray());
                verifyProgramButton_Click(sender, e);
                programLoaded = true;
                UpdateUI();
                statusLabel.Text = $"Loaded {bytesLoaded} bytes";
                StatusLog($"Loaded {bytesLoaded} bytes");
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Load Error: {ex.Message}";
                StatusLog($"Load Error: {ex.Message}");
                programLoaded = false;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (!programLoaded)
            {
                statusLabel.Text = "Error: Load a program first";
                StatusLog("Error: No program loaded");
                return;
            }
            if (realTimeRadio.Checked)
            {
                if (!executionTimer.Enabled)
                {
                    cpu.StartRealTime();
                    executionTimer.Start();
                    statusLabel.Text = "Running (Real-Time)";
                    StatusLog($"Started real-time mode at {clockSpeedNumeric.Value} Hz");
                }
            }
            else
            {
                cpu.Run();
                UpdateUI();
                statusLabel.Text = "Program Executed";
                StatusLog("Run completed");
            }
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            if (!programLoaded)
            {
                statusLabel.Text = "Error: Load a program first";
                StatusLog("Error: No program loaded");
                return;
            }
            if (!realTimeRadio.Checked)
            {
                cpu.Step();
                UpdateUI();
                statusLabel.Text = "Step Executed";
                StatusLog("Step executed");
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            cpu.Stop();
            executionTimer.Stop();
            UpdateUI();
            statusLabel.Text = "Stopped";
            StatusLog("Execution stopped manually");
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            cpu.Reset();
            executionTimer.Stop();
            programLoaded = false;
            UpdateUI();
            statusLabel.Text = "CPU Reset";
            StatusLog("CPU reset");
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateUI();
            statusLabel.Text = "Log Refreshed";
            StatusLog("Log refreshed");
        }

        private void dumpRamButton_Click(object sender, EventArgs e)
        {
            string ramLog = "RAM Dump: ";
            for (int i = 0; i < 16; i++)
            {
                ramLog += $"0x{memory.Read((ushort)i):X2} ";
            }
            StatusLog(ramLog);
            statusLabel.Text = "RAM Dumped";
        }

        private void testMemoryButton_Click(object sender, EventArgs e)
        {
            memory.Write(0xFFFF, 0x55);
            byte value = memory.Read(0xFFFF);
            StatusLog($"Memory Test: Wrote 0x55 to 0xFFFF, Read 0x{value:X2}");
            statusLabel.Text = $"Memory Test: {value:X2}";
        }

        private void verifyProgramButton_Click(object sender, EventArgs e)
        {
            string programLog = "Program at 0x0000: ";
            for (int i = 0; i < 16; i++)
            {
                programLog += $"0x{memory.Read((ushort)i):X2} ";
            }
            StatusLog(programLog);
            statusLabel.Text = "Program Verified";
        }

        private void keypadButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            byte value = Convert.ToByte(btn.Tag.ToString(), 16);
            int port = 1; 
            memory.WriteIO((ushort)(0xFF01 + (port - 1)), value);
            statusLabel.Text = $"Keypad Input: {value:X} to INP {port}";
            StatusLog($"Keypad input: 0x{value:X2} to INP {port}");
            UpdateUI();
        }

        private void clockSpeedNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateTimerInterval();
            StatusLog($"Clock speed set to {clockSpeedNumeric.Value} Hz");
        }

        private void realTimeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (realTimeRadio.Checked)
            {
                StatusLog("Switched to Real-Time mode");
            }
        }

        private void stepModeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (stepModeRadio.Checked)
            {
                cpu.Stop();
                executionTimer.Stop();
                StatusLog("Switched to Step mode");
            }
        }

        private void runCyclesButton_Click(object sender, EventArgs e)
        {
            if (!programLoaded)
            {
                statusLabel.Text = "Error: Load a program first";
                StatusLog("Error: No program loaded");
                return;
            }
            if (int.TryParse(cycleCountTextBox.Text, out int cycles) && cycles > 0)
            {
                cpu.RunCycles(cycles);
                UpdateUI();
                statusLabel.Text = $"Ran {cycles} cycles";
                StatusLog($"Ran {cycles} cycles");
            }
            else
            {
                statusLabel.Text = "Invalid cycle count";
                StatusLog("Error: Invalid cycle count");
            }
        }

        private void interruptButton_Click(object sender, EventArgs e)
        {
            cpu.TriggerInterrupt();
            statusLabel.Text = "Interrupt Triggered";
            StatusLog("Interrupt triggered");
            UpdateUI();
        }

        private void memoryStartNumeric_ValueChanged(object sender, EventArgs e)
        {
            memoryPictureBox.Invalidate();
            StatusLog($"Memory display start address set to 0x{memoryStartNumeric.Value:X4}");
        }

        private void addInstructionButton_Click(object sender, EventArgs e)
        {
            string opcode = opcodeComboBox.SelectedItem?.ToString();
            string operand = operandTextBox.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(opcode))
            {
                statusLabel.Text = "Error: Select an opcode";
                StatusLog("Error: No opcode selected");
                return;
            }

            bool operandRequired = opcode == "LDA" || opcode == "STR" || opcode == "BR" || opcode == "BZ" || opcode == "BNZ" || opcode == "SEP";
            if (operandRequired && string.IsNullOrEmpty(operand))
            {
                statusLabel.Text = "Error: Operand required";
                StatusLog($"Error: Operand required for {opcode}");
                return;
            }

            byte[] instructionBytes = null;
            try
            {
                switch (opcode)
                {
                    case "ADD":
                        instructionBytes = new byte[] { 0x74 };
                        break;
                    case "SUB":
                        instructionBytes = new byte[] { 0x75 };
                        break;
                    case "AND":
                        instructionBytes = new byte[] { 0xF2 };
                        break;
                    case "OR":
                        instructionBytes = new byte[] { 0xF1 };
                        break;
                    case "LDA":
                        if (!byte.TryParse(operand, System.Globalization.NumberStyles.HexNumber, null, out byte reg) || reg > 0xF)
                            throw new ArgumentException("Invalid register (0-F)");
                        instructionBytes = new byte[] { (byte)(0xF8 | reg) };
                        break;
                    case "STR":
                        if (!byte.TryParse(operand, System.Globalization.NumberStyles.HexNumber, null, out reg) || reg > 0xF)
                            throw new ArgumentException("Invalid register (0-F)");
                        instructionBytes = new byte[] { (byte)(0x40 | reg) };
                        break;
                    case "BR":
                        if (!byte.TryParse(operand, System.Globalization.NumberStyles.HexNumber, null, out byte addr))
                            throw new ArgumentException("Invalid address (00-FF)");
                        instructionBytes = new byte[] { 0x30, addr };
                        break;
                    case "BZ":
                        if (!byte.TryParse(operand, System.Globalization.NumberStyles.HexNumber, null, out addr))
                            throw new ArgumentException("Invalid address (00-FF)");
                        instructionBytes = new byte[] { 0x32, addr };
                        break;
                    case "BNZ":
                        if (!byte.TryParse(operand, System.Globalization.NumberStyles.HexNumber, null, out addr))
                            throw new ArgumentException("Invalid address (00-FF)");
                        instructionBytes = new byte[] { 0x33, addr };
                        break;
                    case "SEP":
                        if (!byte.TryParse(operand, System.Globalization.NumberStyles.HexNumber, null, out reg) || reg > 0xF)
                            throw new ArgumentException("Invalid register (0-F)");
                        instructionBytes = new byte[] { (byte)(0xD0 | reg) };
                        break;
                    case "INP 1":
                    case "INP 2":
                    case "INP 3":
                    case "INP 4":
                    case "INP 5":
                    case "INP 6":
                    case "INP 7":
                        int inpPort = int.Parse(opcode.Split(' ')[1]);
                        instructionBytes = new byte[] { (byte)(0x68 + inpPort) };
                        break;
                    case "OUT 1":
                    case "OUT 2":
                    case "OUT 3":
                    case "OUT 4":
                    case "OUT 5":
                    case "OUT 6":
                    case "OUT 7":
                        int outPort = int.Parse(opcode.Split(' ')[1]);
                        instructionBytes = new byte[] { (byte)(0x60 + outPort) };
                        break;
                    default:
                        throw new ArgumentException("Invalid opcode");
                }

                programBytes.AddRange(instructionBytes);
                string instructionText = $"{opcode}{(string.IsNullOrEmpty(operand) ? "" : $" {operand}")}";
                programListBox.Items.Add(instructionText);
                statusLabel.Text = "Instruction Added";
                StatusLog($"Added instruction: {instructionText}");
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error: {ex.Message}";
                StatusLog($"Error adding instruction: {ex.Message}");
            }
        }

        private void clearProgramButton_Click(object sender, EventArgs e)
        {
            programBytes.Clear();
            programListBox.Items.Clear();
            programLoaded = false;
            statusLabel.Text = "Program Cleared";
            StatusLog("Program cleared");
        }

        private void loadProgramButton_Click(object sender, EventArgs e)
        {
            loadButton_Click(sender, e);
        }

        private void ExecutionTimer_Tick(object sender, EventArgs e)
        {
            if (!programLoaded)
            {
                executionTimer.Stop();
                statusLabel.Text = "Error: No program loaded";
                StatusLog("Stopped: No program loaded in real-time mode");
                return;
            }

            if (!cpu.IsRunning && cpu.LastInstruction == 0x00)
            {
                statusLabel.Text = "Paused: IDL waiting for interrupt";
                return; // Wait for interrupt
            }

            cpu.Step();
            UpdateUI();
        }

        private void UpdateTimerInterval()
        {
            if (clockSpeedNumeric.Value > 0)
            {
                executionTimer.Interval = (int)(1000 / clockSpeedNumeric.Value);
            }
        }

        private void UpdateUI()
        {
            statusLedPanel.Invalidate();
            memoryPictureBox.Invalidate();
            registerPictureBox.Invalidate();
            Invalidate();

            debugLabel.Text = $"Inst: 0x{cpu.LastInstruction:X2} PC: 0x{cpu.Registers[cpu.P]:X4} Cycles: {cpu.CycleCount}";
            string outputLog = "Output ports: ";
            for (int i = 0; i < 7; i++)
            {
                outputLog += $"OUT {i + 1}: 0x{memory.ReadIO((ushort)(0xFF08 + i)):X2} ";
            }
            logTextBox.AppendText($"{outputLog}\n");
        }

        public void LogInstruction(string message)
        {
            StatusLog(message);
        }

        private void StatusLog(string message)
        {
            logTextBox.AppendText($"{message}\n");
            Debug.WriteLine($"[CDP1802] {message}");
        }
    }
}