using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;

namespace CHCJ
{
    public partial class LoginForm : Form
    {
        public const string imgDir = "../../resource/img/";
        public const string icoDir = "../../resource/ico/";
        public const string conf_login_Path = "../../config/loginForm_conf.xml";
        public const string XMLHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement rootNode;
        public CJTcpConnect conn;
        public CJLog log = 
            new CJLog(CJLog.LogLevel.ALL, CJLog.LogModel.MESSAGE_BOX_SHOW);
        
        private Point mouse_sub_form;
        private List<LocalUser> localUsers = new List<LocalUser>();
        private CJUser user_local = new CJUser();
        delegate void CB_V_V();

        private int loading_pic_rotate = 0;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void initConfLocal()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                string xmlFrame = @"
<cjstudio>
  <Project>
    <Name>CHCJ</Name>
    <Version>v1.0</Version>
    <Author>CJ_Studio</Author>
    <CreateTime>2014-5-7 下午</CreateTime>
    <UpdateTime>2014-5-11 下午</UpdateTime>
  </Project>
  <Config>
    <UserList>
    </UserList>
  </Config>
</cjstudio>";
                xmlDoc.LoadXml(XMLHeader + xmlFrame);

                XmlElement rootNode = xmlDoc.DocumentElement;
                rootNode.SetAttribute("name", "loginFrom.conf");
                xmlDoc.Save(conf_login_Path);
            }
            catch (Exception)
            {
                MessageBox.Show("初始化配置文件出错，可能需要重新安装");
                System.Environment.Exit(-1);
            }
        }
        private void getConfLocal()
        {
            try
            {
                xmlDoc.Load(conf_login_Path);
            }
            catch
            {
                initConfLocal();
                xmlDoc.LoadXml(conf_login_Path);
            }
            try
            {
                rootNode = xmlDoc.DocumentElement;
                XmlNode node;
                node = rootNode.SelectSingleNode("Config").SelectSingleNode("UserList");
                foreach(XmlNode userNode in node.SelectNodes("User"))
                {
                    LocalUser user = new LocalUser();
                    user.userID = userNode.SelectSingleNode("UserID").InnerText;
                    user.userName = userNode.SelectSingleNode("Name").InnerText;
                    user.password = userNode.SelectSingleNode("Password").InnerText;
                    if(userNode.SelectSingleNode("IsAutoLogin").InnerText=="Y")
                    {
                        user.is_auto_login = true;
                    }
                    else
                    {
                        user.is_auto_login = false;
                    }
                    if(userNode.SelectSingleNode("IsRemPasswd").InnerText=="Y")
                    {
                        user.is_rem_passwd = true;
                    }
                    else
                    {
                        user.is_rem_passwd =false;
                    }
                    user.last_login_time_string = userNode.SelectSingleNode("LastLoginTime").InnerText;
                    user.last_login_time = DateTime.Parse(user.last_login_time_string);
                    localUsers.Add(user);
                }
                localUsers.Sort(LocalUser.CompareByDate);
            }
            catch (Exception)
            {
                ;
            }
        }
        private void saveConfLocal()
        {
            XmlNode node;
            bool user_exitst = false;
            node = rootNode.SelectSingleNode("Config").SelectSingleNode("UserList");
            foreach (XmlNode userNode in node.SelectNodes("User"))
            {
                LocalUser user = new LocalUser();
                user.userID = userNode.SelectSingleNode("UserID").InnerText;
                if (user.userID == comboBox1.Text)
                {
                    user_exitst = true;
                    if (checkBox2.Checked == true)
                    {
                        userNode.SelectSingleNode("IsRemPasswd").InnerText = "Y";
                        userNode.SelectSingleNode("Password").InnerText = textBox2.Text;
                    }
                    else
                    {
                        userNode.SelectSingleNode("IsRemPasswd").InnerText = "N";
                        userNode.SelectSingleNode("Password").InnerText = "";
                    }
                    if (checkBox1.Checked == true)
                    {
                        userNode.SelectSingleNode("IsAutoLogin").InnerText = "Y";
                        userNode.SelectSingleNode("IsRemPasswd").InnerText = "Y";
                        userNode.SelectSingleNode("Password").InnerText = textBox2.Text;
                    }
                    else
                    {
                        userNode.SelectSingleNode("IsAutoLogin").InnerText = "N";
                    }
                    userNode.SelectSingleNode("LastLoginTime").InnerText= 
                        System.DateTime.Now.ToString();
                }
            }
            if (!user_exitst)
            {
                XmlElement xeluser = xmlDoc.CreateElement("User");
                XmlElement xeluid = xmlDoc.CreateElement("UserID");
                XmlElement xeluname = xmlDoc.CreateElement("Name");
                XmlElement xelupass = xmlDoc.CreateElement("Password");
                XmlElement xelisauto = xmlDoc.CreateElement("IsAutoLogin");
                XmlElement xelisrem = xmlDoc.CreateElement("IsRemPasswd");
                XmlElement xellastdate = xmlDoc.CreateElement("LastLoginTime");
                xeluid.InnerText = comboBox1.Text;
                xellastdate.InnerText = System.DateTime.Now.ToString();
                if (checkBox2.Checked == true)
                {
                    xelisrem.InnerText = "Y";
                    xelupass.InnerText = textBox2.Text;
                }
                else
                {
                    xelisrem.InnerText = "N";
                    xelupass.InnerText = "";
                }
                if (checkBox1.Checked == true)
                {
                    xelisauto.InnerText = "Y";
                    xelisrem.InnerText = "Y";
                    xelupass.InnerText = textBox2.Text;
                }
                else
                {
                    xelisauto.InnerText = "N";
                }
                xellastdate.InnerText =
                    System.DateTime.Now.ToString();

                xeluser.AppendChild(xeluid);
                xeluser.AppendChild(xeluname);
                xeluser.AppendChild(xelupass);
                xeluser.AppendChild(xelisauto);
                xeluser.AppendChild(xelisrem);
                xeluser.AppendChild(xellastdate);
                node.AppendChild(xeluser);
            }
            xmlDoc.Save(conf_login_Path);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            notifyIcon1.Icon = new Icon(icoDir + "mine.ico");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Image.FromFile(imgDir + "login_bg.jpg");
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Image.FromFile(imgDir + "close.png");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            //pictureBox2.BackgroundImage = Image.FromFile(icoDir + "mine.ico");
            pictureBox2.BackgroundImage = Image.FromFile(imgDir + "mine.jpg");
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Image.FromFile(imgDir + "minForm.png");
            pictureBox4.Visible = false;
            pictureBox4.Size = new Size(50, 50);

            getConfLocal();
            foreach (LocalUser user in localUsers)
            {
                if (user.userID == localUsers[0].userID)
                {
                    comboBox1.Text = user.userID;
                }
                comboBox1.Items.Add(user.userID);
            }
            timer_loading.Start();

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
            notifyIcon1.Dispose();
            System.Environment.Exit(0);
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Image.FromFile(imgDir + "minForm.png");
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(imgDir + "minFroming.png");
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(imgDir + "minForm.png");
        }
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Image.FromFile(imgDir + "minFroming.png");
            this.Visible = false;
        }

        private void timer_loading_Tick(object sender, EventArgs e)
        {
            if (this.Opacity >= 1.0)
            {
                timer_loading.Stop();
            }
            else
            {
                this.Opacity += .1;
            }
        }
        private void timer_closing_Tick(object sender, EventArgs e)
        {
            if (this.Opacity <= 0.0)
            {
                timer_closing.Stop();
                Program.t_mainForm.Start(user_local);
                CB_V_V cb = new CB_V_V(FormClose);
                this.Invoke(cb);
            }
            else
            {
                CB_V_V cb = new CB_V_V(OpacityDown);
                this.Invoke(cb);
            }
        }
        private void OpacityDown()
        {
            this.Opacity -= 0.1;
        }
        private void TimerClosingStart()
        {
            this.timer_closing.Start();
        }
        private void FormClose()
        {
            notifyIcon1.Dispose();
            this.Close();
        }
        private void timer_moving_from_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(Control.MousePosition.X - mouse_sub_form.X,
                Control.MousePosition.Y - mouse_sub_form.Y);
        }
        private void timer_chage_pic_Tick(object sender, EventArgs e)
        {
            Image img;
            img = Image.FromFile(imgDir + "waiting.png");
            loading_pic_rotate += 30;
            loading_pic_rotate %= 360;
            int newWidth = Math.Max(img.Height, img.Width);
            Bitmap bmp = new Bitmap(newWidth, newWidth);
            Graphics g = Graphics.FromImage(bmp);
            Matrix x = new Matrix();
            PointF point = new PointF(img.Width / 2f, img.Height / 2f);
            x.RotateAt(loading_pic_rotate,
                point);
            g.Transform = x;
            g.DrawImage(img, 0, 0);
            g.Dispose();
            img = bmp;
            pictureBox4.BackgroundImage = img;
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            //            pictureBox4.BackgroundImage = 
            //                Image.FromFile(icoDir + "Rotate"+(timer_chage_pic_tmp%8+1).ToString()+".ico");
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_sub_form.X = e.X;
            mouse_sub_form.Y = e.Y;
            timer_moving_from.Start();
        }
        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            timer_moving_from.Stop();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string userid = comboBox1.Text;
            textBox2.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            foreach (LocalUser user in localUsers)
            {
                if (userid == user.userID)
                {
                    if (user.is_auto_login)
                    {
                        textBox2.Text = user.password;
                        checkBox1.Checked = true;
                        checkBox2.Checked = true;
                        break;
                    }
                    if (user.is_rem_passwd)
                    {
                        textBox2.Text = user.password;
                        checkBox2.Checked = true;
                    }
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = true;
            }
        }

        private void 显示主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true; ;
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            System.Environment.Exit(0);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.Visible = !this.Visible;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "登    录" && expTextboxText())
            {
                panel1.Visible = false;
                pictureBox4.Visible = true;
                if(textBox2.Text.Length!=32)
                textBox2.Text = EncryptMd5(textBox2.Text);
                button1.Text = "取    消";
                timer_chage_pic.Start();
                saveConfLocal();
                conn = new CJTcpConnect();
                conn.ReceiveOver += new DelegateConnectHandle(auth_Over);
                authUser();
            }
            else
            {
                timer_chage_pic.Stop();
                panel1.Visible = true;
                pictureBox4.Visible = false;
                button1.Text = "登    录";
                conn.Close();
            }
        }
        private bool expTextboxText()
        {
            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("账号不能为空", "CJ_Studio");
                return false;
            }
            if (textBox2.Text.Length ==0)
            {
                MessageBox.Show("密码不能为空", "CJ_Studio");
                return false;
            }
            try
            {
                long l = long.Parse(comboBox1.Text);
            }
            catch (Exception )
            {
                MessageBox.Show("账号错误", "CJ_Studio");
            }
            return true ;
        }
        public string EncryptMd5(string strPwd)
        {
            byte[] result = Encoding.Default.GetBytes(strPwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string str = BitConverter.ToString(output).Replace("-", "");
            return str.ToUpper();
        }

        // 登陆认证
        public void authUser()
        {
            CJMsg msg_send = new CJMsg();
            msg_send.setMsgType(MsgType.C_AUTH);
            msg_send.setMsgToNode(CJConfig.ServerIp.ToString(),
                                    CJConfig.ServerTcpPort,
                                    CJConfig.ServerID,
                                    CJConfig.ServerName);
            msg_send.setMsgFromNode(CJConfig.LocalIp.ToString(),
                                    conn.port_tcp_local,
                                    comboBox1.Text,
                                    "");
            msg_send.addMsgText(textBox2.Text);
            conn.msg_send = msg_send;
            conn.tcp_start();
            conn.tcp_sendMsg();
            log.loging(conn.msg_send.ToString(), CJLog.LogLevel.DEBUG);
        }
        public void auth_Over(object sender, CJReceiveOverEvent e)
        {
            if (e.sendState == SendState.OK)
            {
                if (e.Msg.getMsgType() == MsgType.S_AUTH_RIGHT)
                {
                    log.loging(e.Msg.ToString(), CJLog.LogLevel.DEBUG);
                    user_local.Id = e.Msg.getMsgPeerTo().id;
                    user_local.Name = e.Msg.getMsgPeerTo().name;
                    foreach (CJMsg.Peer p in e.Msg.getMsgTextKVs("id_name"))
	                {
                        user_local += p;
                    }
                    foreach (CJMsg msg_tmp in e.Msg.getMsgTextVs("no_receive"))
                    {
                        user_local.records.Add(msg_tmp);
                    }
                    CB_V_V cb = new CB_V_V(TimerClosingStart);
                    this.Invoke(cb);
                    log.loging("Login_Form Closing", CJLog.LogLevel.DEBUG);
                    return;
                } 
//                 else if(e.Msg.getMsgType() == MsgType.S_TCP_OVER)
//                 {
//                     log.loging("tcp连接断开", CJLog.LogLevel.DEBUG);
//                     conn.Close();
//                 }
            }
            else
            {
                log.loging(e.Remark, e.Level);
            }
        }

    }
}
