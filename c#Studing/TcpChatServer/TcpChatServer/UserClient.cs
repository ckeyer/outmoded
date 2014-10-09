using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace TcpChatServer
{
    class UserClient
    {
        public int id;
        public EndPoint endPoint;
        public string name;
        public IPAddress ip;
        public int port;
        public NetworkStream netStream;
        public TcpClient client;
    }
}
