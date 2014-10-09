using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleTCP同步服务器端
{
    class Program
    {
        private static int myport = 3600;
        private static TcpListener tcLis;
        private static NetworkStream ns;
        private static TcpClient tcC;
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            tcLis = new TcpListener(ip, myport);
            try
            {
                tcLis.Start();
                Console.WriteLine("启动监听{0}成功", myport);
                Thread revThread = new Thread(RevMsg);
                revThread.Start();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("监听启动异常：" + ex.Message);
            }         
        }  

        //接收信息
        private static void RevMsg()
        {
            try
            {
                tcC = tcLis.AcceptTcpClient();
                ns = tcC.GetStream();
                while (true)
                {
                    int readLen = tcC.Available;
                    if (readLen > 0)
                    {
                        byte[] getData = new byte[128];
                        ns.Read(getData, 0, getData.Length);
                        string getMsg = Encoding.Default.GetString(getData);                        
                        Console.WriteLine("从{0}接收消息为：{1}",tcC.Client.LocalEndPoint,getMsg);
                     }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine("监听信息：" + ex.Message);
               if (ns != null)
                   ns.Dispose();
               if (tcC != null)
                   tcC.Close();              
             }
        }
    }
}
