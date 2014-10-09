using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Collections;


namespace CHCJ
{
	public static class  CJConfig
    {
        private const string confPath = "../../config/server_conf.xml";
        private const string logPath = "../../user/config.log";
        public const string XMLHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";

        private static int max_context_bytes = 2048;
        private static int timeout = 5000;   // 重传间隔时间
        private static int max_repeat_times = 3;   // 最大重传次数
        private static IPEndPoint server_end_point = 
            new IPEndPoint(IPAddress.Parse("127.0.0.1"),3333);
        private static  int server_port_tcp=2222;
        
        public static int TimeOut
        {
            get{return timeout;}
            set{timeout = value;}
        }
        public static int MaxContextBytes
        {
            get {return max_context_bytes;}
            set {max_context_bytes = value;}
        }
        public static int MaxRepeatTimes
        {
            get{return max_repeat_times;}
            set{max_repeat_times = value;}
        }
        public static string ServerName = "cj_server";
        public static string ServerID = "10000";
        public static IPAddress ServerIp
        {
            get{return server_end_point.Address;}
            set{server_end_point.Address = value;}
        }
        public static int ServerUdpPort
        {
            get{return server_end_point.Port;}
            set{server_end_point.Port=value;}
        }
        public static int ServerTcpPort
        {
            get{return server_port_tcp;}
            set{server_port_tcp=value;}
        }
        public static IPEndPoint ServerUdpEndPoint
        {
            get{return server_end_point;}
            set { server_end_point = value; }
        }
        public static IPAddress LocalIp
        {
            get
            {
                System.Net.IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
                foreach (IPAddress ip in addressList)
                {
                    if(ip.GetType().ToString()=="System.Net.IPAddress")
                        return ip;
                }
                return IPAddress.Parse("127.0.0.1");
            }
        }
        public static string Version;
        public static string Author;
        public static string Name;

        public static  CJLog log;
        static XmlDocument  xmlDoc = new XmlDocument();
        static XmlElement  rootNode;
        public enum ConfigState:uint
        {
            OK = 0,     // 发送成功，并收到回复
            DEFAULT,  // 有错误，而且已经使用默认值
            WARING,    // 警告
            ERROR    // 严重错误
        }

        public static  void init()
        {
            log = new CJLog();
            log.setLogLevel(CJLog.LogLevel.DEBUG);
            log.setLogModel(CJLog.LogModel.MESSAGE_BOX_SHOW);
            getConf();
        }

        // 获取配置信息
        private static ConfigState getConf()
        {
            try
            {
                xmlDoc.Load(confPath);
            }
            catch
            {
                ConfigState cstmp = initConfFile();
                if (cstmp > ConfigState.WARING)
                {
                    return cstmp;
                }
                xmlDoc.LoadXml(confPath);
            }
            try
            {
                rootNode = xmlDoc.DocumentElement;
                XmlNode node;
                node = rootNode.SelectSingleNode("Project");
                Author = node.SelectSingleNode("Author").InnerText;
                Version = node.SelectSingleNode("Version").InnerText;
                Name = node.SelectSingleNode("Name").InnerText;
                try
                {
                    Name = "fuck";
                }
                catch (Exception ex)
                {
                    //Name = "fuck";
                    MessageBox.Show(ex.Message); 
                }
                node = rootNode.SelectSingleNode("Config");
                foreach (XmlNode userNode in node.SelectNodes("Server"))
                {
                    ServerIp = IPAddress.Parse(userNode.SelectSingleNode("IPAddress").InnerText);
                    ServerTcpPort = int.Parse(userNode.SelectSingleNode("PortTcp").InnerText);
                    ServerUdpPort = int.Parse(userNode.SelectSingleNode("PortUdp").InnerText);
                    TimeOut = int.Parse(userNode.SelectSingleNode("TimeOut").InnerText);
                    MaxRepeatTimes = int.Parse(userNode.SelectSingleNode("MaxRepeatTimes").InnerText);
                    MaxContextBytes = int.Parse(userNode.SelectSingleNode("MaxContextBytes").InnerText);
                }
            }
            catch (Exception)
            {
                log.loging("读取链接配置文件出现错误",CJLog.LogLevel.COMMON_ERROR);
                return ConfigState.DEFAULT;
                //System.Environment.Exit(-1);
            }
            return ConfigState.OK;
        }
        // 初始化配置文件
        private static  ConfigState initConfFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                string xmlFrame = @"
<cjstudio>
  <Project>
    <Name>CHCJ</Name>
    <Version>v1.0</Version>
    <Author>CJ_Studio</Author>
    <CreateTime>2014-5-7 下午</CreateTime>
    <UpdateTime>2014-5-11 下午</UpdateTime>
  </Project>
 <Config>
    <Server>
      <IPAddress>127.0.0.1</IPAddress>
      <PortTcp>2222</PortTcp>
      <PortUdp>3333</PortUdp>
      <TimeOut>5000</TimeOut>
      <MaxRepeatTimes>3</MaxRepeatTimes>
      <MaxContextBytes>2048</MaxContextBytes>
    </Server>
  </Config>
</cjstudio>";
                xmlDoc.LoadXml(XMLHeader + xmlFrame);

                XmlElement rootNode = xmlDoc.DocumentElement;
                rootNode.SetAttribute("name", "connect.conf");
                xmlDoc.Save(confPath);
            }
            catch (Exception)
            {
                log.loging("初始化链接配置文件出错，可能需要重新安装",
                    CJLog.LogLevel.FATAL_ERROR);
                return ConfigState.ERROR;
            }
            return ConfigState.OK;
        }
	}
}
