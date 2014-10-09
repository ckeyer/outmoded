using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleTCP同步客户端
{
    class Program
    {
        private static int myport = 3600;       
        private static NetworkStream ns;
        private static TcpClient tcC;

        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            tcC = new TcpClient();
            try
            {                
                tcC.Connect(ip, myport);
                ns = tcC.GetStream();  //获取绑定的网络数据流
                Console.WriteLine("连接服务器成功！");
                for (int i = 1; i < 6; i++)
                {
                    Thread.Sleep(1000);
                    string sendMessages = "客户端发送消息" + i.ToString ();
                    byte [] sendData=new byte[1024];
                    sendData =Encoding.Default.GetBytes (sendMessages );
                    ns.Write(sendData,0,sendData.Length);
                    Console.WriteLine("向"+sendMessages);          
                 }
                 Console.WriteLine("发送完毕，按回车键退出");
                 Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("连接服务器失败：" + ex.Message);
                if (ns != null)
                   ns.Dispose();
                if (tcC != null)
                   tcC.Close();
            }
        }
    }
}
