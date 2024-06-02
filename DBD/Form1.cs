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
using static System.Windows.Forms.LinkLabel;
using System.Windows.Forms.VisualStyles;

namespace ScreenCaptureTest
{
    public partial class Main : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        public static bool isSkillCheckVisible = false;
        private bool skipConfig = false;
        private KeyboardHook minimizeHook = new KeyboardHook();
        private KeyboardHook onOffHook = new KeyboardHook();
        private bool iSMinimize = false;
        private bool isActive = true;
        private long UsedMemory;
        private int cleanupTimeout = 100;
        private ImageHelper imgHelper;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public Main()
        {
            InitializeComponent();
            imgHelper = new ImageHelper(this);
            RegisterGlobalHotKey();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isActive) return;

            imgHelper.ProcessFrame();

            timer1.Interval = 16;

            if (isSkillCheckVisible)
            {
                if (indicator.BackColor != Color.DeepSkyBlue)
                {
                    indicator.BackColor = Color.DeepSkyBlue;
                }
                timer1.Interval = 1;
            }
            else
            {
                if (indicator.BackColor != Color.Lime)
                {
                    indicator.BackColor = Color.Lime;
                }
                //handleMemoryCleanup();
            }
        }

        private void handleMemoryCleanup()
        {
            cleanupTimeout--;
            if (cleanupTimeout < 0)
            {
                UsedMemory = System.Diagnostics.Process.GetCurrentProcess().PagedMemorySize64;
                if (UsedMemory > 84857600) //10 Mb
                {
                    GC.Collect();
                }
                cleanupTimeout = 100;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            imgHelper.RVal = int.Parse(r.Text);
            imgHelper.GVal = int.Parse(g.Text);
            imgHelper.BVal = int.Parse(b.Text);

            imgHelper.RRing = int.Parse(r_ring.Text);
            imgHelper.GRing = int.Parse(g_ring.Text);
            imgHelper.BRing = int.Parse(b_ring.Text);
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(!File.Exists(Path.Combine(docPath, "dbd_skillcheck_bind.cfg"))) return;
            using (StreamReader reader = new StreamReader(Path.Combine(docPath, "dbd_skillcheck_bind.cfg")))
            {
                string text = reader.ReadToEnd();
                skipConfig = true;
                skillcheck_bind.SelectedIndex = int.Parse(text);
            }
        }
            
        private void RegisterGlobalHotKey()
        {
            minimizeHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(MinimizeHook);
            minimizeHook.RegisterHotKey((ModifierKeys)(2 | 4), Keys.E);

            onOffHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(OnOffHook);
            onOffHook.RegisterHotKey((ModifierKeys)(2 | 4), Keys.Q);
        }

        void OnOffHook(object sender, KeyPressedEventArgs e)
        {
            isActive = !isActive;
            if(isActive)
            {
                indicator.BackColor = Color.Lime;
            } else
            {
                indicator.BackColor = Color.Red;
            }
        }

        void MinimizeHook(object sender, KeyPressedEventArgs e)
        {
            if (iSMinimize)
            {
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
                Size = new Size(181, 177);
                indicator.Visible = false;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                Size = new Size(16, 16);
                Location = new Point(1, 1);
                indicator.Visible = true;
            }
            iSMinimize = !iSMinimize;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(skipConfig)
            {
                skipConfig = false;
                return;
            }
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "dbd_skillcheck_bind.cfg")))
            {
                    outputFile.WriteLine(skillcheck_bind.SelectedIndex);
            }
        }

        public void scoreSkillCheck()
        {
            switch (skillcheck_bind.Text) {
                case "Mouse1":
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                    break;
                case "Mouse2":
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                    break;
                case "Mouse Middle":
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.MiddleDown);
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.MiddleUp);
                    break;
                case "Space":
                    KeyboardOperations.PressKey((byte)System.Windows.Forms.Keys.Space);
                    break;
                case "Tab":
                    KeyboardOperations.PressKey((byte)System.Windows.Forms.Keys.Tab);
                    break;
                default:
                    KeyboardOperations.PressKey((byte)skillcheck_bind.Text[0]);
                    break;
            }
            indicator.BackColor = Color.Yellow;
        }
    }
}
