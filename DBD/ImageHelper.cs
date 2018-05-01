using System.Numerics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ScreenCaptureTest
{
    

    class ImageHelper
    {
        
        Bitmap screen;
        Bitmap postProcessedScreen;
        public int screenHeight         = 1440;
        public int screenWidth          = 2560;
        public int skillCheckSize       = 140;
        public bool debugModeFlag       = false;

        public int RVal  = 214;
        public int GVal = 20;
        public int BVal = 20;

        public int BRing = 150;
        public int GRing = 100;
        public int RRing = 100;

        public PictureBox mainScreenshot;
        public PictureBox postProcessedScreenshot;
        public Label arrowAngleLbl;
        public Label perfectAngleLbl;
        float chillTicks = 0;
        public Vector2 RotateVector(Vector2 v,int angle)
        {
            double deg = System.Math.PI /  180;
            float x1 = v.X * (float)System.Math.Cos(deg) - v.Y * (float)System.Math.Sin(deg);
            float y1 = v.Y * (float)System.Math.Cos(deg) + v.X * (float)System.Math.Sin(deg);
            v.X = x1;
            v.Y = y1;
            return v;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public int perfectAngle = 0;
        public int arrowAngle = 0;
        public Bitmap PostProcess(Bitmap Image)
        {

            Bitmap NewBitmap = new Bitmap(Image.Size.Width, Image.Size.Height);
           
            
            int checkRadius = skillCheckSize / 2;
            Vector2 RoundTest = new Vector2(0, -skillCheckSize / 2 + 5);

            arrowAngle = 0;
            Color blue = Color.FromArgb(150,Color.Blue);
            

          for(int i = 1; i < 360; i++)
            {
                ///if(i > 90) { break; };
                RoundTest = RotateVector(RoundTest, i);
                
                int x = (int)RoundTest.X;
                int y = (int)RoundTest.Y;
                x += skillCheckSize / 2;
                y += skillCheckSize / 2;
                
                Color tes = Image.GetPixel(x, y);

                if (tes.R < RRing)
                {
                    NewBitmap.SetPixel(x, y, blue);
                } else
                {
                    if(tes.B < BVal && tes.G < GVal)
                    {
                        //arrow
                        NewBitmap.SetPixel(x, y, Color.Green);
                        if(arrowAngle == 0)
                        {
                            arrowAngle = i + 90;
                        }
                    } else
                    {
                        NewBitmap.SetPixel(x, y, Color.Yellow);
                        if (perfectAngle == 0 && arrowAngle > 0)
                        {
                            perfectAngle = i+90;
                            
                        }
                    }
                }
                if(perfectAngle > 0 && arrowAngle > 0)
                {
                    break;
                }
            }
          if((arrowAngle > perfectAngle-5 || arrowAngle == perfectAngle-5) && perfectAngle > 0)
            {
                arrowAngle = 0;
                perfectAngle = 0;
                char e = 'E';
                keybd_event((byte)e, 0, 0x0001, 0);
                keybd_event((byte)e, 0, 0x0002, 0);
                chillTicks = 200;
            }

            arrowAngleLbl.Text = arrowAngle.ToString();
            perfectAngleLbl.Text = perfectAngle.ToString();
            return NewBitmap;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr WindowHandle);

        [DllImport("user32.dll")]
        private static extern void ReleaseDC(IntPtr WindowHandle, IntPtr DC);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr WindowHandle, ref RECT rect);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            private int _Left;
            private int _Top;
            private int _Right;
            private int _Bottom;

            public RECT(RECT Rectangle) : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
            {
            }
            public RECT(int Left, int Top, int Right, int Bottom)
            {
                _Left = Left;
                _Top = Top;
                _Right = Right;
                _Bottom = Bottom;
            }

            public int X
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Y
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Left
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Top
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Right
            {
                get { return _Right; }
                set { _Right = value; }
            }
            public int Bottom
            {
                get { return _Bottom; }
                set { _Bottom = value; }
            }
            public int Height
            {
                get { return _Bottom - _Top; }
                set { _Bottom = value + _Top; }
            }
            public int Width
            {
                get { return _Right - _Left; }
                set { _Right = value + _Left; }
            }
            public Point Location
            {
                get { return new Point(Left, Top); }
                set
                {
                    _Left = value.X;
                    _Top = value.Y;
                }
            }
            public Size Size
            {
                get { return new Size(Width, Height); }
                set
                {
                    _Right = value.Width + _Left;
                    _Bottom = value.Height + _Top;
                }
            }

            public static implicit operator Rectangle(RECT Rectangle)
            {
                return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
            }
            public static implicit operator RECT(Rectangle Rectangle)
            {
                return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
            }
            public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
            {
                return Rectangle1.Equals(Rectangle2);
            }
            public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
            {
                return !Rectangle1.Equals(Rectangle2);
            }

            public override string ToString()
            {
                return "{Left: " + _Left + "; " + "Top: " + _Top + "; Right: " + _Right + "; Bottom: " + _Bottom + "}";
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool Equals(RECT Rectangle)
            {
                return Rectangle.Left == _Left && Rectangle.Top == _Top && Rectangle.Right == _Right && Rectangle.Bottom == _Bottom;
            }

            public override bool Equals(object Object)
            {
                if (Object is RECT)
                {
                    return Equals((RECT)Object);
                }
                else if (Object is Rectangle)
                {
                    return Equals(new RECT((Rectangle)Object));
                }

                return false;
            }
        }
        public RECT rct;
        public bool initedFlag = false;
        public Process proc;
        public Bitmap CaptureWindow()
        {
            if( ! initedFlag)
            {
                proc = Process.GetProcessesByName("phpstorm64")[0];


                rct = new RECT();
                GetWindowRect(proc.Handle, ref rct);
                int width = rct.Right - rct.Left;
                int height = rct.Bottom - rct.Top;
                if (width == 0)
                {
                    width = screenWidth;
                    height = screenHeight;
                }

                screen = new Bitmap(width, height, PixelFormat.Format32bppRgb);
                initedFlag = true;
            }
            

            using (Graphics memory_graphics = Graphics.FromImage(screen))
            {
                IntPtr hdc = memory_graphics.GetHdc();
                PrintWindow(proc.Handle, hdc, 0);
                memory_graphics.ReleaseHdc(hdc);
            }

            return screen;
        }

        public void grabFrame()
        {
            if (chillTicks > 0)
            {
                chillTicks--;
                return;
            }
                if (screen == null)
            {
                screen = new Bitmap(skillCheckSize, skillCheckSize);
                postProcessedScreen = new Bitmap(skillCheckSize, skillCheckSize);
                
            }

            using (Graphics g = Graphics.FromImage(screen))
            {
                Size sz = new Size();
                sz.Height = screenHeight / 2 + skillCheckSize;
                sz.Width = screenWidth / 2 + skillCheckSize;
                g.CopyFromScreen((screenWidth - skillCheckSize)/2, (screenHeight - skillCheckSize) / 2, 0, 0, sz);
                //screen.Save("test_source.bmp");
   

            }

            postProcessedScreen = PostProcess(screen);
            if(postProcessedScreenshot != null)
            {
                postProcessedScreenshot.Image = postProcessedScreen;
            }
            
           
          
        }
      
    }
}
