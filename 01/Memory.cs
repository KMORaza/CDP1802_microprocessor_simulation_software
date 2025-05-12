using System;
using System.Linq;

namespace CDP1802Simulator
{
    public class Memory
    {
        private readonly byte[] ram = new byte[65536]; 
        private readonly byte[] ioPorts = new byte[2]; 
        private readonly Form1 form;

        public Memory(Form1 form = null)
        {
            this.form = form;
        }

        public byte Read(ushort address)
        {
            return ram[address];
        }

        public void Write(ushort address, byte value)
        {
            ram[address] = value;
        }

        public byte ReadIO(ushort address)
        {
            if (address == 0xFF00) return ioPorts[0]; 
            if (address == 0xFF01) return ioPorts[1]; 
            return 0;
        }

        public void WriteIO(ushort address, byte value)
        {
            if (address == 0xFF00) ioPorts[0] = value; 
            if (address == 0xFF01) ioPorts[1] = value;
        }

        public int LoadProgram(byte[] programBytes)
        {
            Array.Clear(ram, 0, ram.Length);
            if (programBytes == null || programBytes.Length == 0)
            {
                form?.LogInstruction("Error: Empty program");
                throw new ArgumentException("Program is empty");
            }
            if (programBytes.All(b => b == 0x00))
            {
                form?.LogInstruction("Error: Program contains only 0x00 bytes");
                throw new ArgumentException("Program contains only 0x00 bytes");
            }

            int bytesLoaded = Math.Min(programBytes.Length, ram.Length);
            Array.Copy(programBytes, 0, ram, 0, bytesLoaded);
            string ramLog = "RAM Loaded: ";
            for (int i = 0; i < Math.Min(bytesLoaded, 16); i++)
            {
                ramLog += $"0x{ram[i]:X2} ";
            }
            form?.LogInstruction(ramLog);
            return bytesLoaded;
        }
    }
}