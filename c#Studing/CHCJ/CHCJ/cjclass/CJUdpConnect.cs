using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CHCJ
{
    class CJUdpConnect
    {
        public const string XMLHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
        public const int max_context_bytes = 2048;
        private int TIMEOUT = 5000;  /***/ // 重传间隔时间
        private int MAX_REPEAT_TIMES = 3;  /***/ // 最大重传次数
        public int times_repeat = 0;    // 已发送的次数
        public IPEndPoint end_point_server;  /***/ // 服务器端
        public IPAddress ip_server;  /***/
        // private UdpClient udp_server;    // 服务器端套接字
        private UdpClient udp_local; /***/    // 本地套接字
        private int port_udp_local = 2232;      // 本地端口
        public int port_udp_server = 3333; /***/
        private SendState send_state=SendState.NONE; // 发送的状态
        public   CJMsg msg_send, msg_receive;       // 要发送和已接收的消息

        private Thread t_moniter, t_sender;     // 发送及监听的线程
        delegate void CB_V_V();
        delegate void CB_V_I(int num);
        CB_V_V cb_moniter;
        CB_V_V cb_sender;
        public DelegateConnectHandle ReceiveOver;

        public CJUdpConnect()
        {
            getConf();
            initSocket(); 
            initThread();
        }
        private void getConf() // 从文件获取基本配置 
        {
            ip_server = CJConfig.ServerIp;
            port_udp_server = CJConfig.ServerUdpPort;
            end_point_server = CJConfig.ServerUdpEndPoint;
            TIMEOUT = CJConfig.TimeOut;
            MAX_REPEAT_TIMES = CJConfig.MaxRepeatTimes;
        }
        private void initSocket() // 初始化本地和服务端套接字
        {
            while (true)    // 防止端口被占用
            {
                try
                {
                    udp_local = new UdpClient(
                        new IPEndPoint(IPAddress.Parse("127.0.0.1"),port_udp_local));
                    break;
                }
                catch (Exception)
                {
                    port_udp_local++;
                }
            }
        }
        private void initThread() // 线程，委托等的初始化 
        {
            cb_moniter = new CB_V_V(do_udp_monitor);
            t_moniter = new Thread(new ThreadStart(cb_moniter));
            t_moniter.Name = "ThreadMoniter";
            cb_sender = new CB_V_V(do_udp_sendMsg);
            t_sender = new Thread(new ThreadStart(cb_sender));
            t_sender.Name = "ThreadSender";
        }

        public void udp_sendMsg(bool reply)
        {
            if (reply)
            {
                if (t_moniter.ThreadState == ThreadState.Running)
                {
                    t_moniter.Abort();
                    fun_do_udp_sendMsg(times_repeat);
                    times_repeat++;
                    if (send_state == SendState.WAITING_REPLY)
                    {
                        initThread();
                        t_moniter.Start();
                        t_sender.Start();
                    }
                }
                else
                {
                    fun_do_udp_sendMsg(times_repeat);
                    times_repeat++;
                    if (send_state == SendState.WAITING_REPLY)
                    {
                        initThread();
                        t_moniter.Start();
                        t_sender.Start();
                    }
                }
            }
            else
            {
                if (t_moniter.ThreadState == ThreadState.Running)
                {
                    t_moniter.Suspend();
                    fun_do_udp_sendMsg(0);
                    t_moniter.Resume();
                }
                else
                {
                    fun_do_udp_sendMsg(0);
                }
            }
        }
        public void udp_sendMsg()
        {
            //t_sender.Start(times_repeat++);
            fun_do_udp_sendMsg(times_repeat);
            times_repeat++;
            if (send_state == SendState.WAITING_REPLY)
            {
                t_moniter.Start();
                t_sender.Start();
            }
        }

        private void do_udp_sendMsg()
        {
            //while (times_repeat <= MAX_REPEAT_TIMES)
            object o = new object();
            while (send_state == SendState.WAITING_REPLY && 
                times_repeat <= MAX_REPEAT_TIMES)
            {
                if (t_moniter.Join(TIMEOUT))
                {
                    return;
                }
                else
                {
                    t_moniter.Suspend();
                    lock (o)
                    {
                        fun_do_udp_sendMsg(times_repeat++);
                    }
                    t_moniter.Resume();
                }
            }
            if (times_repeat >= MAX_REPEAT_TIMES)
            {
                Thread.Sleep(TIMEOUT);
                send_state = SendState.OUTTIME;
                t_moniter.Abort();
                lock (o)
                {
                    times_repeat++;
                }
                receiveOver();
            }
        }
        private void do_udp_monitor()
        {
            object o = new object();
            lock (o)
            {
                while (times_repeat <= MAX_REPEAT_TIMES)
                {
                    try
                    {
                        byte[] b = udp_local.Receive(ref end_point_server);
                        string s = Encoding.UTF8.GetString(b);
                        msg_receive = new CJMsg(s);
                        if (CHCJ.MsgType.CS_REPLY == msg_receive.getMsgType())
                        {
                            send_state = SendState.OK;
                            receiveOver();
                            break;
                        }
                        else
                        {
                            send_state = SendState.SERVER_ERROR;
                            receiveOver();
                            break;
                        }
                    }
                    catch (Exception )
                    {
                        ;
                    }
                }
            }
        }
        private void fun_do_udp_sendMsg(int num)
        {
            object o = new object();
            lock (o)
            {
                try
                {
                    byte[] b = Encoding.UTF8.GetBytes(msg_send.ToString());
                    if (b.Length > max_context_bytes)
                    {
                        send_state = SendState.CONTENT_TOO_LONG;
                        return;
                    }
                    udp_local.Connect(end_point_server);
                    udp_local.Send(b, b.Length);
                    send_state = SendState.WAITING_REPLY;
                }
                catch (Exception)
                {
                    send_state = SendState.LOCAL_ERROR;
                    receiveOver();
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
                e.Remark = remark;
                ReceiveOver(this, e);
            }
        }
    }
}
