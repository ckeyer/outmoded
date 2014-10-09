using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Collections;

namespace CHCJ
{
    public partial class TestForm1 : Form
    {
        public TestForm1()
        {
            InitializeComponent();
        }

        private int msg_seq=0;
        List<CJConnect> conns = new List<CJConnect>();
        IPAddress local_ip = IPAddress.Parse("127.0.0.1");
        private int local_port = 3333;
        IPAddress server_ip = IPAddress.Parse("127.0.0.1");
        private int server_port = 2222;
        private CJLog log;
        CJConnect conn = new CJConnect();
        CJMsg msg = new CJMsg();

        private void TestForm1_Load(object sender, EventArgs e)
        {
            log = new CJLog(CJLog.LogLevel.ALL, CJLog.LogModel.TEXT_BOX_SHOW);
            log.setControl(textBox1);
            log.loging(conn.ip_server.ToString());
        }

        form.UserBox ub = new form.UserBox("fuck", "haha");
        private void button1_Click(object sender, EventArgs e)
        {
//             conn = new CJConnect();
//             conn.ReceiveOver += new DelegateConnectHandle(this.receive_Over);
//             string sendstr = textBox1.Text == "" ? "fuck" : textBox1.Text;
//             msg = new CJMsg();
//             msg.setMsgType(MsgType.C_CONNECT,msg_seq++);
//             msg.setMsgFromNode(local_ip.ToString(),local_port,"1001","cjstudio");
//             msg.setMsgToNode(server_ip.ToString(),server_port,"10000","server");
//             msg.addMsgText("hello serverPC");
//             msg.addMsgData_Attr("name", "wangcj");
//             msg.setMsgHash();
//             conn.msg_send = msg;
//             sendstr = conn.msg_send.ToString();
//             //conn.udp_sendMsg();
//             textBox2.Text = sendstr;
//             ub.Location = new Point(20, 200);
//             this.Controls.Add(ub);
            //             ub.Show();
            form.UserListBox ul = new form.UserListBox();
            ub.Location = new Point(50, 50);
            ub.BackColor = Color.White;
            this.Controls.Add(ul);
            ul.Show();
        }

        public void receive_Over(object sender, CJReceiveOverEvent e)
        {
            log.loging("事件触发啦");
            log.loging(e.sendState.ToString());
            if (e.sendState == SendState.OK)
            {
                log.loging(e.Msg.getMsgDataText());
            }
            //log.loging(e.Msg.data_text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
//             HashSet<string> s = new HashSet<string>();
//             s.Add("fuck");
//             Hashtable ha = new Hashtable();
            //ub.Active = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = EncryptMd5(textBox1.Text);
        }

        public string EncryptMd5(string strPwd)
        {
            byte[] result = Encoding.Default.GetBytes(strPwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string str = BitConverter.ToString(output).Replace("-", "");
            return str.ToUpper();
        }

    }

}
