﻿using Konamiman.Z80dotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPlayer.Driver.AY
{
    public class port : IMemory
    {
        public IZ80Registers registers;
        public ChipRegister chipRegister;
        public EnmModel model;
        private byte AYReg = 0;
        private byte AYDat = 0;

        public byte this[int address]
        {
            get
            {
                return InPort(address);
            }

            set
            {
                OutPort(address, value);
            }
        }

        public int Size => throw new NotImplementedException();

        public byte[] GetContents(int startAddress, int length)
        {
            throw new NotImplementedException();
        }

        public void SetContents(int startAddress, byte[] contents, int startIndex = 0, int? length = null)
        {
            throw new NotImplementedException();
        }

        private void OutPort(int address, byte value)
        {
            address = registers.B * 0x100 | (byte)address;
            //Console.WriteLine("Out Port Adr:{0:x04} Dat:{1:x02}", address, value);

            if ((address & 0xc002) == 0xc000)
            {
                AYReg = value;
            }
            else if ((address & 0xc002) == 0x8000)
            {
                AYDat = value;
                chipRegister.setAY8910Register(0, AYReg, AYDat, model);
                //Console.WriteLine("AY Reg:{0:x02} Dat:{1:x02}", AYReg, AYDat);
            }

        }

        private byte InPort(int address)
        {
            //Console.WriteLine("In Port Adr:{0:x04}", address);
            return 0;
        }

    }
}