﻿using MDPlayer;
using MDPlayer.Driver.MuSICA;
using MDSound;
using NAudio.Midi;
using NAudio.Wave;
using NAudio.Wave.Compression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MDPlayer.PlayList;
using static MDPlayer.xgm;
using static MDSound.XGMFunction;

namespace MDPlayerx64.Driver
{
    public class aiff : baseDriver
    {

        public System.Drawing.Image img = null;

        public override GD3 getGD3Info(byte[] buf, uint vgmGd3)
        {
            GD3 ret = new GD3();
            img = null;
            try
            {
                if (buf[0] != 0x46 || buf[1] != 0x4f || buf[2] != 0x52 || buf[3] != 0x4d
                    || buf[8] != 0x41 || buf[9] != 0x49 || buf[10] != 0x46 || buf[11] != 0x46)
                {
                    throw new Exception("Not AIFF file.");
                }

                Encoding enc = Encoding.Default;
                byte[] v1 = null;
                byte[] v2 = null;
                int ind = 12;
                do
                {
                    string cid = Encoding.ASCII.GetString(buf, ind, 4);
                    ind += 4;
                    int csize = (buf[ind] << 24) + (buf[ind + 1] << 16) + (buf[ind + 2] << 8) + (buf[ind + 3] << 0);
                    ind += 4;
                    if(cid=="ID3 ")
                    {
                        v2 = new byte[buf.Length - ind];
                        Array.Copy(buf, ind, v2, 0, v2.Length);
                        break;
                    }
                    ind += csize;
                } while (ind < buf.Length);


                //さんこう ：
                //https://so-zou.jp/software/tech/programming/c-sharp/media/audio/naudio/#no2

                //Encoding enc = Encoding.Default;
                string v1Title = null;
                string v1Artist = null;
                string v1Album = null;
                string v1Year = null;
                if (v1 != null)
                {
                    char[] trimChars = { '\0' };
                    v1Title = enc.GetString(v1, 3, 30).TrimEnd(trimChars);
                    v1Artist = enc.GetString(v1, 33, 30).TrimEnd(trimChars);
                    v1Album = enc.GetString(v1, 63, 30).TrimEnd(trimChars);
                    v1Year = enc.GetString(v1, 93, 4).TrimEnd(trimChars);
                }


                if (v2[0] != 0x49 || v2[1] != 0x44 || v2[2] != 0x33)
                {
                    throw new Exception("Error ID3v2TAG Header.");
                }

                int v = v2[3];
                int flag = v2[5];
                uint size = (uint)((v2[6] << 21) + (v2[7] << 14) + (v2[8] << 7) + (v2[9] << 0));

                Dictionary<string, string> tags = new Dictionary<string, string>();


                if (v == 2)
                {
                    for (int index = 10; index < v2.Length;)
                    {
                        if (v2[index] == '\0') break;
                        string frameID = Encoding.ASCII.GetString(v2, index, 3);
                        index += 3;
                        int frameSize = (int)((v2[index] << 16) + (v2[index + 1] << 8) + v2[index + 2]);
                        index += 3;

                        if (frameID == "PIC")
                        {
                            byte[] pic = new byte[frameSize-6];
                            Array.Copy(v2, index + 6, pic, 0, frameSize - 6);
                            //byte[] pic = new byte[frameSize];
                            //Array.Copy(v2, index, pic, 0, frameSize);
                            index += frameSize;
                            MemoryStream mb = new MemoryStream(pic);
                            img = System.Drawing.Image.FromStream(mb);
                            continue;
                        }

                        byte[] v3 = new byte[frameSize - 1];
                        Array.Copy(v2, index + 1, v3, 0, frameSize - 1);
                        Encoding enc2 = Common.GetCode(v3);

                        enc = Encoding.Default;// Unicode; // UTF-16LE
                        byte c = v2[index++];
                        switch (c)
                        {
                            case 0x00:
                                enc = Encoding.GetEncoding(28591); // iso-8859-1
                                if (enc2 != null) enc = enc2;
                                break;

                            case 0x01:
                                enc = Encoding.GetEncoding("UTF-16");//.BigEndianUnicode; // UTF-16BE
                                if (enc2 != null) enc = enc2;
                                break;
                        }

                        string content = enc.GetString(v2, index, frameSize - 1);
                        index += frameSize - 1;

                        if (!tags.ContainsKey(frameID)) tags.Add(frameID, content);
                    }

                    if (tags.ContainsKey("TT2"))
                    {
                        string title = tags["TT2"];
                        GD3.TrackName = string.IsNullOrEmpty(title)
                            ? (
                                string.IsNullOrEmpty(v1Title)
                                ? "" : v1Title
                        )
                            : title;
                        GD3.TrackNameJ = GD3.TrackName;
                    }

                    if (tags.ContainsKey("TP1"))
                    {
                        string artist = tags["TP1"];
                        GD3.Composer = string.IsNullOrEmpty(artist)
                            ? (
                                string.IsNullOrEmpty(v1Artist)
                                ? "" : v1Artist
                        )
                            : artist;
                        GD3.ComposerJ = GD3.Composer;
                    }

                    if (tags.ContainsKey("TAL"))
                    {
                        string album = tags["TAL"];
                        GD3.GameName = string.IsNullOrEmpty(album)
                            ? (
                                string.IsNullOrEmpty(v1Album)
                                ? "" : v1Album
                                )
                            : album;
                        GD3.GameNameJ = GD3.GameName;
                    }
                }
                else
                {
                    for (int index = 10; index < v2.Length;)
                    {
                        if (v2[index] == '\0') break;

                        string frameID = Encoding.ASCII.GetString(v2, index, 4);
                        index += 4;

                        if (BitConverter.IsLittleEndian)
                        {
                            Array.Reverse(v2, index, 4);
                        }
                        int frameSize = BitConverter.ToInt32(v2, index);
                        index += 4;

                        byte flag1 = v2[index++];
                        byte flag2 = v2[index++];

                        if (frameID == "APIC")
                        {
                            //参考
                            //http://takaaki.info/wp-content/uploads/2013/01/id3v2_4_0-frames_j.txt

                            //enc = Encoding.Default;// Unicode; // UTF-16LE
                            byte c = v2[index++];
                            switch (c)
                            {
                                case 0x00:
                                    enc = Encoding.GetEncoding(28591); // iso-8859-1
                                    break;

                                case 0x01:
                                    if (index + 1 < v2.Length && (v2[index] == 0xfe && v2[index + 1] == 0xff))
                                    {
                                        enc = Encoding.GetEncoding("UTF-16");//.BigEndianUnicode; // UTF-16BE
                                    }
                                    break;
                                case 0x02:
                                    enc = Encoding.GetEncoding("UTF-16BE");
                                    break;
                                case 0x03:
                                    enc = Encoding.GetEncoding("UTF-8");
                                    break;

                            }
                            uint uindex = (uint)index;
                            string mime = Common.getNRDString(v2, ref uindex);//mimeはASCII限定かも?
                            index = (int)uindex;
                            int pictType = v2[index++];
                            string content = enc.GetString(v2, index, v2.Length - index);
                            content = content[..(content.IndexOf('\0') + 1)];//終端文字も含めて、有効な文字を切り出す
                            int n = enc.GetByteCount(content);//バイト数を求める
                            index += n;

                            byte[] pic = new byte[v2.Length - index];
                            Array.Copy(v2, index , pic, 0, v2.Length - index);
                            index += frameSize;
                            MemoryStream mb = new MemoryStream(pic);
                            img = System.Drawing.Image.FromStream(mb);
                            continue;
                        }

                        if (frameID[0] == 'T')
                        {
                            byte[] v3 = new byte[frameSize-1];
                            Array.Copy(v2,index + 1, v3, 0, frameSize - 1);
                            Encoding enc2 = Common.GetCode(v3);

                            enc = Encoding.Default;// Unicode; // UTF-16LE
                            byte c = v2[index++];
                            switch (c)
                            {
                                case 0x00:
                                    enc = Encoding.GetEncoding(28591); // iso-8859-1
                                    if (enc2 != null) enc = enc2;
                                    break;

                                case 0x01:
                                    if (index + 1 < v2.Length && (v2[index] == 0xfe && v2[index + 1] == 0xff))
                                    {
                                        enc = Encoding.BigEndianUnicode; // UTF-16BE
                                    }
                                    else if (enc2 != null) enc = enc2;
                                    break;
                            }

                            string content = enc.GetString(v2, index, frameSize - 1);
                            index += frameSize - 1;

                            if (!tags.ContainsKey(frameID)) tags.Add(frameID, content);
                        }
                        else
                        {
                            index += frameSize;
                        }
                    }

                    if (tags.ContainsKey("TIT2"))
                    {
                        string title = tags["TIT2"];
                        GD3.TrackName = string.IsNullOrEmpty(title)
                            ? (
                                string.IsNullOrEmpty(v1Title)
                                ? "" : v1Title
                        )
                            : title;
                        GD3.TrackNameJ = GD3.TrackName;
                    }

                    if (tags.ContainsKey("TPE1"))
                    {
                        string artist = tags["TPE1"];
                        GD3.Composer = string.IsNullOrEmpty(artist)
                            ? (
                                string.IsNullOrEmpty(v1Artist)
                                ? "" : v1Artist
                        )
                            : artist;
                        GD3.ComposerJ = GD3.Composer;
                    }

                    if (tags.ContainsKey("TALB"))
                    {
                        string album = tags["TALB"];
                        GD3.GameName = string.IsNullOrEmpty(album)
                            ? (
                                string.IsNullOrEmpty(v1Album)
                                ? "" : v1Album
                                )
                            : album;
                        GD3.GameNameJ = GD3.GameName;
                    }
                }

                GD3.pic = img;
            }
            catch
            {
                GD3.TrackName = "";
            }

            return GD3;
        }

        public override bool init(byte[] vgmBuf, ChipRegister chipRegister, EnmModel model, EnmChip[] useChip, uint latency, uint waitTime)
        {
            throw new NotImplementedException();
        }

        public override bool init(byte[] vgmBuf, int fileType, ChipRegister chipRegister, EnmModel model, EnmChip[] useChip, uint latency, uint waitTime)
        {
            throw new NotImplementedException();
        }

        public override void oneFrameProc()
        {
            throw new NotImplementedException();
        }
    }
}