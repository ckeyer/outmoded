using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace TCP_Client
{
    public partial class ConfForm : Form
    {
        IPAddress ip;
        int port;
        XmlDocument xmlDoc;
        const string ConfFilePath = "D:/ChatClient/clientConf.xml";
        const string HeaderXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n";
        const string DefaultConfFrame = @"<cjstudio>
    <Project>
        <Name>TcpChatServer</Name>
        <Version>v1.0</Version>
        <Author>CJ_Studio</Author>
        <CreateTime>2014-4-9 下午</CreateTime>
        <UpdateTime>2014-4-12 下午</UpdateTime>
    </Project>
    <Server>
        <IPAddress>127.0.0.1</IPAddress>
        <Port>2222</Port>
    </Server>
    <Config>
    </Config>
</cjstudio>";
        public ConfForm()
        {
            InitializeComponent();
        }

        private void ConfForm_Load(object sender, EventArgs e)
        {
            xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(ConfFilePath);
                XmlElement rootNode = xmlDoc.DocumentElement;
                XmlNode node = rootNode.SelectSingleNode("Server");

                ip = IPAddress.Parse( node.SelectSingleNode("IPAddress").InnerText);
                port = Int32.Parse(node.SelectSingleNode("Port").InnerText);

                numericUpDown1.Value = port;
                textBox1.Text = ip.ToString();
            }
            catch (Exception ex)
            {
                xmlDoc.LoadXml(HeaderXML + DefaultConfFrame);
                XmlElement rootNode = xmlDoc.DocumentElement;
                XmlNode node = rootNode.SelectSingleNode("Server");

                ip = IPAddress.Parse(node.SelectSingleNode("IPAddress").InnerText);
                port = Int32.Parse(node.SelectSingleNode("Port").InnerText);

                xmlDoc.Save(ConfFilePath);

                numericUpDown1.Value = port;
                textBox1.Text = ip.ToString();
            }
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.BackColor != Color.Salmon)
            {
                saveConfig();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("IP地址不合法");
            }
        }

        private void saveConfig()
        {
            XmlElement rootNode = xmlDoc.DocumentElement;
            XmlNode node = rootNode.SelectSingleNode("Server");

            node.SelectSingleNode("IPAddress").InnerText = ip.ToString();
            node.SelectSingleNode("Port").InnerText = port.ToString();

            xmlDoc.Save(ConfFilePath);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            try
            {
                ip = IPAddress.Parse(textBox1.Text);
                textBox1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                textBox1.BackColor = Color.Salmon;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.BackColor != Color.Salmon)
            {
                saveConfig();
                this.Close();
            }
            else
            {
                MessageBox.Show("IP地址不合法");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
