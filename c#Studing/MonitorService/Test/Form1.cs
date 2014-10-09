using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.ServiceProcess;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            JsonReader reader =
                new JsonTextReader(new StringReader(@"{input : ""value"", output : 12}"));
            int i = 1;
            while (reader.Read())
            {
                textBox1.Text +=(i+"\t\t" + reader.ValueType
                    + "\t\t" + reader.Value + "\r\n");
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceController sc = new ServiceController("MonitorService");
            textBox1.Text += sc.Status;
            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.StopPending,new TimeSpan(50));
            }
            else
            {
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.StartPending,new TimeSpan(50));
            }
            textBox1.Text += sc.Status;
        }
        public void operateAccess()
        {
            String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\monitor\\monitoir.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            string sql = "insert into filelog(filename,fullpath,operate) VALUES('test','D:/test','测试')";
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
