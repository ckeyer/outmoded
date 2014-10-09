using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TCP_Client
{
    public static class userClient
    {
        public static EndPoint endPoint;
        public static int id;
        public static string name;
        public static IPAddress ip;
        public static int port;
        public static IPAddress serverIp;
        public static int serverPort;
        public static NetworkStream netStream;
        public static TcpClient client;
    }
}
