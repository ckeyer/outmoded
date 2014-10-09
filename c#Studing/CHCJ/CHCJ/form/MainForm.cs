using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CHCJ
{
    public partial class MainForm : Form
    {
        public const string imgDir = "../../resource/img/";
        public const string icoDir = "../../resource/ico/";
        private CJLog log = new CJLog(CJLog.LogLevel.ALL, CJLog.LogModel.MESSAGE_BOX_SHOW);
        public CJUser user_local;
        form.UserListBox ul;

        private Point mouse_sub_form;
        public MainForm()
        {
            InitializeComponent();
            /* Test Start */
            // user_local = new CJUser();
            //             StringBuilder s = new StringBuilder();
            //             s.Append(user_local.FriendsCount.ToString());
            //             foreach (user u in user_local.Friends)
            //             {
            //                 s.Append(u.id + ":");
            //                 s.Append(u.name + "\r\n");
            //             }
            //             log.loging(s.ToString(), CJLog.LogLevel.DEBUG);
            /* Test Over */
        }
        public MainForm(CJUser luser)
        {
            InitializeComponent();
            user_local = luser;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Icon icon = new Icon(icoDir+"mine.ico");
            this.Icon = icon;

            notifyIcon1.Icon = new Icon(icoDir + "mine.ico");
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Image.FromFile(imgDir + "close.png");

            ul= new form.UserListBox(user_local);
            ul.Location = new Point(0, 60);
            ul.BackColor = Color.White;
            this.Controls.Add(ul);
            ul.Show();
        }


        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(imgDir + "closing.png");
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(imgDir + "close.png");
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(imgDir + "close.png");
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(imgDir + "closing.png");
            this.Visible = false;
            //notifyIcon1.Dispose();
            //System.Environment.Exit(0);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = !this.Visible;
        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                
                contextMenuStrip1.Show();
            }
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            System.Environment.Exit(0);
        }
        private void 显示主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true; ;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_sub_form.X = e.X;
            mouse_sub_form.Y = e.Y;
            timer_moving_from.Start();
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            timer_moving_from.Stop();
        }
        private void timer_moving_from_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(Control.MousePosition.X - mouse_sub_form.X,
                Control.MousePosition.Y - mouse_sub_form.Y);
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.Visible = !this.Visible;
        }

    }
}
