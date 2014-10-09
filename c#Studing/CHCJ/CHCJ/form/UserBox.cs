using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CHCJ.form
{
    public partial class UserBox : UserControl
    {
        public const string def_noline_img = "../../resource/img/online.png";
        public const string def_downline_img = "../../resource/img/online2.bmp";
        public string state_img = "../../resource/img/online2.bmp";
        public string Id, Name;
        private bool check = false;
        private bool active = false;
        private bool online = false;
        public DelegateActiveFriendHandle ActiveFriend ;
        public delegate void CB_V_V();
        public UserBox()
        {
            InitializeComponent();
            init();
        }
        public UserBox(string id,string name)
        {
            InitializeComponent();
            Id = id;
            Name = name;
            this.BackColor = Color.White;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.BackgroundImage = Image.FromFile(state_img);
            this.label1.Text = id;
            this.label2.Text = name;
            init();
        }
        public UserBox(user u)
        {
            InitializeComponent();
            this.Id = u.id;
            this.Name = u.name;
            this.Online = u.is_online;
            this.BackColor = Color.White;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.BackgroundImage = Image.FromFile(state_img);
            this.label1.Text = u.id;
            this.label2.Text = u.name;
            init();
        }
        private void init()
        {
            this.pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);
            this.label1.MouseClick += new MouseEventHandler(label1_MouseClick);
            this.label2.MouseClick += new MouseEventHandler(label2_MouseClick);
            this.pictureBox1.MouseDoubleClick += new MouseEventHandler(pictureBox1_MouseDoubleClick);
            this.label1.MouseDoubleClick += new MouseEventHandler(label1_MouseDoubleClick);
            this.label2.MouseDoubleClick += new MouseEventHandler(label2_MouseDoubleClick);
        }

        void label1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Check = true;
        }
        void label2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Check = true;
        }
        void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Check = true;
        }

        void label2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            start_chat();
        }
        void label1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            start_chat();
        }
        void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            start_chat();
        }

        public bool Check
        {
            set 
            {
                if (value == this.check)
                {
                    ;
                }
                else if(value == true)
                {
                    this.check = true;
                    CB_V_V toBigger = new CB_V_V(check_UBox);
                    this.Invoke(toBigger);
                    activeFriend("check");
                }
                else
                {
                    this.check = false;
                    CB_V_V toSmaller = new CB_V_V(uncheck_UBox);
                    this.Invoke(toSmaller);
                }
            }
            get 
            {
                return check; 
            }
        }
        public void check_UBox()
        {
            this.Size = new Size(230,40);
            this.pictureBox1.Size = new Size(40, 40);
            this.pictureBox1.Location = new Point(0, 0);

            this.label1.Size = new Size(185, 20);
            this.label1.Location = new Point(45, 0);

            this.label2.Size = new Size(185, 20);
            this.label2.Location = new Point(45, 20);
        }
        public void uncheck_UBox()
        {
            this.Size = new Size(230, 20);
            this.pictureBox1.Size = new Size(20, 20);
            this.pictureBox1.Location = new Point(0, 0);
            this.label1.Size = new Size(80, 20);
            this.label1.Location = new Point(20, 0);
            this.label2.Size = new Size(127, 20);
            this.label2.Location = new Point(100, 0);
        }

        public bool Active
        {
            set
            {
                if (value == this.active)
                    ;
                else if (value == true)
                    timer_active.Start();
                else
                    timer_active.Stop();
            }
        }
        private void timer_active_Tick(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }

        public bool Online
        {
            set
            {
                if (value == this.online)
                    ;
                else if (value == true)
                    online_UBox();
                else
                    downline_UBox();
            }
        }
        private void online_UBox()
        {
            state_img = def_noline_img;
            this.pictureBox1.BackgroundImage = Image.FromFile( state_img);
        }
        private void downline_UBox()
        {
            state_img = def_downline_img;
            this.pictureBox1.BackgroundImage = Image.FromFile(state_img);
        }

        public void start_chat()
        {
            activeFriend("chat") ;
            this.Active = false;
            this.Visible = true;
        }

        public void clear()
        {
            activeFriend("clear");
        }

        private void activeFriend(string type)
        {
            if (ActiveFriend != null)
            {
                CJActiveFriendEvent e = new CJActiveFriendEvent();
                e.Id = this.Id;
                e.Type = type.ToString();
                ActiveFriend(this, e);
            }
        }

    }
}
