using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Pipes;
using System.IO;
using System.Security.Principal;

namespace pipeCLient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //这里第一个参数是我的计算机名
                NamedPipeClientStream pipeClientA =
                new NamedPipeClientStream("localhost", "testpipe",
                PipeDirection.InOut, PipeOptions.None,
                TokenImpersonationLevel.Impersonation);
                StreamWriter sw = new StreamWriter(pipeClientA);
                StreamReader sr = new StreamReader(pipeClientA);
                pipeClientA.Connect();
                sw.AutoFlush = true;

                //确认服务器连接
                if (sr.ReadLine() == "My Server!")
                {
                    Console.WriteLine("OK");
                    sw.WriteLine("Client Connected");
                    //向管道中写入数据（先转化为字符串）
                }
                else
                {
                }
                //关闭客户端
                pipeClientA.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
