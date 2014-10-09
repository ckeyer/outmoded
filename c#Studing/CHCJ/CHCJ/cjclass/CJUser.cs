using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace CHCJ
{
    public struct user
    {
        public string id;
        public string name;
        public string pic;
        public IPAddress ip;
        public int udp_port;
        public int tcp_port;
        public bool is_online;
    }
    public  class CJUser 
    {
        public string Id;
        public string Name;
        private Timer timer_online = new Timer();
        public int FriendsCount
        {
            get { return Friends.Count; }
        }
        public List<CJMsg> records = new List<CJMsg>();
        public List<user> Friends= new List<user>();

        public static  CJUser operator +(CJUser a, user b)
        {
            a.Friends.Add(b);
            return a;
        }
        public static CJUser operator +(CJUser a ,CJUser b)
        {
            user u = new user();
            u.id = b.Id;
            u.name = b.Name;
            a.Friends.Add(u);
            return a;
        }
        public static CJUser operator +(CJUser a,CJMsg.Peer b)
        {
            user u = new user();
            u.id = b.id;
            u.name = b.name;
            a.Friends.Add(u);
            return a;
        }

        public CJUser()
        {
            user admin = new user();
            admin.id = "10000";
            admin.name = "admin";
            Friends.Add(admin);
            timer_online.Tick += new EventHandler(timer_online_Tick);
        }
        public CJUser(IPAddress ip, int uport, int tport)
        {
            user admin = new user();
            admin.id = "10000";
            admin.name = "admin";
            admin.ip = ip;
            admin.udp_port = uport;
            admin.tcp_port = tport;
            Friends = new List<user>();
            Friends.Add(admin);
        }

        private void timer_online_Tick(object sender, EventArgs e)
        {
            ;
        }
    }
}
