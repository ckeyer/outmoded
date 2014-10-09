using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;

namespace TcpChatServer
{
    public partial class confForm : Form
    {
        const string ConfFilePath = "D:/ChatServer/serverConf.xml";
        const string UListFilePath = "D:/ChatServer/userList.xml";
        const string HeaderXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n";
        const string DefaultConfFrame = @"<TcpChatServer>
    <Project>
        <Name>XML测试</Name>
        <Version>v1.0</Version>
        <Author>CJ_Studio</Author>
        <CreateTime>2014-4-1 下午</CreateTime>
        <UpdateTime>2014-4-7 下午</UpdateTime>
    </Project>
    <Config>
        <IPAddress>127.0.0.1</IPAddress>
        <Port>2222</Port>
        <MaxConnect>20</MaxConnect>
        <TimeOut>3000</TimeOut>
    </Config>
</TcpChatServer>";

        private XmlDocument xmlDoc;
        public IPAddress hostIP { private set; get; }
        public int hostPort { private set; get ;}
        public int maxConnect { private set; get ;}
        public confForm()
        {
            InitializeComponent();
        }

        private void confForm_Load(object sender, EventArgs e)
        {
            xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(ConfFilePath);
                XmlElement rootNode = xmlDoc.DocumentElement;
                XmlNode node = rootNode.SelectSingleNode("Config");

                numericUpDown1.Value = Int32.Parse(node.SelectSingleNode("Port").InnerText);
                numericUpDown2.Value = Int32.Parse(node.SelectSingleNode("MaxConnect").InnerText);
                numericUpDown3.Value = Int32.Parse(node.SelectSingleNode("TimeOut").InnerText);
            }
            catch (Exception ex)
            {
                xmlDoc.LoadXml(HeaderXML + DefaultConfFrame);
                XmlElement rootNode = xmlDoc.DocumentElement;
                XmlNode node = rootNode.SelectSingleNode("Config");

                numericUpDown1.Value = Int32.Parse(node.SelectSingleNode("Port").InnerText);
                numericUpDown2.Value = Int32.Parse(node.SelectSingleNode("MaxConnect").InnerText);
                numericUpDown3.Value = Int32.Parse(node.SelectSingleNode("TimeOut").InnerText);
                xmlDoc.Save(ConfFilePath);
            }
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveConfig();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveConfig();
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void saveConfig()
        {
            XmlElement rootNode = xmlDoc.DocumentElement;
            XmlNode node = rootNode.SelectSingleNode("Config");

            node.SelectSingleNode("Port").InnerText = numericUpDown1.Value.ToString();
            node.SelectSingleNode("MaxConnect").InnerText = numericUpDown2.Value.ToString();
            node.SelectSingleNode("TimeOut").InnerText = numericUpDown3.Value.ToString();

            xmlDoc.Save(ConfFilePath);
        }
    }
}
