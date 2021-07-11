using System;
using System.Windows.Forms;

namespace DrinkWaterReminder
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitMenuItem();
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        private void InitMenuItem()
        {
            MenuItem[] menuItems = new MenuItem[1];
            MenuItem exit = new MenuItem();
            exit.Text = "关闭";
            exit.Click += new System.EventHandler(this.Exit);
            menuItems[0] = exit;
            ContextMenu contextMenu = new ContextMenu(menuItems);
            notifyIcon.ContextMenu = contextMenu;
        }

        private void Exit(object sender, System.EventArgs e)
        {
            timer.Stop();
            this.Close();
            this.Dispose(true);
        }

        private void BtnSure_Click(object sender, EventArgs e)
        {
            pictureBox.Visible = true;
            int interval = (int)numericUpDown.Value;
            timer.Interval = interval * 1000 * 60;
            timer.Start();
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            pictureBox.Visible = false;
            label.Text = "『每隔 " + numericUpDown.Value.ToString() + "分钟提醒一次』";
            timer.Stop();
        }

        private Bomb bomb;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (bomb == null)
            {
                bomb = new Bomb();
                bomb.Show();
            }
            else
            {
                if (bomb.IsDisposed)
                {
                    bomb = new Bomb();
                    bomb.Show();
                }
                else
                {
                    bomb.Activate();
                }
            }
        }
    }
}
