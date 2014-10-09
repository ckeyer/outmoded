using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MonitorService
{
    public delegate void MsgConfHandle(object sender, MsgEvent e);
    public class TcpServer
    {
        private IPAddress ip;
        private int port;
        private TcpListener listener;
        public MsgConfHandle msgConf;
        public TcpServer(int port)
        {
            ip = IPAddress.Parse("127.0.0.1");
            this.port = port;
            listener = new TcpListener(ip,port);
        }
        private void sendEventMsg()
        {
            if (this.msgConf != null)
            {
                MsgConfEvent e = new MsgConfEvent();
            }
        }

        public void startListen()
        {
            try 
	        {
                this.listener.Start();
	        }
	        catch (Exception ex)
	        {
                CJMonitor.writeLog("Error101-TCP-SERVER", ex.Message);
	        }
        }
        private void RevMsg()
        {
            while (true)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream ns = client.GetStream();
                    int readLen = client.Available;
                    if (readLen > 0)
                    {
                        Thread netsThread = new Thread(() => 
                        {
                            operateStream(ns); 
                        });
                        netsThread.Start();
                    }
                }
                catch (Exception ex)
                {
                    CJMonitor.writeLog("监听信息", ex.Message);
                }
            }
        }
        void operateStream(NetworkStream ns)
        {
            byte[] getData = new byte[128];
            ns.Read(getData, 0, getData.Length);
            string getMsg = Encoding.Default.GetString(getData);
        }
    }

    /*********************************************/
    public class MsgConfEvent : EventArgs
    {
        public EventArgs EventMsg;
        public Dictionary<string, string> Msg =
            new Dictionary<string, string>();
        public string Type;
        public string ShowControl;
        public int Num = 0;
        public MsgConfEvent() { }
        public MsgConfEvent(string title,string msg)
        {
            this.Msg.Add(title,msg);
        }
        public void addMsg(string title,string msg)
        {
            this.Msg.Add(title,msg);
        }
    }
}
