using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;

namespace TcpChatServer
{
    public partial class Form1 : Form
    {
        public IPAddress hostIP=IPAddress.Parse("127.0.0.1");
        public int hostPort= 2222;
        public int maxConnect= 20;
        public int timeOut= 5000;
        public int connectCount=0;
        private bool listenEnable = true;

        const string ConfFilePath = "D:/ChatServer/serverConf.xml";
        const string UListFilePath = "D:/ChatServer/userList.xml";
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
    <UserID></UserID>
    <Name></Name>
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
        const string ConnectingFrame =
@"<cjstudio>
  <Data>
    <Name></Name>
    <UserID></UserID>
    <Error></Error>
  </Data>
</cjstudio>";
        private static TcpListener listener;    // TCP监听
        private Thread listenThread;    //  监听线程
        //private static NetworkStream netStream;
        //private static TcpClient client;
        private List<UserClient> userList;  // 在线用户列表

        delegate void CallBackSetTextBox(string str);
        CallBackSetTextBox cbSetTextBox;
        delegate void CallBackContOnlineUserList(int type,UserClient client);
        CallBackContOnlineUserList cbContUserList;
        delegate void ATalk(UserClient client);
        ATalk aTalk;    // 一个会话委托

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void initConf()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfFilePath);
                XmlElement rootNode = xmlDoc.DocumentElement;
                XmlNode node = rootNode.SelectSingleNode("Config");

                hostIP = IPAddress.Parse(node.SelectSingleNode("IPAddress").InnerText);
                hostPort = Int32.Parse(node.SelectSingleNode("Port").InnerText);
                maxConnect = Int32.Parse(node.SelectSingleNode("MaxConnect").InnerText);
                timeOut = Int32.Parse(node.SelectSingleNode("TimeOut").InnerText);

            }
            catch (Exception ex)
            {
                writeLog("加载配置文件失败");
                hostIP = IPAddress.Parse("127.0.0.1");
                hostPort = 2222;
                maxConnect = 20;
                timeOut = 5000;
            }

            connectCount=0;
        }

        void SetTextBox(string str)
        {
            System.DateTime now = new DateTime();
            now = DateTime.Now;
            textBox1.Text += now.ToLongTimeString() + ": ";
            textBox1.Text += str;
            textBox1.Text += "\r\n";
            textBox1.SelectionStart = textBox1.Text.Length - 1;
            textBox1.ScrollToCaret();
        }

        // type___ 1:add    2:remove
        void ContUserList(int type, UserClient client)
        {
            if (1 == type)
            {
                foreach (UserClient cli in userList)
                {
                    if (cli.id == client.id)
                    {
                        if (cli.ip == client.ip && cli.port == client.port)
                        {
                            return ;
                        }
                        else
                        {
                            userList.Remove(cli);
                        }
                    }
                }
                userList.Add(client);
            }
            else if (2 == type)
            {
                userList.Remove(client);
            }
        }

        private void writeLog(string str)
        {
            textBox1.Invoke(cbSetTextBox,str);
        }

        // level为日志级别，0为记录到窗体,其他待写
        private void writeLog(string str,int level)
        {
            switch (level)
            {
                case 1: break;
                case 2: break;
                default:
                    textBox1.Invoke(cbSetTextBox, str);
                    break;
            }
        }

        public string EncryptSha256(string strPwd)
        {
            byte[] result = Encoding.Default.GetBytes(strPwd);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] output = sha256.ComputeHash(result);
            string str = BitConverter.ToString(output).Replace("-", "");
            return str.ToUpper();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initConf();
            cbSetTextBox = new CallBackSetTextBox(SetTextBox);
            cbContUserList = new CallBackContOnlineUserList(ContUserList);
            listener = new TcpListener(hostIP, hostPort);
            stopToolStripMenuItem.Enabled = false;
            userList = new List<UserClient>();
        }

        private void startTalking(UserClient client)
        {
            while (listenEnable)
            {
                try
                {
                    int readLen = client.client.Available;
                    if (readLen > 0)
                    {
                        byte[] getData = new byte[2048];
                        client.netStream.Read(getData, 0, getData.Length);
                        string getMsg = Encoding.UTF8.GetString(getData);
                        //writeLog(client.endPoint.ToString()+"\r\n\t"+ getMsg);
                        readMessage(client, getMsg);
                        //textBox1.Invoke(cbSetTextBox, "从" + client.Client.LocalEndPoint + "接收消息为：\r\n\t" + getMsg);
                    }
                }
                catch (Exception ex)
                {
                    writeLog("与会话出现");
                    return;
                }
            }
        }

        private void Server()
        {
            listenEnable = true;
            listener.Start(maxConnect);
            //Thread revThread = new Thread(RevMsg);
            //revThread.Start();
            writeLog("监听程序启动成功，端口：" + hostPort);
            while (listenEnable)
            {
                UserClient clientTmp = new UserClient(); 
                try
                {
                    clientTmp.client = listener.AcceptTcpClient();
                    clientTmp.netStream = clientTmp.client.GetStream();
                    clientTmp.endPoint = clientTmp.client.Client.LocalEndPoint;
                    Thread threadTalk = new Thread(() => { startTalking(clientTmp); });
                    threadTalk.Start();
                }
                catch (Exception ex)
                {
                    writeLog("监听信息：" + ex.Message);
                    if (clientTmp.netStream != null)
                        clientTmp.netStream.Dispose();
                    if (clientTmp.client != null)
                        clientTmp.client.Close();
                }
            }
        }

        private void readMessage(UserClient client ,string str)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(str);
                XmlElement rootNode = xmlDoc.DocumentElement;
                string stype= rootNode.GetAttribute("type");    //接收到的数据类型、用途
                
                // 连接请求处理及用户认证
                if (String.Equals("Connect", stype, StringComparison.OrdinalIgnoreCase))
                {
                    XmlNode node = rootNode.SelectSingleNode("From");
                    client.ip = IPAddress.Parse(node.SelectSingleNode("IPAddress").InnerText);
                    client.port = Convert.ToInt32(node.SelectSingleNode("Port").InnerText.ToString());

                    node = rootNode.SelectSingleNode("Data");
                    string userid = node.SelectSingleNode("UserID").InnerText ;
                    client.id = Int32.Parse(userid);
                    string password = EncryptSha256( node.SelectSingleNode("Password").InnerText );


                    foreach (UserClient cli in userList)
                    {
                        if (client.id == cli.id)
                        {
                            this.sendConnectingMsg(client, 2);
                            writeLog("<" + client.id.ToString() + ">(" + client.ip.ToString() + ":"
                                         + client.port.ToString() + ") 重复登陆失败");
                            return;
                        }
                    }

                    try
                    {
                        XmlDocument xmlDocUserL = new XmlDocument();
                        xmlDocUserL.Load(UListFilePath);
                        XmlElement ulRootNode = xmlDocUserL.DocumentElement;
                        foreach (XmlNode user in ulRootNode.SelectNodes("User"))
                        {
                            if (userid == user.SelectSingleNode("UserID").InnerText)
                            {
                                if (password.Equals(user.SelectSingleNode("Password").InnerText))
                                {
                                    client.name = user.SelectSingleNode("Name").InnerText;
                                    client.id = Int32.Parse( user.SelectSingleNode("UserID").InnerText);
                                    this.sendConnectingMsg(client, 1);
                                    ContUserList(1, client);
                                    writeLog("用户 " + client.name + "<" + client.id.ToString() + "> 从"
                                        + client.ip.ToString() + ":" + client.port.ToString() + "登陆成功");
                                    freshOnlineToEveryone();
                                    return;
                                }
                                else
                                {
                                    writeLog("<" + client.id.ToString() + ">(" + client.ip.ToString() + ":"
                                        + client.port.ToString() + ") 尝试连接失败");
                                    this.sendConnectingMsg(client, 0);  //密码错误
                                    return ;
                                }
                            }
                        }
                        this.sendConnectingMsg(client, -1); //没有该用户错误
                        return;
                    }
                    catch (Exception ex)
                    {
                        writeLog("用户认证异常"+ex.Message);
                    }
                }
                // 断开连接处理
                else if (String.Equals("ConnectOver", stype, StringComparison.OrdinalIgnoreCase))
                {
                    XmlNode node =  rootNode.SelectSingleNode("Data");
                    int userid = Int32.Parse( node.SelectSingleNode("UserID").InnerText);
                    UserClient cli = new UserClient();
                    foreach (UserClient clitmp in userList)
                    {
                        if (clitmp.id == userid)
                        {
                            writeLog("用户 " + clitmp.name + " 离开");
                            cli = clitmp;
                            break;
                        }
                    }
                    if(cli != null)
                        ContUserList(2, cli);
                    freshOnlineToEveryone();
                }
                // 正常聊天处理
                else if (String.Equals("clientChat", stype, StringComparison.OrdinalIgnoreCase))
                {
                    XmlNode node = rootNode.SelectSingleNode("From");
                    client.ip = IPAddress.Parse(node.SelectSingleNode("IPAddress").InnerText);
                    client.port = Convert.ToInt32(node.SelectSingleNode("Port").InnerText.ToString());
                    client.name = node.SelectSingleNode("Name").InnerText;
                    client.id = Int32.Parse( node.SelectSingleNode("UserID").InnerText);
                    StringBuilder getmsg = new StringBuilder();
                    getmsg.Append(client.name);
                    getmsg.Append("<");
                    getmsg.Append(client.id.ToString() + "> 向 ");

                    node = rootNode.SelectSingleNode("To");
                    IPAddress toIP = IPAddress.Parse(node.SelectSingleNode("IPAddress").InnerText);
                    int toPort = Convert.ToInt32(node.SelectSingleNode("Port").InnerText);
                    getmsg.Append(node.SelectSingleNode("Name").InnerText);
                    int tmpid = Int32.Parse(node.SelectSingleNode("UserID").InnerText);
                    if (0 == tmpid)
                    {
                        getmsg.Append("<服务器> 发送：\r\n--> ");
                        node = rootNode.SelectSingleNode("Data");
                        getmsg.Append(node.SelectSingleNode("Text").InnerText);
                        writeLog(getmsg.ToString());
                        return;
                    }
                    int toUserid = Int32.Parse(node.SelectSingleNode("UserID").InnerText);
                    getmsg.Append("<" + node.SelectSingleNode("UserID").InnerText);
                    getmsg.Append("> 发送：\r\n--> ");

                    node = rootNode.SelectSingleNode("Data");
                    getmsg.Append(node.SelectSingleNode("Text").InnerText);
                    writeLog(getmsg.ToString());
                    foreach (UserClient toC in userList)
                    {
                        if (toC.id == toUserid)
                        {
                            sendMessageChat(toC, str);
                        }
                    }
                }
                // 用户注册处理
                else if (String.Equals("Regist", stype, StringComparison.OrdinalIgnoreCase))
                {
                    XmlNode node = rootNode.SelectSingleNode("Data");
                    string username = node.SelectSingleNode("Name").InnerText;
                    string password = node.SelectSingleNode("Password").InnerText;
                    try
                    {
                        XmlDocument xmlDocUserL = new XmlDocument();
                        xmlDocUserL.Load(UListFilePath);
                        XmlElement ulRootNode = xmlDocUserL.DocumentElement;
                        int maxID=10000;
                        foreach (XmlNode user in ulRootNode.SelectNodes("User"))
                        {
                            int tmpint = Int32.Parse(user.SelectSingleNode("UserID").InnerText);
                            if(maxID < tmpint)
                                maxID = tmpint;
                        }
                        maxID++;

                        XmlElement nameNode = xmlDocUserL.CreateElement("Name");
                        nameNode.InnerText = username;
                        XmlElement idNode = xmlDocUserL.CreateElement("UserID");
                        idNode.InnerText = maxID.ToString();
                        XmlElement passwordNode = xmlDocUserL.CreateElement("Password");
                        passwordNode.InnerText = EncryptSha256(password);
                        XmlElement userNode = xmlDocUserL.CreateElement("User");
                        userNode.AppendChild(idNode);
                        userNode.AppendChild(nameNode);
                        userNode.AppendChild(passwordNode);
                        ulRootNode.AppendChild(userNode);
                        sendRegistMsg(client, maxID);
                        xmlDocUserL.Save(UListFilePath);
                        writeLog("添加新用户 " + username + "<" + maxID.ToString() + "> 成功");
                        return;
                    }
                    catch (Exception ex)
                    {
                        writeLog("添加用户异常：" + ex.Message);
                    }
                }
                else
                {
                    writeLog("未知的数据类型");
                }
            }
            catch (Exception ex)
            {
                writeLog("获取数据出现异常：" + ex.Message+"..."+str);
            }
        }

        private void sendConnectingMsg(UserClient client,int isOk)
        {
            string sendMessages;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(HeaderXML + ConnectingFrame);

            XmlElement rootNode = xmlDoc.DocumentElement;
            rootNode.SetAttribute("type", "ConnectingMsg");

            XmlNode node = rootNode.SelectSingleNode("Data");
            node.SelectSingleNode("Error").InnerText = isOk.ToString();
            node.SelectSingleNode("UserID").InnerText = client.id.ToString();
            if (1 == isOk)
            {
                node.SelectSingleNode("Name").InnerText = client.name;
            }
            sendMessages = xmlDoc.InnerXml;
            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.UTF8.GetBytes(sendMessages);
                client.netStream.Write(sendData, 0, sendData.Length);
                //textBox2.Invoke(callb, "\r\n向服务器发送：\r\n\t" + sendMessages);
                //textBox2.Invoke(callb, "\r\n=====发送完毕=====");
            }
            catch (Exception ex)
            {
                writeLog("连接请求回复发送失败：" + ex.Message);
                if (client.netStream != null)
                    client.netStream.Dispose();
                if (client.client != null)
                    client.client.Close();
            }
        }

        private void sendRegistMsg(UserClient client, int userid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(HeaderXML + ConnectingFrame);

            XmlElement rootNode = xmlDoc.DocumentElement;
            rootNode.SetAttribute("type", "RegistMsg");

            XmlNode node = rootNode.SelectSingleNode("Data");
            node.SelectSingleNode("Error").InnerText = "1";
            node.SelectSingleNode("UserID").InnerText = userid.ToString(); 
            string sendMessages = xmlDoc.InnerXml;
            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.UTF8.GetBytes(sendMessages);
                client.netStream.Write(sendData, 0, sendData.Length);
                //textBox2.Invoke(callb, "\r\n向服务器发送：\r\n\t" + sendMessages);
                //textBox2.Invoke(callb, "\r\n=====发送完毕=====");
            }
            catch (Exception ex)
            {
                writeLog("连接请求回复发送失败：" + ex.Message);
                if (client.netStream != null)
                    client.netStream.Dispose();
                if (client.client != null)
                    client.client.Close();
            }
        }

        private void sendMessageChat(UserClient toC, string str)
        {

            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.UTF8.GetBytes(str);
                toC.netStream.Write(sendData, 0, sendData.Length);
                //textBox2.Invoke(callb, "\r\n向服务器发送：\r\n\t" + sendMessages);
                //textBox2.Invoke(callb, "\r\n=====发送完毕=====");
            }
            catch (Exception ex)
            {
                writeLog("连接服务器请求失败：" + ex.Message);
                if (toC.netStream != null)
                    toC.netStream.Dispose();
                if (toC.client != null)
                    toC.client.Close();
                userList.Remove(toC);
            }
        }

        private void resendMessageChat(UserClient toC, string str)
        {

            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.UTF8.GetBytes(str);
                toC.netStream.Write(sendData, 0, sendData.Length);
                //textBox2.Invoke(callb, "\r\n向服务器发送：\r\n\t" + sendMessages);
                //textBox2.Invoke(callb, "\r\n=====发送完毕=====");
            }
            catch (Exception ex)
            {
                writeLog("连接服务器请求失败：" + ex.Message);
                if (toC.netStream != null)
                    toC.netStream.Dispose();
                if (toC.client != null)
                    toC.client.Close();
                userList.Remove(toC);
            }
        }

        private void sendMessageWithOnlineFriends(UserClient toC)
        {
            string sendMessages;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(HeaderXML + OnlineFrame);

            XmlElement rootNode = xmlDoc.DocumentElement;
            rootNode.SetAttribute("type", "OnlineFriends");

            XmlNode node = rootNode.SelectSingleNode("Data");
            foreach (UserClient cli in userList)
            {
                if (!toC.Equals(cli))
                {
                    XmlElement userNode = xmlDoc.CreateElement("OnlineUser");
                    XmlElement ipNode = xmlDoc.CreateElement("IPAddress");
                    ipNode.InnerText = cli.ip.ToString();
                    XmlElement portNode = xmlDoc.CreateElement("Port");
                    portNode.InnerText = cli.port.ToString();
                    XmlElement nameNode = xmlDoc.CreateElement("Name");
                    nameNode.InnerText = cli.name;
                    XmlElement idNode = xmlDoc.CreateElement("UserID");
                    idNode.InnerText = cli.id.ToString();
                    userNode.AppendChild(ipNode);
                    userNode.AppendChild(portNode);
                    userNode.AppendChild(nameNode);
                    userNode.AppendChild(idNode);
                    node.AppendChild(userNode);
                }
            }
            sendMessages = xmlDoc.InnerXml;
            //writeLog(sendMessages);
            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.UTF8.GetBytes(sendMessages);
                toC.netStream.Write(sendData, 0, sendData.Length);
                //textBox2.Invoke(callb, "\r\n向服务器发送：\r\n\t" + sendMessages);
                //textBox2.Invoke(callb, "\r\n=====发送完毕=====");
            }
            catch (Exception ex)
            {
                writeLog("连接服务器请求失败：" + ex.Message);
                if (toC.netStream != null)
                    toC.netStream.Dispose();
                if (toC.client != null)
                    toC.client.Close();
                userList.Remove(toC);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startServer();
            startToolStripMenuItem.Enabled = false;
            restartToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = true;
            configToolStripMenuItem.Enabled = false;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopServer();
            startToolStripMenuItem.Enabled = true;
            restartToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            configToolStripMenuItem.Enabled = true;
        }
        
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopServer();
            startServer();
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
            restartToolStripMenuItem.Enabled = true;
            configToolStripMenuItem.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //confForm confform = new confForm();
            //confform.Show(this);
            //textBox1.Invoke(cbSetTextBox, "fuck");
            //sendMessageWithOnlineFriends(null);
            //writeLog("fuck");
            //writeLog("hhhhhhhh");
            try
                    {
                        XmlDocument xmlDocUserL = new XmlDocument();
                        xmlDocUserL.Load(UListFilePath);
                        XmlElement ulRootNode = xmlDocUserL.DocumentElement;
                        foreach (XmlNode user in ulRootNode.SelectNodes("User"))
                        {
                            writeLog(user.SelectSingleNode("UserID").InnerXml);
                            writeLog(user.SelectSingleNode("Password").InnerXml);  
                        }
                    }
                    catch (Exception ex)
                    {
                        writeLog("用户认证异常"+ex.Message);
                    }
        }

        private void OnlineConnectTimer_Tick(object sender, EventArgs e)
        {
            freshOnlineToEveryone();
        }

        private void freshOnlineToEveryone()
        {
            foreach (UserClient cli in userList)
            {
                UserClient tmp = new UserClient();
                tmp = cli;
                Thread sendConnect = new Thread(() =>
                {
                    sendMessageWithOnlineFriends(tmp);
                });
                sendConnect.Start();
            }
        }

        private bool startServer()
        {
            initConf();
            try
            {
                listenThread = new Thread(Server);
                listenThread.Start();
                OnlineConnectTimer.Interval = timeOut;
                OnlineConnectTimer.Start();
                return true;
                //textBox1.Invoke(cbSetTextBox, "监听程序启动成功，端口：" + hostPort);
            }
            catch (Exception ex)
            {
                //textBox1.Invoke(cbSetTextBox, "监听启动异常：" + ex.Message);
                writeLog("监听启动异常：" + ex.Message);
                return false;
            }
        }

        private bool stopServer()
        {
            try
            {
                OnlineConnectTimer.Stop();
                listenEnable = false;
                listener.Stop();
                listenThread.Abort();
                listenThread = null;
                //if (netStream != null)
                //    netStream.Dispose();
                //if (client != null)
                //    client.Close();
                //textBox1.Invoke(cbSetTextBox, "服务端程序已关闭...");
                writeLog("服务端监听已关闭...");
                return true;
            }
            catch (Exception ex)
            {
                //textBox1.Invoke(cbSetTextBox, "服务端关闭出现异常！！！");
                writeLog("服务端关闭出现异常！！！");
                return false;
            }
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            confForm form2 = new confForm();
            form2.Show(this);
        }

    }
}
