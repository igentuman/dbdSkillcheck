using System.Numerics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using static MouseOperations;
using System.Threading.Tasks;

namespace ScreenCaptureTest
{
    class ImageHelper
    {
        private Bitmap screen = new Bitmap(skillCheckSize, skillCheckSize);
        private Size sz = new Size(screenWidth / 2 + skillCheckSize, screenHeight / 2 + skillCheckSize);
        private Vector2 RoundTest = new Vector2(0, -skillCheckSize / 2 + 5);
        public static int screenHeight         = 1080;
        public static int screenWidth          = 1920;
        public int verticalShift        = 24;
        public static int skillCheckSize       = 140;
        public bool debugModeFlag       = false;
        public int perfectAngle = 0;
        public int arrowAngle = 0;

        public int RVal  = 214;
        public int GVal = 20;
        public int BVal = 20;

        public int BRing = 150;
        public int GRing = 100;
        public int RRing = 100;

        public ImageHelper(Main main)
        {
            this.main = main;
        }

        float chillTicks = 0;
        public Vector2 RotateVector(Vector2 v,int angle)
        {
            double deg = Math.PI /  180;
            float x1 = v.X * (float)Math.Cos(deg) - v.Y * (float)Math.Sin(deg);
            float y1 = v.Y * (float)Math.Cos(deg) + v.X * (float)Math.Sin(deg);
            v.X = x1;
            v.Y = y1;
            return v;
        }
        

        public void DetectSkillCheck(Bitmap Image)
        {
            arrowAngle = 0;
            perfectAngle = 0;
            RoundTest = new Vector2(0, -skillCheckSize / 2 + 5);
            for (int i = 1; i < 360; i++)
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
                    // postProcessedScreen.SetPixel(x, y, blue);
                } else
                {
                    if(tes.B < BVal && tes.G < GVal)
                    {
                        //arrow
                        //  postProcessedScreen.SetPixel(x, y, Color.Green);
                        if(arrowAngle == 0)
                        {
                            arrowAngle = i + 90;
                        }
                    } else
                    {
                        // postProcessedScreen.SetPixel(x, y, Color.Yellow);
                        if (perfectAngle == 0 && arrowAngle > 0)
                        {
                            perfectAngle = i+90;
                        }
                    }
                }
                if(perfectAngle > 0 && arrowAngle > 0)
                {
                    if (arrowAngle < 180) arrowAngle++;
                    return;
                }
            }
        }

        private Main main;

        public void ProcessFrame()
        {
            if (chillTicks > 0)
            {
                chillTicks--;
                return;
            }
            using (Graphics g = Graphics.FromImage(screen))
            {
                g.CopyFromScreen((screenWidth - skillCheckSize) / 2, (screenHeight - verticalShift - skillCheckSize) / 2, 0, 0, sz);
            }
           

            DetectSkillCheck(screen);
            
            if ((arrowAngle >= perfectAngle - 4 && perfectAngle > 0) && arrowAngle < perfectAngle + 8)
            {
                arrowAngle = 0;
                perfectAngle = 0;
                main.scoreSkillCheck();
                chillTicks = 1;
            }
            Main.isSkillCheckVisible = arrowAngle > 0 && perfectAngle > 0;
        }
    }
}
