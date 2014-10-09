using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;

namespace CHCJ
{
    public enum SendState
    {
        OK = 0,     // 发送成功，并收到回复
        OUTTIME,    // 发送成功，但等待回复超时
        LOCAL_ERROR,    // 本地错误
        SERVER_ERROR,   // 服务端接收数据错误
        CONTENT_TOO_LONG,   // 要发送的数据过长
        CONTENT_ERROR,   // 连接异常
        SENDING,        // 发送中
        WAITING_REPLY,  // 发送成功，等待回复
        NONE
    }
    public  class CJTcpConnect
    {
        private const string confPath = "../../config/connect_conf.xml";
        public const string XMLHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
        public const int max_context_bytes = 2048;
        private bool is_listening= true;
        public IPAddress ip_server;
        private TcpClient tcp_client;
        private NetworkStream tcp_netstream;
        public  int port_tcp_local = 2233;      // 本地端口
        public int port_tcp_server = 2222;
        private SendState send_state = SendState.NONE; // 发送的状态
        public CJMsg msg_send, msg_receive;       // 要发送和已接收的消息

        private Thread t_moniter, t_sender;     // 发送及监听的线程
        delegate void CB_V_V();
        delegate void CB_V_S(string s);
        CB_V_V cb_moniter;
        CB_V_S cb_sender;

        public DelegateConnectHandle ReceiveOver;

        public CJTcpConnect()
        {
            getConf();
            init();
        }
        private void init()
        {
            try
            {
                receiveOver(CJLog.LogLevel.DEBUG, "tcp_client初始化");
                tcp_client = 
                    new TcpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port_tcp_local));
                tcp_client.Connect(new IPEndPoint(ip_server, port_tcp_server));
                try
                {
                    tcp_netstream = tcp_client.GetStream();  //获取绑定的网络数据流
                    receiveOver(CJLog.LogLevel.DEBUG, "tcp_netstream初始化");
                }
                catch (Exception)
                {
                    send_state = SendState.SERVER_ERROR;
                    receiveOver(CJLog.LogLevel.COMMON_ERROR, "error: 网络流获取失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                receiveOver(CJLog.LogLevel.COMMON_ERROR, "连接服务器失败");
            }
        }
        private void getConf() // 从文件获取基本配置 
        {
            ip_server = CJConfig.ServerIp;
            port_tcp_server = CJConfig.ServerTcpPort;
        }
        public void Close()
        {
            is_listening = false;
            try
            {
                if (tcp_client != null)
                {
                    tcp_client.Close();
                }
                if (t_moniter.ThreadState == ThreadState.Running)
                {
                    t_moniter.Abort();
                }
            }
            catch (Exception)
            {
                send_state = SendState.LOCAL_ERROR;
                receiveOver(CJLog.LogLevel.DEBUG,"error: TcpConnect Closing");
                return;
            }
        }

        public void tcp_start()
        {
            t_moniter = new Thread(new ThreadStart(tcp_moniter));
            t_moniter.Name = "ThreadTcpMoniter";
            t_moniter.Start();
            receiveOver(CJLog.LogLevel.DEBUG, "tcp开始监听");
        }
        public void tcp_sendMsg()
        {
            if (tcp_netstream == null)
                init();
            try
            {
                byte[] sendData = new byte[2048];
                sendData = Encoding.Default.GetBytes(msg_send.ToString());
                tcp_netstream.Write(sendData, 0, sendData.Length);
            }
            catch (Exception ex)
            {
                send_state = SendState.SERVER_ERROR;
                receiveOver(CJLog.LogLevel.COMMON_ERROR,"error: 发送数据时出现错误-"+ex.Message);
            }
        }
        private void tcp_moniter()
        {
             while (is_listening)
            {
                try
                {
                    int readLen = tcp_client.Available;
                    if (readLen > 0)
                    {
                        byte[] getData = new byte[2048];
                        tcp_netstream.Read(getData, 0, getData.Length);
                        try
                        {
                            string getMsg = Encoding.UTF8.GetString(getData);
                            msg_receive = new CJMsg(getMsg);
                            send_state = SendState.OK;
                            receiveOver(CJLog.LogLevel.DEBUG,"接收到消息"+getMsg);
                        }
                        catch (Exception ex)
                        {
                            send_state = SendState.SERVER_ERROR;
                            receiveOver(CJLog.LogLevel.COMMON_ERROR, "error: 接收数据后解析错误-"+ex.Message);
                        }
                    }
                }
                catch (Exception)
                {
                    receiveOver(CJLog.LogLevel.COMMON_ERROR,"error: 接收数据时出现错误");
                }
            }
        }

        public void receiveOver() // 接收到数据后，触发事件 
        {
            if (ReceiveOver != null)
            {
                CJReceiveOverEvent e = new CJReceiveOverEvent();
                e.sendState = this.send_state;
                e.Msg = this.msg_receive;
                e.Level = CJLog.LogLevel.DEFAULT;
                e.Remark = "";
                ReceiveOver(this, e);
            }
        }
        public void receiveOver(string remark) // 接收到数据后，触发事件 
        {
            if (ReceiveOver != null)
            {
                CJReceiveOverEvent e = new CJReceiveOverEvent();
                e.sendState = this.send_state;
                e.Msg = this.msg_receive;
                e.Level = CJLog.LogLevel.DEFAULT;
                e.Remark = remark;
                ReceiveOver(this, e);
            }
        }
        public void receiveOver(CJLog.LogLevel level, string remark) // 接收到数据后，触发事件 
        {
            if (ReceiveOver != null)
            {
                CJReceiveOverEvent e = new CJReceiveOverEvent();
                e.sendState = this.send_state;
                e.Msg = this.msg_receive;
                e.Level = level;
                e.Remark = remark;
                ReceiveOver(this, e);
            }
        }
    }
}
