using System;

namespace CDP1802Simulator
{
    public class CDP1802
    {
        private readonly Memory memory;
        private readonly Form1 form;
        public ushort[] Registers { get; } = new ushort[16]; /// R0-RF
        public byte D { get; set; } /// Data register
        public byte P { get; set; } /// Program counter register
        public byte X { get; set; } /// Index register
        public byte T { get; set; } /// Auxiliary register
        public bool Q { get; set; } /// Output flip-flop
        private bool running;
        public byte LastInstruction { get; private set; }
        public long CycleCount { get; private set; }
        private int unknownInstructionCount;

        public CDP1802(Memory memory, Form1 form = null)
        {
            this.memory = memory;
            this.form = form;
            Reset();
        }

        public void Reset()
        {
            Array.Clear(Registers, 0, 16);
            D = 0; P = 0; X = 0; T = 0; Q = false;
            running = false;
            LastInstruction = 0;
            CycleCount = 0;
            unknownInstructionCount = 0;
            form?.LogInstruction("CPU reset");
        }

        public void Step()
        {
            ExecuteInstruction();
            CycleCount++;
            form?.LogInstruction($"Step completed, Cycle: {CycleCount}");
        }

        public void Run()
        {
            if (!ValidateState()) return;
            running = true;
            unknownInstructionCount = 0;
            form?.LogInstruction("Run started");
            while (running)
            {
                ExecuteInstruction();
                CycleCount++;
            }
            form?.LogInstruction($"Run stopped, Cycle: {CycleCount}");
        }

        public void RunCycles(int cycles)
        {
            if (!ValidateState()) return;
            running = true;
            unknownInstructionCount = 0;
            form?.LogInstruction($"Running {cycles} cycles");
            for (int i = 0; i < cycles && running; i++)
            {
                ExecuteInstruction();
                CycleCount++;
            }
            running = false;
            form?.LogInstruction($"Ran {cycles} cycles, Cycle: {CycleCount}");
        }

        public void StartRealTime()
        {
            if (!ValidateState()) return;
            running = true;
            unknownInstructionCount = 0;
            form?.LogInstruction("Real-time mode started");
        }

        public void Stop()
        {
            running = false;
            unknownInstructionCount = 0;
            form?.LogInstruction($"Stopped, Cycle: {CycleCount}");
        }

        private bool ValidateState()
        {
            if (P >= 16)
            {
                form?.LogInstruction($"Warning: P = {P} (out of range)");
                return true; /// Allow execution for debugging
            }
            if (Registers[P] >= 65536)
            {
                form?.LogInstruction($"Warning: PC = 0x{Registers[P]:X4} (out of memory)");
                return true; /// Allow execution for debugging
            }
            return true;
        }

        private void ExecuteInstruction()
        {
            try
            {
                ushort pc = Registers[P];
                byte instruction = memory.Read(pc);
                LastInstruction = instruction;
                Registers[P]++;
                form?.LogInstruction($"Executing 0x{instruction:X2} at PC: 0x{pc:X4}, P: {P}, Running: {running}");

                byte opcode = (byte)(instruction >> 4);
                byte n = (byte)(instruction & 0xF);

                switch (instruction)
                {
                    case 0x00: /// IDL 
                        unknownInstructionCount = 0;
                        form?.LogInstruction("IDL: No operation (skipped)");
                        break;
                    default:
                        switch (opcode)
                        {
                            case 0x7 when n == 0x4: /// ADD
                                D = (byte)(D + memory.Read(Registers[X]));
                                Registers[X]++;
                                unknownInstructionCount = 0;
                                form?.LogInstruction($"ADD: D = 0x{D:X2}");
                                break;
                            case 0xF when n == 0x8: /// LDA
                                D = memory.Read(Registers[n]);
                                Registers[n]++;
                                unknownInstructionCount = 0;
                                form?.LogInstruction($"LDA: D = 0x{D:X2}, R{n:X} = 0x{Registers[n]:X4}");
                                break;
                            case 0x4: // STR
                                memory.Write(Registers[n], D);
                                unknownInstructionCount = 0;
                                form?.LogInstruction($"STR: Wrote 0x{D:X2} to 0x{Registers[n]:X4}");
                                break;
                            case 0x3 when n == 0x0: /// BR
                                Registers[P] = memory.Read(pc);
                                unknownInstructionCount = 0;
                                form?.LogInstruction($"BR: PC = 0x{Registers[P]:X4}");
                                break;
                            case 0x6 when n == 0x9: /// INP 1
                                D = memory.ReadIO(0xFF00);
                                memory.Write(Registers[X], D);
                                Registers[X]++;
                                unknownInstructionCount = 0;
                                form?.LogInstruction($"INP 1: D = 0x{D:X2}, Wrote to 0x{Registers[X] - 1:X4}");
                                break;
                            case 0x6 when n == 0x1: /// OUT 1
                                memory.WriteIO(0xFF01, D);
                                unknownInstructionCount = 0;
                                form?.LogInstruction($"OUT 1: Wrote 0x{D:X2} to 0xFF01");
                                break;
                            default:
                                unknownInstructionCount++;
                                form?.LogInstruction($"Unknown instruction: 0x{instruction:X2}, continuing");
                                if (unknownInstructionCount >= 10)
                                {
                                    running = false;
                                    form?.LogInstruction("Stopped due to 10 unknown instructions");
                                }
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                running = false;
                unknownInstructionCount = 0;
                form?.LogInstruction($"Execution error: {ex.Message}");
            }
        }
    }
}