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
    public partial class UserListBox : UserControl
    {
        public const string imgDir = "../../resource/img/";
        public const string def_noline_img = "../../resource/img/online.png";
        public const string def_downline_img = "../../resource/img/online2.bmp";

        public DelegateActiveFriendHandle CheckFriend;
        public CJUser user_local;
        public List<UserBox> ubox_list = new List<UserBox>();
        //public List<
        public UserListBox()
        {
            InitializeComponent();
            user_local = new CJUser();
            user_local.Id = "123456";
            user_local.Name = "CJ_Studio";
            user u= new user();
            u.id = "10001";
            u.name = "user1";
            user_local += u; 
            u = new user();
            u.id = "10002";
            u.name = "user2";
            user_local += u; 
            u = new user();
            u.id = "10003";
            u.name = "user3";
            user_local += u;
            u = new user();
            u.id = "10004";
            u.name = "user4";
            user_local += u;
            init();
        }
        public UserListBox(CJUser user_l)
        {
            InitializeComponent();
            user_local = user_l;
        }
        public void init()
        {
            this.BackColor = Color.White;
            this.Size = new Size(220, 445);
            for (int height = 0, i = 0; i < this.user_local.FriendsCount; i++)
            {
                UserBox u = new UserBox(user_local.Friends[i].id, user_local.Friends[i].name);
                u.ActiveFriend += new DelegateActiveFriendHandle(event_friend);
                u.Location = new Point(0,height);
                this.Controls.Add(u);
                u.Show();
                ubox_list.Add(u);
                height += u.Size.Height;
            }
            this.Show();
        }
         
        public  void event_friend(object sender, CJActiveFriendEvent e)
        {
            ubox_list[3].Active = true;
            if (e.Type == "check")
                check_friend(e.Id);
            else if (e.Type == "chat")
                chat_friend(e.Id);
        }
        private void check_friend(string id)
        {
            int height = 0;
            foreach (UserBox u in ubox_list)
            {
                if (u.Id == id)
                {
                    u.Check = true;
                }
                else
                {
                    u.Check = false;
                }
                u.Location = new Point(0, height);
                height += u.Height;
            }
        }
        private void chat_friend(string id)
        {
            MessageBox.Show("chating");
        }
    }
}
