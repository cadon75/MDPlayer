﻿# MDPlayer
VGMファイルなどのPlayer(メガドライブ音源チップなどのエミュレーションによる演奏ツール)  
  
[概要]  
  このツールは、鍵盤表示を行いながらVGMファイルの再生を行います。  
  (NRD,XGM,S98,MID,RCP,RCS,NSF,GBS,HES,SID,AY,MGS,MDR,MDX,MND,ZMD,ZMS,MUC,MUB,M,M2,MZ,MPI,MVI,MZI,OPI,OVI,OZI,WAV,MP3,AIFFファイルにも対応。)  
  
[注意]  
  ・FileAssociationTool(ファイル関連付け設定ツール)についてはREADME_AST.md/README_AST_EN.mdを参照お願いします。  
  
  ・再生時の音量に注意してください。バグによる雑音が大音量で再生される場合もあります。  
  (特に再生したことのないファイルを試す場合や、プログラムを更新した場合。)  
  
  ・使用中に不具合を見つけた場合はお手数ですが以下までご連絡ください。  
    Twitter(@kumakumakumaT_T)  
    Github Issues(https://github.com/kuma4649/MDPlayer/issues)  
  !!重要!!  
  VGMPlayやNRTDRV、その他素晴らしいソフトウェアの作者様方に、  
  直接MDPlayerについての連絡がいくことの無い様にお願いします。  
  但し、できるかぎり対応させていただくつもりですが、ご希望に添えないことも多々あります。ご了承ください。  
  
[対応フォーマット]  
  .VGM (所謂vgmファイル)  
  .VGZ (vgmファイルをgzipしたもの)  
  .NRD (NRTDRV X1でOPM2個とAY8910を鳴らすドライバの演奏ファイル)  
  .XGM (MegaDrive向けファイル)  
  .ZGM (mml2vgmで生成可能なVGM拡張フォーマットファイル)  
  .S98 (主に日本製レトロPC向けファイル)  
  .MID (StandardMIDIファイル。フォーマット0/1対応)  
  .RCP (レコポンファイル CM6,GSDの送信可)  
  .RCS (上記RCPを演奏しながらPCM8も発音できるファイル)  
  .NSF (NES Sound Format)  
  .GBS (Gameboy Sound Format)  
  .HES (HESファイル)  
  .SID (コモドール向けファイル)  
  .AY  (ZX Spectrum / Amstrad CPC向けファイル)  
  .MGS (MGSDRVファイル 演奏するにはMGSDRV.COMが必要です)  
  .BGM (MuSICAファイル 演奏するにはKINROU5.DRVが必要です)  
  .MDR (MoonDriver MSXで,MoonSound(OPL4)を鳴らすドライバの演奏ファイル)  
  .MDX (MXDRV向けファイル)  
  .MND (MNDRV X68000(OPM,OKIM6258) & まーきゅりーゆにっと(OPNAx2)を使用するドライバの演奏ファイル)  
  .MUC (MUCOM88Windows 向けファイル)  
  .MUB (MUCOM88Windows 向けファイル)  
  .M   (PMD 向けファイル)  
  .M2  (PMD 向けファイル)  
  .MZ  (PMD 向けファイル)  
  .MPI (FMP 向けファイル 演奏するにはFMC.EXE,FMP.COMが必要です)    
  .MVI (FMP 向けファイル 演奏するにはFMC.EXE,FMP.COMが必要です)    
  .MZI (FMP 向けファイル 演奏するにはFMC.EXE,FMP.COMが必要です)    
  .OPI (FMP 向けファイル 演奏するにはFMP.COMが必要です)    
  .OVI (FMP 向けファイル 演奏するにはFMP.COMが必要です)    
  .OZI (FMP 向けファイル 演奏するにはFMP.COMが必要です)    
  .ZMS (ZMUSIC2/3 向けファイル 演奏するにはZMUSIC.X,ZMC.X,ZMSC3.Xが必要です)    
  .ZMD (ZMUSIC3 向けファイル 演奏するにはZMC.X,ZMSC3.Xが必要です)    
  .ZMD (ZMUSIC2 向けファイル 演奏するにはZMUSIC.Xが必要です)    
  .WAV (音声ファイル)  
  .MP3 (音声ファイル)  
  .AIF (音声ファイル)  
  .M3U (プレイリスト)  
  
[機能、特徴]  
  ・現在、以下の主にメガドライブ系音源チップのエミュレーションによる再生が可能です。  
     
      AY8910    , YM2612(YM3438) , SN76489 , RF5C164 , PWM     , C140(C219) , OKIM6295 , OKIM6258(PCM8,MPCM含)  
      , SEGAPCM , YM2151         , YM2203  , YM2413  , YM2608  , YM2609     , YM2610/B 
      , HuC6280 , C352     
      , K054539 , NES_APU        , NES_DMC , NES_FDS , MMC5    , FME7       , N160     , VRC6  
      , VRC7    , MultiPCM       , YMF262  , YMF271  , YMF278B , YMZ280B    , DMG      , QSound  
      , S5B     , GA20           , X1-010  , SAA1099
      , RF5C68  , SID            , Y8950   , YM3526  , YM3812  , K053260    , K051649(K052539)  
  
  ・現在、以下の鍵盤表示が可能です。  
     
      YM2612(YM3438), SN76489    , RF5C164  
      , AY8910      , C140(C219) , C352    , SEGAPCM    , K054539 , GA20 , OKIM6295 , OKIM6258(PCM8,MPCM含)  
      , Y8950       , YM2151     , YM2203  , YM2413     , YM2608 , YM2609 , YM2610/B 
      , YM3526      , YM3812     
      , YMF262      , YMF278B    , YMZ280B , MultiPCM   
      , HuC6280     , MIDI       
      , NES_APU&DMC , NES_FDS    , MMC5    , N106(N163) , VRC6   , VRC7   , PPZ8    
  
      チャンネル(鍵盤)を左クリックすることでマスクさせることができます。  
      右クリックすると全チャンネルのマスクを解除します。  
      (いろいろなレベルで対応していないのもあり)  
    　各鍵盤表示ウィンドウで'ch'をクリックすると一括でマスクを切り替えます。  


      再生するファイルの情報から使用する鍵盤を自動で開くことができます。  
      (同じ鍵盤を2枚まで表示できますが、MIDIの鍵盤はひとつだけ開きます。)  
  
  ・C#で作成されています。  
  
  ・VGMPlay,MAME,DOSBOXのソースを参考、移植しています。  
  
  ・FMGenのソースを参考、移植しています。  
  
  ・NSFPlayのソースを参考、移植しています。  
  
  ・NEZ Plug++のソースを参考、移植しています。  
  
  ・libsidplayfpのソースを参考、移植しています。  
  
  ・sidplayfpのソースを参考、移植しています。  
  
  ・YMEmuWithFiltersのソースを参考にしています。  

  ・NRTDRVのソースを参考、移植しています。  
  
  ・MoonDriverのソースを参考、移植しています。  
  
  ・MXPのソースを参考、移植しています。  
  
  ・MXDRVのソースを参考、移植しています。  
  
  ・MNDRVのソースを参考、移植しています。  
  
  ・X68Soundのソースを参考、移植しています。  
  (m_puusanさん/rururutanさん版両方)  
  
  ・PMDのソースを参考、移植にしています。  
  
  ・MGSDRVのコードを参考にしています。  
  
  ・MuSICAのコードを参考にしています。  
  
  ・FMPのコードを参考にしています。  
  
  ・run68のコードを参考にしています。  
  
  ・ZMUSICv2/v3のコードを参考にしています。  

  ・CVS.EXEの出力を参考に同じデータが出力されるよう調整しています。  
  
  ・SCCI2を利用して本物のYM2612(YM3438),SN76489,YM2608,YM2151,YMF262から再生が可能です。  
  またSPPCMにも対応しています。  
  SCCI2は別途ダウンロードしMDPlayerと同じ場所に置き、scci2config.exeで設定を行っておくことが必須です。  
  
  ・GIMIC(C86ctl)を利用して本物のYM2608,YM2151,YMF262から再生が可能です。  
  
  ・Z80dotNetを利用しています。  
  
  ・ボタンは以下の順に並んでいます。  
     
     設定、停止、一時停止、フェードアウト、前の曲、1/4速再生、再生、4倍速再生、次の曲、  
     プレイモード、ファイルを開く、プレイリスト、  
     情報パネル表示、ミキサーパネル表示、パネルリスト表示、VSTeffectの設定、MIDI鍵盤表示、表示倍率変更  
  
  ・OPN,OPM,OPL系の音色パラメーターを左クリックするとクリップボードに音色パラメーターをテキストとしてコピーします。  
  パラメーターの形式はオプション設定から変更可能です。  
     
      FMP7 , MDX , MUCOM88(MUSIC LALF) , NRTDRV , HuSIC , MML2VGM , .TFI , MGSC , .DMP , .OPNI  
  
  に対応しており、.TFI / .DMP / .OPNIを選んだ場合はクリップボードの代わりにファイルに出力します。  
  
  ・出来は今一歩ですが、YM2612(YM3438) , YM2151 の演奏データをMIDIファイルとして出力が可能です。  
  VOPMexを使用すれば、FM音源の音色情報も反映させることが可能です。  
  (VOPMではなく、VOPMexです。;-P )  
  
  ・PCMデータをダンプすることができます。SEGAPCMの場合のみWAVで出力します。  
  
  ・演奏をwavで書き出すことが可能です。  
  
  ・MIDI音源にVSTiを指定可能です。  
  
  ・キーボード、MIDIキーボードから、再生、停止などの操作が可能です。  
  
  ・プレイリストから、再生中の拡張子違いの同名ファイル(Text,MML,Image)を開くことができます。  
  
  ・VGM/VGZファイルに独自機能を追加しています。  
      RF5C164のDual演奏  
      歌詞表示  

  ・コマンドラインからmdc.exeを使用してMDPlayerを操作できるようにした♪  
  mdc.exeは主にSTREAM DECKやエディタなどからMDPlayerを操作するのに使います。  
        mdc.exeのコマンドは以下の通り。  
            PLAY [file]  
            STOP  
            NEXT  
            PREV  
            FADEOUT  
            FAST  
            SLOW  
            PAUSE  
            CLOSE  
            LOOP  
            MIXER  
            INFO  
  
  ・コマンドラインから起動時にファイルを指定するとそれを読みこみ、再生を行います。  
    通常、指定したファイルはプレイリストに追加されますが"-PL-"オプションを指定すると追加を行いません。  
      例)
        MDPlayerx64.exe sample.vgm  
          起動時にsample.vgmを読み込み、再生を開始する。プレイリストに追加する。
        MDPlayerx64.exe -PL- sample.vgm
          起動時にsample.vgmを読み込み、再生を開始する。但しプレイリストに追加しない。

[ちょっと分かりづらい操作]  
  ・各ウィンドウのタイトルバーをダブルクリック(トグル)すると常に前面に表示するようになります。  
　・Shiftキーを押しながらアプリを起動すると、ウィンドウの位置を初期化できるように機能追加。  
　・OPN系の鍵盤ではShiftキーを押しながらFM3OP1～4をクリックすると、SLOT毎のミュートが可能です。（但しキャリアのみ)  

  
  
[ちょっと分かりづらい設定項目]  
  ・[Options]ウィンドウ > [other]タブ > [Search paths on additional file]  
    このテキストボックスにパスを入力しておくと、  
    曲データを再生するときに追加で参照されるファイルをその場所を検索するようになります。  
    パスは;区切りで複数列挙可能です。  
    ドライバ毎に追加で探すファイルは以下の通りです。  
      ・レコンポーザ(.RCP)  
        .CM6 / .GSD  
      ・MoonDriver(.MDR)  
        .PCM  
      ・MXDRV(.MDX)  
        .PDX  
      ・MNDRV(.MND)  
        .PND  
    尚、PMDDotNETの場合は環境変数PMDで指定されたパスを参照します。  

  ・レコンポーザ(.RCP)ファイル演奏時にの.CM6 .GSDを読ませるためには  
    設定画面のMIDIデバイス設定時にそれぞれLA、GSと音源種を適切に選択しておく必要があります。  

  ・X68000系のファイル(.MDX .ZMS .ZMD .RCS)演奏時はPCM再生ドライバ(PCM8,PCM8PP,MPCM,MPCMPP)を適切に選択する必要があります。  
    (これらはデータから最適なドライバを自動選択させるための手段を持たない為)   

  
  
[G.I.M.I.C.関連情報]  
  ・SSG volumeについて  
    SSG volumeは、ミキサー画面右下の「G.OPN」「G.OPNA」フェーダーで調節してください。  
    それぞれ  
      G.OPN    ->  YM2203(Pri/Sec)に設定したG.I.M.I.C.のモジュール  
      G.OPNA   ->  YM2608(Pri/Sec)に設定したG.I.M.I.C.のモジュール  
    に設定情報が送信されます。  
    なお、設定は再生開始時にのみ送信されます。  
    よって演奏中にフェーダーを動かしてもその値が即時反映されることはありません。  
    初期値としては、  
      .muc(mucom88)  ->  63 (PC-8801-11相当)  
      .mub(mucom88)  ->  63 (PC-8801-11相当)  
      .mnd(MNDRV)    ->  31 (PC-9801-86相当)  
      .s98           ->  31 (PC-9801-86相当)  
      .vgm           ->  31 (PC-9801-86相当)  
    を設定しています。  
    必要に応じて、ドライバ毎又はファイル毎にバランスを調節し、  
    保存(ミキサー画面で右クリックすると保存メニューを表示)してください。  
    
    また、以下の演奏ファイルは、ファイル内に記述されているタグを判別して自動で設定することも可能です(TBD)。
    
    .S98ファイル  
    「system」タグ内に「8801」という文字を見つけるとMDPlayerは「63」を設定します。  
    「9801」という文字を見つけるとMDPlayerは「31」を設定します。  
    両方見つけた場合は「8801」を優先します。  
    見つからない場合は、ミキサー画面で設定した値になります。  
    
    .vgmファイル  
    「systemname」「systemnamej」タグ内に「8801」という文字を見つけるとMDPlayerは「63」を設定します。  
    「9801」という文字を見つけるとMDPlayerは「31」を設定します。  
    両方見つけた場合は「8801」を優先します。  
    見つからない場合は、ミキサー画面で設定した値になります。  
    
    
  ・周波数について  
    ファイル形式ごとにモジュールの周波数(チップのマスタークロック)の設定を行います。  
    設定値は以下の通りです。  
      .vgm           ->  ファイル中に設定されている値を使用  
      .s98           ->  ファイル中に設定されている値を使用  
      .mub(mucom88)  ->  OPNA:7987200Hz  
      .muc(mucom88)  ->  OPNA:7987200Hz  
      .nrd(NRTDRV)   ->  OPM:4000000Hz  
      .mdx(MXDRV)    ->  OPM:4000000Hz  
      .mnd(MNDRV)    ->  OPM:4000000Hz  OPNA:8000000Hz  
      .mml(PMD)      ->  OPNA:7987200Hz  
      .m(PMD)        ->  OPNA:7987200Hz  
      .m2(PMD)       ->  OPNA:7987200Hz  
      .mz(PMD)       ->  OPNA:7987200Hz  
      .opi(FMP)      ->  OPNA:7987200Hz  
      .ovi(FMP)      ->  OPNA:7987200Hz  
      .ozi(FMP)      ->  OPNA:7987200Hz  
  
  
[必要な動作環境]  
  ・Windows7(64bit)以降のOS。私はWindows11Home(x64)を使用しています。  
  XPでは動作しません。  
  
  ・.NET8をインストールしている必要あり。  
  
  ・Visual Studio 2012 更新プログラム 4 の Visual C++ 再頒布可能パッケージ をインストールしている必要あり。  
  
  ・Microsoft Visual C++ 2015 Redistributable(x86) - 14.0.23026をインストールしている必要あり。  
  
  ・LZHファイルを使用する場合はUNLHA32.DLL(Ver3.0以降)をインストールしている必要あり。  
  
  ・音声を再生できるオーディオデバイスが必須。  
  そこそこ性能があるものが必要です。UMX250のおまけでついてたUCA222でも十分いけます。私はこれを使ってました。  
  
  ・もしあれば、SPFM Light(SCCI2対応版)＋YM2612(YM3438)＋YM2608＋YM2151＋SPPCM  
  
  ・もしあれば、GIMIC＋YM2608＋YM2151  
  
  ・YM2608のエミュレーション時、リズム音を鳴らすために以下の音声ファイルが必要です。  
  作成方法は申し訳ありませんがお任せします。  
      
      バスドラム      2608_BD.WAV  
      ハイハット      2608_HH.WAV  
      リムショット    2608_RIM.WAV  
      スネアドラム    2608_SD.WAV  
      タムタム        2608_TOM.WAV  
      トップシンバル  2608_TOP.WAV  
      (44.1KHz 16bitPCM モノラル 無圧縮Microsoft WAVE形式ファイル)  
    曲ファイルと同じ位置に上記ファイルが存在する場合はそちらを読み込んで発音します。  
    リズム音を独自に変えたい場合に便利。  
  
  ・YMF278Bのエミュレーション時、MoonSoundの音色を鳴らすために以下のROMファイルが必要です。  
  作成方法は申し訳ありませんがお任せします。  
  	yrw801.rom  
  
  ・C64のエミュレーション時、以下のROMファイルが必要です。  
  作成方法は申し訳ありませんがお任せします。  
  	Kernal , Basic , Character  
  
  ・そこそこ速いCPU。  
  使用するChipなどによって必要な処理量が変わります。  
  私はi7-9700K 3.6GHzを使用しています。  
  
  ・MGSDRVのファイルを演奏するには、以下のファイルが必要です。  
  (予め同梱させていただいていますが必要であれば、公式サイトから入手してください。)
    MGSDRV.COM  

  ・MuSICAのファイルを演奏するには、以下のファイルが必要です。  
  (予め同梱させていただいていますが必要であれば、公式サイトから入手してください。)
    KINROU5.DRV  

  ・FMPのファイルを演奏するには、以下のファイルが必要です。  
  (公式サイト,VECTORなどから入手してください。)
    FMP.COM  
    FMC.EXE  
    PPZ8.COM  

  ・ZMUSICv2のファイルを演奏するには、以下のファイルが必要です。  
  (公式サイトなどから入手してください。)
    ZMUSIC.X  

  ・ZMUSICv3のファイルを演奏するには、以下のファイルが必要です。  
  (公式サイトなどから入手してください。)
    ZMC.X  
    ZMSC3.X  
  
  ・SCCI2を使用して実チップから演奏するには、以下のファイルが必要です。  
  (公式サイトなどから入手してください。)
    scci2.dll  
    scci2config.exe  

[同期のすゝめ]  
    
  ・SCCI2/GIMIC(C86ctl)とエミュレーション(以下EMUと略す)による音を同期させるのにはコツがいります。  
  環境にもよるので何が正解かはわからないのですが、私の環境での調整手順を紹介します。  
      
    １．まず、[Output]タブから音声の出力に使用するデバイスを選びます。  
    おすすめはWasapiOutで共有を選ぶ、又はASIOを選ぶパターンです。  
      
    ２．遅延時間は50msか100msを選びます。ここで一度[OK]を押してEMUのみを使用する曲を再生し  
    音がざらざらしたりプチプチといったノイズが混ざらないことを確認します。  
    (もし綺麗に再生されない場合は遅延時間をひとつ大きく設定します。)  
      
    ３．[Sound]タブからYM2612(YM3438)のSCCIを選択し使用するモジュールを選択します。  
    SCCIのみ  
    チェックボックスは「Send Wait Signal」と「Emulate PCM only」にチェックを入れてください。  
    「Emulate PCM only」にチェックを入れるとPCMのみエミュレーションするようになります。  
    チェックを入れない場合はSCCIにPCMデータを送るようになりますが音質、テンポが安定しません。  
    「Send Wait Signal」を行うとSCCIのテンポが安定するようです。  
    しかし「Double wait」にチェックするとPCMの音質は上がりますがテンポが乱れる傾向があります。  
      
    ４．遅延演奏のグループはとりあえずSCCI/GIMICもEMUも0msを設定し「日和見モード」にはチェックをいれてください。  
    「日和見モード」は、例えば演奏中に大きな負荷がかかり、SCCI/GIMICの再生とEMUの再生が大きくずれた場合に  
    SCCI/GIMICの再生スピードを調整してズレを軽減させる機能です。但し、遅延演奏で設定した(意図した)ズレは保ち続けます。  
      
    ５．SCCI/GIMICとEMUの両方が使用されている曲を再生し、どちらが先に鳴っているか注意深く確認します。  
    SCCI/GIMICとEMUのうち先に演奏されている方の遅延演奏時間を増やし曲再生を行い確認します。  
      
    ６．５の手順をズレがなくなるまで繰り返せば同期作業は完了です。楽しんで！  
      
    ７．SCCIとGIMICの演奏ずれについて。  
    SCCIが早い場合はSCCIのディレイ設定項目を調整します。  
    GIMICが早い場合はGIMICのディレイ設定項目を調整します。  
  
  
[MIDI鍵盤のすゝめ]  
  ・MIDIキーボードを用意すると、それを使用してYM2612(YM3438)(EMU)から発音させることができます。  
  これは主にMML打ち込み支援のために用意された機能です。  
  (今のところ実装途中の状態で使用できない機能があります。)  
  
  ・とりあえずの使い方  
      
    １. 設定画面で、使用するMIDIキーボードを選択します。  
       
    ２. YM2612(YM3438)のデータを再生中に(CC:97)を送信します。  
        YM2612(YM3438)の1Chの音色が全てのチャンネルへセットされます。  
       
    ３. 後は弾くだけ。  
    
  ・主な機能  
      
    １. 音色データ取り込み  
      各OPN系音源又はOPM音源、鍵盤表示の音色データ部をクリックすると  
      音色データが選択チャンネルへコピーされます。  
      
    ２. 演奏モード切替  
      MONOモード(単一チャンネルを使用して演奏)と  
      POLYモード(複数チャンネル(最大6Ch)を使用して演奏)を  
      切り替えることが可能です。  
      MONOモード  打ち込み時に短いフレーズを演奏し、MMLとして出力することを想定。  
      POLYモード  打ち込み時に和音を確認するために使用することを想定。  
      
    ３. チャンネルノートログ  
      チャンネルごとに最大100音の発音記録を残すことができます。  
      
    ４. チャンネルノートログMML変換機能  
      ログ欄をクリックすると発音記録がMMLとしてクリップボードにコピーされます。  
      音長は出力されません。対応コマンドは、c d e f g a b o < > です。  
      オクターブ情報は初めの一音のみoコマンドで絶対指定され、  
      その後は<コマンド>コマンドによる相対指定で展開されます。  
      
    ５. 音色保存、読み込み  
      メモリ上に256種類の音色を保存する、又は読み込むことが可能です。  
      そのデータを、指定された形式でファイルへ出力する、又は読み込むことが可能です。  
      以下のソフトウェア向けの形式で保存、読み込みが可能です。  
        FMP7  
        MUCOM88(MUSIC LALF/mucomMD2vgm)  
        NRTDRV  
        MXDRV  
        mml2vgm  
      
    ６. 簡易音色編集(TBD)  
      入力したいパラメータを選択後、数値を入力することで編集が可能です。  
      
  ・画面  
      
    ０. 鍵盤(TBD)  
      演奏中のノートが表示されます。  
      
    １．MONO  
      クリックするとMONOモードに切り替えます。切り替わると♪アイコンになります。  
      
    ２．POLY  
      クリックするとPOLYモードに切り替えます。切り替わると♪アイコンになります。  
      
    ３．PANIC  
      全チャンネルにキーオフを送信します。(音が鳴り続けてしまう場合に使用します。)  
      
    ４．L.CLS  
      全チャンネルのノートログをクリアします。  
      
    ５．TP.PUT  
      TonePallet(メモリ上の音色保管領域)へ選択チャンネルの音色を保存します。  
      
    ６．TP.GET  
      TonePalletから音色を選択チャンネルへ読み込みます。  
      
    ７．T.SAVE  
      TonePalletをファイルへ保存します。  
      
    ８．T.LOAD  
      ファイルからTonePalletを読み込みます。  
      
    ９．音色データ(6Ch分)  
      ・「-」又は「♪」をクリックすることで チャンネルの選択、選択解除ができます。  
      ・パラメータを右クリックすることで、そのパラメータの変更ができます。(TBD)  
      ・パラメータを左クリックすることで、コンテキストメニューが表示されます。  
        コピー   : クリックした音色をクリップボードにコピーします。  
        貼り付け : クリップボードの音色をクリックした音色にペーストします。  
        上記の機能で使用されるテキスト形式をFORMATの欄のソフトウェア名をクリックすることで変更できます。  
        キー操作でもコピーと貼り付けが可能です。この場合は選択されているチャンネルが対象になります。  
        尚、貼り付け時に形式の自動判別は行われません。  
      ・「LOG」の隣の「♪」をクリックすることで、そのチャンネルのノートログがクリアされます。  
      ・LOGをクリックすることで、MMLデータをクリップボードに設定します。  
      
  ・MIDI鍵盤からの操作  
    以下、デフォルト設定の場合です。(設定でカスタマイズ可能。設定値をブランクにすることで使用しないことも可能。)  
      
    CC:97(DATA DEC)  
      YM2612(YM3438)の1Chの音色を全てのチャンネルにコピーします。(選択状況無視)  
      
    CC:96(DATA INC)  
      直近のログをひとつだけ削除します。(弾き間違い等を取り消す機能)  
      
    CC:66(SOSTENUTO)  
      MONOモード時のみ、選択行のログをMMLにしクリップボードに設定します。  
      画面クリック時の処理との違い  
        Ctrl+V（ペースト）のキーストロークを送信します。  
        選択チャンネルのノートログをクリアします。  
        初めのオクターブコマンドは出力しません。  
      
      
[SpecialThanks]  
  本ツールは以下の方々にお世話になっております。また以下のソフトウェア、ウェブページを参考、使用しています。  
  本当にありがとうございます。  
     
    ・ラエル さん  
    ・とぼけがお さん  
    ・HI-RO さん  
    ・餓死3 さん  
    ・おやぢぴぴ さん  
    ・osoumen さん  
    ・なると さん  
    ・hex125 さん  
    ・Kitao Nakamura さん  
    ・くろま さん  
    ・かきうち さん  
    ・ぼう☆きち さん  
    ・dj.tuBIG/MaliceX さん  
    ・じごふりん さん  
    ・WING さん  
    ・そんそん さん  
    ・欧場豪 さん  
    ・sgq1205 さん  
    ・千霧＠ぶっちぎりP(but80) さん  
    ・ひぽぽ さん  
    ・Ichiro Ota さん  

    ・Visual Studio Community 2015/2017  
    ・MinGW/msys  
    ・gcc  
    ・SGDK  
    ・VGM Player  
    ・Git  
    ・SourceTree  
    ・さくらエディター  
    ・VOPMex  
    ・NRTDRV  
    ・MoonDriver  
    ・MXP  
    ・MXDRV  
    ・MNDRV  
    ・MPCM  
    ・X68Sound  
    ・hoot  
    ・XM6 TypeG  
    ・ASLPLAY  
    ・NAUDIO  
    ・VST.NET  
    ・NSFPlay  
    ・CVS.EXE  
    ・KeyboardHook3.cs  
    ・MUCOM88  
    ・MUCOM88windows  
    ・C86ctlのソース  
    ・MGSDRV  
    ・Z80dotNET  
    ・blueMSX  
    ・FMP  
    ・PPZ8  
    ・ZMUSICv2/v3    
    ・RCSMP  
     
    ・SMS Power!  
    ・DOBON.NET  
    ・Wikipedia  
    ・GitHub  
    ・ぬるり。  
    ・Gigamix Online  
    ・MSX Datapack wiki化計画  
    ・MSX Resource Center  
    ・msxnet  
    ・Xyzさんのツイートのリンク先(https://twitter.com/XyzGonGivItToYa/status/1216942514902634496?s=20)  
    ・がんず Work's Diary  
    ・pastraider.com(https://www.pastraiser.com/cpu/gameboy/gameboy_opcodes.html)  
    ・Pan Docs(http://bgb.bircd.org/pandocs.htm#memorymap)  
    ・プラスウイングTV(https://youtu.be/p13EdWrQFjY?si=2L93LDE6SyvINzXX)  


[FAQ]  
  
  ・起動しない  
  
    Case1  
      ゾーン識別子がファイルに付加されてしまっている為起動中にエラーがでてしまう為です。  
    ゾーン識別子はOSの保護機能のひとつで、ネットからダウンロードしたファイルに自動的に付加され意図しないファイルの実行を防ぎます。  
    が、意図してダウンロードしたものに対しては今回の様に邪魔してしまうことになります。  
    →解凍するとできるremoveZoneIdent.batをダブルクリックして実行してください。  
    このバッチファイルはゾーン識別子を一括削除します。  
    因みに以下のようなメッセージが表示されます。  
        不明なエラーが発生しました。  
        Exception Message:  
        Could not load file or assembly  
        'file://.....dll' or one of its dependencies,Operation is not supported.  
        (Exception from HRESULT:xxxx)  

    Case2  
      主に実チップ使用時に発生します。SCCI2がc86ctlを使用する状態になっている為です。  
    MDPlayerもc86ctlを使用するため取り合いになってしまい、起動に失敗します。  
    →scci2config.exeを使用してc86ctlの設定項目である「enable」のチェックを外してください。  
  
    Case3  
      .NETframeworkのバージョンが違う為です。  
    →最新の.NETframeworkをインストールすることで改善することがあります。  
    因みに以下のようなメッセージが表示されます。  
        不明なエラーが発生しました。  
        Exception Message:  
        Could not load file or assembly  
        'netstandard, Version=..., Culture=..., PublicKeyToken=...' or one of its dependencies.指定されたファイルが見つかりません。    

    CaseX  
      TBD  
  
  
  ・テンポが安定しない、演奏開始時に曲の初めが演奏されない、早送りになる  
  
    Case1  
      主に実チップ使用時に発生します。実チップは演奏開始時の処理に少し時間がかかります。  
    一方エミュレーションの演奏開始時の処理はすぐに完了します。  
    その時間差を詰めるために実チップがエミュレーションに追い付こうとする為です。  
    →「オプション」画面：「Sound」タブ：左下の「日和見～」のチェックボックスからチェックを外してください。  
  
    CaseX  
      TBD  
  
  
  ・音がぷつぷつ途切れる。表示がとても重い  
  
    Case1  
    限られた時間内に必要な処理が、全て出来ていない場合に発生します。  
    「オプション」画面から「Output」タブを開き、デバイスを切り替えてください。  
    どのデバイスが良いかは環境によるので色々試していただくことをお勧めします。  
    WasapiとASIOが良いレスポンスを得られることが多いです。  
    デバイスによっては「遅延時間（レンダリングバッファ）」の数値を調整すると改善することもあります。  
  
    CaseX  
      TBD  
  
  
  ・実チップで演奏した時、PCMの音がいまいちおかしい音源がある  

    YM2612(YM3438)やSSGによるPCM再生など、実チップの場合は正確な割り込み処理ができないのでPCMの音がおかしな状態になります。  
  
  
  
[著作権・免責]  
  MDPlayerはGPLv3ライセンスに準ずる物とします。LICENSE.txtを参照。  
  著作権は作者が保有しています。  
  このソフトは無保証であり、このソフトを使用した事による  
  いかなる損害も作者は一切の責任を負いません。  
  また、著作権表示および本許諾表示は本ソフトでは不要です。  
  そして以下のソフトウェアのソースコードをC#向けに移植改変、またはそのまま使用しています。  
  これらのソース、ソフトウェアは各著作者が著作権を持ちます。 ライセンスに関しては、各ドキュメントを参照してください。  
  
  ・VGMPlay  
  ・MAME  
  ・DOSBOX  
  ・FMGen  
  ・NSFPlay  
  ・NEZ Plug++  
  ・libsidplayfp  
  ・sidplayfp  
  ・NRTDRV  
  ・MoonDriver  
  ・MXP  
  ・MXDRV  
  ・MNDRV  
  ・X68Sound  
  (m_puusanさん/rururutanさん版両方)  
  ・MUCOM88  
  ・MUCOM88windows(mucomDotNET)  
  ・M86(M86DotNET)  
  ・VST.NET  
  ・NAudio  
  ・SCCI  
  ・c86ctl  
  ・PMD(PMDDotNET)  
  ・MGSDRV  
  ・勤労5号  
  ・Z80dotNet  
  ・mucom88torym2612  
  ・FMP  
  ・PPZ8  
  ・ZMUSICv2  
  ・ZMUSICv3  
  
  
  