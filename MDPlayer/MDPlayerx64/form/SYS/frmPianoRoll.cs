using Driver.libsidplayfp.sidtune;
using MDPlayer;
using MDPlayer.Driver.FMP;
using MDPlayerx64;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MDPlayer.Setting;

namespace MDPlayer.form
{
    public partial class frmPianoRoll : frmBase
    {
        public bool isClosed = false;
        public int x = -1;
        public int y = -1;

        private FrameBuffer frameBuffer = new FrameBuffer();
        private int zoom = 1;
        Image img = new Bitmap(1024, 8 * 12 * 4);
        private PianoRollMng pianoRollMng = null;

        //private List<Note> lstNotes = new List<Note>();
        private const double FREQ = 44100;
        private long tick = 0;
        private int noteHeight = 4;
        private int noteThin = 3;
        private int playLine = (int)FREQ;//1秒(44100Hz)
        private double mul = 1 / FREQ * 200.0;
        private int[] kn = new int[] { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1 };

        public frmPianoRoll(frmMain frm)
        {
            parent = frm;
            pianoRollMng = Audio.pianoRollMng;

            InitializeComponent();
            frameBuffer.Add(pbScreen, img, null, zoom);
        }

        private void frmPianoRoll_Shown(object sender, EventArgs e)
        {
        }

        private void frmPianoRoll_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                parent.setting.location.PosPianoRoll = Location;
            }
            else
            {
                parent.setting.location.PosPianoRoll = RestoreBounds.Location;
            }
            isClosed = true;
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private void frmPianoRoll_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x, y);
        }

        public void screenChangeParams()
        {
        }

        public void screenDrawParams()
        {
            int x;
            int len;

            tick = Audio.GetDriverCounter();
            for (int i = 0; i < 8 * 12; i++)
            {
                int k = kn[i % kn.Length];
                frameBuffer.drawFillBox(
                    0,
                    i * noteHeight,
                    pbScreen.Width,
                    noteHeight,
                    (byte)(0x08 * k), (byte)(0x08 * k), (byte)(0x08 * k));
            }

            for (int i = 0; i < pianoRollMng.lstPrNote.Count; i++)
            {
                PrNote n = pianoRollMng.lstPrNote[i];
                x = (int)((n.startTick - tick + playLine) * mul);
                len = (int)(n.endTick == -1 ? pbScreen.Width : ((n.endTick - tick + playLine) * mul) - x);

                if (tick>=0 &&( x + len < 0 || len == 0))
                {
                    pianoRollMng.lstPrNote.RemoveAt(i);
                    i--;
                    continue;
                }

                for (int j = 0; j < 6; j++)
                {
                    if (n.color[j] == n.trgColor[j]) continue;
                    n.color[j] += (byte)(Math.Sign(n.trgColor[j] - n.color[j]) * 2);
                }
                if (n.startTick <= tick && (n.endTick >= tick || n.endTick == -1))
                {
                    for (int j = 0; j < 6; j++)
                    {
                        n.color[j] = n.noteColor2[j];
                        n.trgColor[j] = n.noteColor2[j];
                    }
                }
                else
                {
                    for (int j = 0; j < 6; j++)
                        n.trgColor[j] = n.noteColor1[j];
                }

                frameBuffer.drawFillBox(
                    x,
                    n.key * noteHeight + (noteHeight - noteThin) / 2,//noteがnote間の中心に描画されるように調整
                    len,
                    noteThin,
                    n.color[0], n.color[1], n.color[2],
                    n.color[3], n.color[4], n.color[5]);
            }
            x = (int)(playLine * mul);
            frameBuffer.drawFillBox(
                x,
                0,
                1,
                img.Height,
                0xff, 0xff, 0xff);
        }

        public void update()
        {
            frameBuffer.Refresh(null);
        }

    }
}
