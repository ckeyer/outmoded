using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCP_Client
{
    public partial class login : Form
    {
        //UserClient userClient;
        private int userID;
        private string password;
        public bool isLogined = false;
        const string ConfFilePath = "D:/ChatClient/clientConf.xml";
        const string HeaderXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n";
        const string LoginFrame =
@"<cjstudio>
  <From>
    <IPAddress></IPAddress>
    <Port></Port>
  </From>
  <Data>
    <UserID></UserID>
    <Password></Password>
  </Data>
</cjstudio>";


        delegate void CallBackNoShow();
        CallBackNoShow cbNoShow;

        public login()
        {
            InitializeComponent();
        }

        private bool isLawful()
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("用户账号不能为空");
                    return false;
                }
                userID = Int32.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("用户账只能为数字");
                return false;
            }
            try
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("用户账号不能为空");
                    return false;
                }
                password = EncryptMd5(textBox2.Text);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isLawful())
            {
                MessageBox.Show("用户名或密码输入有误...");
                return;
            }
            else
            {
                userClient.client = new TcpClient();
                connectServer();
            }
        }

        private void connectServer()
        {
            try
            {
                userClient.client.Connect(userClient.serverIp, userClient.serverPort);
                userClient.netStream = userClient.client.GetStream();  //获取绑定的网络数据流

                sendMessageConnect();
                Thread revThread = new Thread(RevMsg);
                revThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("\r\n连接服务器失败：" + ex.Message);
                if (userClient.netStream != null)
                    userClient.netStream.Dispose();
                if (userClient.client != null)
                    userClient.client.Close();
            }
        }

        public string EncryptMd5(string strPwd)
        {
            byte[] result = Encoding.Default.GetBytes(strPwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string str = BitConverter.ToString(output).Replace("-", "");
            return str.ToUpper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //textBox2.Text = EncryptMd5(textBox1.Text);
            RegistForm registfrom = new RegistForm();
            registfrom.Show(this);
        }

        private void RevMsg()
        {
            try
            {
                userClient.netStream = userClient.client.GetStream();
                while (!isLogined)
                {
                    int readLen = userClient.client.Available;
                    if (readLen > 0)
                    {
                        byte[] getData = new byte[2048];
                        userClient.netStream.Read(getData, 0, getData.Length);
                        string getMsg = Encoding.UTF8.GetString(getData);
                        readMessage(getMsg);
                        //textBox2.Invoke(callb, "\r\n从" + tcC.Client.LocalEndPoint + "接收消息为：\r\n\t" + getMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
                if (userClient.netStream != null)
                    userClient.netStream.Dispose();
                if (userClient.client != null)
                    userClient.client.Close();
            }
        }

        private void sendMessageConnect()
        {
            string sendMessages;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(HeaderXML + LoginFrame);

            XmlElement rootNode = xmlDoc.DocumentElement;
            rootNode.SetAttribute("type", "Connect");

            XmlNode node = rootNode.SelectSingleNode("From");
            int tmp = userClient.client.Client.LocalEndPoint.ToString().IndexOf(':');
            string endPointString = userClient.client.Client.LocalEndPoint.ToString();
            userClient.ip = IPAddress.Parse(endPointString.Substring(0, tmp));
            userClient.port = Int32.Parse(endPointString.Substring(tmp + 1));
            userClient.id = userID;
            node.SelectSingleNode("IPAddress").InnerText = userClient.ip.ToString();
            node.SelectSingleNode("Port").InnerText = userClient.port.ToString();
            node = rootNode.SelectSingleNode("Data");
            node.SelectSingleNode("UserID").InnerText = userID.ToString() ;
            node.SelectSingleNode("Password").InnerText = password;
            sendMessages = xmlDoc.InnerXml;
            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.Default.GetBytes(sendMessages);
                userClient.netStream.Write(sendData, 0, sendData.Length);
                //textBox2.Invoke(callb, "\r\n向服务器发送：\r\n\t" + sendMessages);
                //textBox2.Invoke(callb, "\r\n=====发送完毕=====");
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接服务器请求失败：" + ex.Message);
                if (userClient.netStream != null)
                    userClient.netStream.Dispose();
                if (userClient.client != null)
                    userClient.client.Close();
            }
        }

        private void sendMessageConnectOver()
        {
            string sendMessages;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(HeaderXML + LoginFrame);

            XmlElement rootNode = xmlDoc.DocumentElement;
            rootNode.SetAttribute("type", "ConnectOver");

            XmlNode node = rootNode.SelectSingleNode("From");
            int tmp = userClient.client.Client.LocalEndPoint.ToString().IndexOf(':');
            string endPointString = userClient.client.Client.LocalEndPoint.ToString();
            node.SelectSingleNode("IPAddress").InnerText = userClient.ip.ToString();
            node.SelectSingleNode("Port").InnerText = userClient.port.ToString();

            node = rootNode.SelectSingleNode("Data");
            node.SelectSingleNode("UserID").InnerText = userClient.id.ToString();
            sendMessages = xmlDoc.InnerXml;
            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.Default.GetBytes(sendMessages);
                userClient.netStream.Write(sendData, 0, sendData.Length);
                //textBox2.Invoke(callb, "\r\n向服务器发送：\r\n\t" + sendMessages);
                //textBox2.Invoke(callb, "\r\n=====发送完毕=====");
            }
            catch (Exception ex)
            {
                System.Environment.Exit(0);
            }
        }

        private void readMessage(string str)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(str);
                XmlElement rootNode = xmlDoc.DocumentElement;
                string stype = rootNode.GetAttribute("type");    //接收到的数据类型、用途
                if (String.Equals("ConnectingMsg", stype, StringComparison.OrdinalIgnoreCase))
                {
                    XmlNode node = rootNode.SelectSingleNode("Data");
                    int isOK = Int32.Parse(node.SelectSingleNode("Error").InnerText);
                    if (1 == isOK)
                    {
                        //MessageBox.Show(userClient.id.ToString()+userClient.ip.ToString()+userClient.port.ToString());
                        userClient.name = node.SelectSingleNode("Name").InnerText;
                        this.Invoke(cbNoShow);
                        isLogined = true;
                        Application.Run(new Form1());
                    }
                    else if (0 == isOK)
                    {
                        MessageBox.Show("用户密码错误");
                        if (userClient.netStream != null)
                            userClient.netStream.Dispose();
                        if (userClient.client != null)
                            userClient.client.Close();
                    }
                    else if (2 == isOK)
                    {
                        MessageBox.Show("用户已在其他处登陆");
                        if (userClient.netStream != null)
                            userClient.netStream.Dispose();
                        if (userClient.client != null)
                            userClient.client.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户账号或者密码错误"+isOK.ToString());
                        if (userClient.netStream != null)
                            userClient.netStream.Dispose();
                        if (userClient.client != null)
                            userClient.client.Close();
                    }
                }
                else 
                {
                    //MessageBox.Show("未知的数据类型");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取数据出现异常：" + ex.Message + "---." + str);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            cbNoShow = new CallBackNoShow(DocbNoShow);
            getConfig();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (userClient.client == null)
            {
                
                System.Environment.Exit(0);
            }
            else
            {
                sendMessageConnectOver();
                System.Environment.Exit(0);
            }
        }

        private void DocbNoShow()
        {
            this.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfForm confform = new ConfForm();
            confform.Show(this);
            getConfig();
        }

        private void getConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(ConfFilePath);
                //userClient = new UserClient();
                XmlElement rootNode = xmlDoc.DocumentElement;
                XmlNode node = rootNode.SelectSingleNode("Server");
                userClient.serverIp = IPAddress.Parse(node.SelectSingleNode("IPAddress").InnerText);
                userClient.serverPort = Int32.Parse(node.SelectSingleNode("Port").InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载配置文件异常");
                ConfForm confform = new ConfForm();
                confform.Show(this);
            }

        }
    }
}
