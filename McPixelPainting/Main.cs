using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;

namespace McPixelPainting
{
    public enum ProcessState : byte
    {
        Default,  //默认
        Exist,  //存在
        DisExist //不存在
    }
    public partial class Main : Form
    {
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32")]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("gdi32.dll", EntryPoint = "CreatePalette")]
        public static extern IntPtr CreatePalette(ref PaletteColors colors_);

        [DllImport("gdi32.dll", EntryPoint = "GetNearestPaletteIndex")]
        public static extern uint GetNearestPaletteIndex(IntPtr palette, UInt32 color);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr ptr);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "ShowWindowAsync")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdshow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", EntryPoint = "GetActiveWindow")]
        public static extern IntPtr GetActiveWindow();

        [DllImport("use32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hwnd);
        public Main()
        {
            InitializeComponent();
        }

        private void ClearCommand_Click(object sender, EventArgs e)
        {
            CommandsTxt.Clear();
        }
        public void FillCommand(int X1, int Y1, int Z1, int X2, int Y2, int Z2, string BlockId)
        {
            CommandsTxt.AppendText("fill " + X1 + " " + Y1 + " " + Z1 + " " + X2 + " " + Y2 + " " + Z2 + " " + BlockId + " replace*\r\n");
        }

        public void SetBlockCommand(int X, int Y, int Z, string BlockId)
        {
            CommandsTxt.AppendText("setblock " + X + " " + Y + " " + Z + " " + BlockId + " replace*\r\n");
        }
        #region 判断颜色值
        string WoolColor = "";
        public string ReturnWoolColor(UInt32 Clr, IntPtr ptr)
        {
            //wool表示羊毛 | stained_hardened_clay表示陶瓦 | concrete表示混凝土 | *_glazed_terracotta表示带釉陶瓦
            //concrete_powder表示混凝土粉末
            uint index = GetNearestPaletteIndex(ptr, Clr);
            switch (index)
            {
                //白色区
                case 0:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 0";   //陶瓦
                        break;
                    }
                case 1:
                    {
                        WoolColor = "minecraft:concrete 0";  //混凝土
                        break;
                    }
                case 2:
                    {
                        WoolColor = "minecraft:wool 0";  //羊毛
                        break;
                    }
                case 3:
                    {
                        WoolColor = "minecraft:concrete_powder 0";  //混凝土粉末
                        break;
                    }
                case 4:
                    {
                        WoolColor = "minecraft:white_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //橙色区
                case 5:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 1";   //陶瓦
                        break;
                    }
                case 6:
                    {
                        WoolColor = "minecraft:concrete 1";  //混凝土
                        break;
                    }
                case 7:
                    {
                        WoolColor = "minecraft:wool 1";  //羊毛
                        break;
                    }
                case 8:
                    {
                        WoolColor = "minecraft:concrete_powder 1";  //混凝土粉末
                        break;
                    }
                case 9:
                    {
                        WoolColor = "minecraft:orange_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //品红色
                case 10:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 2";   //陶瓦
                        break;
                    }
                case 11:
                    {
                        WoolColor = "minecraft:concrete 2";  //混凝土
                        break;
                    }
                case 12:
                    {
                        WoolColor = "minecraft:wool 2";  //羊毛
                        break;
                    }
                case 13:
                    {
                        WoolColor = "minecraft:concrete_powder 2";  //混凝土粉末
                        break;
                    }
                case 14:
                    {
                        WoolColor = "minecraft:magenta_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //淡蓝色区
                case 15:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 3";   //陶瓦
                        break;
                    }
                case 16:
                    {
                        WoolColor = "minecraft:concrete 3";  //混凝土
                        break;
                    }
                case 17:
                    {
                        WoolColor = "minecraft:wool 3";  //羊毛
                        break;
                    }
                case 18:
                    {
                        WoolColor = "minecraft:concrete_powder 3";  //混凝土粉末
                        break;
                    }
                case 19:
                    {
                        WoolColor = "minecraft:light_blue_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //黄色区
                case 20:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 4";   //陶瓦
                        break;
                    }
                case 21:
                    {
                        WoolColor = "minecraft:concrete 4";  //混凝土
                        break;
                    }
                case 22:
                    {
                        WoolColor = "minecraft:wool 4";  //羊毛
                        break;
                    }
                case 23:
                    {
                        WoolColor = "minecraft:concrete_powder 4";  //混凝土粉末
                        break;
                    }
                case 24:
                    {
                        WoolColor = "minecraft:yellow_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //黄绿色区
                case 25:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 5";   //陶瓦
                        break;
                    }
                case 26:
                    {
                        WoolColor = "minecraft:concrete 5";  //混凝土
                        break;
                    }
                case 27:
                    {
                        WoolColor = "minecraft:wool 5";  //羊毛
                        break;
                    }
                case 28:
                    {
                        WoolColor = "minecraft:concrete_powder 5";  //混凝土粉末
                        break;
                    }
                case 29:
                    {
                        WoolColor = "minecraft:lime_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //粉红色区
                case 30:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 6";   //陶瓦
                        break;
                    }
                case 31:
                    {
                        WoolColor = "minecraft:concrete 6";  //混凝土
                        break;
                    }
                case 32:
                    {
                        WoolColor = "minecraft:wool 6";  //羊毛
                        break;
                    }
                case 33:
                    {
                        WoolColor = "minecraft:concrete_powder 6";  //混凝土粉末
                        break;
                    }
                case 34:
                    {
                        WoolColor = "minecraft:pink_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //灰色区
                case 35:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 7";   //陶瓦
                        break;
                    }
                case 36:
                    {
                        WoolColor = "minecraft:concrete 7";  //混凝土
                        break;
                    }
                case 37:
                    {
                        WoolColor = "minecraft:wool 7";  //羊毛
                        break;
                    }
                case 38:
                    {
                        WoolColor = "minecraft:concrete_powder 7";  //混凝土粉末
                        break;
                    }
                case 39:
                    {
                        WoolColor = "minecraft:gray_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //淡灰色区
                case 40:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 8";   //陶瓦
                        break;
                    }
                case 41:
                    {
                        WoolColor = "minecraft:concrete 8";  //混凝土
                        break;
                    }
                case 42:
                    {
                        WoolColor = "minecraft:wool 8";  //羊毛
                        break;
                    }
                case 43:
                    {
                        WoolColor = "minecraft:concrete_powder 8";  //混凝土粉末
                        break;
                    }
                case 44:
                    {
                        WoolColor = "minecraft:silver_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //青色区
                case 45:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 9";   //陶瓦
                        break;
                    }
                case 46:
                    {
                        WoolColor = "minecraft:concrete 9";  //混凝土
                        break;
                    }
                case 47:
                    {
                        WoolColor = "minecraft:wool 9";  //羊毛
                        break;
                    }
                case 48:
                    {
                        WoolColor = "minecraft:concrete_powder 9";  //混凝土粉末
                        break;
                    }
                case 49:
                    {
                        WoolColor = "minecraft:cyan_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //紫色区
                case 50:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 10";   //陶瓦
                        break;
                    }
                case 51:
                    {
                        WoolColor = "minecraft:concrete 10";  //混凝土
                        break;
                    }
                case 52:
                    {
                        WoolColor = "minecraft:wool 10";  //羊毛
                        break;
                    }
                case 53:
                    {
                        WoolColor = "minecraft:concrete_powder 10";  //混凝土粉末
                        break;
                    }
                case 54:
                    {
                        WoolColor = "minecraft:purple_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //蓝色区
                case 55:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 11";   //陶瓦
                        break;
                    }
                case 56:
                    {
                        WoolColor = "minecraft:concrete 11";  //混凝土
                        break;
                    }
                case 57:
                    {
                        WoolColor = "minecraft:wool 11";  //羊毛
                        break;
                    }
                case 58:
                    {
                        WoolColor = "minecraft:concrete_powder 11";  //混凝土粉末
                        break;
                    }
                case 59:
                    {
                        WoolColor = "minecraft:blue_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //棕色区
                case 60:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 12";   //陶瓦
                        break;
                    }
                case 61:
                    {
                        WoolColor = "minecraft:concrete 12";  //混凝土
                        break;
                    }
                case 62:
                    {
                        WoolColor = "minecraft:wool 12";  //羊毛
                        break;
                    }
                case 63:
                    {
                        WoolColor = "minecraft:concrete_powder 12";  //混凝土粉末
                        break;
                    }
                case 64:
                    {
                        WoolColor = "minecraft:brown_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //绿色区
                case 65:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 13";   //陶瓦
                        break;
                    }
                case 66:
                    {
                        WoolColor = "minecraft:concrete 13";  //混凝土
                        break;
                    }
                case 67:
                    {
                        WoolColor = "minecraft:wool 13";  //羊毛
                        break;
                    }
                case 68:
                    {
                        WoolColor = "minecraft:concrete_powder 13";  //混凝土粉末
                        break;
                    }
                case 69:
                    {
                        WoolColor = "minecraft:green_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //红色区
                case 70:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 14";   //陶瓦
                        break;
                    }
                case 71:
                    {
                        WoolColor = "minecraft:concrete 14";  //混凝土
                        break;
                    }
                case 72:
                    {
                        WoolColor = "minecraft:wool 14";  //羊毛
                        break;
                    }
                case 73:
                    {
                        WoolColor = "minecraft:concrete_powder 14";  //混凝土粉末
                        break;
                    }
                case 74:
                    {
                        WoolColor = "minecraft:red_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                //黑色区
                case 75:
                    {
                        WoolColor = "minecraft:stained_hardened_clay 15";   //陶瓦
                        break;
                    }
                case 76:
                    {
                        WoolColor = "minecraft:concrete 15";  //混凝土
                        break;
                    }
                case 77:
                    {
                        WoolColor = "minecraft:wool 15";  //羊毛
                        break;
                    }
                case 78:
                    {
                        WoolColor = "minecraft:concrete_powder 15";  //混凝土粉末
                        break;
                    }
                case 79:
                    {
                        WoolColor = "minecraft:black_glazed_terracotta 0";  //带釉陶瓦(彩色)
                        break;
                    }
                case 80:
                    {
                        WoolColor = "minecraft:sea_lantern 0";  //海晶灯
                        break;
                    }
                case 81:
                    {
                        WoolColor = "minecraft:stone 0";  //石头
                        break;
                    }
                case 82:
                    {
                        WoolColor = "minecraft:packed_ice 0";  //浮冰
                        break;
                    }
                case 83:
                    {
                        WoolColor = "minecraft:red_sandstone 2";  //平滑红砂岩
                        break;
                    }
                case 84:
                    {
                        WoolColor = "minecraft:obsidian 0";  //黑曜石
                        break;
                    }
                case 85:
                    {
                        WoolColor = "minecraft:diamond_block 0";  //钻石块
                        break;
                    }
                case 86:
                    {
                        WoolColor = "minecraft:gold_block 0";  //金块
                        break;
                    }
                case 87:
                    {
                        WoolColor = "minecraft:icon_block 0";  //铁块
                        break;
                    }
                case 88:
                    {
                        WoolColor = "minecraft:snow 0";  //雪块
                        break;
                    }
                case 89:
                    {
                        WoolColor = "minecraft:clay 0";  //黏土块
                        break;
                    }
                case 90:
                    {
                        WoolColor = "minecraft:bone_block 0";  //骨块
                        break;
                    }
                case 91:
                    {
                        WoolColor = "minecraft:sandstone 2";  //平滑砂岩
                        break;
                    }
                case 92:
                    {
                        WoolColor = "minecraft:quartz_block 0";  //石英块
                        break;
                    }
                case 93:
                    {
                        WoolColor = "minecraft:hardened_clay 0";  //陶瓦
                        break;
                    }
                case 94:
                    {
                        WoolColor = "minecraft:ice 0";  //带釉陶瓦(彩色)
                        break;
                    }
            }
            return WoolColor;
        }
        #endregion
        int Z, X;
        UInt32 StartColor = 0, NextColor = 0;
        int BeginX = 0;
        int XFor, YFor, ZFor;
        private void GenerateCommand_Click(object sender, EventArgs e)
        {
            try
            {
                if ((XTxt.Text == "" || YTxt.Text == "" || ZTxt.Text == "") || (PreViewImage.ImageLocation == ""))
                {
                    MessageBox.Show("请输入打印像素画平面起始X,Y,Z坐标或选择图像路径");
                    return;
                }
            }
            catch { }
            try
            {
                XFor = Convert.ToInt32(XTxt.Text);
                YFor = Convert.ToInt32(YTxt.Text);
                ZFor = Convert.ToInt32(ZTxt.Text);
            }
            catch
            {
                MessageBox.Show("坐标位置请输入整数");
                return;               
            }
            #region 调色板赋值
            PaletteColors cl;
            cl.palVersion = 0x300;
            cl.palNumEntries = 80;
            //白色
            cl.B1WhiteColor_0 = 0xCBCBCB; //203,203,203
            cl.B2WhiteColor_1 = 0xE7EAEB; //混凝土 231,234,235
            cl.B3WhiteColor_2 = 0xFAFAFA; //羊毛 250,250,250
            cl.B4WhiteColor_3 = 0xECEDED; //混凝土粉末 236, 237, 237
            cl.B5WhiteColor_4 = 0xF5F5F5; //带釉混凝土 245 245 245	
            //橙色
            cl.B6OrangeColor_5 = 0xD0A992; //208, 169, 146
            cl.B7OrangeColor_6 = 0xFF8C00; //255,140,0
            cl.B8OrangeColor_7 = 0xEE7621; //238 118 33
            cl.B9OrangeColor_8 = 0xEEBD8C; //238, 189, 140
            cl.B10OrangeColor_9 = 0xF8B988; //255 140 0
            //品红色
            cl.B11MagentaColor_10 = 0x6F5674; //111, 86, 116
            cl.B12MagentaColor_11 = 0xD02090; //208 32 144
            cl.B13MagentaColor_12 = 0xEE6AA7; //238 106 167
            cl.B14MagentaColor_13 = 0xE066FF; //224 102 255
            cl.B15MagentaColor_14 = 0xB23AEE; //178 58 238
            //淡蓝色
            cl.B16LightBlueColor_15 = 0x63CEF2; //99, 206, 242
            cl.B17LightBlueColor_16 = 0x499DBF; //73, 157, 191
            cl.B18LightBlueColor_17 = 0x86CBDA; //134, 203, 218
            cl.B19LightBlueColor_18 = 0x6699D8; //102, 153, 216
            cl.B20LightBlueColor_19 = 0x00B2EE; //0 178 238
            //黄色
            cl.B21YellowColor_20 = 0xDCC191;//220, 194, 146
            cl.B22YellowColor_21 = 0xEEEE00; //238 238 0
            cl.B23YellowColor_22 = 0xEEB422; //238 180 34
            cl.B24YellowColor_23 = 0xF6E398; //246, 227, 152
            cl.B25YellowColor_24 = 0xFFB90F; //255 185 15
            //黄绿色
            cl.B26LimeColor_25 = 0xB3BA9A; //179, 186, 154
            cl.B27LimeColor_26 = 0x7CFC00; //124 252 0	
            cl.B28LimeColor_27 = 0x76EE00; //118 238 0 
            cl.B29LimeColor_28 = 0xB3EE3A; //179 238 58
            cl.B30LimeColor_29 = 0x32CD32; //50 205 50
            //粉红色
            cl.B31PinkColor_30 = 0xCFA5A6; //207, 165, 166
            cl.B32PinkColor_31 = 0xFF69B4; //255 105 180	
            cl.B33PinkColor_32 = 0xFFD2D9; //255, 210, 217
            cl.B34PinkColor_33 = 0xEE799F; //238 121 159	
            cl.B35PinkColor_34 = 0xF9C5D5; //249, 197, 213
            //灰色
            cl.B36GrayColor_35 = 0x9E9692; //158, 150, 146
            cl.B37GrayColor_36 = 0x9B9C9E; //155, 156, 158
            cl.B38GrayColor_37 = 0x8B8B8B; //139, 139, 139
            cl.B39GrayColor_38 = 0xA7A9AB; //167, 169, 171
            cl.B40GrayColor_39 = 0x696969; //105 105 105	
            //淡灰色
            cl.B41SilverColor_40 = 0xB7B5C4; //183, 181, 196
            cl.B42SilverColor_41 = 0x9C9C9C; //156 156 156
            cl.B43SilverColor_42 = 0xC1BEB9; //193, 190, 185
            cl.B44SilverColor_43 = 0xD0CEC9; //208, 206, 201
            cl.B45SilverColor_44 = 0xC3B5B0; //195,181,176
            //青色
            cl.B46CyanColor_45 = 0xABADAD; //171, 173, 173
            cl.B47CyanColor_46 = 0x1E90FF; //30 144 255
            cl.B48CyanColor_47 = 0x73DAFB; //115, 218, 251
            cl.B49CyanColor_48 = 0x56BCEC; //86, 188, 236
            cl.B50CyanColor_49 = 0x00CDCD; //0 205 205
            //紫色
            cl.B51PurpleColor_50 = 0x58415D; //88, 65, 93
            cl.B52PurpleColor_51 = 0xD497CF; //212, 151, 207
            cl.B53PurpleColor_52 = 0xEBB0E8; //235, 176, 232
            cl.B54PurpleColor_53 = 0xD15FEE; //209 95 238
            cl.B55PurpleColor_54 = 0x912CEE; //145 44 238
            //蓝色
            cl.B56BlueColor_55 = 0x334CB2; //51, 76, 178
            cl.B57BlueColor_56 = 0x27539A; //39, 83, 154
            cl.B58BlueColor_57 = 0x487AC1; //72, 122, 193
            cl.B59BlueColor_58 = 0x3156AE; //49, 86, 174
            cl.B60BlueColor_59 = 0x00008B; //0 0 139
            //棕色
            cl.B61BrownColor_60 = 0xA79A92; //167, 154, 146
            cl.B62BrownColor_61 = 0x8B4513; //139 69 19
            cl.B63BrownColor_62 = 0x8B5A49; //139,90,73
            cl.B64BrownColor_63 = 0xBDA89A; //189, 168, 154
            cl.B65BrownColor_64 = 0x8B2323; //139 35 35
            //绿色
            cl.B66GreenColor_65 = 0xA6AA95; //166, 170, 149
            cl.B67GreenColor_66 = 0x556B2F; //85 107 47
            cl.B68GreenColor_67 = 0x6B8E23; //107 142 35
            cl.B69GreenColor_68 = 0xBCEE68; //188 238 104
            cl.B70GreenColor_69 = 0x548B54; //84 139 84
            //红色
            cl.B71RedColor_70 = 0xC89F98; //200, 158, 151
            cl.B72RedColor_71 = 0xEE2C2C; //238 44 44
            cl.B73RedColor_72 = 0xEE0000; //238 0 0
            cl.B74RedColor_73 = 0xD39491; //211, 148, 145
            cl.B75RedColor_74 = 0xCD3700; //205 55 0
            //黑色
            cl.B76BlackColor_75 = 0x8B4726; //139 71 38
            cl.B77BlackColor_76 = 0x000000; //0 0 0
            cl.B78BlackColor_77 = 0x363636; //54 54 54
            cl.B79BlackColor_78 = 0x5B5B5B; //47,47,47
            cl.B80BlackColor_79 = 0x8B0000; //139 0 0
            //额外
            cl.B81Extra = 0xF1F5F3; //海晶灯 241, 245, 243
            cl.B82Extra = 0xBFBFBF; //石头 191, 191, 191
            cl.B83Extra = 0xCCDDED; //浮冰 204, 221, 237
            cl.B84Extra = 0xD2AA8E; //平滑红砂岩 210, 170, 142
            cl.B85Extra = 0x4E4E4E; //黑曜石 78,78,78
            cl.B86Extra = 0xEE9A49; //238 154 73 //钻石块
            cl.B87Extra = 0xFFF8A2; //金块 255, 248, 162
            cl.B88Extra = 0xF3F3F3; //铁块 243, 243, 243
            cl.B89Extra = 0xF1F9F9; //雪块 241, 249, 249
            cl.B90Extra = 0xD2D4DC; //黏土块 210, 212, 220
            cl.B91Extra = 0xD8D5C6; //骨块 216, 213, 198
            cl.B92Extra = 0xEBE7CF; //平滑砂岩 235, 231, 207
            cl.B93Extra = 0xF6F4F1; //石英块 246, 244, 241
            cl.B94Extra = 0xC9AB9E; //陶瓦 201, 171, 158
            cl.B95Extra = 0xBFCFE9; //冰 191, 207, 233
            //暂时
            #endregion
            IntPtr Palette = CreatePalette(ref cl);
            Bitmap bitmap = new Bitmap(ImagePath);
            Color color = bitmap.GetPixel(0, 0);
            UInt32 i = (UInt32)(color.R + color.G * 256 + color.G * 65536);
            NextColor = i;
            CommandsTxt.Text = "";
            try
            {
                for (Z = 0; Z <= bitmap.Height - 1; Z++)
                {
                    for (X = 0; X <= bitmap.Width - 1; X++)
                    {
                        Color colorWidth = bitmap.GetPixel(X, Z);
                        UInt32 j = (UInt32)(colorWidth.R + colorWidth.G * 256 + colorWidth.B * 65536);
                        StartColor = j;
                        if (StartColor != NextColor)
                        {
                            if (X - 1 == BeginX)
                            {
                                SetBlockCommand(BeginX + XFor, YFor, Z + ZFor, ReturnWoolColor(NextColor, Palette));
                            }
                            else
                            {
                                FillCommand(BeginX + XFor, YFor, Z + ZFor, X - 1 + XFor, YFor, Z + ZFor, ReturnWoolColor(NextColor, Palette));
                            }
                            NextColor = StartColor;
                            BeginX = X;
                        }
                    }
                    if (X - 1 == BeginX)
                    {
                        SetBlockCommand(BeginX + XFor, YFor, Z + ZFor, ReturnWoolColor(NextColor, Palette));
                    }
                    else
                    {
                        FillCommand(BeginX + XFor, YFor, Z + ZFor, X - 1 + XFor, YFor, Z + ZFor, ReturnWoolColor(NextColor, Palette));
                    }
                    Color colorWidth_1 = bitmap.GetPixel(0, Z + 1);
                    UInt32 d = (UInt32)(colorWidth_1.R + colorWidth_1.G * 256 + colorWidth_1.B * 65536);
                    NextColor = d;
                    BeginX = 0;
                }

                DeleteObject(Palette);
            }
            catch { }
            MessageBox.Show("指令生成完毕，请封装成function函数指令");
        }
        private void CommandSend_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(2000);
            //AutoSend();
        }
        string ImagePath = "";
        private void Main_Load(object sender, EventArgs e)
        {
            Bitmap LoadImage = new Bitmap(128, 128);
            Graphics g = Graphics.FromImage(LoadImage);
            Point point = new Point(25, 55);
            g.DrawString("请加载图片", new Font("宋体", 12, FontStyle.Bold), new SolidBrush(Color.Red), point);
            PreViewImage.Image = LoadImage;
        }

        public string FunctionsFiles = "";
        private void Function_Click(object sender, EventArgs e)
        {
            if (CommandsTxt.Text == "")
            {
                MessageBox.Show("请先生成指令");
                return;
            }
            #region 压缩指令
            if (MapPath.Text != "")
            {
                DirectoryInfo Myfunction = new DirectoryInfo(FunctionsPath + "\\data\\functions\\PixelPainting");
                if (!Myfunction.Exists)
                {
                    Myfunction.Create();
                }

                //if (CommandsTxt.Lines.Length <= 65536)
                //{
                    FunctionsFiles = FunctionsPath + "\\data\\functions\\PixelPainting\\" + ImageName + ".mcfunction";
                    FileInfo fileinfo = new FileInfo(FunctionsFiles);
                    if (!fileinfo.Exists)
                    {
                        fileinfo.Create().Close();
                    }
                    //
                    byte[] bytes = Encoding.UTF8.GetBytes(CommandsTxt.Text.Replace('*',' '));
                    FileStream FileWay_1 = new FileStream(FunctionsFiles, FileMode.Open, FileAccess.Write, FileShare.Write);
                    FileWay_1.Write(bytes, 0, bytes.Length);
                    FileWay_1.Close();

                    CommandsTxt.Clear();
                    CommandsTxt.AppendText("往MC客户端按以下顺序手动输入指令：\r\n");
                    CommandsTxt.AppendText("/reload\r\n");
                    CommandsTxt.AppendText("/function PixelPainting:" + ImageName + "\r\n");
                //}
  /*              else
                {
                    int TxtCount = 0; //标志创建.mcfunction数量
                    string [] Commands = new string[CommandsTxt.Lines.Length];
                    for (int i = 0; i < Commands.Length; i++)
                    {
                        Commands[i] = CommandsTxt.Lines[i];
                    }

                    string result = (CommandsTxt.Lines.Length / 65536).ToString();
                    TxtCount = Convert.ToInt32(result.Substring(0, result.IndexOf("."))) + 1;
                    for (int j = 0; j < TxtCount; j++)
                    {
                        FunctionsFiles = FunctionsPath + "\\data\\functions\\PixelPainting\\" + ImageName + "__" + j + ".mcfunction";
                        FileInfo fileinfo = new FileInfo(FunctionsFiles);
                        if (!fileinfo.Exists)
                        {
                            fileinfo.Create().Close();
                        }
                        
                        byte[] bytes = Encoding.UTF8.GetBytes(CommandsTxt.Text);
                        FileStream FileWay_1 = new FileStream(FunctionsFiles, FileMode.Open, FileAccess.Write, FileShare.Write);
                        FileWay_1.Write(bytes, 0, bytes.Length);
                        FileWay_1.Close();
                    }

                }*/
                //using (StreamWriter WriteCommands = new StreamWriter(file_,Encoding.UTF8))
                //{
                //        WriteCommands.Write(CommandsTxt.Text.Replace('*', ' '));
                //        WriteCommands.Flush();
                //        WriteCommands.Close();
                //        file_.Close();
                //}
            }
            else
            {
                MessageBox.Show("压缩指令前请选择客户端路径");
                return;
            }
#endregion
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://qm.qq.com/cgi-bin/qm/qr?k=Gnb5EehRakdedbP84A7FsdULgZ0q7Q34&authKey=Q%2FlRjQFbsHArSomDtKc1bKwvU7PUnIee7OrT410nNKCHb%2BsLUHsf4ZPHlxhDsFZp&group_code=695734979");
        }
        public string FunctionsPath = "";
        private void Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog functionFolders = new FolderBrowserDialog();
            if (functionFolders.ShowDialog() == DialogResult.OK)
            {
                FunctionsPath = functionFolders.SelectedPath;
                MapPath.Text = functionFolders.SelectedPath;
            }
        }
        public string ImageName = "";
        private void OpenPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "位图格式|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.psd";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog1.FileName;
                PreViewImage.ImageLocation = ImagePath;
                Bitmap bit = new Bitmap(ImagePath);
                String name = ImagePath.Substring(ImagePath.LastIndexOf("\\") + 1);
                ImageName = name.Substring(0, name.LastIndexOf("."));
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(GetAsyncKeyState(117)!=0)
            {
                AutoSend();
            }
        }
        //int keyState = 0;
        //private void Main_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.F)
        //    {
        //        MessageBox.Show("24");
        //    }
        //}

        public void AutoSend()
        {
            try
            {
                ProcessState State = ProcessState.Default;
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (!((process.ProcessName.ToLower() == "javaw") || (process.ProcessName.ToLower() == "java")))  //参数可能是java也可能是javaw
                    {
                        if (State != ProcessState.Exist)
                        {
                            State = ProcessState.DisExist;
                        }
                    }
                    else
                    {
                        State = ProcessState.Exist;
                    }
                }
                if (State == ProcessState.DisExist)
                {
                    MessageBox.Show("没有查找到MC客户端进程，请打开客户端");
                    return;
                }
                else
                {
                    Process[] processesJava = Process.GetProcessesByName("java");
                    IntPtr McClient = FindWindow(null, processesJava[0].MainWindowTitle);
                    ShowWindowAsync(McClient, 3);
                    //if(SetForegroundWindow(McClient))
                    //{
                    //    MessageBox.Show("MC客户端窗口已激活");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("没有激活");
                    //}
                    
                    //Process[] processes1 = Process.GetProcessesByName("java");
                    //IntPtr McPtr = FindWindow(null, processes1[0].MainWindowTitle);
                    //MessageBox.Show(processes1[0].MainWindowTitle);
                    //ShowWindowAsync(McClient, 3);
                }
            }
            catch { }
            string[] Lines = CommandsTxt.Text.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < Lines.Length; i++)
            {
                Lines[i] = Lines[i].Trim();
                if (Lines[i] != "")
                {
                    keybd_event((byte)Keys.T, 0, 0, 0);
                    Thread.Sleep(10);
                    Application.DoEvents();
                    keybd_event((byte)Keys.T, 0, 2, 0);
                    Thread.Sleep(100);
                    Application.DoEvents();

                    SendKeys.Send(Lines[i] + "\r");
                    Application.DoEvents();
                    Thread.Sleep(200);
                    Application.DoEvents();
                }
                if (GetAsyncKeyState(118) != 0)
                {
                    break;
                }
            }
        }
    }
}
