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
using System.Xml;
using System.Threading;
using System.Security.Cryptography;

namespace TCP_Client
{
    public partial class RegistForm : Form
    {
        private string password;
        public bool isLogined = false;
        const string ConfFilePath = "D:/ChatClient/clientConf.xml";
        const string HeaderXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n";
        const string RegistFrame =
@"<cjstudio>
  <From>
    <IPAddress></IPAddress>
    <Port></Port>
  </From>
  <Data>
    <Name></Name>
    <Password></Password>
  </Data>
</cjstudio>";


        delegate void CallBackCloseForm();
        CallBackCloseForm cbCloseForm;
        public RegistForm()
        {
            InitializeComponent();
        }

        private void CloseForm()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 == null)
            {
                MessageBox.Show("用户名不得为空");
                return;
            }
            if (textBox2 == null)
            {
                MessageBox.Show("密码不得为空");
                return;
            }
            if (!textBox2.Text.Equals( textBox3.Text))
            {
                MessageBox.Show("两次密码不相同");
                return;
            }

            userClient.client = new TcpClient();
            connectServer();
        }

        private void connectServer()
        {
            try
            {
                userClient.client.Connect(userClient.serverIp, userClient.serverPort);
                userClient.netStream = userClient.client.GetStream();  //获取绑定的网络数据流

                sendMessageRegist();
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

        private void sendMessageRegist()
        {
            string sendMessages;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(HeaderXML + RegistFrame);

            XmlElement rootNode = xmlDoc.DocumentElement;
            rootNode.SetAttribute("type", "Regist");

            XmlNode node = rootNode.SelectSingleNode("From");
            int tmp = userClient.client.Client.LocalEndPoint.ToString().IndexOf(':');
            string endPointString = userClient.client.Client.LocalEndPoint.ToString();
            userClient.ip = IPAddress.Parse(endPointString.Substring(0, tmp));
            userClient.port = Int32.Parse(endPointString.Substring(tmp + 1));

            node.SelectSingleNode("IPAddress").InnerText = userClient.ip.ToString();
            node.SelectSingleNode("Port").InnerText = userClient.port.ToString();
            node = rootNode.SelectSingleNode("Data");
            node.SelectSingleNode("Name").InnerText = textBox1.Text;
            node.SelectSingleNode("Password").InnerText = EncryptMd5(textBox2.Text);
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
                if (userClient.netStream != null)
                    userClient.netStream.Dispose();
                if (userClient.client != null)
                    userClient.client.Close();
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
                if (String.Equals("RegistMsg", stype, StringComparison.OrdinalIgnoreCase))
                {
                    XmlNode node = rootNode.SelectSingleNode("Data");
                    int id = Int32.Parse(node.SelectSingleNode("UserID").InnerText);
                    MessageBox.Show("新用户账号为："+id.ToString(),"注册成功");

                    if (userClient.netStream != null)
                        userClient.netStream.Dispose();
                    if (userClient.client != null)
                        userClient.client.Close();
                    this.Invoke(cbCloseForm);
                }
                else
                {
                    MessageBox.Show("数据返回错误");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("RegistForm:获取数据出现异常：" + ex.Message + "---." + str);
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

        private void RegistForm_Load(object sender, EventArgs e)
        {
            cbCloseForm = new CallBackCloseForm(CloseForm);
        }

    }
}
