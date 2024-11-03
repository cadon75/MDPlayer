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
        private int[][] YM2612Fnum;
        private int[][] YM2612FnumOld;
        private int[][] YM2612FnumCh3;
        private int[][] YM2612FnumCh3Old;
        private bool[] YM2612Ch3ExFlg;
        private bool[] YM2612Ch3ExFlgOld;
        private PrNote[][] YM2612Note;
        private PrNote[][] YM2612NoteCh3;

        public void Clear()
        {
            lstPrNote.Clear();

            YM2612reg = [new byte[0x200], new byte[0x200]];
            YM2612KeyOn = [new int[6], new int[6]];
            YM2612KeyOnCh3 = [0, 0];
            YM2612KeyOnOld = [new int[6], new int[6]];
            YM2612KeyOnCh3Old = [0, 0];
            YM2612Fnum = [new int[6], new int[6]];
            YM2612FnumOld = [new int[6], new int[6]];
            YM2612FnumCh3 = [new int[4], new int[4]];
            YM2612FnumCh3Old = [new int[4], new int[4]];
            YM2612Note = [new PrNote[6], new PrNote[6]];
            YM2612NoteCh3 = [new PrNote[4], new PrNote[4]];
            YM2612Ch3ExFlg = [false, false];
            YM2612Ch3ExFlgOld = [false, false];
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
                                YM2612KeyOn[chipID][ch] = (dData & 0xf0) | 1;
                            else
                                YM2612KeyOn[chipID][ch] = (dData & 0xf0) | 0;
                        }
                    }
                    else
                    {
                        YM2612KeyOn[chipID][2] = (dData & 0xf0);
                        for (int i = 0; i < 4; i++)
                        {
                            int b = 0x10 << i;
                            if ((YM2612KeyOnCh3[chipID] & b) != (dData & b))
                                YM2612KeyOnCh3[chipID] = (YM2612KeyOnCh3[chipID] & ~b) | (dData & b);
                        }
                    }
                }
            }

            //fnumチェック
            if ((dAdr >= 0xa0 && dAdr <= 0xa6)||(dAdr >= 0x1a0 && dAdr <= 0x1a6))
            {
                for (int i = 0; i < 6; i++)
                {
                    int p = (i > 2) ? 0x100 : 0;
                    int c = (i > 2) ? i - 3 : i;
                    int freq = YM2612reg[chipID][p + 0xa0 + c] + (YM2612reg[chipID][p + 0xa4 + c] & 0x3f) * 0x100;
                    YM2612Fnum[chipID][i] = freq;
                }
                for (int i = 0; i < 4; i++)
                {
                    int c = (i == 0) ? (-6) : (i - 1);
                    int freq = YM2612reg[chipID][0xa8 + c] + (YM2612reg[chipID][0xac + c] & 0x3f) * 0x100;
                    YM2612FnumCh3[chipID][i] = freq;
                }
            }

            //Ch3ExFlgチェック
            if (dAdr == 0x27)
            {
                YM2612Ch3ExFlg[chipID] = (dData & 0xc0) != 0;
            }

            int masterClock = 8000000;// defaultMasterClock
            if (Audio.ClockYM2612 != 0)
                masterClock = Audio.ClockYM2612;
            float fmDiv = 6;

            for (int i = 0; i < 6; i++)
            {
                if (i != 2 || (YM2612reg[chipID][0x000 * 0 + 0x27] & 0xc0) != 0x40)
                {
                    if (!(
                        YM2612KeyOnOld[chipID][i] != YM2612KeyOn[chipID][i]
                        || (
                            (YM2612KeyOn[chipID][i] & 0xf) != 0 && YM2612FnumOld[chipID][i] != YM2612Fnum[chipID][i]
                           )
                       ))
                        continue;

                    YM2612KeyOnOld[chipID][i] = YM2612KeyOn[chipID][i];
                    YM2612FnumOld[chipID][i] = YM2612Fnum[chipID][i];

                    if ((YM2612KeyOn[chipID][i] & 0xf) == 0)
                    {
                        //keyOff
                        if (YM2612Note[chipID][i] != null)
                            YM2612Note[chipID][i].endTick = vgmFrameCounter;
                        continue;
                    }

                    //keyOn
                    if (YM2612Note[chipID][i] != null && YM2612Note[chipID][i].endTick == -1)
                        YM2612Note[chipID][i].endTick = vgmFrameCounter;

                    int p = (i > 2) ? 0x100 : 0;
                    int c = (i > 2) ? i - 3 : i;
                    int freq = YM2612reg[chipID][p + 0xa0 + c] + (YM2612reg[chipID][p + 0xa4 + c] & 0x07) * 0x100;
                    int octav = (YM2612reg[chipID][p + 0xa4 + c] & 0x38) >> 3;
                    float ff = freq / ((2 << 20) / (masterClock / (24 * fmDiv))) * (2 << (octav + 2));
                    ff /= 1038f;

                    YM2612Note[chipID][i] = YM2612MakeNote(i, vgmFrameCounter, ff, freq);
                    lstPrNote.Add(YM2612Note[chipID][i]);
                    continue;
                }

                //Ch3Ex
                for (int j = 0; j < 4; j++)
                {
                    int b = 0x10 << j;
                    if (
                        !(
                            (YM2612KeyOnCh3Old[chipID] & b) != (YM2612KeyOnCh3[chipID] & b)
                            || (
                                (YM2612KeyOnCh3[chipID] & b) != 0
                                && YM2612FnumCh3Old[chipID][j] != YM2612FnumCh3[chipID][j])
                        )) continue;

                    YM2612KeyOnCh3Old[chipID] = (YM2612KeyOnCh3Old[chipID] & ~b) | (YM2612KeyOnCh3[chipID] & b);
                    YM2612FnumCh3Old[chipID][j] = YM2612FnumCh3[chipID][j];
                    if ((YM2612KeyOn[chipID][j] & b) == 0)
                    {
                        //keyOff
                        if (YM2612NoteCh3[chipID][j] != null)
                            YM2612NoteCh3[chipID][j].endTick = vgmFrameCounter;
                        continue;
                    }

                    //keyOn
                    if (YM2612NoteCh3[chipID][j] != null && YM2612NoteCh3[chipID][j].endTick == -1)
                        YM2612NoteCh3[chipID][j].endTick = vgmFrameCounter;

                    int c = (j == 0) ? (-6) : (j - 1);
                    int freq = YM2612reg[chipID][0xa8 + c] + (YM2612reg[chipID][0xac + c] & 0x07) * 0x100;
                    int octav = (YM2612reg[chipID][0xac + c] & 0x38) >> 3;
                    float ff = freq / ((2 << 20) / (masterClock / (24 * fmDiv))) * (2 << (octav + 2));
                    ff /= 1038f;

                    YM2612NoteCh3[chipID][j] = YM2612MakeNote(j, vgmFrameCounter, ff, freq);
                    lstPrNote.Add(YM2612NoteCh3[chipID][j]);
                }
            }

            if (YM2612Ch3ExFlgOld[chipID] != YM2612Ch3ExFlg[chipID])
            {
                YM2612Ch3ExFlgOld[chipID] = YM2612Ch3ExFlg[chipID];
                for (int i = 0; i < 4; i++)
                {
                    if (YM2612NoteCh3[chipID][i] == null || YM2612NoteCh3[chipID][i].endTick != -1) continue;
                    YM2612NoteCh3[chipID][i].endTick = vgmFrameCounter;
                }
                if (YM2612Note[chipID][2] != null && YM2612Note[chipID][2].endTick == -1)
                    YM2612Note[chipID][2].endTick = vgmFrameCounter;

            }
        }

        private PrNote YM2612MakeNote(int ch,long startTick,float ff,int freq)
        {
            PrNote ret = new PrNote
            {
                ch = ch,
                startTick = startTick,
                endTick = -1,//長さ未確定
                key = 95 - Math.Min(Math.Max(Common.searchYM2608Adpcm(ff) - 1, 0), 95),
                freq = freq
            };
            ret.noteColor1[0] = 0xd0;
            ret.noteColor1[1] = 0x00;
            ret.noteColor1[2] = 0x50;
            ret.noteColor1[3] = 0xf0;
            ret.noteColor1[4] = 0x00;
            ret.noteColor1[5] = 0x70;
            ret.noteColor2[0] = 0x90;
            ret.noteColor2[1] = 0x00;
            ret.noteColor2[2] = 0x90;
            ret.noteColor2[3] = 0xd0;
            ret.noteColor2[4] = 0x00;
            ret.noteColor2[5] = 0xb0;

            return ret;
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

        public byte[] noteColor1 = new byte[6];
        public byte[] noteColor2 = new byte[6];
    }
}
