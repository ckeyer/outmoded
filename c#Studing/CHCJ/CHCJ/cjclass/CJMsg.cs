using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CHCJ
{
    public enum MsgType
    {
        CS_REPLY = 0,      // 回复
        C_CONNECT,    // 连接请求
        C_AUTH,     // 认证信息
        S_AUTH_RIGHT,   // 认证回复
        S_AUTH_ERROR,   // 认证回复
        C_CONNECTING,      // 保持连接请求
        CS_CONFIG,     // 配置协商信息
        CS_CHAT_MSG,    // 聊天数据
        C_PIC_REQUEST,     // 图片发送请求
        C_FILE_REQUEST,   // 文件发送请求
        S_TCP_OVER,     // TCP连接正常中断
        CS_OTHERS   // 其它
    }
    public class CJMsg
    {
        const string MsgFrame =
@"<cjstudio>
  <From>
    <IPAddress></IPAddress>
    <Port></Port>
    <UserID></UserID>
    <Name></Name>
  </From>
  <To>
    <IPAddress></IPAddress>
    <Port></Port>
    <UserID></UserID>
    <Name></Name>
  </To>
  <Data>
  </Data>
  <Hash>
  </Hash>
</cjstudio>";
        public const string XMLHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
        
        public  struct Peer
        {
            public string ip ;
            public int port;
            public string id;
            public string name;
        }

        public long msg_ID;
        private XmlDocument xmlDoc;
        private XmlElement rootNode;
        public Peer peer_from, peer_to;
        public MsgType type_msg;
        public int seq;
        public string data_text;

        public CJMsg()
        {
            init();
            xmlDoc.LoadXml(XMLHeader + MsgFrame);
            rootNode = xmlDoc.DocumentElement;
        }
        public CJMsg(string xmlStr)
        {
            init();
            xmlDoc.LoadXml(xmlStr);
            rootNode = xmlDoc.DocumentElement;
        }
        public CJMsg(string str, bool b) // For test
        {
            ;
        }
        private void init()
        {
            xmlDoc = new XmlDocument();
        }

        public void setMsgType(MsgType type)
        {
            rootNode.SetAttribute("type", type.ToString());
            this.type_msg = type;
        }
        public void setMsgType(MsgType type,int seq)
        {
            setMsgType(type);
            rootNode.SetAttribute("seq", seq.ToString());
            this.seq = seq;
        }
        public void setMsgFromNode(string ip,int port,string userID,string name)
        {
            XmlNode node = rootNode.SelectSingleNode("From");
            node.SelectSingleNode("IPAddress").InnerText = ip;
            node.SelectSingleNode("Port").InnerText = port.ToString();
            node.SelectSingleNode("UserID").InnerText = userID;
            node.SelectSingleNode("Name").InnerText = name;
            peer_from.ip = ip;
            peer_from.port = port;
            peer_from.id = userID;
            peer_from.name = name;
        }
        public void setMsgToNode(string ip, int port, string userID, string name)
        {
            XmlNode node = rootNode.SelectSingleNode("To");
            node.SelectSingleNode("IPAddress").InnerText = ip;
            node.SelectSingleNode("Port").InnerText = port.ToString();
            node.SelectSingleNode("UserID").InnerText = userID;
            node.SelectSingleNode("Name").InnerText = name;
            peer_to.ip = ip;
            peer_to.port = port;
            peer_to.id = userID;
            peer_to.name = name;
        }
        public void setMsgFromNode(Peer fromPeer)
        {
            XmlNode node = rootNode.SelectSingleNode("From");
            node.SelectSingleNode("IPAddress").InnerText = fromPeer.ip;
            node.SelectSingleNode("Port").InnerText = fromPeer.port.ToString();
            node.SelectSingleNode("UserID").InnerText = fromPeer.id;
            node.SelectSingleNode("Name").InnerText = fromPeer.name;
        }
        public void setMsgToNode(Peer toPeer)
        {
            XmlNode node = rootNode.SelectSingleNode("To");
            node.SelectSingleNode("IPAddress").InnerText = toPeer.ip;
            node.SelectSingleNode("Port").InnerText = toPeer.port.ToString();
            node.SelectSingleNode("UserID").InnerText = toPeer.id;
            node.SelectSingleNode("Name").InnerText = toPeer.name;
        }
        public void setMsgDataNode(XmlNode inNode)
        {
            XmlElement node = (XmlElement)rootNode.SelectSingleNode("Data");
            node.InnerXml = inNode.InnerXml;
            data_text = inNode.InnerText;
        }
        public void setMsgDataNode(int id, XmlNode inNode)
        {
            XmlElement node = (XmlElement)rootNode.SelectSingleNode("Data");
            node.SetAttribute("id", id.ToString());
            node.InnerXml = inNode.InnerXml;
            data_text = inNode.InnerText;
        }
        public void addMsgText(string msgstr)
        {
            XmlNode noddata = rootNode.SelectSingleNode("Data");
            XmlElement xeltext = xmlDoc.CreateElement("Text");
            xeltext.InnerText = msgstr;
            noddata.AppendChild(xeltext);
            data_text = msgstr;
        }
        public void addMsgText_Attr(string type,string msgstr)
        {
            XmlNode noddata = rootNode.SelectSingleNode("Data");
            XmlElement xeltext = xmlDoc.CreateElement("Text");
            xeltext.SetAttribute("type",type);
            xeltext.InnerText = msgstr;
            noddata.AppendChild(xeltext);
            data_text = msgstr;
        }
        public void addMsgData_Attr(string name, string value)
        {
            XmlElement noddata = (XmlElement)rootNode.SelectSingleNode("Data");
            noddata.SetAttribute(name, value);
        }
        public void addMsgText_Node(string key, string value)
        {
            XmlNode noddata = rootNode.SelectSingleNode("Data");
            XmlElement xeltext = xmlDoc.CreateElement("Text");
            XmlElement xelkey = xmlDoc.CreateElement("Key");
            XmlElement xelvalue = xmlDoc.CreateElement("Value");
            xelkey.InnerText = key;
            xelvalue.InnerText = value;
            xeltext.AppendChild(xelkey);
            xeltext.AppendChild(xelvalue);
            noddata.AppendChild(xeltext);
        }
        public void setMsgHash()
        {
            StringBuilder str = new StringBuilder();
            str.Append(rootNode.SelectSingleNode("Data").InnerXml);
            str.Append(rootNode.SelectSingleNode("To").InnerXml);
            str.Append(rootNode.SelectSingleNode("From").InnerXml);
            XmlNode node = rootNode.SelectSingleNode("Hash");
            node.InnerText = hashStr(str.ToString());
        }
        private string hashStr(string str)
        {
            byte[] result = Encoding.UTF8.GetBytes(str);
            MD5 hash = new MD5CryptoServiceProvider();
            byte[] output = hash.ComputeHash(result);
            string s = BitConverter.ToString(output).Replace("-", "");
            return s.ToUpper();
        }

        public string getMsgXML()
        {
            return xmlDoc.InnerXml;
        }
        public override string ToString()
        {
            return getMsgXML();
        }
        public MsgType getMsgType()
        {
            string s= rootNode.GetAttribute("type");
            if (s == MsgType.C_CONNECT.ToString())
            {
                type_msg = MsgType.C_CONNECT;
            }
            else if (s == MsgType.C_CONNECTING.ToString())
            {
                type_msg = MsgType.C_CONNECTING;
            }
            else if (s == MsgType.CS_REPLY.ToString())
            {
                type_msg = MsgType.CS_REPLY;
            }
            else if (s == MsgType.CS_CONFIG.ToString())
            {
                type_msg = MsgType.CS_CONFIG;
            }
            else if (s == MsgType.CS_CHAT_MSG.ToString())
            {
                type_msg = MsgType.CS_CHAT_MSG;
            }
            else if (s == MsgType.C_PIC_REQUEST.ToString())
            {
                type_msg = MsgType.C_PIC_REQUEST;
            }
            else if (s == MsgType.C_FILE_REQUEST.ToString())
            {
                type_msg = MsgType.C_FILE_REQUEST;
            }
            else if (s == MsgType.C_AUTH.ToString())
            {
                type_msg = MsgType.C_AUTH;
            }
            else if (s == MsgType.S_AUTH_ERROR.ToString())
            {
                type_msg = MsgType.S_AUTH_ERROR;
            }
            else if (s == MsgType.S_AUTH_RIGHT.ToString())
            {
                type_msg = MsgType.S_AUTH_RIGHT;
            }
            else if (s == MsgType.S_TCP_OVER.ToString())
            {
                type_msg = MsgType.S_TCP_OVER;
            }
            else
            {
                type_msg = MsgType.CS_OTHERS;
            }
            return type_msg;
        }
        public Peer getMsgPeerTo()
        {
            XmlNode node = rootNode.SelectSingleNode("To");
            peer_from.ip= node.SelectSingleNode("IPAddress").InnerText;
            peer_from.port = Int32.Parse(node.SelectSingleNode("Port").InnerText);
            peer_from.id = node.SelectSingleNode("UserID").InnerText;
            peer_from.name = node.SelectSingleNode("Name").InnerText;
            return peer_from;
        }
        public Peer getMsgPeerFrom()
        {
            XmlNode node = rootNode.SelectSingleNode("From");
            peer_to.ip = node.SelectSingleNode("IPAddress").InnerText;
            peer_to.port = Int32.Parse(node.SelectSingleNode("Port").InnerText);
            peer_to.id = node.SelectSingleNode("UserID").InnerText;
            peer_to.name = node.SelectSingleNode("Name").InnerText;
            return peer_to;
        }
        public string getMsgDataText()
        {
            getMsgType();
            if (type_msg == MsgType.CS_CHAT_MSG)
            {
                try
                {
                    XmlNode node = rootNode.SelectSingleNode("Data");
                    XmlNode nodeText = node.SelectSingleNode("Text");
                    data_text = nodeText.InnerText;
                }
                catch (Exception)
                {
                    XmlNode node = rootNode.SelectSingleNode("Data");
                    data_text = node.InnerText;
                }
            }
            else
            {
                XmlNode node = rootNode.SelectSingleNode("Data");
                data_text = node.InnerText;
            }
            return data_text;
        }
        public List<Peer> getMsgTextKVs(string type)
        {
            List<Peer> friends = new List<Peer>();
            XmlNode noddata = rootNode.SelectSingleNode("Data");
            foreach (XmlNode nodetext in noddata.SelectNodes("Text"))
            {
                if (((XmlElement)nodetext).GetAttribute("type") == type)
                {
                    Peer p = new Peer();
                    p.id = nodetext.SelectSingleNode("Key").InnerText;
                    p.name = nodetext.SelectSingleNode("Value").InnerText;
                    friends.Add(p);
                }
            }
            return friends;
        }
        public List<CJMsg> getMsgTextVs(string type)
        {
            List<CJMsg> noReceive = new List<CJMsg>();
            XmlNode noddata = rootNode.SelectSingleNode("Data");
            foreach (XmlNode nodetext in noddata.SelectNodes("Text"))
            {
                if (((XmlElement)nodetext).GetAttribute("type") == type)
                {
                    string str = nodetext.InnerText;
                    str = System.Text.RegularExpressions.Regex.Replace(str, "&gt;", ">");
                    str = System.Text.RegularExpressions.Regex.Replace(str, "&lt;", "<");
                    CJMsg tmp = new CJMsg(str);
                    noReceive.Add(tmp);
                }
            }
            return noReceive;
        }
        public bool isTrueData()
        {
            StringBuilder str = new StringBuilder();
            str.Append(rootNode.SelectSingleNode("Data").InnerXml);
            str.Append(rootNode.SelectSingleNode("To").InnerXml);
            str.Append(rootNode.SelectSingleNode("From").InnerXml);
            XmlNode node = rootNode.SelectSingleNode("Hash");
            if (node.InnerText == hashStr(str.ToString()))
                return true;
            else 
            return false;
        }

        public void formatByXml()
        {
            getMsgType();
            getMsgPeerFrom();
            getMsgPeerTo();
            getMsgDataText();
        }
        public void formatByValue()
        {
            setMsgType(this.type_msg);
            setMsgFromNode(this.peer_from);
            setMsgToNode(this.peer_to);
            addMsgText(this.data_text);
        }
        public void exchagePeer()
        {
            Peer tmp = new Peer();
            tmp = this.peer_from;
            peer_from=peer_to;
            peer_to = tmp;
            setMsgFromNode(this.peer_from);
            setMsgToNode(this.peer_to);
        }
    }
}
