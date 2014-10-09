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
using System.Xml;
using System.IO;

namespace TCP_Client
{
    public partial class Form1 : Form
    {
        const string ConfFilePath = "H:/chat/chatServer.conf";
        const string HeaderXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n";
        const string MsgFrame =
@"<cjstudio>
  <From>
    <IPAddress></IPAddress>
    <Port></Port>
    <UserID></UserID>
    <Name></Name>
  </From>
  <To>
    <IPAddress></IPAddress>
    <Port></Port>
    <Name></Name>
    <UserID></UserID>
  </To>
  <Data>
    <Font></Font>
    <Text></Text>
    <Photo></Photo>
  </Data>
</cjstudio>";
        const string OnlineFrame =
@"<cjstudio>
  <Data>
  </Data>
</cjstudio>";
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
        public Form1()
        {
            InitializeComponent();
        }

        private static int myport = 2222;
        private bool isLogined = false;
        private static NetworkStream ns;
        private static TcpClient tcC;
        private List<Friends> friends;
        IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        int serverPort = 2222;

        delegate void CallBackSetTextBox(string str);
        CallBackSetTextBox callb;
        delegate void CallBackFreshListBox();
        CallBackFreshListBox callbackFreshlist;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            callb = new CallBackSetTextBox(SetTextBox);
            callbackFreshlist =new CallBackFreshListBox(freshFriendList);
            friends = new List<Friends>();
            friends.Clear();

            tcC = userClient.client;
            //textBox2.Invoke(callb, "\r\n连接服务器成功！");
            Thread revThread = new Thread(RevMsg);
            revThread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                sendMessageConnectOver();
            }
            catch (Exception ex)
            {
                ;
            }
            System.Environment.Exit(0);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                toolTip1.ToolTipTitle = "发送消息不得为空";
            }
            else
            {
                toolTip1.ToolTipTitle = "发送消息";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcC = new TcpClient();
            try
            {
                tcC.Connect(serverIP, serverPort);
                ns = tcC.GetStream();  //获取绑定的网络数据流
                textBox2.Invoke(callb, "\r\n连接服务器成功！");

                Thread revThread = new Thread(RevMsg);
                revThread.Start();
                sendMessageConnect();
            }
            catch (Exception ex)
            {
                textBox2.Invoke(callb, "\r\n连接服务器失败：" + ex.Message);
                if (ns != null)
                    ns.Dispose();
                if (tcC != null)
                    tcC.Close();
            }
        }

        private void writeLog(string str)
        {
            textBox2.Invoke(callb, str);
        }

        void SetTextBox(string str)
        {
            System.DateTime now = new DateTime();
            now = DateTime.Now;
            textBox2.Text += now.ToLongTimeString() + ": ";
            textBox2.Text += str;
            textBox2.Text += "\r\n";
            textBox2.SelectionStart = textBox2.Text.Length - 1;
            textBox2.ScrollToCaret();
        }

        public void freshFriendList()
        {
            ListBox1.Items.Clear();
            string selected = "";
            try
            {
                selected = ListBox1.SelectedItem.ToString();
                
            }
            catch (Exception ex)
            {
                ;
            }
            for (int i = 0; i < friends.Count; i++)
            {
                Friends f = friends[i];
                ListBox1.Items.Add(f.name + "<" + f.id + ">");
            }
            if ("" == selected)
            {
                for (int i = 0; i < friends.Count; i++)
                {
                    Friends f = friends[i];
                    if (selected.Equals(f.name + "<" + f.id + ">"))
                    {
                        ListBox1.SelectedIndex = i;
                    }
                }
            }
        }

        private void sendMessageConnect()
        {
            string sendMessages;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(HeaderXML + MsgFrame);

            XmlElement rootNode = xmlDoc.DocumentElement;
            rootNode.SetAttribute("type", "Connect");

            XmlNode node = rootNode.SelectSingleNode("From");
            int tmp = tcC.Client.LocalEndPoint.ToString().IndexOf(':');
            string endPointString = tcC.Client.LocalEndPoint.ToString();
            node.SelectSingleNode("IPAddress").InnerText = endPointString.Substring(0, tmp);
            node.SelectSingleNode("Port").InnerText = endPointString.Substring(tmp + 1);
            node.SelectSingleNode("Name").InnerText = "ChatClient";

            sendMessages = xmlDoc.InnerXml;
            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.Default.GetBytes(sendMessages);
                ns.Write(sendData, 0, sendData.Length);
                //textBox2.Invoke(callb, "\r\n向服务器发送：\r\n\t" + sendMessages);
                //textBox2.Invoke(callb, "\r\n=====发送完毕=====");
            }
            catch (Exception ex)
            {
                textBox2.Invoke(callb, "\r\n连接服务器请求失败：" + ex.Message);
                if (ns != null)
                    ns.Dispose();
                if (tcC != null)
                    tcC.Close();
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

        private void writeMessage(Friends frid)
        {
            string msg;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(HeaderXML + MsgFrame);

            XmlElement rootNode = xmlDoc.DocumentElement;
            rootNode.SetAttribute("type", "clientChat");

            XmlNode node = rootNode.SelectSingleNode("From");
            int tmp = tcC.Client.LocalEndPoint.ToString().IndexOf(':');
            string endPointString = tcC.Client.LocalEndPoint.ToString();
            node.SelectSingleNode("IPAddress").InnerText = endPointString.Substring(0, tmp);
            node.SelectSingleNode("Port").InnerText = endPointString.Substring(tmp + 1);
            node.SelectSingleNode("Name").InnerText = userClient.name;
            node.SelectSingleNode("UserID").InnerText = userClient.id.ToString();

            node = rootNode.SelectSingleNode("To");
            tmp = tcC.Client.LocalEndPoint.ToString().IndexOf(':');
            endPointString = tcC.Client.LocalEndPoint.ToString();
            node.SelectSingleNode("IPAddress").InnerText = frid.ip;
            node.SelectSingleNode("Port").InnerText = frid.port;
            node.SelectSingleNode("Name").InnerText = frid.name;
            node.SelectSingleNode("UserID").InnerText = frid.id.ToString() ;
            if (0 == frid.id)
                writeLog("向 <服务器> 发送:\r\n--> " + textBox1.Text);
            else
            writeLog("向 " + frid.name + "<" + frid.id + "> 发送:\r\n--> " + textBox1.Text);
            node = rootNode.SelectSingleNode("Data");
            tmp = tcC.Client.LocalEndPoint.ToString().IndexOf(':');
            endPointString = tcC.Client.LocalEndPoint.ToString();
            node.SelectSingleNode("Font").InnerText = textBox1.Font.Name;
            node.SelectSingleNode("Text").InnerText = textBox1.Text;
            msg = xmlDoc.InnerXml;
            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.UTF8.GetBytes(msg);
                ns.Write(sendData, 0, sendData.Length);
                //textBox2.Invoke(callb, "\r\n向服务器发送：\r\n\t" + sendMessages);
                //textBox2.Invoke(callb, "\r\n=====发送完毕=====");
            }
            catch (Exception ex)
            {
                textBox2.Invoke(callb, "数据\""+textBox1.Text +"\"发送失败" + ex.Message);
                if (ns != null)
                    ns.Dispose();
                if (tcC != null)
                    tcC.Close();
            }
        }

        private void readMessage( string str)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(str);
                XmlElement rootNode = xmlDoc.DocumentElement;
                string stype = rootNode.GetAttribute("type");    //接收到的数据类型、用途
                if (String.Equals("OnlineFriends", stype, StringComparison.OrdinalIgnoreCase))
                {
                    List<Friends> tmpfriends = new List<Friends>();
                    tmpfriends.Clear();
                    XmlNode node = rootNode.SelectSingleNode("Data");
                    if (node.SelectNodes("OnlineUser").Count > 0)
                    {
                        foreach (XmlNode userNode in node.SelectNodes("OnlineUser"))
                        {
                            Friends ftmp = new Friends();
                            ftmp.ip = userNode.SelectSingleNode("IPAddress").InnerText;
                            ftmp.port = userNode.SelectSingleNode("Port").InnerText;
                            ftmp.name = userNode.SelectSingleNode("Name").InnerText;
                            ftmp.id = Int32.Parse(userNode.SelectSingleNode("UserID").InnerText);
                            tmpfriends.Add(ftmp);
                        }
                    }
                    if (tmpfriends.Count == friends.Count)
                    {
                        int tmpCount=0;
                        for (int i = 0; i < friends.Count; i++)
                        {
                            for (int j = 0; j < tmpfriends.Count; j++)
                            {
                                if (friends[i].id == tmpfriends[j].id)
                                {
                                    tmpCount++;
                                }
                            }
                        }
                        if (tmpCount != friends.Count)
                        {
                            friends.Clear();
                            friends = tmpfriends;
                            ListBox1.Invoke(callbackFreshlist);
                        }
                    }
                    else
                    {
                        friends.Clear();
                        friends = tmpfriends;
                        ListBox1.Invoke(callbackFreshlist);
                    }
                }
                else if (String.Equals("clientChat", stype, StringComparison.OrdinalIgnoreCase))
                {
                    Friends ftmp = new Friends();
                    XmlNode node = rootNode.SelectSingleNode("From");
                    ftmp.ip = node.SelectSingleNode("IPAddress").InnerText;
                    ftmp.port = node.SelectSingleNode("Port").InnerText;
                    ftmp.name = node.SelectSingleNode("Name").InnerText;
                    
                    StringBuilder getmsg = new StringBuilder();
                    getmsg.Append("来自: "+ftmp.name);
                    getmsg.Append("<" + ftmp.id + "> 的消息:\r\n--> ");

                    node = rootNode.SelectSingleNode("Data");
                    getmsg.Append(node.SelectSingleNode("Text").InnerText);
                    writeLog(getmsg.ToString());
                }
                else if (String.Equals("Connect", stype, StringComparison.OrdinalIgnoreCase))
                {
                }
                else
                {
                    writeLog("未知的数据类型:"+str);
                }
            }
            catch (Exception ex)
            {
                writeLog("处理数据出现异常：" + ex.Message + "..." + str);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                toolTip1.ToolTipTitle = "发送消息不得为空";
                toolTip1.Show(" ", button2);
            }
            else
            {
                try
                {
                    int index ;
                    try
                    {
                        index = ListBox1.SelectedIndex;
                        writeMessage(friends[index]);
                    }
                    catch (Exception)
                    {
                        Friends f = new Friends();
                        f.port = serverPort.ToString();
                        f.ip = serverIP.ToString();
                        f.id = 0;
                        writeMessage(f);
                    }
                    textBox1.Clear();
                }
                catch (Exception ex)
                {
                    textBox2.Invoke(callb, "\r\n连接服务器失败：" + ex.Message);
                    if (ns != null)
                        ns.Dispose();
                    if (tcC != null)
                        tcC.Close();
                }
            }
        }

        private void RevMsg()
        {
            try
            {
                ns = tcC.GetStream();
                while (true)
                {
                    int readLen = tcC.Available;
                    if (readLen > 0)
                    {
                        byte[] getData = new byte[2048];
                        ns.Read(getData, 0, getData.Length);
                        string getMsg = Encoding.UTF8.GetString(getData);
                        readMessage(getMsg);
                        //textBox2.Invoke(callb, "\r\n从" + tcC.Client.LocalEndPoint + "接收消息为：\r\n\t" + getMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                textBox2.Invoke(callb, "\r\n监听信息：" + ex.Message );
                if (ns != null)
                    ns.Dispose();
                if (tcC != null)
                    tcC.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //sendMessageConnect();
            //freshFriendList();
            //ListBox1.Items.Add("sdfhosfdja(127.0.0.1:8080)");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        }

    }
}
