﻿namespace MDPlayer
{
    public class Vgm : baseDriver
    {

        public Vgm(Setting setting)
        {
            this.setting = setting;
            dacControl = new dacControl(setting);
        }

        public const int FCC_VGM = 0x206D6756;	// "Vgm "
        public const int FCC_GD3 = 0x20336447;  // "Gd3 "

        public const uint defaultSN76489ClockValue = 3579545;
        public const uint defaultYM2612ClockValue = 7670454;
        public const uint defaultRF5C164ClockValue = 12500000;
        public const uint defaultPWMClockValue = 23011361;
        public const uint defaultC140ClockValue = 21390;
        public const MDSound.c140.C140_TYPE defaultC140Type = MDSound.c140.C140_TYPE.ASIC219;
        public const uint defaultOKIM6258ClockValue = 4000000;
        public const uint defaultOKIM6295ClockValue = 4000000;
        public const uint defaultSEGAPCMClockValue = 4000000;
        public const uint defaultAY8910ClockValue = 1789750;


        public uint SN76489ClockValue = 3579545;
        public uint YM2612ClockValue = 7670454;
        public uint RF5C68ClockValue = 12500000;
        public uint RF5C164ClockValue = 12500000;
        public uint PWMClockValue = 23011361;
        public uint C140ClockValue = 21390;
        public MDSound.c140.C140_TYPE C140Type = MDSound.c140.C140_TYPE.ASIC219;
        public uint OKIM6258ClockValue = 4000000;
        public byte OKIM6258Type = 0;
        public uint OKIM6295ClockValue = 4000000;
        public uint SEGAPCMClockValue = 4000000;
        public int SEGAPCMInterface = 0;
        public uint YM2151ClockValue;
        public uint YM2608ClockValue;
        public uint YM2203ClockValue;
        public uint YM2610ClockValue;
        public uint YM3812ClockValue;
        public uint YM3526ClockValue;
        public uint Y8950ClockValue;
        public uint YMF262ClockValue;
        public uint YMF271ClockValue;
        public uint YMF278BClockValue;
        public uint YMZ280BClockValue;
        public uint AY8910ClockValue;
        public uint YM2413ClockValue;
        public uint HuC6280ClockValue;
        public uint QSoundClockValue;
        public uint SAA1099ClockValue;
        public uint WSwanClockValue;
        public uint ES5503ClockValue;
        public uint X1_010ClockValue;
        public uint C352ClockValue;
        public byte C352ClockDivider;
        public uint GA20ClockValue;
        public uint K053260ClockValue;
        public uint K054539ClockValue;
        public byte K054539Flags;
        public uint K051649ClockValue;
        public uint DMGClockValue;
        public uint NESClockValue;
        public uint MultiPCMClockValue;
        public uint uPD7759ClockValue;
        public uint POKEYClockValue;

        public bool YM2612DualChipFlag;
        public bool YM2151DualChipFlag;
        public bool YM2203DualChipFlag;
        public bool YM2608DualChipFlag;
        public bool YM2610DualChipFlag;
        public bool YM3812DualChipFlag;
        public bool YM3526DualChipFlag;
        public bool Y8950DualChipFlag;
        public bool YMF262DualChipFlag;
        public bool YMF271DualChipFlag;
        public bool YMF278BDualChipFlag;
        public bool YMZ280BDualChipFlag;
        public bool OKIM6295DualChipFlag;
        public bool SN76489DualChipFlag;
        public bool SN76489NGPFlag;
        public object[] SN76489Option;
        public bool RF5C68DualChipFlag;
        public bool RF5C164DualChipFlag;
        public bool AY8910DualChipFlag;
        public bool YM2413DualChipFlag;
        public bool YM2413VRC7Flag;
        public bool HuC6280DualChipFlag;
        public bool C140DualChipFlag;
        public bool SAA1099DualChipFlag;
        public bool ES5503DualChipFlag;
        public bool WSwanDualChipFlag;
        public bool X1_010DualChipFlag;
        public bool C352DualChipFlag;
        public bool GA20DualChipFlag;
        public bool K053260DualChipFlag;
        public bool K054539DualChipFlag;
        public bool K051649DualChipFlag;
        public bool DMGDualChipFlag;
        public bool NESDualChipFlag;
        public bool MultiPCMDualChipFlag;
        public bool uPD7759DualChipFlag;
        public bool POKEYDualChipFlag;

        public dacControl dacControl = null;
        public bool isPcmRAMWrite = false;
        public bool useChipYM2612Ch6 = false;
        public int ES5503Ch = 2;
        //public Setting setting = null;


        private Action[] vgmCmdTbl = new Action[0x100];

        private List<string> chips = null;

        private uint vgmAdr;
        private int vgmWait;
        private long vgmLoopOffset = 0;
        private uint vgmEof;
        private bool vgmAnalyze;

        private long vgmDataOffset = 0;

        private const int PCM_BANK_COUNT = 0x40;
        private VGM_PCM_BANK[] PCMBank = new VGM_PCM_BANK[PCM_BANK_COUNT];
        private PCMBANK_TBL PCMTbl = new();
        private byte DacCtrlUsed;
        private byte[] DacCtrlUsg = new byte[0xFF];
        private DACCTRL_DATA[] DacCtrl = new DACCTRL_DATA[0xFF];

        private byte[][] ym2610AdpcmA = new byte[2][] { null, null };
        private byte[][] ym2610AdpcmB = new byte[2][] { null, null };

        public override bool init(byte[] vgmBuf, ChipRegister chipRegister, EnmModel model, EnmChip[] useChip, uint latency, uint waitTime)
        {
            this.vgmBuf = vgmBuf;
            this.chipRegister = chipRegister;
            this.model = model;
            this.useChip = useChip;
            this.latency = latency;
            this.waitTime = waitTime;
            this.opnaRamType = 0;

            dumpCounter = 0;

            ym2610AdpcmA = new byte[2][] { null, null };
            ym2610AdpcmB = new byte[2][] { null, null };

            if (!getInformationHeader()) return false;

            vgmAdr = (uint)vgmDataOffset;
            vgmWait = 0;
            vgmAnalyze = true;
            Counter = 0;
            vgmFrameCounter = -latency - waitTime;
            vgmCurLoop = 0;
            vgmSpeed = 1;
            vgmSpeedCounter = 0;

            for (int i = 0; i < PCM_BANK_COUNT; i++) PCMBank[i] = new VGM_PCM_BANK();
            dacControl.refresh();
            DacCtrlUsed = 0x00;
            for (byte CurChip = 0x00; CurChip < 0xFF; CurChip++)
            {
                DacCtrl[CurChip] = new DACCTRL_DATA();
                DacCtrl[CurChip].Enable = false;
            }

            SetCommands();

            Stopped = false;
            isDataBlock = false;
            isPcmRAMWrite = false;
            useChipYM2612Ch6 = false;
            foreach (EnmChip uc in useChip)
            {
                if (uc == EnmChip.YM2612Ch6)
                {
                    useChipYM2612Ch6 = true;
                    break;
                }
            }
            return true;
        }

        public override bool init(byte[] vgmBuf, int fileType, ChipRegister chipRegister, EnmModel model, EnmChip[] useChip, uint latency, uint waitTime)
        {
            throw new NotImplementedException("このdriverはこのメソッドを必要としない");
        }

        public override void oneFrameProc()
        {
            try
            {
                vgmSpeedCounter += (double)Common.VGMProcSampleRate / setting.outputDevice.SampleRate * vgmSpeed;
                while (vgmSpeedCounter >= 1.0)
                {
                    vgmSpeedCounter -= 1.0;
                    if (vgmFrameCounter > -1)
                    {
                        OneFrameVGMMain();
                    }
                    else
                    {
                        vgmFrameCounter++;
                    }
                }
            }
            catch (Exception ex)
            {
                log.ForcedWrite(ex);

            }
        }

        private void OneFrameVGMMain()
        {
            if (vgmWait > 0)
            {
                //if (model == enmModel.VirtualModel)
                OneFrameVGMStream();
                vgmWait--;
                Counter++;
                vgmFrameCounter++;
                return;
            }

            OneFrameVGMStream();

            if (!vgmAnalyze)
            {
                //if (model == enmModel.VirtualModel)
                //    oneFrameVGMStream();
                Stopped = true;
                return;
            }

            int countNum = 0;
            while (vgmWait <= 0)
            {
                if (vgmAdr >= vgmBuf.Length || (vgmEof != 0 && vgmAdr >= vgmEof))
                {
                    if (LoopCounter != 0)
                    {
                        vgmAdr = (uint)(vgmLoopOffset + 0x1c);
                        vgmCurLoop++;
                        Counter = 0;
                    }
                    else
                    {
                        vgmAnalyze = false;
                        return;
                    }
                }

                byte cmd = vgmBuf[vgmAdr];
                //Console.WriteLine("[{0}]: Adr:{1:X} Dat:{2:X}",model, vgmAdr , vgmBuf[vgmAdr]);
                if (vgmCmdTbl[cmd] != null)
                {
                    //if (model == EnmModel.VirtualModel) Console.WriteLine("{0:X05} : {1:X02} ", vgmAdr, vgmBuf[vgmAdr]);
                    vgmCmdTbl[cmd]();
                }
                else
                {
                    //わからんコマンド
                    Console.WriteLine("[{0}]:unknown command: Adr:{1:X} Dat:{2:X}", model, vgmAdr, vgmBuf[vgmAdr]);
                    vgmAdr++;
                }
                countNum++;
                if (countNum > 100)
                {
                    if (model == EnmModel.RealModel && countNum % 100 == 0)
                    {
                        isDataBlock = true;
                        chipRegister.sendDataYM2608(0, model);
                        chipRegister.setYM2608SyncWait(0, 1);
                        chipRegister.sendDataYM2151(0, model);
                        chipRegister.setYM2151SyncWait(0, 1);

                        chipRegister.sendDataYM2608(1, model);
                        chipRegister.setYM2608SyncWait(1, 1);
                        chipRegister.sendDataYM2151(1, model);
                        chipRegister.setYM2151SyncWait(1, 1);
                    }
                }
            }

            if (model == EnmModel.RealModel && isDataBlock)
            {
                isDataBlock = false;
                //Console.WriteLine("{0} countnum:{1}", model, countNum);
                countNum = 0;
            }

            //Send wait
            if (model == EnmModel.RealModel)
            {
                if (vgmSpeed == 1) //等速の場合のみウェイトをかける
                {
                    if (useChipYM2612Ch6)
                        chipRegister.setYM2612SyncWait(0, vgmWait);
                    //if ((useChip & enmUseChip.SN76489) == enmUseChip.SN76489)
                    //    chipRegister.setSN76489SyncWait(vgmWait);
                    //chipRegister.setYM2608SyncWait(vgmWait);
                    //chipRegister.setYM2151SyncWait(vgmWait);
                }
            }

            //if (model == enmModel.VirtualModel)
            //oneFrameVGMStream();

            vgmWait--;
            Counter++;
            vgmFrameCounter++;

        }

        private void OneFrameVGMStream()
        {
            for (int CurChip = 0x00; CurChip < DacCtrlUsed; CurChip++)
            {
                dacControl.update(DacCtrlUsg[CurChip], 1);
            }
        }

        private void SetCommands()
        {

            for (int i = 0; i < vgmCmdTbl.Length; i++) vgmCmdTbl[i] = null;

            vgmCmdTbl[0x30] = VcPSG;
            vgmCmdTbl[0x31] = VcDummy1Ope;
            vgmCmdTbl[0x32] = VcDummy1Ope;
            vgmCmdTbl[0x33] = VcDummy1Ope;
            vgmCmdTbl[0x34] = VcDummy1Ope;
            vgmCmdTbl[0x35] = VcDummy1Ope;
            vgmCmdTbl[0x36] = VcDummy1Ope;
            vgmCmdTbl[0x37] = VcDummy1Ope;

            vgmCmdTbl[0x38] = VcDummy1Ope;
            vgmCmdTbl[0x39] = VcDummy1Ope;
            vgmCmdTbl[0x3a] = VcDummy1Ope;
            vgmCmdTbl[0x3b] = VcDummy1Ope;
            vgmCmdTbl[0x3c] = VcDummy1Ope;
            vgmCmdTbl[0x3d] = VcDummy1Ope;
            vgmCmdTbl[0x3e] = VcDummy1Ope;
            vgmCmdTbl[0x3f] = VcGGPSGPort06;

            vgmCmdTbl[0x40] = VcDummy2Ope;
            vgmCmdTbl[0x41] = VcDummy2Ope;
            vgmCmdTbl[0x42] = VcDummy2Ope;
            vgmCmdTbl[0x43] = VcDummy2Ope;
            vgmCmdTbl[0x44] = VcDummy2Ope;
            vgmCmdTbl[0x45] = VcDummy2Ope;
            vgmCmdTbl[0x46] = VcDummy2Ope;
            vgmCmdTbl[0x47] = VcDummy2Ope;

            vgmCmdTbl[0x48] = VcDummy2Ope;
            vgmCmdTbl[0x49] = VcDummy2Ope;
            vgmCmdTbl[0x4a] = VcDummy2Ope;
            vgmCmdTbl[0x4b] = VcDummy2Ope;
            vgmCmdTbl[0x4c] = VcDummy2Ope;
            vgmCmdTbl[0x4d] = VcDummy2Ope;
            vgmCmdTbl[0x4e] = VcDummy2Ope;

            vgmCmdTbl[0x4f] = VcGGPSGPort06;
            vgmCmdTbl[0x50] = VcPSG;

            vgmCmdTbl[0x51] = VcYM2413;
            vgmCmdTbl[0x52] = VcYM2612Port0;
            vgmCmdTbl[0x53] = VcYM2612Port1;

            vgmCmdTbl[0x54] = VcYM2151;
            vgmCmdTbl[0x55] = VcYM2203;
            vgmCmdTbl[0x56] = VcYM2608Port0;
            vgmCmdTbl[0x57] = VcYM2608Port1;

            vgmCmdTbl[0x58] = VcYM2610Port0;
            vgmCmdTbl[0x59] = VcYM2610Port1;
            vgmCmdTbl[0x5a] = VcYM3812;
            vgmCmdTbl[0x5b] = VcYM3526;
            vgmCmdTbl[0x5c] = VcY8950;
            vgmCmdTbl[0x5d] = VcYMZ280B;
            vgmCmdTbl[0x5e] = VcYMF262Port0;
            vgmCmdTbl[0x5f] = VcYMF262Port1;

            vgmCmdTbl[0x61] = VcWaitNSamples;
            vgmCmdTbl[0x62] = VcWait735Samples;
            vgmCmdTbl[0x63] = VcWait882Samples;
            vgmCmdTbl[0x64] = VcOverrideLength;

            vgmCmdTbl[0x66] = VcEndOfSoundData;
            vgmCmdTbl[0x67] = VcDataBlock;
            vgmCmdTbl[0x68] = VcPCMRamWrite;

            vgmCmdTbl[0x70] = VcWaitN1Samples;
            vgmCmdTbl[0x71] = VcWaitN1Samples;
            vgmCmdTbl[0x72] = VcWaitN1Samples;
            vgmCmdTbl[0x73] = VcWaitN1Samples;
            vgmCmdTbl[0x74] = VcWaitN1Samples;
            vgmCmdTbl[0x75] = VcWaitN1Samples;
            vgmCmdTbl[0x76] = VcWaitN1Samples;
            vgmCmdTbl[0x77] = VcWaitN1Samples;

            vgmCmdTbl[0x78] = VcWaitN1Samples;
            vgmCmdTbl[0x79] = VcWaitN1Samples;
            vgmCmdTbl[0x7a] = VcWaitN1Samples;
            vgmCmdTbl[0x7b] = VcWaitN1Samples;
            vgmCmdTbl[0x7c] = VcWaitN1Samples;
            vgmCmdTbl[0x7d] = VcWaitN1Samples;
            vgmCmdTbl[0x7e] = VcWaitN1Samples;
            vgmCmdTbl[0x7f] = VcWaitN1Samples;

            vgmCmdTbl[0x80] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x81] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x82] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x83] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x84] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x85] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x86] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x87] = VcWaitNSamplesAndSendYM26120x2a;

            vgmCmdTbl[0x88] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x89] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8a] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8b] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8c] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8d] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8e] = VcWaitNSamplesAndSendYM26120x2a;
            vgmCmdTbl[0x8f] = VcWaitNSamplesAndSendYM26120x2a;

            vgmCmdTbl[0x90] = VcSetupStreamControl;
            vgmCmdTbl[0x91] = VcSetStreamData;
            vgmCmdTbl[0x92] = VcSetStreamFrequency;
            vgmCmdTbl[0x93] = VcStartStream;
            vgmCmdTbl[0x94] = VcStopStream;
            vgmCmdTbl[0x95] = VcStartStreamFastCall;

            vgmCmdTbl[0xa0] = VcAY8910;
            vgmCmdTbl[0xa1] = VcYM2413;
            vgmCmdTbl[0xa2] = VcYM2612Port0;
            vgmCmdTbl[0xa3] = VcYM2612Port1;
            vgmCmdTbl[0xa4] = VcYM2151;
            vgmCmdTbl[0xa5] = VcYM2203;
            vgmCmdTbl[0xa6] = VcYM2608Port0;
            vgmCmdTbl[0xa7] = VcYM2608Port1;

            vgmCmdTbl[0xa8] = VcYM2610Port0;
            vgmCmdTbl[0xa9] = VcYM2610Port1;
            vgmCmdTbl[0xaa] = VcYM3812;
            vgmCmdTbl[0xab] = VcYM3526;
            vgmCmdTbl[0xac] = VcY8950;
            vgmCmdTbl[0xad] = VcYMZ280B;
            vgmCmdTbl[0xae] = VcYMF262Port0;
            vgmCmdTbl[0xaf] = VcYMF262Port1;

            vgmCmdTbl[0xb0] = VcRf5c68;
            vgmCmdTbl[0xb1] = VcRf5c164;
            vgmCmdTbl[0xb2] = VcPWM;
            vgmCmdTbl[0xb3] = VcDMG;
            vgmCmdTbl[0xb4] = VcNES;
            vgmCmdTbl[0xb5] = VcMultiPCM;
            vgmCmdTbl[0xb6] = VcuPD7759;
            vgmCmdTbl[0xb7] = VcOKIM6258;

            vgmCmdTbl[0xb8] = VcOKIM6295;
            vgmCmdTbl[0xb9] = VcHuC6280;
            vgmCmdTbl[0xba] = VcK053260;
            vgmCmdTbl[0xbb] = VcPOKEY;
            vgmCmdTbl[0xbc] = VcWSwan;
            vgmCmdTbl[0xbd] = VcSAA1099;
            vgmCmdTbl[0xbe] = VcDummy2Ope;
            vgmCmdTbl[0xbf] = VcGA20;

            vgmCmdTbl[0xc0] = VcSEGAPCM;
            vgmCmdTbl[0xc1] = VcRf5c68MemoryWrite;
            vgmCmdTbl[0xc2] = VcRf5c164MemoryWrite;
            vgmCmdTbl[0xc3] = VcMultiPCMSetBank;
            vgmCmdTbl[0xc4] = VcQSound;
            vgmCmdTbl[0xc5] = VcDummy3Ope;
            vgmCmdTbl[0xc6] = VcWSwanMem;
            vgmCmdTbl[0xc7] = VcDummy3Ope;

            vgmCmdTbl[0xc8] = VcX1_010;
            vgmCmdTbl[0xc9] = VcDummy3Ope;
            vgmCmdTbl[0xca] = VcDummy3Ope;
            vgmCmdTbl[0xcb] = VcDummy3Ope;
            vgmCmdTbl[0xcc] = VcDummy3Ope;
            vgmCmdTbl[0xcd] = VcDummy3Ope;
            vgmCmdTbl[0xce] = VcDummy3Ope;
            vgmCmdTbl[0xcf] = VcDummy3Ope;

            vgmCmdTbl[0xd0] = VcYMF278B;
            vgmCmdTbl[0xd1] = VcYMF271;
            vgmCmdTbl[0xd2] = VcK051649;
            vgmCmdTbl[0xd3] = VcK054539;
            vgmCmdTbl[0xd4] = VcC140;
            vgmCmdTbl[0xd5] = VcES5503;
            vgmCmdTbl[0xd6] = VcDummy3Ope;
            vgmCmdTbl[0xd7] = VcDummy3Ope;

            vgmCmdTbl[0xd8] = VcDummy3Ope;
            vgmCmdTbl[0xd9] = VcDummy3Ope;
            vgmCmdTbl[0xda] = VcDummy3Ope;
            vgmCmdTbl[0xdb] = VcDummy3Ope;
            vgmCmdTbl[0xdc] = VcDummy3Ope;
            vgmCmdTbl[0xdd] = VcDummy3Ope;
            vgmCmdTbl[0xde] = VcDummy3Ope;
            vgmCmdTbl[0xdf] = VcDummy3Ope;

            vgmCmdTbl[0xe0] = VcSeekToOffsetInPCMDataBank;
            vgmCmdTbl[0xe1] = VcC352;
            vgmCmdTbl[0xe2] = VcDummy4Ope;
            vgmCmdTbl[0xe3] = VcDummy4Ope;
            vgmCmdTbl[0xe4] = VcDummy4Ope;
            vgmCmdTbl[0xe5] = VcDummy4Ope;
            vgmCmdTbl[0xe6] = VcDummy4Ope;
            vgmCmdTbl[0xe7] = VcDummy4Ope;

            vgmCmdTbl[0xe8] = VcDummy4Ope;
            vgmCmdTbl[0xe9] = VcDummy4Ope;
            vgmCmdTbl[0xea] = VcDummy4Ope;
            vgmCmdTbl[0xeb] = VcDummy4Ope;
            vgmCmdTbl[0xec] = VcDummy4Ope;
            vgmCmdTbl[0xed] = VcDummy4Ope;
            vgmCmdTbl[0xee] = VcDummy4Ope;
            vgmCmdTbl[0xef] = VcDummy4Ope;

            vgmCmdTbl[0xf0] = VcDummy4Ope;
            vgmCmdTbl[0xf1] = VcDummy4Ope;
            vgmCmdTbl[0xf2] = VcDummy4Ope;
            vgmCmdTbl[0xf3] = VcDummy4Ope;
            vgmCmdTbl[0xf4] = VcDummy4Ope;
            vgmCmdTbl[0xf5] = VcDummy4Ope;
            vgmCmdTbl[0xf6] = VcDummy4Ope;
            vgmCmdTbl[0xf7] = VcDummy4Ope;

            vgmCmdTbl[0xf8] = VcDummy4Ope;
            vgmCmdTbl[0xf9] = VcDummy4Ope;
            vgmCmdTbl[0xfa] = VcDummy4Ope;
            vgmCmdTbl[0xfb] = VcDummy4Ope;
            vgmCmdTbl[0xfc] = VcDummy4Ope;
            vgmCmdTbl[0xfd] = VcDummy4Ope;
            vgmCmdTbl[0xfe] = VcDummy4Ope;
            vgmCmdTbl[0xff] = VcDummy4Ope;

        }

        private void VcDummy1Ope()
        {
            //Console.Write("({0:X02}:{1:X02})", vgmBuf[vgmAdr], vgmBuf[vgmAdr + 1]);
            vgmAdr += 2;
        }

        private void VcDummy2Ope()
        {
            //Console.Write("({0:X02}:{1:X02}:{2:X02})", vgmBuf[vgmAdr], vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2]);
            vgmAdr += 3;
        }

        private void VcDummy3Ope()
        {
            //Console.Write("({0:X02}:{1:X02}:{2:X02}:{3:X02})", vgmBuf[vgmAdr], vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], vgmBuf[vgmAdr + 3]);
            vgmAdr += 4;
        }

        private void VcDummy4Ope()
        {
            //Console.WriteLine("unknown command:Adr:{0:X}({1:X02}:{2:X02}:{3:X02}:{4:X02}:{5:X02})",vgmAdr, vgmBuf[vgmAdr], vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], vgmBuf[vgmAdr + 3], vgmBuf[vgmAdr + 4]);
            vgmAdr += 5;
        }

        private void VcGGPSGPort06()
        {
            chipRegister.setSN76489RegisterGGpanning(vgmBuf[vgmAdr] == 0x4f ? 0 : 1, vgmBuf[vgmAdr + 1], model, vgmFrameCounter);
            vgmAdr += 2;
        }

        private void VcPSG()
        {
            chipRegister.setSN76489Register(vgmBuf[vgmAdr] == 0x50 ? 0 : 1, vgmBuf[vgmAdr + 1], model, vgmFrameCounter);
            vgmAdr += 2;
        }

        private void VcAY8910()
        {
            chipRegister.setAY8910Register((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1] & 0x7f, vgmBuf[vgmAdr + 2], model, vgmFrameCounter);
            //chipRegister.setAY8910Register(0, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcDMG()
        {
            chipRegister.setDMGRegister((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1] & 0x7f, vgmBuf[vgmAdr + 2], model);
            //chipRegister.setAY8910Register(0, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcNES()
        {
            chipRegister.setNESRegister((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1] & 0x7f, vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcMultiPCM()
        {
            chipRegister.setMultiPCMRegister((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1] & 0x7f, vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcuPD7759()
        {
            //if(model== EnmModel.VirtualModel) Console.WriteLine("adr:{0} data:{1:x02}",vgmBuf[vgmAdr + 1] & 0x7f, vgmBuf[vgmAdr + 2]);
            chipRegister.setuPD7759Register((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1] & 0x7f, vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcMultiPCMSetBank()
        {
            chipRegister.setMultiPCMSetBank((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1] & 0x7f, vgmBuf[vgmAdr + 2] + vgmBuf[vgmAdr + 3] * 0x100, model);
            vgmAdr += 4;
        }

        private void VcQSound()
        {
            chipRegister.setQSoundRegister(0, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], vgmBuf[vgmAdr + 3], model);
            vgmAdr += 4;
        }

        private void VcX1_010()
        {
            chipRegister.setX1_010Register((byte)((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1), (byte)(vgmBuf[vgmAdr + 1] & 0x7f), vgmBuf[vgmAdr + 2], vgmBuf[vgmAdr + 3], model);
            vgmAdr += 4;
        }

        private void VcYM2413()
        {
            chipRegister.setYM2413Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcYM3812()
        {
            chipRegister.setYM3812Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcHuC6280()
        {
            chipRegister.setHuC6280Register((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1] & 0x7f, vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcGA20()
        {
            chipRegister.setGA20Register((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1] & 0x7f, vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcYM2612Port0()
        {
            chipRegister.setYM2612Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, 0, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model, vgmFrameCounter);
            vgmAdr += 3;
        }

        private void VcYM2612Port1()
        {
            chipRegister.setYM2612Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, 1, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model, vgmFrameCounter);
            vgmAdr += 3;
        }

        private void VcYM2203()
        {
            chipRegister.setYM2203Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcYM2608Port0()
        {
            chipRegister.setYM2608Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, 0, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model, vgmFrameCounter);
            vgmAdr += 3;
        }

        private void VcYM2608Port1()
        {
            int adr = vgmBuf[vgmAdr + 1];
            int dat = vgmBuf[vgmAdr + 2];
            //if (adr >= 0x00 && adr <= 0x10 && model== enmModel.RealModel)
            //{
            //    Console.WriteLine("{0:X2}:{1:X2}", adr, dat);
            //}
            //if (adr == 0x01)
            //{
            //    //dat &= 0xfd;
            //    //dat |= 1;
            //}
            //if (adr == 0x00 && (dat & 0x20) != 0)
            //{
            //    //dat &= 0xdf;
            //}
            chipRegister.setYM2608Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, 1, adr, dat, model, vgmFrameCounter);
            vgmAdr += 3;
        }

        private void VcYM2610Port0()
        {
            chipRegister.setYM2610Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, 0, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model, vgmFrameCounter);
            vgmAdr += 3;
        }

        private void VcYM2610Port1()
        {
            int adr = vgmBuf[vgmAdr + 1];
            int dat = vgmBuf[vgmAdr + 2];
            chipRegister.setYM2610Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, 1, adr, dat, model, vgmFrameCounter);
            vgmAdr += 3;
        }

        private void VcYMF262Port0()
        {
            chipRegister.setYMF262Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, 0, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcYMF262Port1()
        {
            int adr = vgmBuf[vgmAdr + 1];
            int dat = vgmBuf[vgmAdr + 2];
            chipRegister.setYMF262Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, 1, adr, dat, model);
            vgmAdr += 3;
        }

        private void VcYM3526()
        {
            chipRegister.setYM3526Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcY8950()
        {
            chipRegister.setY8950Register((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcYMZ280B()
        {
            chipRegister.setYMZ280BRegister((vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1, vgmBuf[vgmAdr + 1], vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcYMF271()
        {
            chipRegister.setYMF271Register(
                (vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1
                , vgmBuf[vgmAdr + 1] & 0x7f
                , vgmBuf[vgmAdr + 2]
                , vgmBuf[vgmAdr + 3]
                , model);
            vgmAdr += 4;
        }

        private void VcYMF278B()
        {
            chipRegister.setYMF278BRegister(
                (vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1
                , vgmBuf[vgmAdr + 1] & 0x7f
                , vgmBuf[vgmAdr + 2]
                , vgmBuf[vgmAdr + 3]
                , model);
            //Console.WriteLine("fm:{0:x02}:{1:x02}:{2:x02}:", vgmBuf[vgmAdr + 1] & 0x7f
            //, vgmBuf[vgmAdr + 2]
            //, vgmBuf[vgmAdr + 3]
            //);
            vgmAdr += 4;
        }

        private void VcYM2151()
        {
            chipRegister.setYM2151Register(
                (vgmBuf[vgmAdr] & 0x80) == 0 ? 0 : 1,
                0,
                vgmBuf[vgmAdr + 1],
                vgmBuf[vgmAdr + 2],
                model,
                (vgmBuf[vgmAdr] & 0x80) == 0 ? YM2151Hosei[0] : YM2151Hosei[1],
                vgmFrameCounter);
            vgmAdr += 3;
        }

        private void VcOKIM6258()
        {
            chipRegister.writeOKIM6258(0, (byte)(vgmBuf[vgmAdr + 0x01] & 0x7F), vgmBuf[vgmAdr + 0x02], model);
            vgmAdr += 3;
        }

        private void VcOKIM6295()
        {
            chipRegister.writeOKIM6295((byte)((vgmBuf[vgmAdr + 0x01] & 0x80) == 0 ? 0 : 1), (byte)(vgmBuf[vgmAdr + 0x01] & 0x7F), vgmBuf[vgmAdr + 0x02], model);
            vgmAdr += 3;
        }

        private void VcSAA1099()
        {
            chipRegister.writeSAA1099((byte)((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1), (byte)(vgmBuf[vgmAdr + 1] & 0x7f), vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcWSwan()
        {
            chipRegister.writeWSwan((byte)((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1), (byte)(vgmBuf[vgmAdr + 1] & 0x7f), vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcWSwanMem()
        {
            chipRegister.writeWSwanMem(0,
                (int)((vgmBuf[vgmAdr + 0x02] & 0xFF) | ((vgmBuf[vgmAdr + 0x01] & 0xFF) << 8)),
                vgmBuf[vgmAdr + 0x03], model);
            vgmAdr += 4;
        }

        private void VcPOKEY()
        {
            chipRegister.writePOKEY((byte)((vgmBuf[vgmAdr + 1] & 0x80) == 0 ? 0 : 1), (byte)(vgmBuf[vgmAdr + 1] & 0x7f), vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcSEGAPCM()
        {
            //Console.WriteLine("{0:X4} {1:X4}", vgmBuf[vgmAdr + 0x01], vgmBuf[vgmAdr + 0x02]);
            chipRegister.writeSEGAPCM(0, (int)((vgmBuf[vgmAdr + 0x01] & 0xFF) | ((vgmBuf[vgmAdr + 0x02] & 0xFF) << 8)), vgmBuf[vgmAdr + 0x03], model);
            vgmAdr += 4;
        }

        private void VcWaitNSamples()
        {
            vgmWait += (int)GetLE16(vgmAdr + 1);
            vgmAdr += 3;
        }

        private void VcWait735Samples()
        {
            vgmWait += 735;
            vgmAdr++;
        }

        private void VcWait882Samples()
        {
            vgmWait += 882;
            vgmAdr++;
        }

        private void VcOverrideLength()
        {
            vgmAdr += 4;
        }

        private void VcEndOfSoundData()
        {
            vgmAdr = (uint)vgmBuf.Length;
        }

        private void VcDataBlock()
        {

            isDataBlock = true;

            uint bAdr = vgmAdr + 7;
            byte bType = vgmBuf[vgmAdr + 2];
            uint bLen = GetLE32(vgmAdr + 3);
            byte chipID = 0;
            if ((bLen & 0x80000000) != 0)
            {
                bLen &= 0x7fffffff;
                chipID = 1;
            }

            switch (bType & 0xe0)
            {
                case 0x00:
                case 0x40:
                    AddPCMData(bType, bLen, bAdr);
                    vgmAdr += (uint)bLen + 7;
                    break;
                case 0x80:
                    uint romSize = GetLE32(vgmAdr + 7);
                    uint startAddress = GetLE32(vgmAdr + 0x0B);
                    switch (bType)
                    {
                        case 0x80:
                            //SEGA PCM
                            chipRegister.writeSEGAPCMPCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpDataForSegaPCM(model, "SEGAPCM_PCMData", vgmAdr + 15, bLen - 8);
                            break;
                        case 0x81:

                            // YM2608

                            chipRegister.setYM2608Register(chipID, 0x1, 0x00, 0x20, model, vgmFrameCounter);
                            chipRegister.setYM2608Register(chipID, 0x1, 0x00, 0x21, model, vgmFrameCounter);
                            chipRegister.setYM2608Register(chipID, 0x1, 0x00, 0x00, model, vgmFrameCounter);

                            chipRegister.setYM2608Register(chipID, 0x1, 0x10, 0x00, model, vgmFrameCounter);
                            chipRegister.setYM2608Register(chipID, 0x1, 0x10, 0x80, model, vgmFrameCounter);

                            chipRegister.setYM2608Register(chipID, 0x1, 0x00, 0x61, model, vgmFrameCounter);
                            chipRegister.setYM2608Register(chipID, 0x1, 0x00, 0x68, model, vgmFrameCounter);
                            chipRegister.setYM2608Register(chipID, 0x1, 0x01, opnaRamType, model, vgmFrameCounter);

                            if (opnaRamType != 2)
                            {
                                chipRegister.setYM2608Register(chipID, 0x1, 0x02, (int)((startAddress >> 2) & 0xff), model, vgmFrameCounter);
                                chipRegister.setYM2608Register(chipID, 0x1, 0x03, (int)((startAddress >> 10) & 0xff), model, vgmFrameCounter);
                            }
                            else
                            {
                                chipRegister.setYM2608Register(chipID, 0x1, 0x02, (int)((startAddress >> 5) & 0xff), model, vgmFrameCounter);
                                chipRegister.setYM2608Register(chipID, 0x1, 0x03, (int)((startAddress >> 13) & 0xff), model, vgmFrameCounter);
                            }
                            chipRegister.setYM2608Register(chipID, 0x1, 0x04, 0xff, model, vgmFrameCounter);
                            chipRegister.setYM2608Register(chipID, 0x1, 0x05, 0xff, model, vgmFrameCounter);
                            chipRegister.setYM2608Register(chipID, 0x1, 0x0c, 0xff, model, vgmFrameCounter);
                            chipRegister.setYM2608Register(chipID, 0x1, 0x0d, 0xff, model, vgmFrameCounter);

                            // データ転送
                            for (int cnt = 0; cnt < bLen - 8; cnt++)
                            {
                                chipRegister.setYM2608Register(chipID, 0x1, 0x08, vgmBuf[vgmAdr + 15 + cnt], model, vgmFrameCounter);
                            }
                            chipRegister.setYM2608Register(chipID, 0x1, 0x00, 0x00, model, vgmFrameCounter);
                            chipRegister.setYM2608Register(chipID, 0x1, 0x10, 0x80, model, vgmFrameCounter);

                            //chipRegister.setYM2608Register(0x1, 0x10, 0x13, model);
                            //chipRegister.setYM2608Register(0x1, 0x10, 0x80, model);
                            //chipRegister.setYM2608Register(0x1, 0x00, 0x60, model);
                            //chipRegister.setYM2608Register(0x1, 0x01, 0x00, model);

                            //chipRegister.setYM2608Register(0x1, 0x02, (int)((startAddress >> 2) & 0xff), model);
                            //chipRegister.setYM2608Register(0x1, 0x03, (int)((startAddress >> 10) & 0xff), model);
                            //chipRegister.setYM2608Register(0x1, 0x04, (int)(((startAddress + bLen - 8) >> 2) & 0xff), model);
                            //chipRegister.setYM2608Register(0x1, 0x05, (int)(((startAddress + bLen - 8) >> 10) & 0xff), model);
                            //chipRegister.setYM2608Register(0x1, 0x0c, 0xff, model);
                            //chipRegister.setYM2608Register(0x1, 0x0d, 0xff, model);

                            //for (int cnt = 0; cnt < bLen - 8; cnt++)
                            //{
                            //    chipRegister.setYM2608Register(0x1, 0x08, vgmBuf[vgmAdr + 15 + cnt], model);
                            //    chipRegister.setYM2608Register(0x1, 0x10, 0x1b, model);
                            //    chipRegister.setYM2608Register(0x1, 0x10, 0x13, model);
                            //}

                            //chipRegister.setYM2608Register(0x1, 0x00, 0x00, model);
                            //chipRegister.setYM2608Register(0x1, 0x10, 0x80, model);

                            while ((chipRegister.getYM2608Register(chipID, 0x1, 0x00, model) & 0xbf) != 0)
                            {
                                System.Threading.Thread.Sleep(0);
                            }
                            if (model == EnmModel.RealModel)
                            {
                                if ((chipID == 0 && setting.YM2608Type[0].UseReal[0])
                                    || (chipID == 1 && setting.YM2608Type[1].UseReal[0]))
                                {
                                    System.Threading.Thread.Sleep(500);
                                }
                            }

                            chipRegister.sendDataYM2608(chipID, model);
                            dumpData(model, "YM2608_ADPCM", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x82:
                            if (ym2610AdpcmA[chipID] == null || ym2610AdpcmA[chipID].Length != romSize) ym2610AdpcmA[chipID] = new byte[romSize];
                            if (ym2610AdpcmA[chipID].Length > 0)
                            {
                                for (int cnt = 0; cnt < bLen - 8; cnt++)
                                {
                                    ym2610AdpcmA[chipID][startAddress + cnt] = vgmBuf[vgmAdr + 15 + cnt];
                                }
                                if (model == EnmModel.VirtualModel) chipRegister.WriteYM2610_SetAdpcmA(chipID, ym2610AdpcmA[chipID], model);
                                else chipRegister.WriteYM2610_SetAdpcmA(chipID, model, (int)startAddress, (int)(bLen - 8), vgmBuf, (int)(vgmAdr + 15));
                                dumpData(model, "YM2610_ADPCMA", vgmAdr + 15, bLen - 8);
                            }
                            break;
                        case 0x83:
                            if (ym2610AdpcmB[chipID] == null || ym2610AdpcmB[chipID].Length != romSize) ym2610AdpcmB[chipID] = new byte[romSize];
                            if (ym2610AdpcmB[chipID].Length > 0)
                            {
                                for (int cnt = 0; cnt < bLen - 8; cnt++)
                                {
                                    ym2610AdpcmB[chipID][startAddress + cnt] = vgmBuf[vgmAdr + 15 + cnt];
                                }
                                if (model == EnmModel.VirtualModel) chipRegister.WriteYM2610_SetAdpcmB(chipID, ym2610AdpcmB[chipID], model);
                                else chipRegister.WriteYM2610_SetAdpcmB(chipID, model, (int)startAddress, (int)(bLen - 8), vgmBuf, (int)(vgmAdr + 15));
                                dumpData(model, "YM2610_ADPCMB", vgmAdr + 15, bLen - 8);
                            }
                            break;

                        case 0x84:
                            // YMF278B
                            chipRegister.writeYMF278BPCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "YMF278B_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x85:
                            // YMF271
                            chipRegister.writeYMF271PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "YMF271_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x86:
                            // YMZ280B
                            chipRegister.writeYMZ280BPCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "YMZ280B_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x87:
                            // YMF278B
                            chipRegister.writeYMF278BPCMRAMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "YMF278B_PCMRAMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x88:
                            // Y8950
                            chipRegister.writeY8950PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "Y8950_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x89:
                            // MultiPCM
                            chipRegister.writeMultiPCMPCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "MultiPCM_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8a:
                            // uPD7759
                            chipRegister.writeuPD7759PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "uPD7759_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8b:
                            // OKIM6295
                            chipRegister.writeOKIM6295PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "OKIM6295_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8c:
                            // K054539
                            chipRegister.writeK054539PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "K054539_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8d:

                            // C140

                            chipRegister.writeC140PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "C140_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8e:
                            // K053260
                            chipRegister.writeK053260PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "K053260_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x8f:
                            // QSound
                            chipRegister.writeQSoundPCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "QSound_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x91:
                            // X1-010
                            chipRegister.writeX1_010PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "X1-010_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x92:
                            // C352
                            chipRegister.writeC352PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "C352_PCMData", vgmAdr + 15, bLen - 8);
                            break;

                        case 0x93:
                            // GA20
                            chipRegister.writeGA20PCMData(chipID, romSize, startAddress, bLen - 8, vgmBuf, vgmAdr + 15, model);
                            dumpData(model, "GA20_PCMData", vgmAdr + 15, bLen - 8);
                            break;
                    }
                    vgmAdr += (uint)bLen + 7;
                    break;
                case 0xc0:
                    uint stAdr = GetLE16(vgmAdr + 7);
                    uint dataSize = bLen - 2;
                    uint ROMData = vgmAdr + 9;
                    if ((bType & 0x20) != 0)
                    {
                        stAdr = GetLE32(vgmAdr + 7);
                        dataSize = bLen - 4;
                        ROMData = vgmAdr + 11;
                    }

                    try
                    {
                        switch (bType)
                        {
                            case 0xc0:
                                chipRegister.writeRF5C68PCMData(chipID, stAdr, dataSize, vgmBuf, vgmAdr + 9, model);
                                dumpData(model, "RF5C68_PCMData(8BitMonoSigned)", vgmAdr + 9, dataSize);
                                break;
                            case 0xc1:
                                chipRegister.writeRF5C164PCMData(chipID, stAdr, dataSize, vgmBuf, vgmAdr + 9, model);
                                dumpData(model, "RF5C164_PCMData(8BitMonoSigned)", vgmAdr + 9, dataSize);
                                break;
                            case 0xc2:
                                chipRegister.writeNESPCMData(chipID, stAdr, dataSize, vgmBuf, vgmAdr + 9, model);
                                dumpData(model, "NES_PCMData", vgmAdr + 9, dataSize);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        log.ForcedWrite(e);
                    }

                    vgmAdr += bLen + 7;
                    break;
                case 0xe0:
                    uint stAdr_E = GetLE32(vgmAdr + 7);
                    uint dataSize_E = bLen - 2;
                    uint ROMData_E = vgmAdr + 9;
                    if ((bType & 0x20) != 0)
                    {
                        stAdr_E = GetLE32(vgmAdr + 7);
                        dataSize_E = bLen - 4;
                        ROMData_E = vgmAdr + 11;
                    }

                    try
                    {
                        switch (bType)
                        {
                            case 0xe1:
                                chipRegister.writeES5503PCMData(chipID, stAdr_E, dataSize_E, vgmBuf, vgmAdr + 11, model);
                                dumpData(model, "ES5503_PCMData", vgmAdr + 9, dataSize_E);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        log.ForcedWrite(e);
                    }

                    vgmAdr += bLen + 7;
                    break;
                default:
                    vgmAdr += bLen + 7;
                    break;
            }

            isDataBlock = false;

        }

        private int dumpCounter = 0;
        private int opnaRamType = 0;

        private void dumpData(EnmModel model, string chipName, uint adr, uint len)
        {
            if (model == EnmModel.RealModel) return;
            if (setting == null) return;
            if (!setting.other.DumpSwitch) return;

            try
            {

                string fn = System.IO.Path.Combine(setting.other.DumpPath, string.Format("{1}_{2}_{0:000}.bin", dumpCounter++, chipName, GD3.TrackName.Replace("*", "").Replace("?", "").Replace(" ", "").Replace("\"", "").Replace("/", "")));
                using System.IO.FileStream fs = new(fn, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                using System.IO.BinaryWriter bw = new(fs);
                bw.Write(vgmBuf, (int)adr, (int)len);
            }
            catch
            {
                //エラーは無視
            }

        }

        private void dumpDataForSegaPCM(EnmModel model, string chipName, uint adr, uint len)
        {
            if (model == EnmModel.RealModel) return;
            if (setting == null) return;
            if (!setting.other.DumpSwitch) return;

            try
            {
                string dFn = System.IO.Path.Combine(setting.other.DumpPath, string.Format("{1}_{2}_{0:000}.wav", dumpCounter++, chipName, GD3.TrackName.Replace("*", "").Replace("?", "").Replace(" ", "").Replace("\"", "")));
                List<byte> des = new();

                // 'RIFF'
                des.Add((byte)'R'); des.Add((byte)'I'); des.Add((byte)'F'); des.Add((byte)'F');
                // サイズ
                //int fsize = src.Length + 36;
                int fsize = (int)len + 36;
                des.Add((byte)((fsize & 0xff) >> 0));
                des.Add((byte)((fsize & 0xff00) >> 8));
                des.Add((byte)((fsize & 0xff0000) >> 16));
                des.Add((byte)((fsize & 0xff000000) >> 24));
                // 'WAVE'
                des.Add((byte)'W'); des.Add((byte)'A'); des.Add((byte)'V'); des.Add((byte)'E');
                // 'fmt '
                des.Add((byte)'f'); des.Add((byte)'m'); des.Add((byte)'t'); des.Add((byte)' ');
                // サイズ(16)
                des.Add(0x10); des.Add(0); des.Add(0); des.Add(0);
                // フォーマット(1)
                des.Add(0x01); des.Add(0x00);
                // チャンネル数(mono)
                des.Add(0x01); des.Add(0x00);
                //サンプリング周波数(16KHz)
                des.Add(0x80); des.Add(0x3e); des.Add(0); des.Add(0);
                //平均データ割合(16K)
                des.Add(0x80); des.Add(0x3e); des.Add(0); des.Add(0);
                //ブロックサイズ(1)
                des.Add(0x01); des.Add(0x00);
                //ビット数(8bit)
                des.Add(0x08); des.Add(0x00);

                // 'data'
                des.Add((byte)'d'); des.Add((byte)'a'); des.Add((byte)'t'); des.Add((byte)'a');
                // サイズ(データサイズ)
                des.Add((byte)((len & 0xff) >> 0));
                des.Add((byte)((len & 0xff00) >> 8));
                des.Add((byte)((len & 0xff0000) >> 16));
                des.Add((byte)((len & 0xff000000) >> 24));

                for (int i = 0; i < len; i++)
                {
                    des.Add(vgmBuf[adr + i]);
                }

                //出力
                System.IO.File.WriteAllBytes(dFn, des.ToArray());

            }
            catch
            {
            }
        }



        private void VcPCMRamWrite()
        {

            isPcmRAMWrite = true;

            byte bType = (byte)(vgmBuf[vgmAdr + 2] & 0x7f);
            //CurrentChip = (vgmBuf[vgmAdr + 2] & 0x80)>>7;
            uint bReadOffset = GetLE24(vgmAdr + 3);
            uint bWriteOffset = GetLE24(vgmAdr + 6);
            uint bSize = GetLE24(vgmAdr + 9);
            if (bSize == 0) bSize = 0x1000000;
            uint? pcmAdr = GetPCMAddressFromPCMBank(bType, bReadOffset);
            if (pcmAdr != null)
            {
                if (bType == 0x01)
                {
                    chipRegister.writeRF5C68PCMData(0, bWriteOffset, bSize, PCMBank[bType].Data, (uint)pcmAdr, model);
                }
                if (bType == 0x02)
                {
                    chipRegister.writeRF5C164PCMData(0, bWriteOffset, bSize, PCMBank[bType].Data, (uint)pcmAdr, model);
                }
            }

            vgmAdr += 12;

            isPcmRAMWrite = false;

        }

        private void VcWaitN1Samples()
        {
            vgmWait += (int)(vgmBuf[vgmAdr] - 0x6f);
            vgmAdr++;
        }

        private void VcWaitNSamplesAndSendYM26120x2a()
        {
            byte dat = GetDACFromPCMBank();

            vgmWait += (int)(vgmBuf[vgmAdr] - 0x80);

            chipRegister.setYM2612Register(0, 0, 0x2a, dat, model, vgmFrameCounter);

            vgmAdr++;
        }

        private void VcSetupStreamControl()
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 5;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1];
            if (si == 0xff)
            {
                vgmAdr += 5;
                return;
            }
            if (!DacCtrl[si].Enable)
            {
                dacControl.device_start_daccontrol(si);
                dacControl.device_reset_daccontrol(si);
                DacCtrl[si].Enable = true;
                DacCtrlUsg[DacCtrlUsed] = si;
                DacCtrlUsed++;
            }
            byte chipId = vgmBuf[vgmAdr + 2];
            byte port = vgmBuf[vgmAdr + 3];
            byte cmd = vgmBuf[vgmAdr + 4];

            dacControl.setup_chip(si, (byte)(chipId & 0x7F), (byte)((chipId & 0x80) >> 7), (uint)(port * 0x100 + cmd));
            vgmAdr += 5;
        }

        private void VcSetStreamData()
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 5;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1];
            if (si == 0xff)
            {
                vgmAdr += 5;
                return;
            }
            DacCtrl[si].Bank = vgmBuf[vgmAdr + 2];
            if (DacCtrl[si].Bank >= PCM_BANK_COUNT)
                DacCtrl[si].Bank = 0x00;

            VGM_PCM_BANK TempPCM = PCMBank[DacCtrl[si].Bank];
            //Last95Max = TempPCM->BankCount;
            dacControl.set_data(si, TempPCM.Data, TempPCM.DataSize,
                            vgmBuf[vgmAdr + 3], vgmBuf[vgmAdr + 4]);

            vgmAdr += 5;
        }

        private void VcSetStreamFrequency()
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 6;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1];
            if (si == 0xFF || !DacCtrl[si].Enable)
            {
                vgmAdr += 0x06;
                return;
            }
            uint TempLng = GetLE32(vgmAdr + 2);
            //Last95Freq = TempLng;
            dacControl.set_frequency(si, TempLng);
            vgmAdr += 6;
        }

        private void VcStartStream()
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 8;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1];
            if (si == 0xFF || !DacCtrl[si].Enable || PCMBank[DacCtrl[si].Bank].BankCount == 0)
            {
                vgmAdr += 0x08;
                return;
            }
            uint DataStart = GetLE32(vgmAdr + 2);
            //Last95Drum = 0xFFFF;
            byte TempByt = vgmBuf[vgmAdr + 6];
            uint DataLen = GetLE32(vgmAdr + 7);
            dacControl.start(si, DataStart, TempByt, DataLen);
            vgmAdr += 0x0B;

        }

        private void VcStopStream()
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 2;
            //    return;
            //}

            byte si = vgmBuf[vgmAdr + 1];
            if (!DacCtrl[si].Enable)
            {
                vgmAdr += 0x02;
                return;
            }
            //Last95Drum = 0xFFFF;
            if (si < 0xFF)
            {
                dacControl.stop(si);
            }
            else
            {
                for (si = 0x00; si < 0xFF; si++)
                    dacControl.stop(si);
            }
            vgmAdr += 0x02;
        }

        private void VcStartStreamFastCall()
        {
            //if (model != enmModel.VirtualModel)
            //{
            //    vgmAdr += 5;
            //    return;
            //}

            byte CurChip = vgmBuf[vgmAdr + 1];
            if (CurChip == 0xFF || !DacCtrl[CurChip].Enable ||
                PCMBank[DacCtrl[CurChip].Bank].BankCount == 0)
            {
                vgmAdr += 0x05;
                return;
            }
            VGM_PCM_BANK TempPCM = PCMBank[DacCtrl[CurChip].Bank];
            uint TempSht = GetLE16(vgmAdr + 2);
            //Last95Drum = TempSht;
            //Last95Max = TempPCM->BankCount;
            if (TempSht >= TempPCM.BankCount)
                TempSht = 0x00;
            VGM_PCM_DATA TempBnk = TempPCM.Bank[(int)TempSht];

            byte TempByt = (byte)(dacControl.DCTRL_LMODE_BYTES |
                        (vgmBuf[vgmAdr + 4] & 0x10) |         // Reverse Mode
                        ((vgmBuf[vgmAdr + 4] & 0x01) << 7));   // Looping
            dacControl.start(CurChip, TempBnk.DataStart, TempByt, TempBnk.DataSize);
            vgmAdr += 0x05;

        }

        private void VcSeekToOffsetInPCMDataBank()
        {
            PCMBank[0x00].DataPos = GetLE32(vgmAdr + 1);
            vgmAdr += 5;
        }

        private void VcRf5c68()
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1] & 0x80) != 0 ? 1 : 0);
            byte cmd = (byte)(vgmBuf[vgmAdr + 1] & 0x7f);
            chipRegister.writeRF5C68(id, cmd, vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcRf5c68MemoryWrite()
        {
            uint offset = GetLE16(vgmAdr + 1);
            chipRegister.writeRF5C68MemW(0, offset, vgmBuf[vgmAdr + 3], model);
            vgmAdr += 4;
        }

        private void VcRf5c164()
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1] & 0x80) != 0 ? 1 : 0);
            byte cmd = (byte)(vgmBuf[vgmAdr + 1] & 0x7f);
            chipRegister.writeRF5C164(id, cmd, vgmBuf[vgmAdr + 2], model);
            vgmAdr += 3;
        }

        private void VcRf5c164MemoryWrite()
        {
            uint offset = GetLE16(vgmAdr + 1);
            chipRegister.writeRF5C164MemW(0, offset, vgmBuf[vgmAdr + 3], model);
            vgmAdr += 4;
        }

        private void VcPWM()
        {
            byte cmd = (byte)((vgmBuf[vgmAdr + 1] & 0xf0) >> 4);
            uint data = (uint)((vgmBuf[vgmAdr + 1] & 0xf) * 0x100 + vgmBuf[vgmAdr + 2]);
            chipRegister.writePWM(0, cmd, data, model);
            vgmAdr += 3;
        }

        private void VcK051649()
        {
            int scc1_port = vgmBuf[vgmAdr + 1] & 0x7f;
            byte scc1_offset = vgmBuf[vgmAdr + 2];
            byte rDat = vgmBuf[vgmAdr + 3];
            byte scc1_chipid = (byte)((vgmBuf[vgmAdr + 1] & 0x80) != 0 ? 1 : 0);
            vgmAdr += 4;
            chipRegister.writeK051649(scc1_chipid, (uint)((scc1_port << 1) | 0x00), scc1_offset, model);
            chipRegister.writeK051649(scc1_chipid, (uint)((scc1_port << 1) | 0x01), rDat, model);

        }

        private void VcK053260()
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1] & 0x80) != 0 ? 1 : 0);
            uint adr = (uint)(vgmBuf[vgmAdr + 1] & 0x7f);
            byte data = vgmBuf[vgmAdr + 2];
            chipRegister.writeK053260(id, adr, data, model);
            vgmAdr += 3;
        }

        private void VcK054539()
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1] & 0x80) != 0 ? 1 : 0);
            uint adr = (uint)((vgmBuf[vgmAdr + 1] & 0x7f) * 0x100 + (vgmBuf[vgmAdr + 2] & 0xff));
            byte data = vgmBuf[vgmAdr + 3];
            chipRegister.writeK054539(id, adr, data, model);
            vgmAdr += 4;
        }

        private void VcC140()
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1] & 0x80) != 0 ? 1 : 0);
            uint adr = (uint)((vgmBuf[vgmAdr + 1] & 0x7f) * 0x100 + (vgmBuf[vgmAdr + 2] & 0xff));
            byte data = vgmBuf[vgmAdr + 3];
            chipRegister.writeC140(id, adr, data, model);
            vgmAdr += 4;
        }

        private void VcES5503()//0xD5 pp aa dd
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1] & 0x80) != 0 ? 1 : 0);
            uint adr = (uint)((vgmBuf[vgmAdr + 1] & 0x7f) * 0x100 + (vgmBuf[vgmAdr + 2] & 0xff));
            byte data = vgmBuf[vgmAdr + 3];
            chipRegister.writeES5503(id, adr, data, model);
            vgmAdr += 4;
        }

        private void VcC352()
        {
            byte id = (byte)((vgmBuf[vgmAdr + 1] & 0x80) != 0 ? 1 : 0);
            uint adr = (uint)((vgmBuf[vgmAdr + 1] & 0x7f) * 0x100 + (vgmBuf[vgmAdr + 2] & 0xff));
            uint data = (uint)((vgmBuf[vgmAdr + 3] & 0xff) * 0x100 + (vgmBuf[vgmAdr + 4] & 0xff));

            chipRegister.writeC352(id, adr, data, model);
            vgmAdr += 5;
        }

        private UInt32 GetLE16(UInt32 adr)
        {
            UInt32 dat;
            dat = (UInt32)vgmBuf[adr] + (UInt32)vgmBuf[adr + 1] * 0x100;

            return dat;
        }

        private uint GetLE24(UInt32 adr)
        {
            UInt32 dat;
            dat = (UInt32)vgmBuf[adr] + (UInt32)vgmBuf[adr + 1] * 0x100 + (UInt32)vgmBuf[adr + 2] * 0x10000;

            return dat;
        }

        private UInt32 GetLE32(UInt32 adr)
        {
            UInt32 dat;
            dat = (UInt32)vgmBuf[adr] + (UInt32)vgmBuf[adr + 1] * 0x100 + (UInt32)vgmBuf[adr + 2] * 0x10000 + (UInt32)vgmBuf[adr + 3] * 0x1000000;

            return dat;
        }


        private void AddPCMData(byte Type, uint DataSize, uint Adr)
        {
            uint CurBnk;
            VGM_PCM_BANK TempPCM;
            VGM_PCM_DATA TempBnk;
            uint BankSize;
            //bool RetVal;
            byte BnkType;
            byte CurDAC;

            BnkType = (byte)(Type & 0x3F);
            if (BnkType >= PCM_BANK_COUNT || vgmCurLoop > 0)
                return;

            if (Type == 0x7F)
            {
                //ReadPCMTable(DataSize, Data);
                ReadPCMTable(DataSize, Adr);
                return;
            }

            TempPCM = PCMBank[BnkType];// &PCMBank[BnkType];
            TempPCM.BnkPos++;
            if (TempPCM.BnkPos <= TempPCM.BankCount)
                return; // Speed hack for restarting playback (skip already loaded blocks)
            CurBnk = TempPCM.BankCount;
            TempPCM.BankCount++;
            //if (Last95Max != 0xFFFF) Last95Max = TempPCM.BankCount;
            TempPCM.Bank.Add(new VGM_PCM_DATA());// = (VGM_PCM_DATA*)realloc(TempPCM->Bank,
                                                 // sizeof(VGM_PCM_DATA) * TempPCM->BankCount);

            if ((Type & 0x40) == 0)
                BankSize = DataSize;
            else
                BankSize = GetLE32(Adr + 1);// ReadLE32(&Data[0x01]);

            byte[] newData = new byte[TempPCM.DataSize + BankSize];
            if (TempPCM.Data != null && TempPCM.Data.Length > 0)
                Array.Copy(TempPCM.Data, newData, TempPCM.Data.Length);
            TempPCM.Data = newData;

            //TempPCM.Data = new byte[TempPCM.DataSize + BankSize];// realloc(TempPCM->Data, TempPCM->DataSize + BankSize);
            TempBnk = TempPCM.Bank[(int)CurBnk];
            TempBnk.DataStart = TempPCM.DataSize;
            TempBnk.Data = new byte[BankSize];
            if ((Type & 0x40) == 0)
            {
                TempBnk.DataSize = DataSize;
                for (int i = 0; i < DataSize; i++)
                {
                    TempPCM.Data[i + TempBnk.DataStart] = vgmBuf[Adr + i];
                    TempBnk.Data[i] = vgmBuf[Adr + i];
                }
                //TempBnk.Data = TempPCM.Data + TempBnk.DataStart;
                //memcpy(TempBnk->Data, Data, DataSize);
            }
            else
            {
                //TempBnk.Data = TempPCM.Data + TempBnk.DataStart;
                bool RetVal = DecompressDataBlk(TempBnk, DataSize, Adr);
                if (RetVal == false)
                {
                    TempBnk.Data = null;
                    TempBnk.DataSize = 0x00;
                    //return;
                    goto RefreshDACStrm;    // sorry for the goto, but I don't want to copy-paste the code
                }
                for (int i = 0; i < BankSize; i++)// DataSize; i++)
                {
                    TempPCM.Data[i + TempBnk.DataStart] = TempBnk.Data[i];
                }
            }
            //if (BankSize != TempBnk.DataSize) Console.Write("Error reading Data Block! Data Size conflict!\n");
            TempPCM.DataSize += BankSize;

        // realloc may've moved the Bank block, so refresh all DAC Streams
        RefreshDACStrm:
            for (CurDAC = 0x00; CurDAC < DacCtrlUsed; CurDAC++)
            {
                if (DacCtrl[DacCtrlUsg[CurDAC]].Bank == BnkType)
                    dacControl.refresh_data(DacCtrlUsg[CurDAC], TempPCM.Data, TempPCM.DataSize);
            }

            return;
        }

        private bool DecompressDataBlk(VGM_PCM_DATA Bank, uint DataSize, uint Adr)
        {
            byte ComprType;
            byte BitDec;
            byte BitCmp;
            byte CmpSubType;
            uint AddVal;
            uint InPos;
            uint InDataEnd;
            uint OutPos;
            uint OutDataEnd;
            uint InVal;
            uint OutVal = 0;// FUINT16 OutVal;
            byte ValSize;
            byte InShift;
            byte OutShift;
            uint Ent1B = 0;// UINT8* Ent1B;
            uint Ent2B = 0;// UINT16* Ent2B;
            //#if defined(_DEBUG) && defined(WIN32)
            //	UINT32 Time;
            //#endif

            // ReadBits Variables
            byte BitsToRead;
            byte BitReadVal;
            byte InValB;
            byte BitMask;
            byte OutBit;

            // Variables for DPCM
            uint OutMask;

            //#if defined(_DEBUG) && defined(WIN32)
            //	Time = GetTickCount();
            //#endif
            ComprType = vgmBuf[Adr + 0];
            Bank.DataSize = GetLE32(Adr + 1);

            switch (ComprType)
            {
                case 0x00:  // n-Bit compression
                    BitDec = vgmBuf[Adr + 5];
                    BitCmp = vgmBuf[Adr + 6];
                    CmpSubType = vgmBuf[Adr + 7];
                    AddVal = GetLE16(Adr + 8);

                    if (CmpSubType == 0x02)
                    {
                        //Bank.DataSize = 0x00;
                        //return false;

                        Ent1B = 0;// (UINT8*)PCMTbl.Entries; // Big Endian note: Those are stored in LE and converted when reading.
                        Ent2B = 0;// (UINT16*)PCMTbl.Entries;
                        if (PCMTbl.EntryCount == 0)
                        {
                            Bank.DataSize = 0x00;
                            //printf("Error loading table-compressed data block! No table loaded!\n");
                            return false;
                        }
                        else if (BitDec != PCMTbl.BitDec || BitCmp != PCMTbl.BitCmp)
                        {
                            Bank.DataSize = 0x00;
                            //printf("Warning! Data block and loaded value table incompatible!\n");
                            return false;
                        }
                    }

                    ValSize = (byte)((BitDec + 7) / 8);
                    InPos = Adr + 0x0A;
                    InDataEnd = Adr + DataSize;
                    InShift = 0;
                    OutShift = (byte)(BitDec - BitCmp);
                    //                    OutDataEnd = Bank.Data + Bank.DataSize;
                    OutDataEnd = Bank.DataSize;

                    //for (OutPos = Bank->Data; OutPos < OutDataEnd && InPos < InDataEnd; OutPos += ValSize)
                    for (OutPos = 0; OutPos < OutDataEnd && InPos < InDataEnd; OutPos += ValSize)
                    {
                        //InVal = ReadBits(Data, InPos, &InShift, BitCmp);
                        // inlined - is 30% faster
                        OutBit = 0x00;
                        InVal = 0x0000;
                        BitsToRead = BitCmp;
                        while (BitsToRead != 0)
                        {
                            BitReadVal = (byte)((BitsToRead >= 8) ? 8 : BitsToRead);
                            BitsToRead -= BitReadVal;
                            BitMask = (byte)((1 << BitReadVal) - 1);

                            InShift += BitReadVal;
                            //InValB = (byte)((vgmBuf[InPos] << InShift >> 8) & BitMask);
                            InValB = (byte)((vgmBuf[InPos] << InShift >> 8) & BitMask);
                            if (InShift >= 8)
                            {
                                InShift -= 8;
                                InPos++;
                                if (InShift != 0)
                                    InValB |= (byte)((vgmBuf[InPos] << InShift >> 8) & BitMask);
                            }

                            InVal |= (uint)(InValB << OutBit);
                            OutBit += BitReadVal;
                        }

                        switch (CmpSubType)
                        {
                            case 0x00:  // Copy
                                OutVal = InVal + AddVal;
                                break;
                            case 0x01:  // Shift Left
                                OutVal = (InVal << OutShift) + AddVal;
                                break;
                            case 0x02:  // Table
                                switch (ValSize)
                                {
                                    case 0x01:
                                        OutVal = PCMTbl.Entries[Ent1B + InVal];
                                        break;
                                    case 0x02:
                                        //#ifndef BIG_ENDIAN
                                        //					OutVal = Ent2B[InVal];
                                        //#else
                                        OutVal = (uint)(PCMTbl.Entries[Ent2B + InVal * 2] + PCMTbl.Entries[Ent2B + InVal * 2 + 1] * 0x100);// ReadLE16((UINT8*)&Ent2B[InVal]);
                                                                                                                                           //#endif
                                        break;
                                }
                                break;
                        }

                        //#ifndef BIG_ENDIAN
                        //			//memcpy(OutPos, &OutVal, ValSize);
                        //			if (ValSize == 0x01)
                        //               *((UINT8*)OutPos) = (UINT8)OutVal;
                        //			else //if (ValSize == 0x02)
                        //                *((UINT16*)OutPos) = (UINT16)OutVal;
                        //#else
                        if (ValSize == 0x01)
                        {
                            Bank.Data[OutPos] = (byte)OutVal;
                        }
                        else //if (ValSize == 0x02)
                        {
                            Bank.Data[OutPos + 0x00] = (byte)((OutVal & 0x00FF) >> 0);
                            Bank.Data[OutPos + 0x01] = (byte)((OutVal & 0xFF00) >> 8);
                        }
                        //#endif
                    }
                    break;
                case 0x01:  // Delta-PCM
                    BitDec = vgmBuf[Adr + 5];// Data[0x05];
                    BitCmp = vgmBuf[Adr + 6];// Data[0x06];
                    OutVal = GetLE16(Adr + 8);// ReadLE16(&Data[0x08]);

                    Ent1B = 0;// (UINT8*)PCMTbl.Entries;
                    Ent2B = 0;// (UINT16*)PCMTbl.Entries;
                    if (PCMTbl.EntryCount == 0)
                    {
                        Bank.DataSize = 0x00;
                        //printf("Error loading table-compressed data block! No table loaded!\n");
                        return false;
                    }
                    else if (BitDec != PCMTbl.BitDec || BitCmp != PCMTbl.BitCmp)
                    {
                        Bank.DataSize = 0x00;
                        //printf("Warning! Data block and loaded value table incompatible!\n");
                        return false;
                    }

                    ValSize = (byte)((BitDec + 7) / 8);
                    OutMask = (uint)((1 << BitDec) - 1);
                    InPos = Adr + 0xa;
                    InDataEnd = Adr + DataSize;
                    InShift = 0;
                    OutShift = (byte)(BitDec - BitCmp);
                    OutDataEnd = Bank.DataSize;// Bank.Data + Bank.DataSize;
                    AddVal = 0x0000;

                    //                    for (OutPos = Bank.Data; OutPos < OutDataEnd && InPos < InDataEnd; OutPos += ValSize)
                    for (OutPos = 0; OutPos < OutDataEnd && InPos < InDataEnd; OutPos += ValSize)
                    {
                        //InVal = ReadBits(Data, InPos, &InShift, BitCmp);
                        // inlined - is 30% faster
                        OutBit = 0x00;
                        InVal = 0x0000;
                        BitsToRead = BitCmp;
                        while (BitsToRead != 0)
                        {
                            BitReadVal = (byte)((BitsToRead >= 8) ? 8 : BitsToRead);
                            BitsToRead -= BitReadVal;
                            BitMask = (byte)((1 << BitReadVal) - 1);

                            InShift += BitReadVal;
                            InValB = (byte)((vgmBuf[InPos] << InShift >> 8) & BitMask);
                            if (InShift >= 8)
                            {
                                InShift -= 8;
                                InPos++;
                                if (InShift != 0)
                                    InValB |= (byte)((vgmBuf[InPos] << InShift >> 8) & BitMask);
                            }

                            InVal |= (byte)(InValB << OutBit);
                            OutBit += BitReadVal;
                        }

                        switch (ValSize)
                        {
                            case 0x01:
                                AddVal = PCMTbl.Entries[Ent1B + InVal];
                                OutVal += AddVal;
                                OutVal &= OutMask;
                                Bank.Data[OutPos] = (byte)OutVal;// *((UINT8*)OutPos) = (UINT8)OutVal;
                                break;
                            case 0x02:
                                //#ifndef BIG_ENDIAN
                                //				AddVal = Ent2B[InVal];
                                //#else
                                AddVal = (uint)(PCMTbl.Entries[Ent2B + InVal] + PCMTbl.Entries[Ent2B + InVal + 1] * 0x100);
                                //AddVal = ReadLE16((UINT8*)&Ent2B[InVal]);
                                //#endif
                                OutVal += AddVal;
                                OutVal &= OutMask;
                                //#ifndef BIG_ENDIAN
                                //				*((UINT16*)OutPos) = (UINT16)OutVal;
                                //#else
                                Bank.Data[OutPos + 0x00] = (byte)((OutVal & 0x00FF) >> 0);
                                Bank.Data[OutPos + 0x01] = (byte)((OutVal & 0xFF00) >> 8);
                                //#endif
                                break;
                        }
                    }
                    break;
                default:
                    //printf("Error: Unknown data block compression!\n");
                    return false;
            }

            //#if defined(_DEBUG) && defined(WIN32)
            //	Time = GetTickCount() - Time;
            //	printf("Decompression Time: %lu\n", Time);
            //#endif

            return true;
        }

        private void ReadPCMTable(uint DataSize, uint Adr)
        {
            byte ValSize;
            uint TblSize;

            PCMTbl.ComprType = vgmBuf[Adr + 0];// Data[0x00];
            PCMTbl.CmpSubType = vgmBuf[Adr + 1];// Data[0x01];
            PCMTbl.BitDec = vgmBuf[Adr + 2];// Data[0x02];
            PCMTbl.BitCmp = vgmBuf[Adr + 3];// Data[0x03];
            PCMTbl.EntryCount = GetLE16(Adr + 4);// ReadLE16(&Data[0x04]);

            ValSize = (byte)((PCMTbl.BitDec + 7) / 8);
            TblSize = PCMTbl.EntryCount * ValSize;

            PCMTbl.Entries = new byte[TblSize];// realloc(PCMTbl.Entries, TblSize);
            for (int i = 0; i < TblSize; i++) PCMTbl.Entries[i] = vgmBuf[Adr + 6 + i];
            //memcpy(PCMTbl.Entries, &Data[0x06], TblSize);

            if (DataSize < 0x06 + TblSize)
            {
                //Console.Write("Warning! Bad PCM Table Length!\n");
                //printf("Warning! Bad PCM Table Length!\n");
            }

            return;
        }

        private byte GetDACFromPCMBank()
        {
            // for YM2612 DAC data only
            /*VGM_PCM_BANK* TempPCM;
            UINT32 CurBnk;*/
            uint DataPos;

            /*TempPCM = &PCMBank[0x00];
            DataPos = TempPCM->DataPos;
            for (CurBnk = 0x00; CurBnk < TempPCM->BankCount; CurBnk ++)
            {
                if (DataPos < TempPCM->Bank[CurBnk].DataSize)
                {
                    if (TempPCM->DataPos < TempPCM->DataSize)
                        TempPCM->DataPos ++;
                    return TempPCM->Bank[CurBnk].Data[DataPos];
                }
                DataPos -= TempPCM->Bank[CurBnk].DataSize;
            }
            return 0x80;*/

            DataPos = PCMBank[0x00].DataPos;
            if (DataPos >= PCMBank[0x00].DataSize)
                return 0x80;

            PCMBank[0x00].DataPos++;
            return PCMBank[0x00].Bank[0].Data[DataPos];
        }

        private uint? GetPCMAddressFromPCMBank(byte Type, uint DataPos)
        {
            if (Type >= PCM_BANK_COUNT)
                return null;

            if (DataPos >= PCMBank[Type].DataSize)
                return null;

            return DataPos;
        }

        private bool getInformationHeader()
        {
            chips = new List<string>();
            UsedChips = "";

            SN76489ClockValue = 0;// defaultSN76489ClockValue;
            YM2612ClockValue = 0;// defaultYM2612ClockValue;
            YM2151ClockValue = 0;
            SEGAPCMClockValue = 0;
            YM2203ClockValue = 0;
            YM2608ClockValue = 0;
            YM2610ClockValue = 0;
            YM3812ClockValue = 0;
            YMF262ClockValue = 0;
            RF5C68ClockValue = 0;
            RF5C164ClockValue = 0;// defaultRF5C164ClockValue;
            PWMClockValue = 0;// defaultPWMClockValue;
            OKIM6258ClockValue = 0;// defaultOKIM6258ClockValue;
            C140ClockValue = 0;// defaultC140ClockValue;
            OKIM6295ClockValue = 0;//defaultOKIM6295ClockValue;
            AY8910ClockValue = 0;
            YM2413ClockValue = 0;
            HuC6280ClockValue = 0;
            K054539ClockValue = 0;
            NESClockValue = 0;
            MultiPCMClockValue = 0;
            uPD7759ClockValue = 0;
            SAA1099ClockValue = 0;
            X1_010ClockValue = 0;
            WSwanClockValue = 0;
            ES5503ClockValue = 0;


            //ヘッダーを読み込めるサイズをもっているかチェック
            if (vgmBuf.Length < 0x40) return false;

            //ヘッダーから情報取得

            uint vgm = GetLE32(0x00);
            if (vgm != FCC_VGM) return false;

            vgmEof = GetLE32(0x04);

            uint version = GetLE32(0x08);
            Version = string.Format("{0}.{1}{2}", (version & 0xf00) / 0x100, (version & 0xf0) / 0x10, (version & 0xf));
            //バージョンチェック
            if (version < 0x0101)
            {
                Console.WriteLine("Warning:This file is older version({0}).", Version);
                //return false;
            }

            uint SN76489clock = GetLE32(0x0c);
            if (SN76489clock != 0)
            {
                SN76489ClockValue = SN76489clock & 0x3fffffff;
                SN76489DualChipFlag = (SN76489clock & 0x40000000) != 0;
                SN76489NGPFlag = (SN76489clock & 0x80000000) != 0;
                if (version < 0x0150)
                {
                    SN76489Option = new object[]{
                                (byte)9,
                                (byte)0,
                                (byte)16,
                                (byte)0
                    };
                }
                else
                {
                    SN76489Option = new object[]{
                                vgmBuf[0x28],
                                vgmBuf[0x29],
                                vgmBuf[0x2a],
                                vgmBuf[0x2b]
                    };
                }
                if (SN76489DualChipFlag) chips.Add("SN76489x2");
                else chips.Add("SN76489");
            }

            uint YM2413clock = GetLE32(0x10);
            if (YM2413clock != 0)
            {
                YM2413ClockValue = YM2413clock & 0x3fffffff;
                YM2413DualChipFlag = (YM2413clock & 0x40000000) != 0;
                YM2413VRC7Flag = (YM2413clock & 0x8000_0000) != 0;
                if (!YM2413VRC7Flag)
                {
                    if (YM2413DualChipFlag) chips.Add("YM2413x2");
                    else chips.Add("YM2413");
                }
                else
                {
                    if (YM2413DualChipFlag) chips.Add("VRC7x2");
                    else chips.Add("VRC7");
                }
            }

            if (version == 0x0101)
            {
                uint YM2612clock = GetLE32(0x10);
                if (YM2612clock != 0)
                {
                    YM2612ClockValue = YM2612clock & 0x3fffffff;
                    YM2612DualChipFlag = (YM2612clock & 0x40000000) != 0;
                    if (YM2612DualChipFlag) chips.Add("YM2612x2");
                    else chips.Add("YM2612");
                }

                uint YM2151clock = GetLE32(0x10);
                if (YM2151clock != 0)
                {
                    YM2151ClockValue = YM2151clock & 0x3fffffff;
                    YM2151DualChipFlag = (YM2151clock & 0x40000000) != 0;
                    if (YM2151DualChipFlag) chips.Add("YM2151x2");
                    else chips.Add("YM2151");
                }
            }

            TotalCounter = GetLE32(0x18);
            if (TotalCounter < 0) return false;

            vgmLoopOffset = GetLE32(0x1c);

            LoopCounter = GetLE32(0x20);

            if (version > 0x0101)
            {

                uint YM2612clock = GetLE32(0x2c);
                if (YM2612clock != 0)
                {
                    YM2612ClockValue = YM2612clock & 0x3fffffff;
                    YM2612DualChipFlag = (YM2612clock & 0x40000000) != 0;
                    if (YM2612DualChipFlag) chips.Add("YM2612x2");
                    else chips.Add("YM2612");
                }

                uint YM2151clock = GetLE32(0x30);
                if (YM2151clock != 0)
                {
                    YM2151ClockValue = YM2151clock & 0x3fffffff;
                    YM2151DualChipFlag = (YM2151clock & 0x40000000) != 0;
                    if (YM2151DualChipFlag) chips.Add("YM2151x2");
                    else chips.Add("YM2151");
                }

                //SetYM2151Hosei();

                vgmDataOffset = GetLE32(0x34);
                if (vgmDataOffset == 0)
                {
                    vgmDataOffset = 0x40;
                }
                else
                {
                    vgmDataOffset += 0x34;
                }

                //if (version >= 0x0151)
                {
                    if (vgmDataOffset > 0x38)
                    {
                        uint SegaPCMclock = GetLE32(0x38);
                        int SPCMInterface = (int)GetLE32(0x3c);
                        if (SegaPCMclock != 0 && SPCMInterface != 0)
                        {
                            chips.Add("Sega PCM");
                            SEGAPCMClockValue = SegaPCMclock;
                            SEGAPCMInterface = SPCMInterface;
                        }
                    }

                    if (vgmDataOffset > 0x40)
                    {
                        uint RF5C68clock = GetLE32(0x40);
                        if (RF5C68clock != 0)
                        {
                            RF5C68ClockValue = RF5C68clock & 0x3fffffff;
                            RF5C68DualChipFlag = (RF5C68clock & 0x40000000) != 0;
                            if (RF5C68DualChipFlag) chips.Add("RF5C68x2");
                            else chips.Add("RF5C68");
                        }
                    }

                    if (vgmDataOffset > 0x44)
                    {
                        uint YM2203clock = GetLE32(0x44);
                        if (YM2203clock != 0)
                        {
                            YM2203ClockValue = YM2203clock & 0x3fffffff;
                            YM2203DualChipFlag = (YM2203clock & 0x40000000) != 0;
                            if (YM2203DualChipFlag) chips.Add("YM2203x2");
                            else chips.Add("YM2203");
                        }
                    }

                    if (vgmDataOffset > 0x48)
                    {
                        uint YM2608clock = GetLE32(0x48);
                        if (YM2608clock != 0)
                        {
                            YM2608ClockValue = YM2608clock & 0x3fffffff;
                            YM2608DualChipFlag = (YM2608clock & 0x40000000) != 0;
                            if (YM2608DualChipFlag) chips.Add("YM2608x2");
                            else chips.Add("YM2608");

                            opnaRamType = SearchOpnaRamType() ? 0x2 : 0x0;
                        }
                    }

                    if (vgmDataOffset > 0x4c)
                    {
                        uint YM2610Bclock = GetLE32(0x4c);
                        if (YM2610Bclock != 0)
                        {
                            YM2610ClockValue = YM2610Bclock & 0x3fff_ffff;
                            YM2610DualChipFlag = (YM2610Bclock & 0x40000000) != 0;
                            if (YM2610DualChipFlag) chips.Add("YM2610/Bx2");
                            else chips.Add("YM2610/B");
                        }
                    }

                    if (vgmDataOffset > 0x50)
                    {
                        uint YM3812clock = GetLE32(0x50);
                        if (YM3812clock != 0)
                        {
                            YM3812ClockValue = YM3812clock & 0x3fffffff;
                            YM3812DualChipFlag = (YM3812clock & 0x40000000) != 0;
                            if (YM2610DualChipFlag) chips.Add("YM3812x2");
                            else chips.Add("YM3812");
                        }
                    }

                    if (vgmDataOffset > 0x54)
                    {
                        uint YM3526clock = GetLE32(0x54);
                        if (YM3526clock != 0)
                        {
                            YM3526ClockValue = YM3526clock & 0x3fffffff;
                            YM3526DualChipFlag = (YM3526clock & 0x40000000) != 0;
                            if (YM3526DualChipFlag) chips.Add("YM3526x2");
                            else chips.Add("YM3526");
                        }
                    }

                    if (vgmDataOffset > 0x58)
                    {
                        uint Y8950clock = GetLE32(0x58);
                        if (Y8950clock != 0)
                        {
                            Y8950ClockValue = Y8950clock & 0x3fffffff;
                            Y8950DualChipFlag = (Y8950clock & 0x40000000) != 0;
                            if (Y8950DualChipFlag) chips.Add("Y8950x2");
                            else chips.Add("Y8950");
                        }
                    }

                    if (vgmDataOffset > 0x5c)
                    {
                        uint YMF262clock = GetLE32(0x5c);
                        if (YMF262clock != 0)
                        {
                            YMF262ClockValue = YMF262clock & 0x3fffffff;
                            YMF262DualChipFlag = (YMF262clock & 0x40000000) != 0;
                            if (YMF262DualChipFlag) chips.Add("YMF262x2");
                            else chips.Add("YMF262");
                        }
                    }

                    if (vgmDataOffset > 0x60)
                    {
                        uint YMF278Bclock = GetLE32(0x60);
                        if (YMF278Bclock != 0)
                        {
                            YMF278BClockValue = YMF278Bclock & 0x3fffffff;
                            YMF278BDualChipFlag = (YMF278Bclock & 0x40000000) != 0;
                            if (YMF278BDualChipFlag) chips.Add("YMF278Bx2");
                            else chips.Add("YMF278B");
                        }
                    }

                    if (vgmDataOffset > 0x64)
                    {
                        uint YMF271clock = GetLE32(0x64);
                        if (YMF271clock != 0)
                        {
                            YMF271ClockValue = YMF271clock & 0x3fffffff;
                            YMF271DualChipFlag = (YMF271clock & 0x40000000) != 0;
                            if (YMF271DualChipFlag) chips.Add("YMF271x2");
                            else chips.Add("YMF271");
                        }
                    }

                    if (vgmDataOffset > 0x68)
                    {
                        uint YMZ280Bclock = GetLE32(0x68);
                        if (YMZ280Bclock != 0)
                        {
                            YMZ280BClockValue = YMZ280Bclock & 0x3fffffff;
                            YMZ280BDualChipFlag = (YMZ280Bclock & 0x40000000) != 0;
                            if (YMZ280BDualChipFlag) chips.Add("YMZ280Bx2");
                            else chips.Add("YMZ280B");
                        }
                    }

                    if (vgmDataOffset > 0x6c)
                    {
                        uint RF5C164clock = GetLE32(0x6c);
                        if (RF5C164clock != 0)
                        {
                            RF5C164ClockValue = RF5C164clock & 0x3fffffff;
                            RF5C164DualChipFlag = (RF5C164clock & 0x40000000) != 0;
                            if (RF5C164DualChipFlag) chips.Add("RF5C164x2");
                            else chips.Add("RF5C164");
                        }
                    }


                    if (vgmDataOffset > 0x70)
                    {
                        uint PWMclock = GetLE32(0x70);
                        if (PWMclock != 0)
                        {
                            chips.Add("PWM");
                            PWMClockValue = PWMclock;
                        }
                    }

                    if (vgmDataOffset > 0x74)
                    {
                        uint AY8910clock = GetLE32(0x74);
                        byte AY8910flag = vgmBuf[0x79];
                        if (AY8910clock != 0)
                        {
                            AY8910ClockValue = AY8910clock & 0x3fffffff;
                            if ((AY8910flag & 0x10) != 0) AY8910ClockValue /= 2;//bit 4   YM2149 Pin 26 (additional /2 clock divider)
                            AY8910DualChipFlag = (AY8910clock & 0x40000000) != 0;
                            if (AY8910DualChipFlag) chips.Add("AY8910x2");
                            else chips.Add("AY8910");
                        }
                    }
                }

                //OKIM6258ClockValue = 0;
                //HuC6280ClockValue = 0;
                //OKIM6295ClockValue = 0;

                //if (version >= 0x0161)
                {
                    if (vgmDataOffset > 0x80)
                    {
                        uint DMGclock = GetLE32(0x80);
                        if (DMGclock != 0)
                        {
                            DMGClockValue = DMGclock & 0x3fffffff;
                            DMGDualChipFlag = (DMGclock & 0x40000000) != 0;
                            if (DMGDualChipFlag) chips.Add("DMGx2");
                            else chips.Add("DMG");
                        }
                    }

                    if (vgmDataOffset > 0x84)
                    {
                        uint NESclock = GetLE32(0x84);
                        if (NESclock != 0)
                        {
                            NESClockValue = NESclock & 0xbfffffff;
                            NESDualChipFlag = (NESclock & 0x40000000) != 0;
                            if (NESDualChipFlag) chips.Add("NES_APUx2");
                            else chips.Add("NES_APU");
                        }
                    }

                    if (vgmDataOffset > 0x88)
                    {
                        uint MultiPCMclock = GetLE32(0x88);
                        if (MultiPCMclock != 0)
                        {
                            MultiPCMClockValue = MultiPCMclock & 0x3fffffff;
                            MultiPCMDualChipFlag = (MultiPCMclock & 0x40000000) != 0;
                            if (MultiPCMDualChipFlag) chips.Add("MultiPCMx2");
                            else chips.Add("MultiPCM");
                        }
                    }

                    if (vgmDataOffset > 0x8c)
                    {
                        uint uPD7759clock = GetLE32(0x8c);
                        if (uPD7759clock != 0)
                        {
                            uPD7759ClockValue = uPD7759clock & 0xbfff_ffff;
                            uPD7759DualChipFlag = (uPD7759clock & 0x40000000) != 0;
                            if (uPD7759DualChipFlag) chips.Add("uPD7759x2");
                            else chips.Add("uPD7759");
                        }
                    }

                    if (vgmDataOffset > 0x90)
                    {
                        uint OKIM6258clock = GetLE32(0x90);
                        if (OKIM6258clock != 0)
                        {
                            chips.Add("OKIM6258");
                            OKIM6258ClockValue = OKIM6258clock;
                            OKIM6258Type = vgmBuf[0x94];
                        }
                    }

                    if (vgmDataOffset > 0x9c)
                    {
                        uint K051649clock = GetLE32(0x9c);
                        if (K051649clock != 0)
                        {
                            K051649ClockValue = K051649clock & 0x3fffffff;
                            K051649DualChipFlag = (K051649clock & 0x40000000) != 0;
                            if (K051649DualChipFlag) chips.Add("K051649x2");
                            else chips.Add("K051649");
                        }
                    }

                    if (vgmDataOffset > 0xa0)
                    {
                        uint K054539clock = GetLE32(0xa0);
                        if (K054539clock != 0)
                        {
                            K054539ClockValue = K054539clock & 0x3fff_ffff;
                            K054539DualChipFlag = (K054539clock & 0x40000000) != 0;
                            if (K054539DualChipFlag) chips.Add("K054539x2");
                            else chips.Add("K054539");
                            K054539Flags = vgmBuf[0x95];
                        }
                    }

                    if (vgmDataOffset > 0xa4)
                    {

                        uint HuC6280clock = GetLE32(0xa4);
                        if (HuC6280clock != 0)
                        {
                            chips.Add("HuC6280");
                            HuC6280ClockValue = HuC6280clock;
                        }
                    }

                    if (vgmDataOffset > 0xa8)
                    {

                        uint C140clock = GetLE32(0xa8);
                        if (C140clock != 0)
                        {
                            C140ClockValue = C140clock & 0x3fff_ffff;
                            C140DualChipFlag = (C140clock & 0x4000_0000) != 0;
                            if (C140DualChipFlag) chips.Add("C140x2");
                            else chips.Add("C140");

                            C140Type = vgmBuf[0x96] switch
                            {
                                0x00 => MDSound.c140.C140_TYPE.SYSTEM2,
                                0x01 => MDSound.c140.C140_TYPE.SYSTEM21,
                                _ => MDSound.c140.C140_TYPE.ASIC219,
                            };
                        }
                    }

                    if (vgmDataOffset > 0xac)
                    {

                        uint K053260clock = GetLE32(0xac);
                        if (K053260clock != 0)
                        {
                            K053260ClockValue = K053260clock & 0x3fffffff;
                            K053260DualChipFlag = (K053260clock & 0x40000000) != 0;
                            if (K053260DualChipFlag) chips.Add("K053260x2");
                            else chips.Add("K053260");
                        }
                    }

                    if (vgmDataOffset > 0xb0)
                    {

                        uint POKEYclock = GetLE32(0xb0);
                        if (POKEYclock != 0)
                        {
                            POKEYClockValue = POKEYclock & 0x3fffffff;
                            POKEYDualChipFlag = (POKEYclock & 0x40000000) != 0;
                            if (POKEYDualChipFlag) chips.Add("POKEYx2");
                            else chips.Add("POKEY");
                        }
                    }

                    if (vgmDataOffset > 0xb4)
                    {

                        uint QSoundclock = GetLE32(0xb4);
                        if (QSoundclock != 0)
                        {
                            chips.Add("QSound");
                            QSoundClockValue = QSoundclock;
                        }
                    }

                    if (vgmDataOffset > 0x98)
                    {
                        uint OKIM6295clock = GetLE32(0x98);
                        if (OKIM6295clock != 0)
                        {
                            OKIM6295DualChipFlag = (OKIM6295clock & 0x40000000) != 0;
                            if (OKIM6295DualChipFlag)
                            {
                                chips.Add("OKIM6295x2");
                            }
                            else
                            {
                                chips.Add("OKIM6295");
                            }
                            OKIM6295ClockValue = OKIM6295clock & 0xbfffffff;
                        }
                    }

                }
                if (version >= 0x0171)
                {
                    if (vgmDataOffset > 0xc0)
                    {

                        uint WSwanclock = GetLE32(0xc0);
                        if (WSwanclock != 0)
                        {
                            WSwanClockValue = WSwanclock & 0x3fff_ffff;
                            WSwanDualChipFlag = (WSwanclock & 0x4000_0000) != 0;
                            if (WSwanDualChipFlag) chips.Add("WSwanx2");
                            else chips.Add("WSwan");
                        }
                    }

                    if (vgmDataOffset > 0xc8)
                    {

                        uint SAA1099clock = GetLE32(0xc8);
                        if (SAA1099clock != 0)
                        {
                            SAA1099ClockValue = SAA1099clock & 0x3fff_ffff;
                            SAA1099DualChipFlag = (SAA1099clock & 0x4000_0000) != 0;
                            if (SAA1099DualChipFlag) chips.Add("SAA1099x2");
                            else chips.Add("SAA1099");
                        }
                    }

                    if (vgmDataOffset > 0xcc)
                    {

                        uint ES5503clock = GetLE32(0xcc);
                        if (ES5503clock != 0)
                        {
                            ES5503ClockValue = ES5503clock & 0x3fff_ffff;//def=7159090
                            ES5503DualChipFlag = (ES5503clock & 0x4000_0000) != 0;
                            ES5503Ch = vgmBuf[0xd4];
                            //if (ES5503Ch == 1) ES5503Ch = 2;
                            if (ES5503DualChipFlag) chips.Add("ES5503x2");
                            else chips.Add("ES5503");
                        }
                    }

                    if (vgmDataOffset > 0xd8)
                    {

                        uint X1_010clock = GetLE32(0xd8);
                        if (X1_010clock != 0)
                        {
                            X1_010ClockValue = X1_010clock & 0x3fff_ffff;
                            X1_010DualChipFlag = (X1_010clock & 0x4000_0000) != 0;
                            if (X1_010DualChipFlag) chips.Add("X1_010x2");
                            else chips.Add("X1_010");
                        }
                    }

                    if (vgmDataOffset > 0xdc)
                    {

                        uint C352clock = GetLE32(0xdc);
                        if (C352clock != 0)
                        {
                            C352ClockValue = C352clock & 0x3fff_ffff;
                            C352DualChipFlag = (C352clock & 0x4000_0000) != 0;
                            if (C352DualChipFlag) chips.Add("C352x2");
                            else chips.Add("C352");

                            C352ClockDivider = vgmBuf[0xd6];
                        }
                    }

                    if (vgmDataOffset > 0xe0)
                    {

                        uint GA20clock = GetLE32(0xe0);
                        if (GA20clock != 0)
                        {
                            GA20DualChipFlag = (GA20clock & 0x40000000) != 0;
                            if (GA20DualChipFlag)
                            {
                                GA20ClockValue = GA20clock & 0x3fffffff;
                                chips.Add("GA20x2");
                            }
                            else
                            {
                                GA20ClockValue = GA20clock & 0xbfffffff;
                                chips.Add("GA20");
                            }
                        }
                    }

                }
            }
            else
            {
                vgmDataOffset = 0x40;
            }

            foreach (string chip in chips)
            {
                UsedChips += chip + " , ";
            }
            if (UsedChips.Length > 2)
            {
                UsedChips = UsedChips[..^3];
            }

            uint vgmGd3 = GetLE32(0x14);
            if (vgmGd3 != 0)
            {
                try
                {
                    uint vgmGd3Id = GetLE32(vgmGd3 + 0x14);
                    if (vgmGd3Id != FCC_GD3) return false;
                    uint adr = vgmGd3 + 12 + 0x14;
                    GD3 = Common.getGD3Info(vgmBuf, adr);
                    GD3.UsedChips = UsedChips;
                    //GD3 = Common.getGD3Info(vgmBuf, vgmGd3);
                }
                catch { }
            }

            return true;
        }


        /// <summary>
        /// OPNAのRAMTypeをデータから調べる
        /// </summary>
        /// <returns>true:x8bit false:x1bit</returns>
        private bool SearchOpnaRamType()
        {
            try
            {
                long adr = vgmDataOffset;

                while (adr < vgmBuf.Length && vgmBuf[adr] != 0x66)
                {
                    byte dat = vgmBuf[adr];
                    if (dat < 0x51) adr += 2;
                    else if (dat < 0x57) adr += 3;
                    else if (dat == 0x57)
                    {
                        byte reg = vgmBuf[adr + 1];
                        byte val = vgmBuf[adr + 2];
                        adr += 3;
                        if (reg == 1)
                        {
                            if ((val & 2) != 0)
                            {
                                return true;
                            }
                        }
                    }
                    else if (dat < 0x62) adr += 3;
                    else if (dat < 0x64) adr++;
                    else if (dat == 0x64) adr += 4;
                    else if (dat == 0x66) adr++;
                    else if (dat == 0x67)
                    {
                        uint bLen = GetLE32((uint)(adr + 3));
                        bLen &= 0x7fffffff;
                        adr += bLen + 7;
                    }
                    else if (dat == 0x68)
                    {
                        adr += 12;
                    }
                    else if (dat < 0x90) adr++;
                    else if (dat == 0x90) adr += 5;
                    else if (dat == 0x91) adr += 5;
                    else if (dat == 0x92) adr += 6;
                    else if (dat == 0x93) adr += 11;
                    else if (dat == 0x94) adr += 2;
                    else if (dat == 0x95) adr += 5;
                    else if (dat < 0xc0) adr += 3;
                    else if (dat < 0xe0) adr += 4;
                    else adr += 5;
                }
            }
            catch
            {
                ;
            }

            return false;
        }

        public override GD3 getGD3Info(byte[] buf, uint vgmGd3)
        {
            vgmBuf = buf;
            getInformationHeader();

            //uint adr = vgmGd3 + 12 + 0x14;
            //GD3 = Common.getGD3Info(buf, adr);
            //GD3.UsedChips = UsedChips;

            return GD3;
        }


    }

    public class VGM_PCM_DATA
    {
        public uint DataSize;
        public byte[] Data;
        public uint DataStart;
    }

    public class VGM_PCM_BANK
    {
        public uint BankCount;
        public List<VGM_PCM_DATA> Bank = new();
        public uint DataSize;
        public byte[] Data;
        public uint DataPos;
        public uint BnkPos;
    }

    public class DACCTRL_DATA
    {
        public bool Enable;
        public byte Bank;
    }

    public class PCMBANK_TBL
    {
        public byte ComprType;
        public byte CmpSubType;
        public byte BitDec;
        public byte BitCmp;
        public uint EntryCount;
        public byte[] Entries;// void* Entries;
    }

    public class GD3
    {
        public string TrackName = "";
        public string TrackNameJ = "";
        public string GameName = "";
        public string GameNameJ = "";
        public string SystemName = "";
        public string SystemNameJ = "";
        public string Composer = "";
        public string ComposerJ = "";
        public string Converted = "";
        public string Notes = "";
        public string VGMBy = "";
        public string Version = "";
        public string UsedChips = "";
        public System.Drawing.Image pic = null;

        public List<Tuple<int, int, string>> Lyrics = null;
    }


}
