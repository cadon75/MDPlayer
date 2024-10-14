﻿using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
#if X64
using MDPlayerx64.Properties;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
#else
using MDPlayer.Properties;
#endif

//今となってはなおせないので
#pragma warning disable IDE1006

namespace MDPlayer
{
    [Serializable]
    public class Setting
    {
        public Setting()
        {
        }

        public string FileSearchPathList
        {
            get;
            set;
        }

        private OutputDevice _outputDevice = new();
        public OutputDevice outputDevice
        {
            get
            {
                return _outputDevice;
            }

            set
            {
                _outputDevice = value;
            }
        }

        private ChipType2[] _AY8910Type = null;
        public ChipType2[] AY8910Type
        {
            get
            {
                return _AY8910Type;
            }

            set
            {
                _AY8910Type = value;
            }
        }

        //private ChipType2[] _AY8910SType = new ChipType2();
        //public ChipType2[] AY8910SType
        //{
        //    get
        //    {
        //        return _AY8910SType;
        //    }

        //    set
        //    {
        //        _AY8910SType = value;
        //    }
        //}

        private ChipType2[] _YM2151Type = null;
        public ChipType2[] YM2151Type
        {
            get
            {
                return _YM2151Type;
            }

            set
            {
                _YM2151Type = value;
            }
        }

        private ChipType2[] _YM2203Type = null;
        public ChipType2[] YM2203Type
        {
            get
            {
                return _YM2203Type;
            }

            set
            {
                _YM2203Type = value;
            }
        }

        private ChipType2[] _YM2413Type = null;
        public ChipType2[] YM2413Type
        {
            get
            {
                return _YM2413Type;
            }

            set
            {
                _YM2413Type = value;
            }
        }

        private ChipType2[] _HuC6280Type = null;
        public ChipType2[] HuC6280Type
        {
            get
            {
                return _HuC6280Type;
            }

            set
            {
                _HuC6280Type = value;
            }
        }

        private ChipType2[] _K051649Type = null;
        public ChipType2[] K051649Type
        {
            get
            {
                return _K051649Type;
            }

            set
            {
                _K051649Type = value;
            }
        }

        //private ChipType2[] _YM2413SType = null;
        //public ChipType2[] YM2413SType
        //{
        //    get
        //    {
        //        return _YM2413SType;
        //    }

        //    set
        //    {
        //        _YM2413SType = value;
        //    }
        //}

        private ChipType2[] _YM2608Type = null;
        public ChipType2[] YM2608Type
        {
            get
            {
                return _YM2608Type;
            }

            set
            {
                _YM2608Type = value;
            }
        }

        private ChipType2[] _YM2610Type = null;
        public ChipType2[] YM2610Type
        {
            get
            {
                return _YM2610Type;
            }

            set
            {
                _YM2610Type = value;
            }
        }

        private ChipType2[] _YMF262Type = null;
        public ChipType2[] YMF262Type
        {
            get
            {
                return _YMF262Type;
            }

            set
            {
                _YMF262Type = value;
            }
        }

        private ChipType2[] _YMF271Type = null;
        public ChipType2[] YMF271Type
        {
            get
            {
                return _YMF271Type;
            }

            set
            {
                _YMF271Type = value;
            }
        }

        private ChipType2[] _YMF278BType = null;
        public ChipType2[] YMF278BType
        {
            get
            {
                return _YMF278BType;
            }

            set
            {
                _YMF278BType = value;
            }
        }

        private ChipType2[] _YMZ280BType = null;
        public ChipType2[] YMZ280BType
        {
            get
            {
                return _YMZ280BType;
            }

            set
            {
                _YMZ280BType = value;
            }
        }

        private ChipType2[] _YM2612Type = null;
        public ChipType2[] YM2612Type
        {
            get
            {
                return _YM2612Type;
            }

            set
            {
                _YM2612Type = value;
            }
        }

        private ChipType2[] _SN76489Type = null;
        public ChipType2[] SN76489Type
        {
            get
            {
                return _SN76489Type;
            }

            set
            {
                _SN76489Type = value;
            }
        }

        //private ChipType2 _YM2151SType = new ChipType2();
        //public ChipType2 YM2151SType
        //{
        //    get
        //    {
        //        return _YM2151SType;
        //    }

        //    set
        //    {
        //        _YM2151SType = value;
        //    }
        //}

        //private ChipType2 _YM2203SType = new ChipType2();
        //public ChipType2 YM2203SType
        //{
        //    get
        //    {
        //        return _YM2203SType;
        //    }

        //    set
        //    {
        //        _YM2203SType = value;
        //    }
        //}

        //private ChipType2 _YM2608SType = new ChipType2();
        //public ChipType2 YM2608SType
        //{
        //    get
        //    {
        //        return _YM2608SType;
        //    }

        //    set
        //    {
        //        _YM2608SType = value;
        //    }
        //}

        //private ChipType2 _YM2610SType = new ChipType2();
        //public ChipType2 YM2610SType
        //{
        //    get
        //    {
        //        return _YM2610SType;
        //    }

        //    set
        //    {
        //        _YM2610SType = value;
        //    }
        //}

        //private ChipType2 _YM2612SType = new ChipType2();
        //public ChipType2 YM2612SType
        //{
        //    get
        //    {
        //        return _YM2612SType;
        //    }

        //    set
        //    {
        //        _YM2612SType = value;
        //    }
        //}

        //private ChipType2 _YMF262SType = new ChipType2();
        //public ChipType2 YMF262SType
        //{
        //    get
        //    {
        //        return _YMF262SType;
        //    }

        //    set
        //    {
        //        _YMF262SType = value;
        //    }
        //}

        //private ChipType2 _YMF271SType = new ChipType2();
        //public ChipType2 YMF271SType
        //{
        //    get
        //    {
        //        return _YMF271SType;
        //    }

        //    set
        //    {
        //        _YMF271SType = value;
        //    }
        //}

        //private ChipType2 _YMF278BSType = new ChipType2();
        //public ChipType2 YMF278BSType
        //{
        //    get
        //    {
        //        return _YMF278BSType;
        //    }

        //    set
        //    {
        //        _YMF278BSType = value;
        //    }
        //}

        //private ChipType2 _YMZ280BSType = new ChipType2();
        //public ChipType2 YMZ280BSType
        //{
        //    get
        //    {
        //        return _YMZ280BSType;
        //    }

        //    set
        //    {
        //        _YMZ280BSType = value;
        //    }
        //}

        //private ChipType2 _SN76489SType = new ChipType2();
        //public ChipType2 SN76489SType
        //{
        //    get
        //    {
        //        return _SN76489SType;
        //    }

        //    set
        //    {
        //        _SN76489SType = value;
        //    }
        //}

        //private ChipType2 _HuC6280SType = new ChipType2();
        //public ChipType2 HuC6280SType
        //{
        //    get
        //    {
        //        return _HuC6280SType;
        //    }

        //    set
        //    {
        //        _HuC6280SType = value;
        //    }
        //}

        private ChipType2[] _YM3526Type = null;
        public ChipType2[] YM3526Type
        {
            get
            {
                return _YM3526Type;
            }

            set
            {
                _YM3526Type = value;
            }
        }

        //private ChipType2 _YM3526SType = new ChipType2();
        //public ChipType2 YM3526SType
        //{
        //    get
        //    {
        //        return _YM3526SType;
        //    }

        //    set
        //    {
        //        _YM3526SType = value;
        //    }
        //}

        private ChipType2[] _YM3812Type = null;
        public ChipType2[] YM3812Type
        {
            get
            {
                return _YM3812Type;
            }

            set
            {
                _YM3812Type = value;
            }
        }

        //private ChipType2 _YM3812SType = new ChipType2();
        //public ChipType2 YM3812SType
        //{
        //    get
        //    {
        //        return _YM3812SType;
        //    }

        //    set
        //    {
        //        _YM3812SType = value;
        //    }
        //}

        private ChipType2[] _Y8950Type = null;
        public ChipType2[] Y8950Type
        {
            get
            {
                return _Y8950Type;
            }

            set
            {
                _Y8950Type = value;
            }
        }

        //private ChipType2 _Y8950SType = new ChipType2();
        //public ChipType2 Y8950SType
        //{
        //    get
        //    {
        //        return _Y8950SType;
        //    }

        //    set
        //    {
        //        _Y8950SType = value;
        //    }
        //}

        private ChipType2[] _C140Type = null;
        public ChipType2[] C140Type
        {
            get
            {
                return _C140Type;
            }

            set
            {
                _C140Type = value;
            }
        }

        private ChipType2[] _ES5503Type = null;
        public ChipType2[] ES5503Type
        {
            get
            {
                return _ES5503Type;
            }

            set
            {
                _ES5503Type = value;
            }
        }
        //private ChipType2 _C140SType = new ChipType2();
        //public ChipType2 C140SType
        //{
        //    get
        //    {
        //        return _C140SType;
        //    }

        //    set
        //    {
        //        _C140SType = value;
        //    }
        //}

        private ChipType2[] _SEGAPCMType = null;
        public ChipType2[] SEGAPCMType
        {
            get
            {
                return _SEGAPCMType;
            }

            set
            {
                _SEGAPCMType = value;
            }
        }

        //private ChipType2 _SEGAPCMSType = new ChipType2();
        //public ChipType2 SEGAPCMSType
        //{
        //    get
        //    {
        //        return _SEGAPCMSType;
        //    }

        //    set
        //    {
        //        _SEGAPCMSType = value;
        //    }
        //}


        private int _LatencyEmulation = 0;
        public int LatencyEmulation
        {
            get
            {
                return _LatencyEmulation;
            }

            set
            {
                _LatencyEmulation = value;
            }
        }

        private int _LatencySCCI = 0;
        public int LatencySCCI
        {
            get
            {
                return _LatencySCCI;
            }

            set
            {
                _LatencySCCI = value;
            }
        }

        private bool _HiyorimiMode = true;
        public bool HiyorimiMode
        {
            get
            {
                return _HiyorimiMode;
            }

            set
            {
                _HiyorimiMode = value;
            }
        }

        private int _playMode = 0;
        public int playMode
        {
            get
            {
                return _playMode;
            }

            set
            {
                _playMode = value;
            }
        }

        private Network _network = new();
        public Network network
        {
            get
            {
                return _network;
            }

            set
            {
                _network = value;
            }
        }

        private Other _other = new();
        public Other other
        {
            get
            {
                return _other;
            }

            set
            {
                _other = value;
            }
        }

        private Debug _debug = new();
        public Debug debug
        {
            get
            {
                return _debug;
            }

            set
            {
                _debug = value;
            }
        }

        private Balance _balance = new();
        public Balance balance
        {
            get
            {
                return _balance;
            }

            set
            {
                _balance = value;
            }
        }

        private Location _location = new();
        public Location location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }

        private MidiExport _midiExport = new();
        public MidiExport midiExport
        {
            get
            {
                return _midiExport;
            }

            set
            {
                _midiExport = value;
            }
        }

        private MidiKbd _midiKbd = new();
        public MidiKbd midiKbd
        {
            get
            {
                return _midiKbd;
            }

            set
            {
                _midiKbd = value;
            }
        }

        private Vst _vst = new();
        public Vst vst
        {
            get
            {
                return _vst;
            }

            set
            {
                _vst = value;
            }
        }

        private MidiOut _midiOut = new();
        public MidiOut midiOut
        {
            get
            {
                return _midiOut;
            }

            set
            {
                _midiOut = value;
            }
        }

        private NSF _nsf = new();
        public NSF nsf
        {
            get
            {
                return _nsf;
            }

            set
            {
                _nsf = value;
            }
        }

        private SID _sid = new();
        public SID sid
        {
            get
            {
                return _sid;
            }

            set
            {
                _sid = value;
            }
        }

        private NukedOPN2 _NukedOPN2 = new();
        public NukedOPN2 nukedOPN2
        {
            get
            {
                return _NukedOPN2;
            }

            set
            {
                _NukedOPN2 = value;
            }
        }

        private AutoBalance _autoBalance = new();
        public AutoBalance autoBalance
        {
            get => _autoBalance; set => _autoBalance = value;
        }

        private PMDDotNET _PMDDotNET = new();
        public PMDDotNET pmdDotNET
        {
            get
            {
                return _PMDDotNET;
            }

            set
            {
                _PMDDotNET = value;
            }
        }

        private Zmusic _Zmusic = new();
        public Zmusic zmusic
        {
            get
            {
                return _Zmusic;
            }

            set
            {
                _Zmusic = value;
            }
        }

        private Mxdrv _Mxdrv = new();
        public Mxdrv mxdrv
        {
            get
            {
                return _Mxdrv;
            }

            set
            {
                _Mxdrv = value;
            }
        }

        private Mndrv _Mndrv = new();
        public Mndrv mndrv
        {
            get
            {
                return _Mndrv;
            }

            set
            {
                _Mndrv = value;
            }
        }

        private Rcs _Rcs = new();
        public Rcs rcs
        {
            get
            {
                return _Rcs;
            }

            set
            {
                _Rcs = value;
            }
        }

        private PlayList _playList = new();
        public PlayList playList
        {
            get
            {
                return _playList;
            }

            set
            {
                _playList = value;
            }
        }

        public KeyBoardHook keyBoardHook { get => _keyBoardHook; set => _keyBoardHook = value; }
        public bool unuseRealChip { get; set; }

        private KeyBoardHook _keyBoardHook = new();

        [Serializable]
        public class OutputDevice
        {

            private int _DeviceType = 0;
            public int DeviceType
            {
                get
                {
                    return _DeviceType;
                }

                set
                {
                    _DeviceType = value;
                }
            }

            private int _Latency = 300;
            public int Latency
            {
                get
                {
                    return _Latency;
                }

                set
                {
                    _Latency = value;
                }
            }

            private int _WaitTime = 500;
            public int WaitTime
            {
                get
                {
                    return _WaitTime;
                }

                set
                {
                    _WaitTime = value;
                }
            }

            private string _WaveOutDeviceName = "";
            public string WaveOutDeviceName
            {
                get
                {
                    return _WaveOutDeviceName;
                }

                set
                {
                    _WaveOutDeviceName = value;
                }
            }

            private string _DirectSoundDeviceName = "";
            public string DirectSoundDeviceName
            {
                get
                {
                    return _DirectSoundDeviceName;
                }

                set
                {
                    _DirectSoundDeviceName = value;
                }
            }

            private string _WasapiDeviceName = "";
            public string WasapiDeviceName
            {
                get
                {
                    return _WasapiDeviceName;
                }

                set
                {
                    _WasapiDeviceName = value;
                }
            }

            private bool _WasapiShareMode = true;
            public bool WasapiShareMode
            {
                get
                {
                    return _WasapiShareMode;
                }

                set
                {
                    _WasapiShareMode = value;
                }
            }

            private string _AsioDeviceName = "";
            public string AsioDeviceName
            {
                get
                {
                    return _AsioDeviceName;
                }

                set
                {
                    _AsioDeviceName = value;
                }
            }

            private int _SampleRate = 44100;
            public int SampleRate
            {
                get
                {
                    return _SampleRate;
                }

                set
                {
                    _SampleRate = value;
                }
            }

            public OutputDevice Copy()
            {
                OutputDevice outputDevice = new()
                {
                    DeviceType = this.DeviceType,
                    Latency = this.Latency,
                    WaitTime = this.WaitTime,
                    WaveOutDeviceName = this.WaveOutDeviceName,
                    DirectSoundDeviceName = this.DirectSoundDeviceName,
                    WasapiDeviceName = this.WasapiDeviceName,
                    WasapiShareMode = this.WasapiShareMode,
                    AsioDeviceName = this.AsioDeviceName,
                    SampleRate = this.SampleRate
                };

                return outputDevice;
            }
        }

        //[Serializable]
        //public class ChipType2
        //{
        //    private bool _UseEmu = true;
        //    public bool UseEmu
        //    {
        //        get
        //        {
        //            return _UseEmu;
        //        }

        //        set
        //        {
        //            _UseEmu = value;
        //        }
        //    }

        //    private bool _UseEmu2 = false;
        //    public bool UseEmu2
        //    {
        //        get
        //        {
        //            return _UseEmu2;
        //        }

        //        set
        //        {
        //            _UseEmu2 = value;
        //        }
        //    }

        //    private bool _UseEmu3 = false;
        //    public bool UseEmu3
        //    {
        //        get
        //        {
        //            return _UseEmu3;
        //        }

        //        set
        //        {
        //            _UseEmu3 = value;
        //        }
        //    }


        //    private bool _UseScci = false;
        //    public bool UseScci
        //    {
        //        get
        //        {
        //            return _UseScci;
        //        }

        //        set
        //        {
        //            _UseScci = value;
        //        }
        //    }

        //    private string _InterfaceName = "";
        //    public string InterfaceName
        //    {
        //        get
        //        {
        //            return _InterfaceName;
        //        }

        //        set
        //        {
        //            _InterfaceName = value;
        //        }
        //    }

        //    private int _SoundLocation = -1;
        //    public int SoundLocation
        //    {
        //        get
        //        {
        //            return _SoundLocation;
        //        }

        //        set
        //        {
        //            _SoundLocation = value;
        //        }
        //    }

        //    private int _BusID = -1;
        //    public int BusID
        //    {
        //        get
        //        {
        //            return _BusID;
        //        }

        //        set
        //        {
        //            _BusID = value;
        //        }
        //    }

        //    private int _SoundChip = -1;
        //    public int SoundChip
        //    {
        //        get
        //        {
        //            return _SoundChip;
        //        }

        //        set
        //        {
        //            _SoundChip = value;
        //        }
        //    }

        //    private string _ChipName = "";
        //    public string ChipName
        //    {
        //        get
        //        {
        //            return _ChipName;
        //        }

        //        set
        //        {
        //            _ChipName = value;
        //        }
        //    }


        //    private bool _UseScci2 = false;
        //    public bool UseScci2
        //    {
        //        get
        //        {
        //            return _UseScci2;
        //        }

        //        set
        //        {
        //            _UseScci2 = value;
        //        }
        //    }

        //    private string _InterfaceName2A = "";
        //    public string InterfaceName2A
        //    {
        //        get
        //        {
        //            return _InterfaceName2A;
        //        }

        //        set
        //        {
        //            _InterfaceName2A = value;
        //        }
        //    }

        //    private int _SoundLocation2A = -1;
        //    public int SoundLocation2A
        //    {
        //        get
        //        {
        //            return _SoundLocation2A;
        //        }

        //        set
        //        {
        //            _SoundLocation2A = value;
        //        }
        //    }

        //    private int _BusID2A = -1;
        //    public int BusID2A
        //    {
        //        get
        //        {
        //            return _BusID2A;
        //        }

        //        set
        //        {
        //            _BusID2A = value;
        //        }
        //    }

        //    private int _SoundChip2A = -1;
        //    public int SoundChip2A
        //    {
        //        get
        //        {
        //            return _SoundChip2A;
        //        }

        //        set
        //        {
        //            _SoundChip2A = value;
        //        }
        //    }

        //    private string _ChipName2A = "";
        //    public string ChipName2A
        //    {
        //        get
        //        {
        //            return _ChipName2A;
        //        }

        //        set
        //        {
        //            _ChipName2A = value;
        //        }
        //    }

        //    private int _Type = 0;
        //    public int Type
        //    {
        //        get
        //        {
        //            return _Type;
        //        }

        //        set
        //        {
        //            _Type = value;
        //        }
        //    }

        //    private string _InterfaceName2B = "";
        //    public string InterfaceName2B
        //    {
        //        get
        //        {
        //            return _InterfaceName2B;
        //        }

        //        set
        //        {
        //            _InterfaceName2B = value;
        //        }
        //    }

        //    private int _SoundLocation2B = -1;
        //    public int SoundLocation2B
        //    {
        //        get
        //        {
        //            return _SoundLocation2B;
        //        }

        //        set
        //        {
        //            _SoundLocation2B = value;
        //        }
        //    }

        //    private int _BusID2B = -1;
        //    public int BusID2B
        //    {
        //        get
        //        {
        //            return _BusID2B;
        //        }

        //        set
        //        {
        //            _BusID2B = value;
        //        }
        //    }

        //    private int _SoundChip2B = -1;
        //    public int SoundChip2B
        //    {
        //        get
        //        {
        //            return _SoundChip2B;
        //        }

        //        set
        //        {
        //            _SoundChip2B = value;
        //        }
        //    }

        //    private string _ChipName2B = "";
        //    public string ChipName2B
        //    {
        //        get
        //        {
        //            return _ChipName2B;
        //        }

        //        set
        //        {
        //            _ChipName2B = value;
        //        }
        //    }


        //    private bool _UseWait = true;
        //    public bool UseWait
        //    {
        //        get
        //        {
        //            return _UseWait;
        //        }

        //        set
        //        {
        //            _UseWait = value;
        //        }
        //    }

        //    private bool _UseWaitBoost = false;
        //    public bool UseWaitBoost
        //    {
        //        get
        //        {
        //            return _UseWaitBoost;
        //        }

        //        set
        //        {
        //            _UseWaitBoost = value;
        //        }
        //    }

        //    private bool _OnlyPCMEmulation = false;
        //    public bool OnlyPCMEmulation
        //    {
        //        get
        //        {
        //            return _OnlyPCMEmulation;
        //        }

        //        set
        //        {
        //            _OnlyPCMEmulation = value;
        //        }
        //    }

        //    private int _LatencyForEmulation = 0;
        //    public int LatencyForEmulation
        //    {
        //        get
        //        {
        //            return _LatencyForEmulation;
        //        }

        //        set
        //        {
        //            _LatencyForEmulation = value;
        //        }
        //    }

        //    private int _LatencyForScci = 0;
        //    public int LatencyForScci
        //    {
        //        get
        //        {
        //            return _LatencyForScci;
        //        }

        //        set
        //        {
        //            _LatencyForScci = value;
        //        }
        //    }


        //    public ChipType2 Copy()
        //    {
        //        ChipType2 ct = new ChipType2();
        //        ct.UseEmu = this.UseEmu;
        //        ct.UseEmu2 = this.UseEmu2;
        //        ct.UseEmu3 = this.UseEmu3;
        //        ct.UseScci = this.UseScci;
        //        ct.SoundLocation = this.SoundLocation;

        //        ct.BusID = this.BusID;
        //        ct.InterfaceName = this.InterfaceName;
        //        ct.SoundChip = this.SoundChip;
        //        ct.ChipName = this.ChipName;
        //        ct.UseScci2 = this.UseScci2;
        //        ct.SoundLocation2A = this.SoundLocation2A;

        //        ct.InterfaceName2A = this.InterfaceName2A;
        //        ct.BusID2A = this.BusID2A;
        //        ct.SoundChip2A = this.SoundChip2A;
        //        ct.ChipName2A = this.ChipName2A;
        //        ct.SoundLocation2B = this.SoundLocation2B;

        //        ct.InterfaceName2B = this.InterfaceName2B;
        //        ct.BusID2B = this.BusID2B;
        //        ct.SoundChip2B = this.SoundChip2B;
        //        ct.ChipName2B = this.ChipName2B;

        //        ct.UseWait = this.UseWait;
        //        ct.UseWaitBoost = this.UseWaitBoost;
        //        ct.OnlyPCMEmulation = this.OnlyPCMEmulation;
        //        ct.LatencyForEmulation = this.LatencyForEmulation;
        //        ct.LatencyForScci = this.LatencyForScci;
        //        ct.Type = this.Type;

        //        return ct;
        //    }
        //}

        [Serializable]
        public class Network
        {
            public bool useMDServer { get; set; }=false;
            public int port { get; set; } = 11000;

            public Network Copy()
            {
                Network network = new()
                {
                    useMDServer = this.useMDServer,
                    port = this.port,
                };

                return network;
            }
        }

        [Serializable]
        public class Other
        {
            private bool _UseLoopTimes = true;
            public bool UseLoopTimes
            {
                get
                {
                    return _UseLoopTimes;
                }

                set
                {
                    _UseLoopTimes = value;
                }
            }

            private int _LoopTimes = 2;
            public int LoopTimes
            {
                get
                {
                    return _LoopTimes;
                }

                set
                {
                    _LoopTimes = value;
                }
            }


            private bool _UseGetInst = true;
            public bool UseGetInst
            {
                get
                {
                    return _UseGetInst;
                }

                set
                {
                    _UseGetInst = value;
                }
            }

            private string _DefaultDataPath = "";
            public string DefaultDataPath
            {
                get
                {
                    return _DefaultDataPath;
                }

                set
                {
                    _DefaultDataPath = value;
                }
            }

            private EnmInstFormat _InstFormat = EnmInstFormat.MML2VGM;
            public EnmInstFormat InstFormat
            {
                get
                {
                    return _InstFormat;
                }

                set
                {
                    _InstFormat = value;
                }
            }

            private int _Zoom = 1;
            public int Zoom
            {
                get
                {
                    return _Zoom;
                }

                set
                {
                    _Zoom = value;
                }
            }

            private int _ScreenFrameRate = 60;
            public int ScreenFrameRate
            {
                get
                {
                    return _ScreenFrameRate;
                }

                set
                {
                    _ScreenFrameRate = value;
                }
            }

            private bool _AutoOpen = false;
            public bool AutoOpen
            {
                get
                {
                    return _AutoOpen;
                }

                set
                {
                    _AutoOpen = value;
                }
            }

            private bool _DumpSwitch = false;
            public bool DumpSwitch
            {
                get
                {
                    return _DumpSwitch;
                }

                set
                {
                    _DumpSwitch = value;
                }
            }

            private string _DumpPath = "";
            public string DumpPath
            {
                get
                {
                    return _DumpPath;
                }

                set
                {
                    _DumpPath = value;
                }
            }

            private bool _WavSwitch = false;
            public bool WavSwitch
            {
                get
                {
                    return _WavSwitch;
                }

                set
                {
                    _WavSwitch = value;
                }
            }

            private string _WavPath = "";
            public string WavPath
            {
                get
                {
                    return _WavPath;
                }

                set
                {
                    _WavPath = value;
                }
            }

            private int _FilterIndex = 0;
            public int FilterIndex
            {
                get
                {
                    return _FilterIndex;
                }

                set
                {
                    _FilterIndex = value;
                }
            }

            private string _TextExt = "txt;doc;hed";
            public string TextExt { get => _TextExt; set => _TextExt = value; }

            private string _MMLExt = "mml;gwi;muc;mdl";
            public string MMLExt { get => _MMLExt; set => _MMLExt = value; }

            private string _ImageExt = "jpg;gif;png;mag";
            public string ImageExt { get => _ImageExt; set => _ImageExt = value; }

            private bool _AutoOpenText = false;
            public bool AutoOpenText { get => _AutoOpenText; set => _AutoOpenText = value; }
            private bool _AutoOpenMML = false;
            public bool AutoOpenMML { get => _AutoOpenMML; set => _AutoOpenMML = value; }
            private bool _AutoOpenImg = false;
            public bool AutoOpenImg { get => _AutoOpenImg; set => _AutoOpenImg = value; }

            private bool _InitAlways = false;
            public bool InitAlways { get => _InitAlways; set => _InitAlways = value; }

            private bool _EmptyPlayList = false;
            public bool EmptyPlayList { get => _EmptyPlayList; set => _EmptyPlayList = value; }
            public bool ExAll { get; set; } = false;
            public bool NonRenderingForPause { get; set; } = false;
            public bool AdjustTLParam { get; set; } = false;
            public string ResourceFile { get; set; } = null;
            public bool SaveCompiledFile { get; set; } = false;
            public bool TappyMode { get;  set; }=true;

            public Other Copy()
            {
                Other other = new()
                {
                    UseLoopTimes = this.UseLoopTimes,
                    LoopTimes = this.LoopTimes,
                    UseGetInst = this.UseGetInst,
                    DefaultDataPath = this.DefaultDataPath,
                    InstFormat = this.InstFormat,
                    Zoom = this.Zoom,
                    ScreenFrameRate = this.ScreenFrameRate,
                    AutoOpen = this.AutoOpen,
                    DumpSwitch = this.DumpSwitch,
                    DumpPath = this.DumpPath,
                    WavSwitch = this.WavSwitch,
                    WavPath = this.WavPath,
                    FilterIndex = this.FilterIndex,
                    TextExt = this.TextExt,
                    MMLExt = this.MMLExt,
                    ImageExt = this.ImageExt,
                    AutoOpenText = this.AutoOpenText,
                    AutoOpenMML = this.AutoOpenMML,
                    AutoOpenImg = this.AutoOpenImg,
                    InitAlways = this.InitAlways,
                    EmptyPlayList = this.EmptyPlayList,
                    ExAll = this.ExAll,
                    NonRenderingForPause = this.NonRenderingForPause,
                    AdjustTLParam = this.AdjustTLParam,
                    ResourceFile = this.ResourceFile,
                    SaveCompiledFile = this.SaveCompiledFile,
                    TappyMode=this.TappyMode,
                };

                return other;
            }
        }

        [Serializable]
        public class Debug
        {
            public LogLevel LogLevel { get; set; } = LogLevel.Information;
            public bool debugOPZ { get; set; } = false;
            public bool DispFrameCounter { get; set; } = false;
            public int SCCbaseAddress { get; set; } = 0x9800;
            public bool logDebug { get; set; } = false;
            public bool ShowConsole { get; set; } = false;
            public LogLevel logLevel { get; set; } = LogLevel.Information;

            public Debug Copy()
            {
                Debug dbg = new()
                {
                    LogLevel = this.LogLevel,
                    debugOPZ = this.debugOPZ,
                    DispFrameCounter = this.DispFrameCounter,
                    SCCbaseAddress = this.SCCbaseAddress,
                    logDebug = this.logDebug,
                    logLevel = this.logLevel,
                    ShowConsole = this.ShowConsole
                };

                return dbg;
            }
        }


        [Serializable]
        public class Balance
        {

            private int _MasterVolume = 0;
            public int MasterVolume
            {
                get
                {
                    if (_MasterVolume > 20 || _MasterVolume < -192) _MasterVolume = 0;
                    return _MasterVolume;
                }

                set
                {
                    _MasterVolume = value;
                    if (_MasterVolume > 20 || _MasterVolume < -192) _MasterVolume = 0;
                }
            }

            private int _YM2612Volume = 0;
            public int YM2612Volume
            {
                get
                {
                    if (_YM2612Volume > 20 || _YM2612Volume < -192) _YM2612Volume = 0;
                    return _YM2612Volume;
                }

                set
                {
                    _YM2612Volume = value;
                    if (_YM2612Volume > 20 || _YM2612Volume < -192) _YM2612Volume = 0;
                }
            }

            private int _SN76489Volume = 0;
            public int SN76489Volume
            {
                get
                {
                    if (_SN76489Volume > 20 || _SN76489Volume < -192) _SN76489Volume = 0;
                    return _SN76489Volume;
                }

                set
                {
                    _SN76489Volume = value;
                    if (_SN76489Volume > 20 || _SN76489Volume < -192) _SN76489Volume = 0;
                }
            }

            private int _RF5C68Volume = 0;
            public int RF5C68Volume
            {
                get
                {
                    if (_RF5C68Volume > 20 || _RF5C68Volume < -192) _RF5C68Volume = 0;
                    return _RF5C68Volume;
                }

                set
                {
                    _RF5C68Volume = value;
                    if (_RF5C68Volume > 20 || _RF5C68Volume < -192) _RF5C68Volume = 0;
                }
            }

            private int _RF5C164Volume = 0;
            public int RF5C164Volume
            {
                get
                {
                    if (_RF5C164Volume > 20 || _RF5C164Volume < -192) _RF5C164Volume = 0;
                    return _RF5C164Volume;
                }

                set
                {
                    _RF5C164Volume = value;
                    if (_RF5C164Volume > 20 || _RF5C164Volume < -192) _RF5C164Volume = 0;
                }
            }

            private int _PWMVolume = 0;
            public int PWMVolume
            {
                get
                {
                    if (_PWMVolume > 20 || _PWMVolume < -192) _PWMVolume = 0;
                    return _PWMVolume;
                }

                set
                {
                    _PWMVolume = value;
                    if (_PWMVolume > 20 || _PWMVolume < -192) _PWMVolume = 0;
                }
            }

            private int _C140Volume = 0;
            public int C140Volume
            {
                get
                {
                    if (_C140Volume > 20 || _C140Volume < -192) _C140Volume = 0;
                    return _C140Volume;
                }

                set
                {
                    _C140Volume = value;
                    if (_C140Volume > 20 || _C140Volume < -192) _C140Volume = 0;
                }
            }

            private int _OKIM6258Volume = 0;
            public int OKIM6258Volume
            {
                get
                {
                    if (_OKIM6258Volume > 20 || _OKIM6258Volume < -192) _OKIM6258Volume = 0;
                    return _OKIM6258Volume;
                }

                set
                {
                    _OKIM6258Volume = value;
                    if (_OKIM6258Volume > 20 || _OKIM6258Volume < -192) _OKIM6258Volume = 0;
                }
            }

            private int _OKIM6295Volume = 0;
            public int OKIM6295Volume
            {
                get
                {
                    if (_OKIM6295Volume > 20 || _OKIM6295Volume < -192) _OKIM6295Volume = 0;
                    return _OKIM6295Volume;
                }

                set
                {
                    _OKIM6295Volume = value;
                    if (_OKIM6295Volume > 20 || _OKIM6295Volume < -192) _OKIM6295Volume = 0;
                }
            }

            private int _SEGAPCMVolume = 0;
            public int SEGAPCMVolume
            {
                get
                {
                    if (_SEGAPCMVolume > 20 || _SEGAPCMVolume < -192) _SEGAPCMVolume = 0;
                    return _SEGAPCMVolume;
                }

                set
                {
                    _SEGAPCMVolume = value;
                    if (_SEGAPCMVolume > 20 || _SEGAPCMVolume < -192) _SEGAPCMVolume = 0;
                }
            }

            private int _AY8910Volume = 0;
            public int AY8910Volume
            {
                get
                {
                    if (_AY8910Volume > 20 || _AY8910Volume < -192) _AY8910Volume = 0;
                    return _AY8910Volume;
                }

                set
                {
                    _AY8910Volume = value;
                    if (_AY8910Volume > 20 || _AY8910Volume < -192) _AY8910Volume = 0;
                }
            }

            private int _YM2413Volume = 0;
            public int YM2413Volume
            {
                get
                {
                    if (_YM2413Volume > 20 || _YM2413Volume < -192) _YM2413Volume = 0;
                    return _YM2413Volume;
                }

                set
                {
                    _YM2413Volume = value;
                    if (_YM2413Volume > 20 || _YM2413Volume < -192) _YM2413Volume = 0;
                }
            }

            private int _YM3526Volume = 0;
            public int YM3526Volume
            {
                get
                {
                    if (_YM3526Volume > 20 || _YM3526Volume < -192) _YM3526Volume = 0;
                    return _YM3526Volume;
                }

                set
                {
                    _YM3526Volume = value;
                    if (_YM3526Volume > 20 || _YM3526Volume < -192) _YM3526Volume = 0;
                }
            }

            private int _Y8950Volume = 0;
            public int Y8950Volume
            {
                get
                {
                    if (_Y8950Volume > 20 || _Y8950Volume < -192) _Y8950Volume = 0;
                    return _Y8950Volume;
                }

                set
                {
                    _Y8950Volume = value;
                    if (_Y8950Volume > 20 || _Y8950Volume < -192) _Y8950Volume = 0;
                }
            }

            private int _HuC6280Volume = 0;
            public int HuC6280Volume
            {
                get
                {
                    if (_HuC6280Volume > 20 || _HuC6280Volume < -192) _HuC6280Volume = 0;
                    return _HuC6280Volume;
                }

                set
                {
                    _HuC6280Volume = value;
                    if (_HuC6280Volume > 20 || _HuC6280Volume < -192) _HuC6280Volume = 0;
                }
            }

            private int _YM2151Volume = 0;
            public int YM2151Volume
            {
                get
                {
                    if (_YM2151Volume > 20 || _YM2151Volume < -192) _YM2151Volume = 0;
                    return _YM2151Volume;
                }

                set
                {
                    _YM2151Volume = value;
                    if (_YM2151Volume > 20 || _YM2151Volume < -192) _YM2151Volume = 0;
                }
            }

            private int _YM2608Volume = 0;
            public int YM2608Volume
            {
                get
                {
                    if (_YM2608Volume > 20 || _YM2608Volume < -192) _YM2608Volume = 0;
                    return _YM2608Volume;
                }

                set
                {
                    _YM2608Volume = value;
                    if (_YM2608Volume > 20 || _YM2608Volume < -192) _YM2608Volume = 0;
                }
            }

            private int _YM2608FMVolume = 0;
            public int YM2608FMVolume
            {
                get
                {
                    if (_YM2608FMVolume > 20 || _YM2608FMVolume < -192) _YM2608FMVolume = 0;
                    return _YM2608FMVolume;
                }

                set
                {
                    _YM2608FMVolume = value;
                    if (_YM2608FMVolume > 20 || _YM2608FMVolume < -192) _YM2608FMVolume = 0;
                }
            }

            private int _YM2608PSGVolume = 0;
            public int YM2608PSGVolume
            {
                get
                {
                    if (_YM2608PSGVolume > 20 || _YM2608PSGVolume < -192) _YM2608PSGVolume = 0;
                    return _YM2608PSGVolume;
                }

                set
                {
                    _YM2608PSGVolume = value;
                    if (_YM2608PSGVolume > 20 || _YM2608PSGVolume < -192) _YM2608PSGVolume = 0;
                }
            }

            private int _YM2608RhythmVolume = 0;
            public int YM2608RhythmVolume
            {
                get
                {
                    if (_YM2608RhythmVolume > 20 || _YM2608RhythmVolume < -192) _YM2608RhythmVolume = 0;
                    return _YM2608RhythmVolume;
                }

                set
                {
                    _YM2608RhythmVolume = value;
                    if (_YM2608RhythmVolume > 20 || _YM2608RhythmVolume < -192) _YM2608RhythmVolume = 0;
                }
            }

            private int _YM2608AdpcmVolume = 0;
            public int YM2608AdpcmVolume
            {
                get
                {
                    if (_YM2608AdpcmVolume > 20 || _YM2608AdpcmVolume < -192) _YM2608AdpcmVolume = 0;
                    return _YM2608AdpcmVolume;
                }

                set
                {
                    _YM2608AdpcmVolume = value;
                    if (_YM2608AdpcmVolume > 20 || _YM2608AdpcmVolume < -192) _YM2608AdpcmVolume = 0;
                }
            }

            private int _YM2203Volume = 0;
            public int YM2203Volume
            {
                get
                {
                    if (_YM2203Volume > 20 || _YM2203Volume < -192) _YM2203Volume = 0;
                    return _YM2203Volume;
                }

                set
                {
                    _YM2203Volume = value;
                    if (_YM2203Volume > 20 || _YM2203Volume < -192) _YM2203Volume = 0;
                }
            }

            private int _YM2203FMVolume = 0;
            public int YM2203FMVolume
            {
                get
                {
                    if (_YM2203FMVolume > 20 || _YM2203FMVolume < -192) _YM2203FMVolume = 0;
                    return _YM2203FMVolume;
                }

                set
                {
                    _YM2203FMVolume = value;
                    if (_YM2203FMVolume > 20 || _YM2203FMVolume < -192) _YM2203FMVolume = 0;
                }
            }

            private int _YM2203PSGVolume = 0;
            public int YM2203PSGVolume
            {
                get
                {
                    if (_YM2203PSGVolume > 20 || _YM2203PSGVolume < -192) _YM2203PSGVolume = 0;
                    return _YM2203PSGVolume;
                }

                set
                {
                    _YM2203PSGVolume = value;
                    if (_YM2203PSGVolume > 20 || _YM2203PSGVolume < -192) _YM2203PSGVolume = 0;
                }
            }

            private int _YM2610Volume = 0;
            public int YM2610Volume
            {
                get
                {
                    if (_YM2610Volume > 20 || _YM2610Volume < -192) _YM2610Volume = 0;
                    return _YM2610Volume;
                }

                set
                {
                    _YM2610Volume = value;
                    if (_YM2610Volume > 20 || _YM2610Volume < -192) _YM2610Volume = 0;
                }
            }

            private int _YM2610FMVolume = 0;
            public int YM2610FMVolume
            {
                get
                {
                    if (_YM2610FMVolume > 20 || _YM2610FMVolume < -192) _YM2610FMVolume = 0;
                    return _YM2610FMVolume;
                }

                set
                {
                    _YM2610FMVolume = value;
                    if (_YM2610FMVolume > 20 || _YM2610FMVolume < -192) _YM2610FMVolume = 0;
                }
            }

            private int _YM2610PSGVolume = 0;
            public int YM2610PSGVolume
            {
                get
                {
                    if (_YM2610PSGVolume > 20 || _YM2610PSGVolume < -192) _YM2610PSGVolume = 0;
                    return _YM2610PSGVolume;
                }

                set
                {
                    _YM2610PSGVolume = value;
                    if (_YM2610PSGVolume > 20 || _YM2610PSGVolume < -192) _YM2610PSGVolume = 0;
                }
            }

            private int _YM2610AdpcmAVolume = 0;
            public int YM2610AdpcmAVolume
            {
                get
                {
                    if (_YM2610AdpcmAVolume > 20 || _YM2610AdpcmAVolume < -192) _YM2610AdpcmAVolume = 0;
                    return _YM2610AdpcmAVolume;
                }

                set
                {
                    _YM2610AdpcmAVolume = value;
                    if (_YM2610AdpcmAVolume > 20 || _YM2610AdpcmAVolume < -192) _YM2610AdpcmAVolume = 0;
                }
            }

            private int _YM2610AdpcmBVolume = 0;
            public int YM2610AdpcmBVolume
            {
                get
                {
                    if (_YM2610AdpcmBVolume > 20 || _YM2610AdpcmBVolume < -192) _YM2610AdpcmBVolume = 0;
                    return _YM2610AdpcmBVolume;
                }

                set
                {
                    _YM2610AdpcmBVolume = value;
                    if (_YM2610AdpcmBVolume > 20 || _YM2610AdpcmBVolume < -192) _YM2610AdpcmBVolume = 0;
                }
            }

            private int _YM3812Volume = 0;
            public int YM3812Volume
            {
                get
                {
                    if (_YM3812Volume > 20 || _YM3812Volume < -192) _YM3812Volume = 0;
                    return _YM3812Volume;
                }

                set
                {
                    _YM3812Volume = value;
                    if (_YM3812Volume > 20 || _YM3812Volume < -192) _YM3812Volume = 0;
                }
            }

            private int _C352Volume = 0;
            public int C352Volume
            {
                get
                {
                    if (_C352Volume > 20 || _C352Volume < -192) _C352Volume = 0;
                    return _C352Volume;
                }

                set
                {
                    _C352Volume = value;
                    if (_C352Volume > 20 || _C352Volume < -192) _C352Volume = 0;
                }
            }

            private int _SAA1099Volume = 0;
            public int SAA1099Volume
            {
                get
                {
                    if (_SAA1099Volume > 20 || _SAA1099Volume < -192) _SAA1099Volume = 0;
                    return _SAA1099Volume;
                }

                set
                {
                    _SAA1099Volume = value;
                    if (_SAA1099Volume > 20 || _SAA1099Volume < -192) _SAA1099Volume = 0;
                }
            }

            private int _ES5503Volume = 0;
            public int ES5503Volume
            {
                get
                {
                    if (_ES5503Volume > 20 || _ES5503Volume < -192) _ES5503Volume = 0;
                    return _ES5503Volume;
                }

                set
                {
                    _ES5503Volume = value;
                    if (_ES5503Volume > 20 || _ES5503Volume < -192) _ES5503Volume = 0;
                }
            }

            private int _WSwanVolume = 0;
            public int WSwanVolume
            {
                get
                {
                    if (_WSwanVolume > 20 || _WSwanVolume < -192) _WSwanVolume = 0;
                    return _WSwanVolume;
                }

                set
                {
                    _WSwanVolume = value;
                    if (_WSwanVolume > 20 || _WSwanVolume < -192) _WSwanVolume = 0;
                }
            }

            private int _POKEYVolume = 0;
            public int POKEYVolume
            {
                get
                {
                    if (_POKEYVolume > 20 || _POKEYVolume < -192) _POKEYVolume = 0;
                    return _POKEYVolume;
                }

                set
                {
                    _POKEYVolume = value;
                    if (_POKEYVolume > 20 || _POKEYVolume < -192) _POKEYVolume = 0;
                }
            }

            private int _X1_010Volume = 0;
            public int X1_010Volume
            {
                get
                {
                    if (_X1_010Volume > 20 || _X1_010Volume < -192) _X1_010Volume = 0;
                    return _X1_010Volume;
                }

                set
                {
                    _X1_010Volume = value;
                    if (_X1_010Volume > 20 || _X1_010Volume < -192) _X1_010Volume = 0;
                }
            }

            private int _K054539Volume = 0;
            public int K054539Volume
            {
                get
                {
                    if (_K054539Volume > 20 || _K054539Volume < -192) _K054539Volume = 0;
                    return _K054539Volume;
                }

                set
                {
                    _K054539Volume = value;
                    if (_K054539Volume > 20 || _K054539Volume < -192) _K054539Volume = 0;
                }
            }

            private int _APUVolume = 0;
            public int APUVolume
            {
                get
                {
                    if (_APUVolume > 20 || _APUVolume < -192) _APUVolume = 0;
                    return _APUVolume;
                }

                set
                {
                    _APUVolume = value;
                    if (_APUVolume > 20 || _APUVolume < -192) _APUVolume = 0;
                }
            }

            private int _DMCVolume = 0;
            public int DMCVolume
            {
                get
                {
                    if (_DMCVolume > 20 || _DMCVolume < -192) _DMCVolume = 0;
                    return _DMCVolume;
                }

                set
                {
                    _DMCVolume = value;
                    if (_DMCVolume > 20 || _DMCVolume < -192) _DMCVolume = 0;
                }
            }

            private int _FDSVolume = 0;
            public int FDSVolume
            {
                get
                {
                    if (_FDSVolume > 20 || _FDSVolume < -192) _FDSVolume = 0;
                    return _FDSVolume;
                }

                set
                {
                    _FDSVolume = value;
                    if (_FDSVolume > 20 || _FDSVolume < -192) _FDSVolume = 0;
                }
            }

            private int _MMC5Volume = 0;
            public int MMC5Volume
            {
                get
                {
                    if (_MMC5Volume > 20 || _MMC5Volume < -192) _MMC5Volume = 0;
                    return _MMC5Volume;
                }

                set
                {
                    _MMC5Volume = value;
                    if (_MMC5Volume > 20 || _MMC5Volume < -192) _MMC5Volume = 0;
                }
            }

            private int _N160Volume = 0;
            public int N160Volume
            {
                get
                {
                    if (_N160Volume > 20 || _N160Volume < -192) _N160Volume = 0;
                    return _N160Volume;
                }

                set
                {
                    _N160Volume = value;
                    if (_N160Volume > 20 || _N160Volume < -192) _N160Volume = 0;
                }
            }

            private int _VRC6Volume = 0;
            public int VRC6Volume
            {
                get
                {
                    if (_VRC6Volume > 20 || _VRC6Volume < -192) _VRC6Volume = 0;
                    return _VRC6Volume;
                }

                set
                {
                    _VRC6Volume = value;
                    if (_VRC6Volume > 20 || _VRC6Volume < -192) _VRC6Volume = 0;
                }
            }

            private int _VRC7Volume = 0;
            public int VRC7Volume
            {
                get
                {
                    if (_VRC7Volume > 20 || _VRC7Volume < -192) _VRC7Volume = 0;
                    return _VRC7Volume;
                }

                set
                {
                    _VRC7Volume = value;
                    if (_VRC7Volume > 20 || _VRC7Volume < -192) _VRC7Volume = 0;
                }
            }

            private int _FME7Volume = 0;
            public int FME7Volume
            {
                get
                {
                    if (_FME7Volume > 20 || _FME7Volume < -192) _FME7Volume = 0;
                    return _FME7Volume;
                }

                set
                {
                    _FME7Volume = value;
                    if (_FME7Volume > 20 || _FME7Volume < -192) _FME7Volume = 0;
                }
            }

            private int _DMGVolume = 0;
            public int DMGVolume
            {
                get
                {
                    if (_DMGVolume > 20 || _DMGVolume < -192) _DMGVolume = 0;
                    return _DMGVolume;
                }

                set
                {
                    _DMGVolume = value;
                    if (_DMGVolume > 20 || _DMGVolume < -192) _DMGVolume = 0;
                }
            }

            private int _GA20Volume = 0;
            public int GA20Volume
            {
                get
                {
                    if (_GA20Volume > 20 || _GA20Volume < -192) _GA20Volume = 0;
                    return _GA20Volume;
                }

                set
                {
                    _GA20Volume = value;
                    if (_GA20Volume > 20 || _GA20Volume < -192) _GA20Volume = 0;
                }
            }

            private int _YMZ280BVolume = 0;
            public int YMZ280BVolume
            {
                get
                {
                    if (_YMZ280BVolume > 20 || _YMZ280BVolume < -192) _YMZ280BVolume = 0;
                    return _YMZ280BVolume;
                }

                set
                {
                    _YMZ280BVolume = value;
                    if (_YMZ280BVolume > 20 || _YMZ280BVolume < -192) _YMZ280BVolume = 0;
                }
            }

            private int _YMF271Volume = 0;
            public int YMF271Volume
            {
                get
                {
                    if (_YMF271Volume > 20 || _YMF271Volume < -192) _YMF271Volume = 0;
                    return _YMF271Volume;
                }

                set
                {
                    _YMF271Volume = value;
                    if (_YMF271Volume > 20 || _YMF271Volume < -192) _YMF271Volume = 0;
                }
            }

            private int _YMF262Volume = 0;
            public int YMF262Volume
            {
                get
                {
                    if (_YMF262Volume > 20 || _YMF262Volume < -192) _YMF262Volume = 0;
                    return _YMF262Volume;
                }

                set
                {
                    _YMF262Volume = value;
                    if (_YMF262Volume > 20 || _YMF262Volume < -192) _YMF262Volume = 0;
                }
            }

            private int _YMF278BVolume = 0;
            public int YMF278BVolume
            {
                get
                {
                    if (_YMF278BVolume > 20 || _YMF278BVolume < -192) _YMF278BVolume = 0;
                    return _YMF278BVolume;
                }

                set
                {
                    _YMF278BVolume = value;
                    if (_YMF278BVolume > 20 || _YMF278BVolume < -192) _YMF278BVolume = 0;
                }
            }

            private int _MultiPCMVolume = 0;
            public int MultiPCMVolume
            {
                get
                {
                    if (_MultiPCMVolume > 20 || _MultiPCMVolume < -192) _MultiPCMVolume = 0;
                    return _MultiPCMVolume;
                }

                set
                {
                    _MultiPCMVolume = value;
                    if (_MultiPCMVolume > 20 || _MultiPCMVolume < -192) _MultiPCMVolume = 0;
                }
            }

            private int _uPD7759Volume = 0;
            public int uPD7759Volume
            {
                get
                {
                    if (_uPD7759Volume > 20 || _uPD7759Volume < -192) _uPD7759Volume = 0;
                    return _uPD7759Volume;
                }

                set
                {
                    _uPD7759Volume = value;
                    if (_uPD7759Volume > 20 || _uPD7759Volume < -192) _uPD7759Volume = 0;
                }
            }

            private int _QSoundVolume = 0;
            public int QSoundVolume
            {
                get
                {
                    if (_QSoundVolume > 20 || _QSoundVolume < -192) _QSoundVolume = 0;
                    return _QSoundVolume;
                }

                set
                {
                    _QSoundVolume = value;
                    if (_QSoundVolume > 20 || _QSoundVolume < -192) _QSoundVolume = 0;
                }
            }

            private int _K051649Volume = 0;
            public int K051649Volume
            {
                get
                {
                    if (_K051649Volume > 20 || _K051649Volume < -192) _K051649Volume = 0;
                    return _K051649Volume;
                }

                set
                {
                    _K051649Volume = value;
                    if (_K051649Volume > 20 || _K051649Volume < -192) _K051649Volume = 0;
                }
            }

            private int _K053260Volume = 0;
            public int K053260Volume
            {
                get
                {
                    if (_K053260Volume > 20 || _K053260Volume < -192) _K053260Volume = 0;
                    return _K053260Volume;
                }

                set
                {
                    _K053260Volume = value;
                    if (_K053260Volume > 20 || _K053260Volume < -192) _K053260Volume = 0;
                }
            }


            private int _PPZ8Volume = 0;
            public int PPZ8Volume
            {
                get
                {
                    if (_PPZ8Volume > 20 || _PPZ8Volume < -192) _PPZ8Volume = 0;
                    return _PPZ8Volume;
                }

                set
                {
                    _PPZ8Volume = value;
                    if (_PPZ8Volume > 20 || _PPZ8Volume < -192) _PPZ8Volume = 0;
                }
            }

            private int _PCM8Volume = 0;
            public int PCM8Volume
            {
                get
                {
                    if (_PCM8Volume > 20 || _PCM8Volume < -192) _PCM8Volume = 0;
                    return _PCM8Volume;
                }

                set
                {
                    _PCM8Volume = value;
                    if (_PCM8Volume > 20 || _PCM8Volume < -192) _PCM8Volume = 0;
                }
            }

            private int _PCM8PPVolume = 0;
            public int PCM8PPVolume
            {
                get
                {
                    if (_PCM8PPVolume > 20 || _PCM8PPVolume < -192) _PCM8PPVolume = 0;
                    return _PCM8PPVolume;
                }

                set
                {
                    _PCM8PPVolume = value;
                    if (_PCM8PPVolume > 20 || _PCM8PPVolume < -192) _PCM8PPVolume = 0;
                }
            }

            private int _MPCMX68kVolume = 0;
            public int MPCMX68kVolume
            {
                get
                {
                    if (_MPCMX68kVolume > 20 || _MPCMX68kVolume < -192) _MPCMX68kVolume = 0;
                    return _MPCMX68kVolume;
                }

                set
                {
                    _MPCMX68kVolume = value;
                    if (_MPCMX68kVolume > 20 || _MPCMX68kVolume < -192) _MPCMX68kVolume = 0;
                }
            }


            private int _GimicOPNVolume = 0;
            public int GimicOPNVolume
            {
                get
                {
                    if (_GimicOPNVolume > 127 || _GimicOPNVolume < 0) _GimicOPNVolume = 30;
                    return _GimicOPNVolume;
                }

                set
                {
                    _GimicOPNVolume = value;
                    if (_GimicOPNVolume > 127 || _GimicOPNVolume < 0) _GimicOPNVolume = 30;
                }
            }

            private int _GimicOPNAVolume = 0;
            public int GimicOPNAVolume
            {
                get
                {
                    if (_GimicOPNAVolume > 127 || _GimicOPNAVolume < 0) _GimicOPNAVolume = 30;
                    return _GimicOPNAVolume;
                }

                set
                {
                    _GimicOPNAVolume = value;
                    if (_GimicOPNAVolume > 127 || _GimicOPNAVolume < 0) _GimicOPNAVolume = 30;
                }
            }

            public Balance Copy()
            {
                Balance Balance = new()
                {
                    MasterVolume = this.MasterVolume,
                    YM2151Volume = this.YM2151Volume,
                    YM2203Volume = this.YM2203Volume,
                    YM2203FMVolume = this.YM2203FMVolume,
                    YM2203PSGVolume = this.YM2203PSGVolume,
                    YM2413Volume = this.YM2413Volume,
                    YM2608Volume = this.YM2608Volume,
                    YM2608FMVolume = this.YM2608FMVolume,
                    YM2608PSGVolume = this.YM2608PSGVolume,
                    YM2608RhythmVolume = this.YM2608RhythmVolume,
                    YM2608AdpcmVolume = this.YM2608AdpcmVolume,
                    YM2610Volume = this.YM2610Volume,
                    YM2610FMVolume = this.YM2610FMVolume,
                    YM2610PSGVolume = this.YM2610PSGVolume,
                    YM2610AdpcmAVolume = this.YM2610AdpcmAVolume,
                    YM2610AdpcmBVolume = this.YM2610AdpcmBVolume,

                    YM2612Volume = this.YM2612Volume,
                    AY8910Volume = this.AY8910Volume,
                    SN76489Volume = this.SN76489Volume,
                    HuC6280Volume = this.HuC6280Volume,
                    SAA1099Volume = this.SAA1099Volume,
                    ES5503Volume = this.ES5503Volume,

                    RF5C164Volume = this.RF5C164Volume,
                    RF5C68Volume = this.RF5C68Volume,
                    PWMVolume = this.PWMVolume,
                    OKIM6258Volume = this.OKIM6258Volume,
                    OKIM6295Volume = this.OKIM6295Volume,
                    C140Volume = this.C140Volume,
                    SEGAPCMVolume = this.SEGAPCMVolume,
                    C352Volume = this.C352Volume,
                    K051649Volume = this.K051649Volume,
                    K053260Volume = this.K053260Volume,
                    K054539Volume = this.K054539Volume,
                    QSoundVolume = this.QSoundVolume,
                    MultiPCMVolume = this.MultiPCMVolume,

                    APUVolume = this.APUVolume,
                    DMCVolume = this.DMCVolume,
                    FDSVolume = this.FDSVolume,
                    MMC5Volume = this.MMC5Volume,
                    N160Volume = this.N160Volume,
                    VRC6Volume = this.VRC6Volume,
                    VRC7Volume = this.VRC7Volume,
                    FME7Volume = this.FME7Volume,
                    DMGVolume = this.DMGVolume,
                    GA20Volume = this.GA20Volume,
                    YMZ280BVolume = this.YMZ280BVolume,
                    YMF271Volume = this.YMF271Volume,
                    YMF262Volume = this.YMF262Volume,
                    YMF278BVolume = this.YMF278BVolume,
                    YM3526Volume = this.YM3526Volume,
                    Y8950Volume = this.Y8950Volume,
                    YM3812Volume = this.YM3812Volume,

                    PPZ8Volume = this.PPZ8Volume,
                    PCM8Volume = this.PCM8Volume,
                    PCM8PPVolume = this.PCM8PPVolume,
                    MPCMX68kVolume = this.MPCMX68kVolume,

                    GimicOPNVolume = this.GimicOPNVolume,
                    GimicOPNAVolume = this.GimicOPNAVolume
                };

                return Balance;
            }

            public void Save(string fullPath)
            {
                XmlSerializer serializer = new(typeof(Balance), typeof(Balance).GetNestedTypes());
                using StreamWriter sw = new(fullPath, false, new UTF8Encoding(false));
                serializer.Serialize(sw, this);
            }

            public static Balance Load(string fullPath)
            {
                try
                {
                    if (!File.Exists(fullPath)) return null;
                    XmlSerializer serializer = new(typeof(Balance), typeof(Balance).GetNestedTypes());
                    using StreamReader sr = new(fullPath, new UTF8Encoding(false));
                    return (Balance)serializer.Deserialize(sr);
                }
                catch (Exception ex)
                {
                    log.ForcedWrite(ex);
                    return null;
                }
            }

        }

        [Serializable]
        public class Location
        {
            public class Form
            {
                public Point Point
                {
                    get
                    {
                        if (_Point.X < 0 || _Point.Y < 0)
                        {
                            return new Point(0, 0);
                        }
                        return _Point;
                    }

                    set
                    {
                        _Point = value;
                    }
                }
                private Point _Point = Point.Empty;

                public bool IsOpen { get; set; } = false;
                public System.Windows.Forms.FormWindowState State { get; set; } = FormWindowState.Normal;
                public Size Size { get; set; } = Size.Empty;

                public Form Copy()
                {
                    Form n = new()
                    {
                        Point = this.Point,
                        IsOpen = this.IsOpen,
                        State = this.State,
                        Size = this.Size
                    };

                    return n;
                }
            }

            public Form Main = new();

            private Point _PInfo = Point.Empty;
            public Point PInfo
            {
                get
                {
                    if (_PInfo.X < 0 || _PInfo.Y < 0)
                    {
                        return new Point(0, 0);
                    }
                    return _PInfo;
                }

                set
                {
                    _PInfo = value;
                }
            }

            private bool _OInfo = false;
            public bool OInfo
            {
                get
                {
                    return _OInfo;
                }

                set
                {
                    _OInfo = value;
                }
            }

            private Point _PPic = Point.Empty;
            public Point PPic
            {
                get
                {
                    if (_PPic.X < 0 || _PPic.Y < 0)
                    {
                        return new Point(0, 0);
                    }
                    return _PPic;
                }

                set
                {
                    _PPic = value;
                }
            }

            private Point _SPic = Point.Empty;
            public Point SPic
            {
                get
                {
                    if (_SPic.X < 0 || _SPic.Y < 0)
                    {
                        return new Point(0, 0);
                    }
                    return _SPic;
                }

                set
                {
                    _SPic = value;
                }
            }

            private bool _OPic = false;
            public bool OPic
            {
                get
                {
                    return _OPic;
                }

                set
                {
                    _OPic = value;
                }
            }

            private Point _PPlayList = Point.Empty;
            public Point PPlayList
            {
                get
                {
                    if (_PPlayList.X < 0 || _PPlayList.Y < 0)
                    {
                        return new Point(0, 0);
                    }
                    return _PPlayList;
                }

                set
                {
                    _PPlayList = value;
                }
            }

            private bool _OPlayList = false;
            public bool OPlayList
            {
                get
                {
                    return _OPlayList;
                }

                set
                {
                    _OPlayList = value;
                }
            }

            private Point _PPlayListWH = Point.Empty;
            public Point PPlayListWH
            {
                get
                {
                    if (_PPlayListWH.X < 0 || _PPlayListWH.Y < 0)
                    {
                        return new Point(0, 0);
                    }
                    return _PPlayListWH;
                }

                set
                {
                    _PPlayListWH = value;
                }
            }

            private Point _PMixer = Point.Empty;
            public Point PMixer
            {
                get
                {
                    if (_PMixer.X < 0 || _PMixer.Y < 0)
                    {
                        return new Point(0, 0);
                    }
                    return _PMixer;
                }

                set
                {
                    _PMixer = value;
                }
            }

            private bool _OMixer = false;
            public bool OMixer
            {
                get
                {
                    return _OMixer;
                }

                set
                {
                    _OMixer = value;
                }
            }

            private Point _PMixerWH = Point.Empty;
            public Point PMixerWH
            {
                get
                {
                    if (_PMixerWH.X < 0 || _PMixerWH.Y < 0)
                    {
                        return new Point(0, 0);
                    }
                    return _PMixerWH;
                }

                set
                {
                    _PMixerWH = value;
                }
            }

            private Point[] _PosRf5c164 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosRf5c164
            {
                get
                {
                    return _PosRf5c164;
                }

                set
                {
                    _PosRf5c164 = value;
                }
            }

            private bool[] _OpenRf5c164 = new bool[2] { false, false };
            public bool[] OpenRf5c164
            {
                get
                {
                    return _OpenRf5c164;
                }

                set
                {
                    _OpenRf5c164 = value;
                }
            }


            private Point[] _PosRf5c68 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosRf5c68
            {
                get
                {
                    return _PosRf5c68;
                }

                set
                {
                    _PosRf5c68 = value;
                }
            }

            private bool[] _OpenRf5c68 = new bool[2] { false, false };
            public bool[] OpenRf5c68
            {
                get
                {
                    return _OpenRf5c68;
                }

                set
                {
                    _OpenRf5c68 = value;
                }
            }

            private Point[] _PosYMF271 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYMF271
            {
                get
                {
                    return _PosYMF271;
                }

                set
                {
                    _PosYMF271 = value;
                }
            }

            private bool[] _OpenYMF271 = new bool[2] { false, false };
            public bool[] OpenYMF271
            {
                get
                {
                    return _OpenYMF271;
                }

                set
                {
                    _OpenYMF271 = value;
                }
            }

            private Point[] _PosC140 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosC140
            {
                get
                {
                    return _PosC140;
                }

                set
                {
                    _PosC140 = value;
                }
            }

            private bool[] _OpenC140 = new bool[2] { false, false };
            public bool[] OpenC140
            {
                get
                {
                    return _OpenC140;
                }

                set
                {
                    _OpenC140 = value;
                }
            }

            private Point[] _PosS5B = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosS5B
            {
                get
                {
                    return _PosS5B;
                }

                set
                {
                    _PosS5B = value;
                }
            }

            private bool[] _OpenS5B = new bool[2] { false, false };
            public bool[] OpenS5B
            {
                get
                {
                    return _OpenS5B;
                }

                set
                {
                    _OpenS5B = value;
                }
            }

            private Point[] _PosDMG = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosDMG
            {
                get
                {
                    return _PosDMG;
                }

                set
                {
                    _PosDMG = value;
                }
            }

            private bool[] _OpenDMG = new bool[2] { false, false };
            public bool[] OpenDMG
            {
                get
                {
                    return _OpenDMG;
                }

                set
                {
                    _OpenDMG = value;
                }
            }

            private Point[] _PosPPZ8 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosPPZ8
            {
                get
                {
                    return _PosPPZ8;
                }

                set
                {
                    _PosPPZ8 = value;
                }
            }

            private bool[] _OpenPPZ8 = new bool[2] { false, false };
            public bool[] OpenPPZ8
            {
                get
                {
                    return _OpenPPZ8;
                }

                set
                {
                    _OpenPPZ8 = value;
                }
            }

            private Point[] _PosYMZ280B = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYMZ280B
            {
                get
                {
                    return _PosYMZ280B;
                }

                set
                {
                    _PosYMZ280B = value;
                }
            }

            private bool[] _OpenYMZ280B = new bool[2] { false, false };
            public bool[] OpenYMZ280B
            {
                get
                {
                    return _OpenYMZ280B;
                }

                set
                {
                    _OpenYMZ280B = value;
                }
            }

            private Point[] _PosK053260 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosK053260
            {
                get
                {
                    return _PosK053260;
                }

                set
                {
                    _PosK053260 = value;
                }
            }

            private bool[] _OpenK053260 = new bool[2] { false, false };
            public bool[] OpenK053260
            {
                get
                {
                    return _OpenK053260;
                }

                set
                {
                    _OpenK053260 = value;
                }
            }

            private Point[] _PosC352 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosC352
            {
                get
                {
                    return _PosC352;
                }

                set
                {
                    _PosC352 = value;
                }
            }

            private bool[] _OpenC352 = new bool[2] { false, false };
            public bool[] OpenC352
            {
                get
                {
                    return _OpenC352;
                }

                set
                {
                    _OpenC352 = value;
                }
            }

            private Point[] _PosGA20 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosGA20
            {
                get
                {
                    return _PosGA20;
                }

                set
                {
                    _PosGA20 = value;
                }
            }

            private bool[] _OpenGA20 = new bool[2] { false, false };
            public bool[] OpenGA20
            {
                get
                {
                    return _OpenGA20;
                }

                set
                {
                    _OpenGA20 = value;
                }
            }


            private Point[] _PosK054539 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosK054539
            {
                get
                {
                    return _PosK054539;
                }

                set
                {
                    _PosK054539 = value;
                }
            }

            private bool[] _OpenK054539 = new bool[2] { false, false };
            public bool[] OpenK054539
            {
                get
                {
                    return _OpenK054539;
                }

                set
                {
                    _OpenK054539 = value;
                }
            }


            private Point[] _PosMultiPCM = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosMultiPCM
            {
                get
                {
                    return _PosMultiPCM;
                }

                set
                {
                    _PosMultiPCM = value;
                }
            }

            private bool[] _OpenMultiPCM = new bool[2] { false, false };
            public bool[] OpenMultiPCM
            {
                get
                {
                    return _OpenMultiPCM;
                }

                set
                {
                    _OpenMultiPCM = value;
                }
            }

            private bool[] _OpenQSound = new bool[2] { false, false };
            public bool[] OpenQSound
            {
                get
                {
                    return _OpenQSound;
                }

                set
                {
                    _OpenQSound = value;
                }
            }

            private Point[] _PosYm2151 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYm2151
            {
                get
                {
                    return _PosYm2151;
                }

                set
                {
                    _PosYm2151 = value;
                }
            }

            private bool[] _OpenYm2151 = new bool[2] { false, false };
            public bool[] OpenYm2151
            {
                get
                {
                    return _OpenYm2151;
                }

                set
                {
                    _OpenYm2151 = value;
                }
            }

            private Point[] _PosYm2608 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYm2608
            {
                get
                {
                    return _PosYm2608;
                }

                set
                {
                    _PosYm2608 = value;
                }
            }

            private bool[] _OpenYm2608 = new bool[2] { false, false };
            public bool[] OpenYm2608
            {
                get
                {
                    return _OpenYm2608;
                }

                set
                {
                    _OpenYm2608 = value;
                }
            }

            private Point[] _PosYm2609 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYm2609
            {
                get
                {
                    return _PosYm2609;
                }

                set
                {
                    _PosYm2609 = value;
                }
            }

            private bool[] _OpenYm2609 = new bool[2] { false, false };
            public bool[] OpenYm2609
            {
                get
                {
                    return _OpenYm2609;
                }

                set
                {
                    _OpenYm2609 = value;
                }
            }

            private Point[] _PosYm2203 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYm2203
            {
                get
                {
                    return _PosYm2203;
                }

                set
                {
                    _PosYm2203 = value;
                }
            }

            private bool[] _OpenYm2203 = new bool[2] { false, false };
            public bool[] OpenYm2203
            {
                get
                {
                    return _OpenYm2203;
                }

                set
                {
                    _OpenYm2203 = value;
                }
            }

            private Point[] _PosYm2610 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYm2610
            {
                get
                {
                    return _PosYm2610;
                }

                set
                {
                    _PosYm2610 = value;
                }
            }

            private bool[] _OpenYm2610 = new bool[2] { false, false };
            public bool[] OpenYm2610
            {
                get
                {
                    return _OpenYm2610;
                }

                set
                {
                    _OpenYm2610 = value;
                }
            }

            private Point[] _PosYm2612 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYm2612
            {
                get
                {
                    return _PosYm2612;
                }

                set
                {
                    _PosYm2612 = value;
                }
            }

            private bool[] _OpenYm2612 = new bool[2] { false, false };
            public bool[] OpenYm2612
            {
                get
                {
                    return _OpenYm2612;
                }

                set
                {
                    _OpenYm2612 = value;
                }
            }

            private Point[] _PosOKIM6258 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosOKIM6258
            {
                get
                {
                    return _PosOKIM6258;
                }

                set
                {
                    _PosOKIM6258 = value;
                }
            }

            private bool[] _OpenOKIM6258 = new bool[2] { false, false };
            public bool[] OpenOKIM6258
            {
                get
                {
                    return _OpenOKIM6258;
                }

                set
                {
                    _OpenOKIM6258 = value;
                }
            }

            private Point[] _PosOKIM6295 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosOKIM6295
            {
                get
                {
                    return _PosOKIM6295;
                }

                set
                {
                    _PosOKIM6295 = value;
                }
            }

            private bool[] _OpenOKIM6295 = new bool[2] { false, false };
            public bool[] OpenOKIM6295
            {
                get
                {
                    return _OpenOKIM6295;
                }

                set
                {
                    _OpenOKIM6295 = value;
                }
            }

            private Point[] _PosPCM8 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosPCM8
            {
                get
                {
                    return _PosPCM8;
                }

                set
                {
                    _PosPCM8 = value;
                }
            }

            private bool[] _OpenPCM8 = new bool[2] { false, false };
            public bool[] OpenPCM8
            {
                get
                {
                    return _OpenPCM8;
                }

                set
                {
                    _OpenPCM8 = value;
                }
            }

            private Point[] _PosMPCMX68k = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosMPCMX68k
            {
                get
                {
                    return _PosMPCMX68k;
                }

                set
                {
                    _PosMPCMX68k = value;
                }
            }

            private bool[] _OpenMPCMX68k = new bool[2] { false, false };
            public bool[] OpenMPCMX68k
            {
                get
                {
                    return _OpenMPCMX68k;
                }

                set
                {
                    _OpenMPCMX68k = value;
                }
            }


            private Point[] _PosSN76489 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosSN76489
            {
                get
                {
                    return _PosSN76489;
                }

                set
                {
                    _PosSN76489 = value;
                }
            }

            private bool[] _OpenSN76489 = new bool[2] { false, false };
            public bool[] OpenSN76489
            {
                get
                {
                    return _OpenSN76489;
                }

                set
                {
                    _OpenSN76489 = value;
                }
            }

            private Point[] _PosMIDI = new Point[4] { Point.Empty, Point.Empty, Point.Empty, Point.Empty };
            public Point[] PosMIDI
            {
                get
                {
                    return _PosMIDI;
                }

                set
                {
                    _PosMIDI = value;
                }
            }

            private bool[] _OpenMIDI = new bool[4] { false, false, false, false };
            public bool[] OpenMIDI
            {
                get
                {
                    return _OpenMIDI;
                }

                set
                {
                    _OpenMIDI = value;
                }
            }

            private Point[] _PosSegaPCM = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosSegaPCM
            {
                get
                {
                    return _PosSegaPCM;
                }

                set
                {
                    _PosSegaPCM = value;
                }
            }

            private bool[] _OpenSegaPCM = new bool[2] { false, false };
            public bool[] OpenSegaPCM
            {
                get
                {
                    return _OpenSegaPCM;
                }

                set
                {
                    _OpenSegaPCM = value;
                }
            }

            private Point[] _PosAY8910 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosAY8910
            {
                get
                {
                    return _PosAY8910;
                }

                set
                {
                    _PosAY8910 = value;
                }
            }

            private bool[] _OpenAY8910 = new bool[2] { false, false };
            public bool[] OpenAY8910
            {
                get
                {
                    return _OpenAY8910;
                }

                set
                {
                    _OpenAY8910 = value;
                }
            }

            private Point[] _PosHuC6280 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosHuC6280
            {
                get
                {
                    return _PosHuC6280;
                }

                set
                {
                    _PosHuC6280 = value;
                }
            }

            private bool[] _OpenHuC6280 = new bool[2] { false, false };
            public bool[] OpenHuC6280
            {
                get
                {
                    return _OpenHuC6280;
                }

                set
                {
                    _OpenHuC6280 = value;
                }
            }

            private Point[] _PosK051649 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosK051649
            {
                get
                {
                    return _PosK051649;
                }

                set
                {
                    _PosK051649 = value;
                }
            }

            private bool[] _OpenK051649 = new bool[2] { false, false };
            public bool[] OpenK051649
            {
                get
                {
                    return _OpenK051649;
                }

                set
                {
                    _OpenK051649 = value;
                }
            }

            private Point[] _PosYm2413 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYm2413
            {
                get
                {
                    return _PosYm2413;
                }

                set
                {
                    _PosYm2413 = value;
                }
            }

            private bool[] _OpenYm2413 = new bool[2] { false, false };
            public bool[] OpenYm2413
            {
                get
                {
                    return _OpenYm2413;
                }

                set
                {
                    _OpenYm2413 = value;
                }
            }

            private Point[] _PosYm3526 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYm3526
            {
                get
                {
                    return _PosYm3526;
                }

                set
                {
                    _PosYm3526 = value;
                }
            }

            private bool[] _OpenYm3526 = new bool[2] { false, false };
            public bool[] OpenYm3526
            {
                get
                {
                    return _OpenYm3526;
                }

                set
                {
                    _OpenYm3526 = value;
                }
            }

            private Point[] _PosY8950 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosY8950
            {
                get
                {
                    return _PosY8950;
                }

                set
                {
                    _PosY8950 = value;
                }
            }

            private bool[] _OpenY8950 = new bool[2] { false, false };
            public bool[] OpenY8950
            {
                get
                {
                    return _OpenY8950;
                }

                set
                {
                    _OpenY8950 = value;
                }
            }

            private Point[] _PosYm3812 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYm3812
            {
                get
                {
                    return _PosYm3812;
                }

                set
                {
                    _PosYm3812 = value;
                }
            }

            private bool[] _OpenYm3812 = new bool[2] { false, false };
            public bool[] OpenYm3812
            {
                get
                {
                    return _OpenYm3812;
                }

                set
                {
                    _OpenYm3812 = value;
                }
            }

            private Point[] _PosYmf262 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYmf262
            {
                get
                {
                    return _PosYmf262;
                }

                set
                {
                    _PosYmf262 = value;
                }
            }

            private bool[] _OpenYmf262 = new bool[2] { false, false };
            public bool[] OpenYmf262
            {
                get
                {
                    return _OpenYmf262;
                }

                set
                {
                    _OpenYmf262 = value;
                }
            }

            private Point[] _PosYmf278b = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosYmf278b
            {
                get
                {
                    return _PosYmf278b;
                }

                set
                {
                    _PosYmf278b = value;
                }
            }

            private bool[] _OpenYmf278b = new bool[2] { false, false };
            public bool[] OpenYmf278b
            {
                get
                {
                    return _OpenYmf278b;
                }

                set
                {
                    _OpenYmf278b = value;
                }
            }

            private Point _PosYm2612MIDI = Point.Empty;
            public Point PosYm2612MIDI
            {
                get
                {
                    return _PosYm2612MIDI;
                }

                set
                {
                    _PosYm2612MIDI = value;
                }
            }

            private bool _OpenYm2612MIDI = false;
            public bool OpenYm2612MIDI
            {
                get
                {
                    return _OpenYm2612MIDI;
                }

                set
                {
                    _OpenYm2612MIDI = value;
                }
            }

            private Point _PosMixer = Point.Empty;
            public Point PosMixer
            {
                get
                {
                    return _PosMixer;
                }

                set
                {
                    _PosMixer = value;
                }
            }

            private bool _OpenMixer = false;
            public bool OpenMixer
            {
                get
                {
                    return _OpenMixer;
                }

                set
                {
                    _OpenMixer = value;
                }
            }

            private Point _PosVSTeffectList = Point.Empty;
            public Point PosVSTeffectList
            {
                get
                {
                    return _PosVSTeffectList;
                }

                set
                {
                    _PosVSTeffectList = value;
                }
            }

            private bool _OpenVSTeffectList = false;
            public bool OpenVSTeffectList
            {
                get
                {
                    return _OpenVSTeffectList;
                }

                set
                {
                    _OpenVSTeffectList = value;
                }
            }

            private Point[] _PosNESDMC = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosNESDMC
            {
                get
                {
                    return _PosNESDMC;
                }

                set
                {
                    _PosNESDMC = value;
                }
            }

            private bool[] _OpenNESDMC = new bool[2] { false, false };
            public bool[] OpenNESDMC
            {
                get
                {
                    return _OpenNESDMC;
                }

                set
                {
                    _OpenNESDMC = value;
                }
            }

            private Point[] _PosFDS = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosFDS
            {
                get
                {
                    return _PosFDS;
                }

                set
                {
                    _PosFDS = value;
                }
            }

            private bool[] _OpenFDS = new bool[2] { false, false };
            public bool[] OpenFDS
            {
                get
                {
                    return _OpenFDS;
                }

                set
                {
                    _OpenFDS = value;
                }
            }

            private Point[] _PosMMC5 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosMMC5
            {
                get
                {
                    return _PosMMC5;
                }

                set
                {
                    _PosMMC5 = value;
                }
            }

            private bool[] _OpenMMC5 = new bool[2] { false, false };
            public bool[] OpenMMC5
            {
                get
                {
                    return _OpenMMC5;
                }

                set
                {
                    _OpenMMC5 = value;
                }
            }

            private Point[] _PosVrc6 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosVrc6
            {
                get
                {
                    return _PosVrc6;
                }

                set
                {
                    _PosVrc6 = value;
                }
            }

            private bool[] _OpenVrc6 = new bool[2] { false, false };
            public bool[] OpenVrc6
            {
                get
                {
                    return _OpenVrc6;
                }

                set
                {
                    _OpenVrc6 = value;
                }
            }

            private Point[] _PosVrc7 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosVrc7
            {
                get
                {
                    return _PosVrc7;
                }

                set
                {
                    _PosVrc7 = value;
                }
            }

            private bool[] _OpenVrc7 = new bool[2] { false, false };
            public bool[] OpenVrc7
            {
                get
                {
                    return _OpenVrc7;
                }

                set
                {
                    _OpenVrc7 = value;
                }
            }

            private Point[] _PosN106 = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosN106
            {
                get
                {
                    return _PosN106;
                }

                set
                {
                    _PosN106 = value;
                }
            }

            private bool[] _OpenN106 = new bool[2] { false, false };
            public bool[] OpenN106
            {
                get
                {
                    return _OpenN106;
                }

                set
                {
                    _OpenN106 = value;
                }
            }

            private Point[] _PosQSound = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosQSound
            {
                get
                {
                    return _PosQSound;
                }

                set
                {
                    _PosQSound = value;
                }
            }


            private Point[] _PosRegTest = new Point[2] { Point.Empty, Point.Empty };
            public Point[] PosRegTest
            {
                get { return _PosRegTest; }
                set { _PosRegTest = value; }
            }

            private bool[] _OpenRegTest = new bool[2] { false, false };
            public bool[] OpenRegTest
            {
                get
                {
                    return _OpenRegTest;
                }

                set
                {
                    _OpenRegTest = value;
                }
            }

            private Point _PosVisWave = Point.Empty;
            public Point PosVisWave
            {
                get { return _PosVisWave; }
                set { _PosVisWave = value; }
            }

            private bool _OpenVisWave = false;
            public bool OpenVisWave
            {
                get
                {
                    return _OpenVisWave;
                }

                set
                {
                    _OpenVisWave = value;
                }
            }

            public int ChipSelect { get; set; }

            public Location Copy()
            {
                Location Location = new()
                {
                    Main = this.Main.Copy(),
                    PInfo = this.PInfo,
                    OInfo = this.OInfo,
                    PPic = this.PPic,
                    SPic = this.SPic,
                    OPic = this.OPic,
                    PPlayList = this.PPlayList,
                    OPlayList = this.OPlayList,
                    PPlayListWH = this.PPlayListWH,
                    PMixer = this.PMixer,
                    OMixer = this.OMixer,
                    PMixerWH = this.PMixerWH,
                    PosMixer = this.PosMixer,
                    OpenMixer = this.OpenMixer,
                    PosRf5c164 = this.PosRf5c164,
                    OpenRf5c164 = this.OpenRf5c164,
                    PosRf5c68 = this.PosRf5c68,
                    OpenRf5c68 = this.OpenRf5c68,
                    PosC140 = this.PosC140,
                    OpenC140 = this.OpenC140,
                    PosPPZ8 = this.PosPPZ8,
                    OpenPPZ8 = this.OpenPPZ8,
                    PosS5B = this.PosS5B,
                    OpenS5B = this.OpenS5B,
                    PosDMG = this.PosDMG,
                    OpenDMG = this.OpenDMG,
                    PosYMZ280B = this.PosYMZ280B,
                    OpenYMZ280B = this.OpenYMZ280B,
                    PosC352 = this.PosC352,
                    OpenC352 = this.OpenC352,
                    PosGA20 = this.PosGA20,
                    OpenGA20 = this.OpenGA20,
                    PosK054539 = this.PosK054539,
                    OpenK054539 = this.OpenK054539,
                    PosQSound = this.PosQSound,
                    OpenQSound = this.OpenQSound,
                    PosYm2151 = this.PosYm2151,
                    OpenYm2151 = this.OpenYm2151,
                    PosYm2608 = this.PosYm2608,
                    OpenYm2608 = this.OpenYm2608,
                    PosYm2609 = this.PosYm2609,
                    OpenYm2609 = this.OpenYm2609,
                    PosYm2203 = this.PosYm2203,
                    OpenYm2203 = this.OpenYm2203,
                    PosYm2610 = this.PosYm2610,
                    OpenYm2610 = this.OpenYm2610,
                    PosYm2612 = this.PosYm2612,
                    OpenYm2612 = this.OpenYm2612,
                    PosYm3526 = this.PosYm3526,
                    OpenYm3526 = this.OpenYm3526,
                    PosY8950 = this.PosY8950,
                    OpenY8950 = this.OpenY8950,
                    PosYm3812 = this.PosYm3812,
                    OpenYm3812 = this.OpenYm3812,
                    PosYmf262 = this.PosYmf262,
                    OpenYmf262 = this.OpenYmf262,
                    PosYMF271 = this.PosYMF271,
                    OpenYMF271 = this.OpenYMF271,
                    PosYmf278b = this.PosYmf278b,
                    OpenYmf278b = this.OpenYmf278b,
                    PosOKIM6258 = this.PosOKIM6258,
                    OpenOKIM6258 = this.OpenOKIM6258,
                    PosOKIM6295 = this.PosOKIM6295,
                    OpenOKIM6295 = this.OpenOKIM6295,
                    PosPCM8 = this.PosPCM8,
                    OpenPCM8 = this.OpenPCM8,
                    PosMPCMX68k = this.PosMPCMX68k,
                    OpenMPCMX68k = this.OpenMPCMX68k,
                    PosSN76489 = this.PosSN76489,
                    OpenSN76489 = this.OpenSN76489,
                    PosSegaPCM = this.PosSegaPCM,
                    OpenSegaPCM = this.OpenSegaPCM,
                    PosAY8910 = this.PosAY8910,
                    OpenAY8910 = this.OpenAY8910,
                    PosHuC6280 = this.PosHuC6280,
                    OpenHuC6280 = this.OpenHuC6280,
                    PosK051649 = this.PosK051649,
                    OpenK051649 = this.OpenK051649,
                    PosK053260 = this.PosK053260,
                    OpenK053260 = this.OpenK053260,
                    PosYm2612MIDI = this.PosYm2612MIDI,
                    OpenYm2612MIDI = this.OpenYm2612MIDI,
                    PosVSTeffectList = this.PosVSTeffectList,
                    OpenVSTeffectList = this.OpenVSTeffectList,
                    PosVrc7 = this.PosVrc7,
                    OpenVrc7 = this.OpenVrc7,
                    PosMIDI = this.PosMIDI,
                    OpenMIDI = this.OpenMIDI,
                    PosRegTest = this.PosRegTest,
                    OpenRegTest = this.OpenRegTest,
                    PosVisWave = this.PosVisWave,
                    OpenVisWave = this.OpenVisWave,
                    ChipSelect = this.ChipSelect
                };

                if (PosMIDI.Length < 3)
                {
                    PosMIDI = new Point[4] { PosMIDI[0], PosMIDI[1], Point.Empty, Point.Empty };
                }
                if (OpenMIDI.Length < 3)
                {
                    OpenMIDI = new bool[4] { OpenMIDI[0], OpenMIDI[1], false,false };
                }
                return Location;
            }
        }

        [Serializable]
        public class MidiExport
        {

            private bool _UseMIDIExport = false;
            public bool UseMIDIExport
            {
                get
                {
                    return _UseMIDIExport;
                }

                set
                {
                    _UseMIDIExport = value;
                }
            }

            private bool _UseYM2151Export = false;
            public bool UseYM2151Export
            {
                get
                {
                    return _UseYM2151Export;
                }

                set
                {
                    _UseYM2151Export = value;
                }
            }

            private bool _UseYM2612Export = true;
            public bool UseYM2612Export
            {
                get
                {
                    return _UseYM2612Export;
                }

                set
                {
                    _UseYM2612Export = value;
                }
            }

            private string _ExportPath = "";
            public string ExportPath
            {
                get
                {
                    return _ExportPath;
                }

                set
                {
                    _ExportPath = value;
                }
            }

            private bool _UseVOPMex = false;
            public bool UseVOPMex
            {
                get
                {
                    return _UseVOPMex;
                }

                set
                {
                    _UseVOPMex = value;
                }
            }

            private bool _KeyOnFnum = false;
            public bool KeyOnFnum
            {
                get
                {
                    return _KeyOnFnum;
                }

                set
                {
                    _KeyOnFnum = value;
                }
            }


            public MidiExport Copy()
            {
                MidiExport MidiExport = new()
                {
                    UseMIDIExport = this.UseMIDIExport,
                    UseYM2151Export = this.UseYM2151Export,
                    UseYM2612Export = this.UseYM2612Export,
                    ExportPath = this.ExportPath,
                    UseVOPMex = this.UseVOPMex,
                    KeyOnFnum = this.KeyOnFnum
                };

                return MidiExport;
            }

        }

        [Serializable]
        public class MidiKbd
        {

            private bool _UseMIDIKeyboard = false;
            public bool UseMIDIKeyboard
            {
                get
                {
                    return _UseMIDIKeyboard;
                }

                set
                {
                    _UseMIDIKeyboard = value;
                }
            }

            private string _MidiInDeviceName = "";
            public string MidiInDeviceName
            {
                get
                {
                    return _MidiInDeviceName;
                }

                set
                {
                    _MidiInDeviceName = value;
                }
            }

            private bool _IsMONO = true;
            public bool IsMONO
            {
                get
                {
                    return _IsMONO;
                }

                set
                {
                    _IsMONO = value;
                }
            }

            private int _useFormat = 0;
            public int UseFormat
            {
                get
                {
                    return _useFormat;
                }

                set
                {
                    _useFormat = value;
                }
            }

            private int _UseMONOChannel = 0;
            public int UseMONOChannel
            {
                get
                {
                    return _UseMONOChannel;
                }

                set
                {
                    _UseMONOChannel = value;
                }
            }

            private bool[] _UseChannel = new bool[9];
            public bool[] UseChannel
            {
                get
                {
                    return _UseChannel;
                }

                set
                {
                    _UseChannel = value;
                }
            }

            private Tone[] _Tones = new Tone[6];
            public Tone[] Tones
            {
                get
                {
                    return _Tones;
                }

                set
                {
                    _Tones = value;
                }
            }

            private int _MidiCtrl_CopyToneFromYM2612Ch1 = 97;
            public int MidiCtrl_CopyToneFromYM2612Ch1
            {
                get
                {
                    return _MidiCtrl_CopyToneFromYM2612Ch1;
                }

                set
                {
                    _MidiCtrl_CopyToneFromYM2612Ch1 = value;
                }
            }

            private int _MidiCtrl_DelOneLog = 96;
            public int MidiCtrl_DelOneLog
            {
                get
                {
                    return _MidiCtrl_DelOneLog;
                }

                set
                {
                    _MidiCtrl_DelOneLog = value;
                }
            }

            private int _MidiCtrl_CopySelecttingLogToClipbrd = 66;
            public int MidiCtrl_CopySelecttingLogToClipbrd
            {
                get
                {
                    return _MidiCtrl_CopySelecttingLogToClipbrd;
                }

                set
                {
                    _MidiCtrl_CopySelecttingLogToClipbrd = value;
                }
            }

            private int _MidiCtrl_Stop = -1;
            public int MidiCtrl_Stop
            {
                get
                {
                    return _MidiCtrl_Stop;
                }

                set
                {
                    _MidiCtrl_Stop = value;
                }
            }

            private int _MidiCtrl_Pause = -1;
            public int MidiCtrl_Pause
            {
                get
                {
                    return _MidiCtrl_Pause;
                }

                set
                {
                    _MidiCtrl_Pause = value;
                }
            }

            private int _MidiCtrl_Fadeout = -1;
            public int MidiCtrl_Fadeout
            {
                get
                {
                    return _MidiCtrl_Fadeout;
                }

                set
                {
                    _MidiCtrl_Fadeout = value;
                }
            }

            private int _MidiCtrl_Previous = -1;
            public int MidiCtrl_Previous
            {
                get
                {
                    return _MidiCtrl_Previous;
                }

                set
                {
                    _MidiCtrl_Previous = value;
                }
            }

            private int _MidiCtrl_Slow = -1;
            public int MidiCtrl_Slow
            {
                get
                {
                    return _MidiCtrl_Slow;
                }

                set
                {
                    _MidiCtrl_Slow = value;
                }
            }

            private int _MidiCtrl_Play = -1;
            public int MidiCtrl_Play
            {
                get
                {
                    return _MidiCtrl_Play;
                }

                set
                {
                    _MidiCtrl_Play = value;
                }
            }

            private int _MidiCtrl_Fast = -1;
            public int MidiCtrl_Fast
            {
                get
                {
                    return _MidiCtrl_Fast;
                }

                set
                {
                    _MidiCtrl_Fast = value;
                }
            }

            private int _MidiCtrl_Next = -1;
            public int MidiCtrl_Next
            {
                get
                {
                    return _MidiCtrl_Next;
                }

                set
                {
                    _MidiCtrl_Next = value;
                }
            }

            public MidiKbd Copy()
            {
                MidiKbd midiKbd = new()
                {
                    MidiInDeviceName = this.MidiInDeviceName,
                    UseMIDIKeyboard = this.UseMIDIKeyboard
                };
                for (int i = 0; i < midiKbd.UseChannel.Length; i++)
                {
                    midiKbd.UseChannel[i] = this.UseChannel[i];
                }
                midiKbd.IsMONO = this.IsMONO;
                midiKbd.UseMONOChannel = this.UseMONOChannel;

                midiKbd.MidiCtrl_CopySelecttingLogToClipbrd = this.MidiCtrl_CopySelecttingLogToClipbrd;
                midiKbd.MidiCtrl_CopyToneFromYM2612Ch1 = this.MidiCtrl_CopyToneFromYM2612Ch1;
                midiKbd.MidiCtrl_DelOneLog = this.MidiCtrl_DelOneLog;
                midiKbd.MidiCtrl_Fadeout = this.MidiCtrl_Fadeout;
                midiKbd.MidiCtrl_Fast = this.MidiCtrl_Fast;
                midiKbd.MidiCtrl_Next = this.MidiCtrl_Next;
                midiKbd.MidiCtrl_Pause = this.MidiCtrl_Pause;
                midiKbd.MidiCtrl_Play = this.MidiCtrl_Play;
                midiKbd.MidiCtrl_Previous = this.MidiCtrl_Previous;
                midiKbd.MidiCtrl_Slow = this.MidiCtrl_Slow;
                midiKbd.MidiCtrl_Stop = this.MidiCtrl_Stop;

                return midiKbd;
            }
        }

        [Serializable]
        public class KeyBoardHook
        {
            [Serializable]
            public class HookKeyInfo
            {
                private bool _Shift = false;
                private bool _Ctrl = false;
                private bool _Win = false;
                private bool _Alt = false;
                private string _Key = "(None)";

                public bool Shift { get => _Shift; set => _Shift = value; }
                public bool Ctrl { get => _Ctrl; set => _Ctrl = value; }
                public bool Win { get => _Win; set => _Win = value; }
                public bool Alt { get => _Alt; set => _Alt = value; }
                public string Key { get => _Key; set => _Key = value; }

                public HookKeyInfo Copy()
                {
                    HookKeyInfo hookKeyInfo = new()
                    {
                        Shift = this.Shift,
                        Ctrl = this.Ctrl,
                        Win = this.Win,
                        Alt = this.Alt,
                        Key = this.Key
                    };

                    return hookKeyInfo;
                }
            }

            private bool _UseKeyBoardHook = false;
            public bool UseKeyBoardHook
            {
                get
                {
                    return _UseKeyBoardHook;
                }

                set
                {
                    _UseKeyBoardHook = value;
                }
            }

            public HookKeyInfo Stop { get => _Stop; set => _Stop = value; }
            public HookKeyInfo Pause { get => _Pause; set => _Pause = value; }
            public HookKeyInfo Fadeout { get => _Fadeout; set => _Fadeout = value; }
            public HookKeyInfo Prev { get => _Prev; set => _Prev = value; }
            public HookKeyInfo Slow { get => _Slow; set => _Slow = value; }
            public HookKeyInfo Play { get => _Play; set => _Play = value; }
            public HookKeyInfo Next { get => _Next; set => _Next = value; }
            public HookKeyInfo Fast { get => _Fast; set => _Fast = value; }
            public HookKeyInfo Umv { get => _Umv; set => _Umv = value; }
            public HookKeyInfo Dmv { get => _Dmv; set => _Dmv = value; }
            public HookKeyInfo Rmv { get => _Rmv; set => _Rmv = value; }
            public HookKeyInfo Upc { get => _Upc; set => _Upc = value; }
            public HookKeyInfo Dpc { get => _Dpc; set => _Dpc = value; }
            public HookKeyInfo Ppc { get => _Ppc; set => _Ppc = value; }
            public HookKeyInfo Sd { get => _Sd; set => _Sd = value; }
            public HookKeyInfo Su { get => _Su; set => _Su = value; }
            public HookKeyInfo Sr { get => _Sr; set => _Sr = value; }
            private HookKeyInfo _Stop = new();
            private HookKeyInfo _Pause = new();
            private HookKeyInfo _Fadeout = new();
            private HookKeyInfo _Prev = new();
            private HookKeyInfo _Slow = new();
            private HookKeyInfo _Play = new();
            private HookKeyInfo _Next = new();
            private HookKeyInfo _Fast = new();
            private HookKeyInfo _Umv = new();
            private HookKeyInfo _Dmv = new();
            private HookKeyInfo _Rmv = new();
            private HookKeyInfo _Upc = new();
            private HookKeyInfo _Dpc = new();
            private HookKeyInfo _Ppc = new();
            private HookKeyInfo _Sd = new();
            private HookKeyInfo _Su = new();
            private HookKeyInfo _Sr = new();

            public KeyBoardHook Copy()
            {
                KeyBoardHook keyBoard = new()
                {
                    UseKeyBoardHook = this.UseKeyBoardHook,
                    Stop = this.Stop.Copy(),
                    Pause = this.Pause.Copy(),
                    Fadeout = this.Fadeout.Copy(),
                    Prev = this.Prev.Copy(),
                    Slow = this.Slow.Copy(),
                    Play = this.Play.Copy(),
                    Next = this.Next.Copy(),
                    Fast = this.Fast.Copy(),
                    Umv = this.Umv.Copy(),
                    Dmv = this.Dmv.Copy(),
                    Rmv = this.Rmv.Copy(),
                    Upc = this.Upc.Copy(),
                    Dpc = this.Dpc.Copy(),
                    Ppc = this.Ppc.Copy(),
                    Sd = this.Sd.Copy(),
                    Su = this.Su.Copy(),
                    Sr = this.Sr.Copy(),
                };

                return keyBoard;
            }
        }

        [Serializable]
        public class Vst
        {
            private string _DefaultPath = "";

            private string[] _VSTPluginPath = null;
            public string[] VSTPluginPath
            {
                get
                {
                    return _VSTPluginPath;
                }

                set
                {
                    _VSTPluginPath = value;
                }
            }


            private vstInfo[] _VSTInfo = null;
            public vstInfo[] VSTInfo
            {
                get
                {
                    return _VSTInfo;
                }

                set
                {
                    _VSTInfo = value;
                }
            }

            public string DefaultPath
            {
                get
                {
                    return _DefaultPath;
                }

                set
                {
                    _DefaultPath = value;
                }
            }

            public Vst Copy()
            {
                Vst vst = new()
                {
                    VSTInfo = this.VSTInfo,
                    DefaultPath = this.DefaultPath
                };

                return vst;
            }

        }

        [Serializable]
        public class MidiOut
        {
            private string _GMReset = "30:F0,7E,7F,09,01,F7";
            public string GMReset { get => _GMReset; set => _GMReset = value; }

            private string _XGReset = "30:F0,43,10,4C,00,00,7E,00,F7";
            public string XGReset { get => _XGReset; set => _XGReset = value; }

            private string _GSReset = "30:F0,41,10,42,12,40,00,7F,00,41,F7";
            public string GSReset { get => _GSReset; set => _GSReset = value; }

            private string _Custom = "";
            public string Custom { get => _Custom; set => _Custom = value; }

            private List<MidiOutInfo[]> _lstMidiOutInfo = null;
            public List<MidiOutInfo[]> lstMidiOutInfo
            {
                get
                {
                    return _lstMidiOutInfo;
                }
                set
                {
                    _lstMidiOutInfo = value;
                }
            }

            public MidiOut Copy()
            {
                MidiOut MidiOut = new()
                {
                    GMReset = this.GMReset,
                    XGReset = this.XGReset,
                    GSReset = this.GSReset,
                    Custom = this.Custom,
                    lstMidiOutInfo = this.lstMidiOutInfo
                };

                return MidiOut;
            }

        }

        [Serializable]
        public class NSF
        {
            private bool _NESUnmuteOnReset = true;
            private bool _NESNonLinearMixer = true;
            private bool _NESPhaseRefresh = true;
            private bool _NESDutySwap = false;

            private int _FDSLpf = 2000;
            private bool _FDS4085Reset = false;
            private bool _FDSWriteDisable8000 = true;

            private bool _DMCUnmuteOnReset = true;
            private bool _DMCNonLinearMixer = true;
            private bool _DMCEnable4011 = true;
            private bool _DMCEnablePnoise = true;
            private bool _DMCDPCMAntiClick = false;
            private bool _DMCRandomizeNoise = true;
            private bool _DMCTRImute = true;
            private bool _DMCTRINull = true;

            private bool _MMC5NonLinearMixer = true;
            private bool _MMC5PhaseRefresh = true;

            private bool _N160Serial = false;

            public bool NESUnmuteOnReset
            {
                get
                {
                    return _NESUnmuteOnReset;
                }

                set
                {
                    _NESUnmuteOnReset = value;
                }
            }
            public bool NESNonLinearMixer
            {
                get
                {
                    return _NESNonLinearMixer;
                }

                set
                {
                    _NESNonLinearMixer = value;
                }
            }
            public bool NESPhaseRefresh
            {
                get
                {
                    return _NESPhaseRefresh;
                }

                set
                {
                    _NESPhaseRefresh = value;
                }
            }
            public bool NESDutySwap
            {
                get
                {
                    return _NESDutySwap;
                }

                set
                {
                    _NESDutySwap = value;
                }
            }

            public int FDSLpf
            {
                get
                {
                    return _FDSLpf;
                }

                set
                {
                    _FDSLpf = value;
                }
            }
            public bool FDS4085Reset
            {
                get
                {
                    return _FDS4085Reset;
                }

                set
                {
                    _FDS4085Reset = value;
                }
            }
            public bool FDSWriteDisable8000
            {
                get
                {
                    return _FDSWriteDisable8000;
                }
                set
                {
                    _FDSWriteDisable8000 = value;
                }
            }

            public bool DMCUnmuteOnReset
            {
                get
                {
                    return _DMCUnmuteOnReset;
                }

                set
                {
                    _DMCUnmuteOnReset = value;
                }
            }
            public bool DMCNonLinearMixer
            {
                get
                {
                    return _DMCNonLinearMixer;
                }

                set
                {
                    _DMCNonLinearMixer = value;
                }
            }
            public bool DMCEnable4011
            {
                get
                {
                    return _DMCEnable4011;
                }

                set
                {
                    _DMCEnable4011 = value;
                }
            }
            public bool DMCEnablePnoise
            {
                get
                {
                    return _DMCEnablePnoise;
                }

                set
                {
                    _DMCEnablePnoise = value;
                }
            }
            public bool DMCDPCMAntiClick
            {
                get
                {
                    return _DMCDPCMAntiClick;
                }

                set
                {
                    _DMCDPCMAntiClick = value;
                }
            }
            public bool DMCRandomizeNoise
            {
                get
                {
                    return _DMCRandomizeNoise;
                }

                set
                {
                    _DMCRandomizeNoise = value;
                }
            }
            public bool DMCTRImute
            {
                get
                {
                    return _DMCTRImute;
                }

                set
                {
                    _DMCTRImute = value;
                }
            }
            public bool DMCTRINull
            {
                get
                {
                    return _DMCTRINull;
                }

                set
                {
                    _DMCTRINull = value;
                }
            }

            public bool MMC5NonLinearMixer
            {
                get
                {
                    return _MMC5NonLinearMixer;
                }

                set
                {
                    _MMC5NonLinearMixer = value;
                }
            }
            public bool MMC5PhaseRefresh
            {
                get
                {
                    return _MMC5PhaseRefresh;
                }

                set
                {
                    _MMC5PhaseRefresh = value;
                }
            }

            public bool N160Serial
            {
                get
                {
                    return _N160Serial;
                }

                set
                {
                    _N160Serial = value;
                }
            }

            public int _HPF = 92;
            public int HPF
            {
                get
                {
                    return _HPF;
                }

                set
                {
                    _HPF = value;
                }
            }

            public int _LPF = 112;
            public int LPF
            {
                get
                {
                    return _LPF;
                }

                set
                {
                    _LPF = value;
                }
            }

            public bool _DMCRandomizeTRI = false;
            public bool DMCRandomizeTRI
            {
                get
                {
                    return _DMCRandomizeTRI;
                }

                set
                {
                    _DMCRandomizeTRI = value;
                }
            }

            public bool _DMCDPCMReverse = false;
            public bool DMCDPCMReverse
            {
                get
                {
                    return _DMCDPCMReverse;
                }

                set
                {
                    _DMCDPCMReverse = value;
                }
            }

            public NSF Copy()
            {
                NSF NSF = new()
                {
                    NESUnmuteOnReset = this.NESUnmuteOnReset,
                    NESNonLinearMixer = this.NESNonLinearMixer,
                    NESPhaseRefresh = this.NESPhaseRefresh,
                    NESDutySwap = this.NESDutySwap,

                    FDSLpf = this.FDSLpf,
                    FDS4085Reset = this.FDS4085Reset,
                    FDSWriteDisable8000 = this.FDSWriteDisable8000,

                    DMCUnmuteOnReset = this.DMCUnmuteOnReset,
                    DMCNonLinearMixer = this.DMCNonLinearMixer,
                    DMCEnable4011 = this.DMCEnable4011,
                    DMCEnablePnoise = this.DMCEnablePnoise,
                    DMCDPCMAntiClick = this.DMCDPCMAntiClick,
                    DMCRandomizeNoise = this.DMCRandomizeNoise,
                    DMCTRImute = this.DMCTRImute,
                    DMCRandomizeTRI = this.DMCRandomizeTRI,
                    DMCDPCMReverse = this.DMCDPCMReverse,
                    //NSF.DMCTRINull = this.DMCTRINull;

                    MMC5NonLinearMixer = this.MMC5NonLinearMixer,
                    MMC5PhaseRefresh = this.MMC5PhaseRefresh,

                    N160Serial = this.N160Serial,

                    HPF = this.HPF,
                    LPF = this.LPF
                };

                return NSF;
            }

        }

        [Serializable]
        public class SID
        {
            public string RomKernalPath = "";
            public string RomBasicPath = "";
            public string RomCharacterPath = "";
            public int Quality = 1;
            public int OutputBufferSize = 5000;
            public int c64model = 0;
            public bool c64modelForce = false;
            public int sidmodel = 0;
            public bool sidmodelForce = false;

            public SID Copy()
            {
                SID SID = new()
                {
                    RomKernalPath = this.RomKernalPath,
                    RomBasicPath = this.RomBasicPath,
                    RomCharacterPath = this.RomCharacterPath,
                    Quality = this.Quality,
                    OutputBufferSize = this.OutputBufferSize,
                    c64model = this.c64model,
                    c64modelForce = this.c64modelForce,
                    sidmodel = this.sidmodel,
                    sidmodelForce = this.sidmodelForce
                };

                return SID;
            }
        }

        [Serializable]
        public class NukedOPN2
        {
            public int EmuType = 0;
            //ごめんGensのオプションもここ。。。
            public bool GensDACHPF = true;
            public bool GensSSGEG = true;

            public NukedOPN2 Copy()
            {
                NukedOPN2 no = new()
                {
                    EmuType = this.EmuType,
                    GensDACHPF = this.GensDACHPF,
                    GensSSGEG = this.GensSSGEG
                };

                return no;
            }
        }

        [Serializable]
        public class AutoBalance
        {
            private bool _UseThis = false;
            private bool _LoadSongBalance = false;
            private bool _LoadDriverBalance = false;
            private bool _SaveSongBalance = false;
            private bool _SamePositionAsSongData = false;

            public bool UseThis { get => _UseThis; set => _UseThis = value; }
            public bool LoadSongBalance { get => _LoadSongBalance; set => _LoadSongBalance = value; }
            public bool LoadDriverBalance { get => _LoadDriverBalance; set => _LoadDriverBalance = value; }
            public bool SaveSongBalance { get => _SaveSongBalance; set => _SaveSongBalance = value; }
            public bool SamePositionAsSongData { get => _SamePositionAsSongData; set => _SamePositionAsSongData = value; }

            public AutoBalance Copy()
            {
                AutoBalance AutoBalance = new()
                {
                    UseThis = this.UseThis,
                    LoadSongBalance = this.LoadSongBalance,
                    LoadDriverBalance = this.LoadDriverBalance,
                    SaveSongBalance = this.SaveSongBalance,
                    SamePositionAsSongData = this.SamePositionAsSongData
                };

                return AutoBalance;
            }
        }

        [Serializable]
        public class PMDDotNET
        {
            public string compilerArguments = "/v /C";
            public bool isAuto = true;
            public int soundBoard = 1;
            public bool usePPSDRV = true;
            public bool usePPZ8 = true;
            public string driverArguments = "";
            public bool setManualVolume = false;
            public bool usePPSDRVUseInterfaceDefaultFreq = true;
            public int PPSDRVManualFreq = 2000;
            public int PPSDRVManualWait = 1;
            public int volumeFM = 0;
            public int volumeSSG = 0;
            public int volumeRhythm = 0;
            public int volumeAdpcm = 0;
            public int volumeGIMICSSG = 31;

            public PMDDotNET Copy()
            {
                PMDDotNET p = new()
                {
                    compilerArguments = this.compilerArguments,
                    isAuto = this.isAuto,
                    soundBoard = this.soundBoard,
                    usePPSDRV = this.usePPSDRV,
                    usePPZ8 = this.usePPZ8,
                    driverArguments = this.driverArguments,
                    setManualVolume = this.setManualVolume,
                    usePPSDRVUseInterfaceDefaultFreq = this.usePPSDRVUseInterfaceDefaultFreq,
                    PPSDRVManualFreq = this.PPSDRVManualFreq,
                    PPSDRVManualWait = this.PPSDRVManualWait,
                    volumeFM = this.volumeFM,
                    volumeSSG = this.volumeSSG,
                    volumeRhythm = this.volumeRhythm,
                    volumeAdpcm = this.volumeAdpcm,
                    volumeGIMICSSG = this.volumeGIMICSSG
                };

                return p;
            }
        }

        [Serializable]
        public class Zmusic
        {
            public int compilePriority = 0;
            public int pcm8type = 1;
            public int mpcmtype = 1;
            public int waitNextPlay = 1000;
            public int pcm8ppSoption = -1;

            public Zmusic Copy()
            {
                Zmusic p = new()
                {
                    compilePriority = this.compilePriority,
                    pcm8type = this.pcm8type,
                    mpcmtype = this.mpcmtype,
                    waitNextPlay = this.waitNextPlay,
                    pcm8ppSoption=this.pcm8ppSoption,
                };

                return p;
            }
        }

        [Serializable]
        public class Mxdrv
        {
            public int pcm8type = 1;
            public int pcm8ppSoption = -1;

            public Mxdrv Copy()
            {
                Mxdrv p = new()
                {
                    pcm8type = this.pcm8type,
                    pcm8ppSoption = this.pcm8ppSoption,
                };

                return p;
            }
        }

        [Serializable]
        public class Mndrv
        {
            public int mpcmtype = 1;

            public Mndrv Copy()
            {
                Mndrv p = new()
                {
                    mpcmtype = this.mpcmtype,
                };

                return p;
            }
        }

        [Serializable]
        public class Rcs
        {
            public int pcm8type = 1;//PCM8PPがデフォルト

            public Rcs Copy()
            {
                Rcs p = new()
                {
                    pcm8type = this.pcm8type,
                };

                return p;
            }
        }

        [Serializable]
        public class PlayList
        {
            public dgvColumnInfo[] clmInfo { get; set; } = null;

            public bool isJP { get; set; } = false;
            public int cwExt { get; set; } = -1;
            public int cwType { get; set; } = -1;
            public int cwTitle { get; set; } = -1;
            public int cwTitleJ { get; set; } = -1;
            public int cwFilename { get; set; } = -1;
            public int cwSupportFilename { get; set; } = -1;
            public int cwGame { get; set; } = -1;
            public int cwGameJ { get; set; } = -1;
            public int cwComposer { get; set; } = -1;
            public int cwComposerJ { get; set; } = -1;
            public int cwVGMby { get; set; } = -1;
            public int cwRelease { get; set; } = -1;
            public int cwNotes { get; set; } = -1;
            public int cwDuration { get; set; } = -1;
            public int cwVersion { get; set; } = -1;
            public int cwUseChips { get; set; } = -1;
            public int cwPL_FileName { get; set; } = -1;
            public int cwPL_Title { get; set; } = -1;
            public int splitterDistance { get; set; } = 0;
            public string[] plList { get; set; } = null;
            public int currentPlayList { get; set; } = 0;

            public PlayList Copy()
            {
                PlayList p = new PlayList()
                {
                    clmInfo=this.clmInfo,
                    isJP = this.isJP,
                    cwExt = this.cwExt,
                    cwType = this.cwType,
                    cwTitle = this.cwTitle,
                    cwTitleJ = this.cwTitleJ,
                    cwFilename = this.cwFilename,
                    cwSupportFilename = this.cwSupportFilename,
                    cwGame = this.cwGame,
                    cwGameJ = this.cwGameJ,
                    cwComposer = this.cwComposer,
                    cwComposerJ = this.cwComposerJ,
                    cwVGMby = this.cwVGMby,
                    cwRelease = this.cwRelease,
                    cwNotes = this.cwNotes,
                    cwDuration = this.cwDuration,
                    cwVersion = this.cwVersion,
                    cwUseChips = this.cwUseChips,
                    cwPL_FileName = this.cwPL_FileName,
                    cwPL_Title = this.cwPL_Title,
                    splitterDistance = this.splitterDistance,
                    plList = this.plList,
                    currentPlayList = this.currentPlayList,
                };

                return p;
            }
        }

        //多音源対応
        [Serializable]
        public class ChipType2
        {
            private bool[] _UseEmu = null;
            public bool[] UseEmu
            {
                get
                {
                    return _UseEmu;
                }

                set
                {
                    _UseEmu = value;
                }
            }

            private bool[] _UseReal = null;
            public bool[] UseReal
            {
                get
                {
                    return _UseReal;
                }

                set
                {
                    _UseReal = value;
                }
            }

            private RealChipInfo[] _realChipInfo = null;
            public RealChipInfo[] realChipInfo
            {
                get
                {
                    return _realChipInfo;
                }

                set
                {
                    _realChipInfo = value;
                }
            }

            public class RealChipInfo
            {
                //Chip共通　識別情報

                private int _InterfaceType = -1;
                public int InterfaceType
                {
                    get
                    {
                        return _InterfaceType;
                    }

                    set
                    {
                        _InterfaceType = value;
                    }
                }

                private int _SoundLocation = -1;
                public int SoundLocation
                {
                    get
                    {
                        return _SoundLocation;
                    }

                    set
                    {
                        _SoundLocation = value;
                    }
                }

                private int _BusID = -1;
                public int BusID
                {
                    get
                    {
                        return _BusID;
                    }

                    set
                    {
                        _BusID = value;
                    }
                }

                private int _SoundChip = -1;
                public int SoundChip
                {
                    get
                    {
                        return _SoundChip;
                    }

                    set
                    {
                        _SoundChip = value;
                    }
                }

                private int _ChipType = 0;
                public int ChipType
                {
                    get
                    {
                        return _ChipType;
                    }

                    set
                    {
                        _ChipType = value;
                    }
                }

                private string _InterfaceName = "";
                public string InterfaceName
                {
                    get
                    {
                        return _InterfaceName;
                    }

                    set
                    {
                        _InterfaceName = value;
                    }
                }

                private string _ChipName = "";
                public string ChipName
                {
                    get
                    {
                        return _ChipName;
                    }

                    set
                    {
                        _ChipName = value;
                    }
                }



                //Chip固有の追加設定

                //ウエイトコマンドをSCCIに送るか
                private bool _UseWait = true;
                public bool UseWait
                {
                    get
                    {
                        return _UseWait;
                    }

                    set
                    {
                        _UseWait = value;
                    }
                }

                //ウエイトコマンドを2倍にするか
                private bool _UseWaitBoost = false;
                public bool UseWaitBoost
                {
                    get
                    {
                        return _UseWaitBoost;
                    }

                    set
                    {
                        _UseWaitBoost = value;
                    }
                }

                //PCMのみエミュレーションするか
                private bool _OnlyPCMEmulation = false;
                public bool OnlyPCMEmulation
                {
                    get
                    {
                        return _OnlyPCMEmulation;
                    }

                    set
                    {
                        _OnlyPCMEmulation = value;
                    }
                }

                public RealChipInfo Copy()
                {
                    RealChipInfo ret = new()
                    {
                        InterfaceType = this.InterfaceType,
                        SoundLocation = this.SoundLocation,
                        BusID = this.BusID,
                        SoundChip = this.SoundChip,
                        ChipType = this.ChipType,
                        InterfaceName = this.InterfaceName,
                        ChipName = this.ChipName,

                        UseWait = this.UseWait,
                        UseWaitBoost = this.UseWaitBoost,
                        OnlyPCMEmulation = this.OnlyPCMEmulation,
                    };

                    return ret;
                }
            }

            private bool _exchgPAN = false;
            public bool exchgPAN { get; set; }

            //Emulation時の遅延時間

            private int _LatencyForEmulation = 0;
            public int LatencyForEmulation
            {
                get
                {
                    return _LatencyForEmulation;
                }

                set
                {
                    _LatencyForEmulation = value;
                }
            }

            //Real時の遅延時間

            private int _LatencyForReal = 0;
            public int LatencyForReal
            {
                get
                {
                    return _LatencyForReal;
                }

                set
                {
                    _LatencyForReal = value;
                }
            }

            private bool[] _useRealChipFreqDiff = null;
            public bool[] UseRealChipFreqDiff { get => _useRealChipFreqDiff; set => _useRealChipFreqDiff = value; }

            private bool[] _useRealChipAutoAdjust = null;
            public bool[] UseRealChipAutoAdjust { get => _useRealChipAutoAdjust; set => _useRealChipAutoAdjust = value; }

            //YM2149モードにするか
            private bool _YM2149mode = false;
            public bool YM2149mode
            {
                get
                {
                    return _YM2149mode;
                }

                set
                {
                    _YM2149mode = value;
                }
            }


            public ChipType2 Copy()
            {
                ChipType2 ct = new()
                {
                    UseEmu = null
                };
                if (this.UseEmu != null)
                {
                    ct.UseEmu = new bool[this.UseEmu.Length];
                    for (int i = 0; i < this.UseEmu.Length; i++) ct.UseEmu[i] = this.UseEmu[i];
                }

                ct.UseReal = null;
                if (this.UseReal != null)
                {
                    ct.UseReal = new bool[this.UseReal.Length];
                    for (int i = 0; i < this.UseReal.Length; i++) ct.UseReal[i] = this.UseReal[i];
                }

                ct.realChipInfo = null;
                if (this.realChipInfo != null)
                {
                    ct.realChipInfo = new RealChipInfo[this.realChipInfo.Length];
                    for (int i = 0; i < this.realChipInfo.Length; i++) if (this.realChipInfo[i] != null) ct.realChipInfo[i] = this.realChipInfo[i].Copy();
                }

                ct.LatencyForEmulation = this.LatencyForEmulation;
                ct.LatencyForReal = this.LatencyForReal;
                ct.UseRealChipFreqDiff = this.UseRealChipFreqDiff;
                ct.UseRealChipAutoAdjust = this.UseRealChipAutoAdjust;
                ct.exchgPAN = this.exchgPAN;
                ct.YM2149mode = this.YM2149mode;

                return ct;
            }
        }



        public Setting Copy()
        {
            Setting setting = new()
            {
                outputDevice = this.outputDevice.Copy(),

                AY8910Type = null
            };
            if (this.AY8910Type != null)
            {
                setting.AY8910Type = new ChipType2[this.AY8910Type.Length];
                for (int i = 0; i < this.AY8910Type.Length; i++) setting.AY8910Type[i] = this.AY8910Type[i].Copy();
            }

            setting.K051649Type = null;
            if (this.K051649Type != null)
            {
                setting.K051649Type = new ChipType2[this.K051649Type.Length];
                for (int i = 0; i < this.K051649Type.Length; i++) setting.K051649Type[i] = this.K051649Type[i].Copy();
            }

            setting.YM2151Type = null;
            if (this.YM2151Type != null)
            {
                setting.YM2151Type = new ChipType2[this.YM2151Type.Length];
                for (int i = 0; i < this.YM2151Type.Length; i++) setting.YM2151Type[i] = this.YM2151Type[i].Copy();
            }

            setting.YM2203Type = null;
            if (this.YM2203Type != null)
            {
                setting.YM2203Type = new ChipType2[this.YM2203Type.Length];
                for (int i = 0; i < this.YM2203Type.Length; i++) setting.YM2203Type[i] = this.YM2203Type[i].Copy();
            }

            setting.YM2413Type = null;
            if (this.YM2413Type != null)
            {
                setting.YM2413Type = new ChipType2[this.YM2413Type.Length];
                for (int i = 0; i < this.YM2413Type.Length; i++) setting.YM2413Type[i] = this.YM2413Type[i].Copy();
            }

            setting.YM2608Type = null;
            if (this.YM2608Type != null)
            {
                setting.YM2608Type = new ChipType2[this.YM2608Type.Length];
                for (int i = 0; i < this.YM2608Type.Length; i++) setting.YM2608Type[i] = this.YM2608Type[i].Copy();
            }

            setting.YM2610Type = null;
            if (this.YM2610Type != null)
            {
                setting.YM2610Type = new ChipType2[this.YM2610Type.Length];
                for (int i = 0; i < this.YM2610Type.Length; i++) setting.YM2610Type[i] = this.YM2610Type[i].Copy();
            }

            setting.YM2612Type = null;
            if (this.YM2612Type != null)
            {
                setting.YM2612Type = new ChipType2[this.YM2612Type.Length];
                for (int i = 0; i < this.YM2612Type.Length; i++) setting.YM2612Type[i] = this.YM2612Type[i].Copy();
            }

            setting.YM3526Type = null;
            if (this.YM3526Type != null)
            {
                setting.YM3526Type = new ChipType2[this.YM3526Type.Length];
                for (int i = 0; i < this.YM3526Type.Length; i++) setting.YM3526Type[i] = this.YM3526Type[i].Copy();
            }

            setting.YM3812Type = null;
            if (this.YM3812Type != null)
            {
                setting.YM3812Type = new ChipType2[this.YM3812Type.Length];
                for (int i = 0; i < this.YM3812Type.Length; i++) setting.YM3812Type[i] = this.YM3812Type[i].Copy();
            }

            setting.YMF262Type = null;
            if (this.YMF262Type != null)
            {
                setting.YMF262Type = new ChipType2[this.YMF262Type.Length];
                for (int i = 0; i < this.YMF262Type.Length; i++) setting.YMF262Type[i] = this.YMF262Type[i].Copy();
            }

            setting.SN76489Type = null;
            if (this.SN76489Type != null)
            {
                setting.SN76489Type = new ChipType2[this.SN76489Type.Length];
                for (int i = 0; i < this.SN76489Type.Length; i++) setting.SN76489Type[i] = this.SN76489Type[i].Copy();
            }

            setting.C140Type = null;
            if (this.C140Type != null)
            {
                setting.C140Type = new ChipType2[this.C140Type.Length];
                for (int i = 0; i < this.C140Type.Length; i++) setting.C140Type[i] = this.C140Type[i].Copy();
            }

            setting.ES5503Type = null;
            if (this.ES5503Type != null)
            {
                setting.ES5503Type = new ChipType2[this.ES5503Type.Length];
                for (int i = 0; i < this.ES5503Type.Length; i++) setting.ES5503Type[i] = this.ES5503Type[i].Copy();
            }

            setting.SEGAPCMType = null;
            if (this.SEGAPCMType != null)
            {
                setting.SEGAPCMType = new ChipType2[this.SEGAPCMType.Length];
                for (int i = 0; i < this.SEGAPCMType.Length; i++) setting.SEGAPCMType[i] = this.SEGAPCMType[i].Copy();
            }

            setting.unuseRealChip = this.unuseRealChip;
            setting.FileSearchPathList = this.FileSearchPathList;

            setting.other = this.other.Copy();
            setting.network = this.network.Copy();
            setting.debug = this.debug.Copy();
            setting.balance = this.balance.Copy();
            setting.LatencyEmulation = this.LatencyEmulation;
            setting.LatencySCCI = this.LatencySCCI;
            setting.HiyorimiMode = this.HiyorimiMode;
            setting.playMode = this.playMode;

            setting.location = this.location.Copy();
            setting.midiExport = this.midiExport.Copy();
            setting.midiKbd = this.midiKbd.Copy();
            setting.vst = this.vst.Copy();
            setting.midiOut = this.midiOut.Copy();
            setting.nsf = this.nsf.Copy();
            setting.sid = this.sid.Copy();
            setting.nukedOPN2 = this.nukedOPN2.Copy();
            setting.autoBalance = this.autoBalance.Copy();
            setting.pmdDotNET = this.pmdDotNET.Copy();
            setting.zmusic = this.zmusic.Copy();
            setting.mxdrv = this.mxdrv.Copy();
            setting.mndrv = this.mndrv.Copy();
            setting.rcs = this.rcs.Copy();
            setting.playList = this.playList.Copy();

            setting.keyBoardHook = this.keyBoardHook.Copy();

            return setting;
        }

        public void Save()
        {
            string fullPath = Common.settingFilePath;
            fullPath = Path.Combine(fullPath, Resources.cntSettingFileName);

            XmlSerializer serializer = new(typeof(Setting), typeof(Setting).GetNestedTypes());
            using StreamWriter sw = new(fullPath, false, new UTF8Encoding(false));
            serializer.Serialize(sw, this);
        }

        public static Setting Load()
        {
            try
            {
                string fn = Resources.cntSettingFileName;
                if (System.IO.File.Exists(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), fn)))
                {
                    //アプリケーションと同じフォルダに設定ファイルがあるならそちらを使用する
                    Common.settingFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                }
                else
                {
                    //上記以外は、アプリケーション向けデータフォルダを使用する
                    Common.settingFilePath = Common.GetApplicationDataFolder(true);
                }

                string fullPath = Common.settingFilePath;
                fullPath = Path.Combine(fullPath, Resources.cntSettingFileName);

                if (!File.Exists(fullPath)) { return new Setting(); }
                XmlSerializer serializer = new(typeof(Setting), typeof(Setting).GetNestedTypes());
                using StreamReader sr = new(fullPath, new UTF8Encoding(false));

                Setting sett= (Setting)serializer.Deserialize(sr); 

                ////調整処理

                //MIDI鍵盤用配列拡張
                if (sett.location.PosMIDI.Length < 3)
                {
                    sett.location.PosMIDI = new Point[4] { sett.location.PosMIDI[0], sett.location.PosMIDI[1], Point.Empty, Point.Empty };
                }
                if (sett.location.OpenMIDI.Length < 3)
                {
                    sett.location.OpenMIDI = new bool[4] { sett.location.OpenMIDI[0], sett.location.OpenMIDI[1], false, false };
                }

                return sett;
            }
            catch (Exception ex)
            {
                log.ForcedWrite(ex);
                return new Setting();
            }
        }

    }
}
