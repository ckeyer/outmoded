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

namespace TCP_Server
{
    public partial class Form1 : Form
    {
        private static int myport = 2222;
        private static TcpListener tcLis;
        private static NetworkStream ns;
        private static TcpClient tcC;

        delegate void CallBackSetTextBox(string str);
        CallBackSetTextBox callb;
        IPAddress ip;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            callb = new CallBackSetTextBox(SetTextBox);
            ip = IPAddress.Parse("127.0.0.1");        
        }

        private void RevMsg()
        {
            try
            {
                while (true)
                {
                    tcC = tcLis.AcceptTcpClient();
                    ns = tcC.GetStream();
                    int readLen = tcC.Available;
                    if (readLen > 0)
                    {
                        Thread netsThread = new Thread(readStream);
                        netsThread.Start();
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

        void readStream()
        {
            byte[] getData = new byte[128];
            ns.Read(getData, 0, getData.Length);
            string getMsg = Encoding.Default.GetString(getData);
            textBox2.Invoke(callb, "\r\n从" + tcC.Client.LocalEndPoint + "接收消息为：\r\n\t" + getMsg); ;
        }

        void SetTextBox(string str)
        {
            textBox2.Text += str;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcLis = new TcpListener(ip, myport);
            try
            {
                tcLis.Start();
                textBox2.Invoke(callb, "\r\n启动监听成功，监听端口：" + myport);
                Thread revThread = new Thread(RevMsg);
                revThread.Start();
            }
            catch (Exception ex)
            {
                textBox2.Invoke(callb, "\r\n监听启动异常：" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sendMessages = textBox1.Text;
                byte[] sendData = new byte[1024];
                sendData = Encoding.Default.GetBytes(sendMessages);
                ns.Write(sendData, 0, sendData.Length);
                textBox2.Invoke(callb, "\r\n向" + tcC.Client.LocalEndPoint + "发送：\r\n\t" + sendMessages);
                textBox2.Invoke(callb, "\r\n=====发送完毕=====");
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
}
