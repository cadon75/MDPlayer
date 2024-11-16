﻿using Konamiman.Z80dotNet;

namespace MDPlayer.Driver.MGSDRV
{
    public class MsxMemory : IMemory
    {
        private ChipRegister chipRegister;
        private EnmModel model;
        public MSXSlot slot;
        private baseDriver driver;

        public MsxMemory(ChipRegister chipRegister, EnmModel model,baseDriver driver)
        {
            this.chipRegister = chipRegister;
            this.model = model;
            this.slot = new MSXSlot(chipRegister, model, driver);
            this.driver = driver;
        }

        public byte this[int address]
        {
            get
            {
                int page = address / Cartridge.PAGE_SIZE;
                return slot.pages[page][(ushort)address];
            }
            set
            {
                int page = address / Cartridge.PAGE_SIZE;
                slot.pages[page][(ushort)address] = value;
            }
        }

        public int Size => 65536;

        public byte[] GetContents(int startAddress, int length)
        {
            if (startAddress >= this.Size)
                throw new IndexOutOfRangeException("startAddress cannot go beyond memory size");

            if (startAddress + length > this.Size)
                throw new IndexOutOfRangeException("startAddress + length cannot go beyond memory size");

            if (startAddress < 0)
                throw new IndexOutOfRangeException("startAddress cannot be negative");

            byte[] ret = new byte[length];
            for (int i = 0; i < length; i++) ret[i] = this[startAddress + i];
            return ret;
        }

        public void SetContents(int startAddress, byte[] contents, int startIndex = 0, int? length = null)
        {
            if (contents == null)
                throw new ArgumentNullException("contents");

            if (length == null)
                length = contents.Length;

            if ((startIndex + length) > contents.Length)
                throw new IndexOutOfRangeException("startIndex + length cannot be greater than contents.length");

            if (startIndex < 0)
                throw new IndexOutOfRangeException("startIndex cannot be negative");

            if (startAddress + length > Size)
                throw new IndexOutOfRangeException("startAddress + length cannot go beyond the memory size");

            for (int i = 0; i < length; i++) this[startAddress + i] = contents[startIndex + i];
        }


        public void ChangePage(int basicSlot, int extendSlot, int toMemoryPage)
        {
            slot.SetPageFromSlot(toMemoryPage, basicSlot, extendSlot);
        }

        public byte ReadSlotMemoryAdr(int slot, int exSlot, ushort address)
        {
            return this.slot.slots[slot][exSlot][address];
        }
    }
}
