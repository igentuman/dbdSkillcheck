using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ScreenCaptureTest
{


    public partial class Form1 : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        ImageHelper imgHelper;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public Form1()
        {
            InitializeComponent();
 
            imgHelper = new ImageHelper();
            imgHelper.postProcessedScreenshot = pictureBox8;
            imgHelper.mainScreenshot = pictureBox1;
            imgHelper.arrowAngleLbl = label1;
            imgHelper.perfectAngleLbl = label2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            imgHelper.RVal = int.Parse(r.Text);
            imgHelper.GVal = int.Parse(g.Text);
            imgHelper.BVal = int.Parse(b.Text);

            imgHelper.RRing = int.Parse(r_ring.Text);
            imgHelper.GRing = int.Parse(g_ring.Text);
            imgHelper.BRing = int.Parse(b_ring.Text);
            imgHelper.grabFrame();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap tempo = imgHelper.CaptureWindow();
            Rectangle kek = new Rectangle(1205, 645, 140, 140);

            Bitmap cloneTempo = tempo.Clone(kek, PixelFormat.Format32bppRgb);
            pictureBox8.Image = imgHelper.PostProcess(tempo);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Bitmap tempo = imgHelper.CaptureWindow();
            Rectangle kek = new Rectangle(1205, 645, 140, 140);

            Bitmap cloneTempo = tempo.Clone(kek,PixelFormat.Format32bppRgb);
            pictureBox8.Image = imgHelper.PostProcess(tempo);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(e.KeyChar == 'x')
            {
                Form1.ActiveForm.Size = new Size(180,200);
                Form1.ActiveForm.TransparencyKey = Color.Black;
                Form1.ActiveForm.FormBorderStyle = FormBorderStyle.None;
            }
            if(e.KeyChar == 'c')
            {
                Form1.ActiveForm.Size = new Size(180, 524);
                Form1.ActiveForm.TransparencyKey = Color.OrangeRed;
                Form1.ActiveForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
        }

        
    }
}
