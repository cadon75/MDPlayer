using MDPlayer.Driver.MNDRV;
using NAudio.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPlayer
{
    public class PianoRollMng
    {
        public List<PrNote> lstPrNote = new List<PrNote>();

        private byte[][] YM2612reg;
        private int[][] YM2612KeyOn;
        private int[] YM2612KeyOnCh3;
        private int[][] YM2612KeyOnOld;
        private int[] YM2612KeyOnCh3Old;
        private PrNote[][] YM2612Note;

        public void Clear()
        {
            lstPrNote.Clear();

            YM2612reg = [new byte[0x200], new byte[0x200]];
            YM2612KeyOn = [new int[6], new int[6]];
            YM2612KeyOnCh3 = [0, 0];
            YM2612KeyOnOld = [new int[6], new int[6]];
            YM2612KeyOnCh3Old = [0, 0];
            YM2612Note = [new PrNote[6], new PrNote[6]];
        }

        public void SetRegister(EnmChip chip, int chipID, int dAdr, int dData, long vgmFrameCounter)
        {
            switch (chip)
            {
                case EnmChip.YM2612:
                    YM2612(chipID, dAdr, dData, vgmFrameCounter);
                    break;
            }
        }

        private void YM2612(int chipID, int dAdr, int dData, long vgmFrameCounter)
        {
            YM2612reg[chipID][dAdr] = (byte)dData;

            //keyon/offチェック
            if (dAdr == 0x100 * 0 + 0x28)
            {
                int ch = (dData & 0x3) + ((dData & 0x4) > 0 ? 3 : 0);
                if (ch >= 0 && ch < 6)// && (dData & 0xf0)>0)
                {
                    if (ch != 2 || (YM2612reg[chipID][0x000 * 0 + 0x27] & 0xc0) != 0x40)
                    {
                        if (ch != 5 || (YM2612reg[chipID][0x000 * 0 + 0x2b] & 0x80) == 0)
                        {
                            if ((dData & 0xf0) != 0)
                            {
                                YM2612KeyOn[chipID][ch] = (dData & 0xf0) | 1;
                            }
                            else
                            {
                                YM2612KeyOn[chipID][ch] = (dData & 0xf0) | 0;
                            }
                        }
                    }
                    else
                    {
                        YM2612KeyOn[chipID][2] = (dData & 0xf0);
                        for (int i = 0; i < 4; i++)
                        {
                            int b = 0x10 << i;
                            if ((YM2612KeyOnCh3[chipID] & b) != (dData & b))
                            {
                                YM2612KeyOnCh3[chipID] = (YM2612KeyOnCh3[chipID] & ~b) | (dData & b);
                            }
                        }
                    }
                }
            }

            int defaultMasterClock = 8000000;
            //float ssgMul = 1.0f;
            int masterClock = defaultMasterClock;
            if (Audio.ClockYM2612 != 0)
            {
                //ssgMul = Audio.ClockYM2612 / (float)defaultMasterClock;
                masterClock = Audio.ClockYM2612;
            }

            float fmDiv = 6;
            //float ssgDiv = 4;
            //ssgMul = ssgMul * ssgDiv / 4;

            for (int i = 0; i < 6; i++)
            {
                if (YM2612KeyOnOld[chipID][i] != YM2612KeyOn[chipID][i])
                {
                    YM2612KeyOnOld[chipID][i] = YM2612KeyOn[chipID][i];
                    if ((YM2612KeyOn[chipID][i] & 1) != 0)//keyOn
                    {
                        YM2612Note[chipID][i] = new PrNote
                        {
                            ch = i,
                            startTick = vgmFrameCounter,
                            endTick = -1//長さ未確定
                        };

                        int p = (i > 2) ? 0x100 : 0;
                        int c = (i > 2) ? i - 3 : i;
                        int freq;
                        int octav;
                        freq = YM2612reg[chipID][p+0xa0 + c] + (YM2612reg[chipID][p+0xa4 + c] & 0x07) * 0x100;
                        octav = (YM2612reg[chipID][p+0xa4 + c] & 0x38) >> 3;
                        float ff = freq / ((2 << 20) / (masterClock / (24 * fmDiv))) * (2 << (octav + 2));
                        ff /= 1038f;
                        YM2612Note[chipID][i].key = 95 - Math.Min(Math.Max(Common.searchYM2608Adpcm(ff) - 1, 0), 95);
                        YM2612Note[chipID][i].freq = freq;

                        lstPrNote.Add(YM2612Note[chipID][i]);
                    }
                    else
                    {
                        if (YM2612Note[chipID][i] != null)
                        {
                            YM2612Note[chipID][i].endTick = vgmFrameCounter;
                        }
                    }
                }
            }

        }

    }

    public class PrNote
    {
        public int ch;//channel
        public long startTick;//開始Tick
        public long endTick;//完了Tick
        public int key;//音程
        public int freq;

        public byte[] color = new byte[6];
        public byte[] trgColor = new byte[6];
    }
}
