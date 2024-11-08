using MDPlayer.Driver.MNDRV;
using MDPlayerx64.PianoRoll;
using NAudio.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MDPlayer
{
    public class PianoRollMng
    {
        public List<PrNote> lstPrNote = [];
        private Dictionary<EnmChip, BaseChip> chipList = [];

        public PianoRollMng()
        {
            chipList.Add(EnmChip.AY8910, new AY8910(lstPrNote));
            chipList.Add(EnmChip.YM2151, new YM2151(lstPrNote));
            chipList.Add(EnmChip.YM2608, new YM2608(lstPrNote));
            chipList.Add(EnmChip.YM2610, new YM2610(lstPrNote));
            chipList.Add(EnmChip.YM2612, new YM2612(lstPrNote));
            chipList.Add(EnmChip.SN76489, new SN76489(lstPrNote));
        }

        public void Clear()
        {
            lstPrNote.Clear();
            foreach(var chip in chipList)
                chip.Value.Clear();
        }

        public void SetRegister(EnmChip chip, int chipID, int dAdr, int dData, long vgmFrameCounter)
        {
            if (!chipList.TryGetValue(chip, out BaseChip value)) return;
            value.Analyze(chipID, dAdr, dData, vgmFrameCounter);
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
