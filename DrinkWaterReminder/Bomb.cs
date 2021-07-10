using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DrinkWaterReminder
{
    public partial class Bomb : Form
    {

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        private const int AW_HOR_POSITIVE = 0x0001;
        private const int AW_HOR_NEGATIVE = 0x0002;
        private const int AW_VER_POSITIVE = 0x0004;
        private const int AW_VER_NEGATIVE = 0x0008;
        private const int AW_CENTER = 0x0010;
        private const int AW_HIDE = 0x10000;
        private const int AW_ACTIVE = 0x20000;
        private const int AW_SLIDE = 0x40000;
        private const int AW_BLEND = 0x80000;

        public Bomb()
        {
            InitializeComponent();
        }

        private void Bomb_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);
            AnimateWindow(this.Handle, 1000, AW_ACTIVE);
        }

        private void Bomb_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_HIDE);
        }
    }
}
