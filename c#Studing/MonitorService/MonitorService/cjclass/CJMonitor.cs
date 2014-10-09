using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MonitorService
{
    using KiVs = KeyValuePair<int, string>;
    using System.IO.Pipes;
    public delegate void MsgSendHandle(object sender, MsgEvent e);
    
    public class CJMonitor
    {
        public KiVs Status = new KiVs(0, "");
        public  List<CJFolder> folders= new List<CJFolder>();
        private XmlDocument xmlDoc;
        private XmlElement rootNode;
        public MsgSendHandle MsgSend; 
        public const string logPath = "D:\\monitor\\tmp.log";
        public string confFile = "D:\\monitor\\FileMonitor.conf";
        public String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\monitor\\monitoir.mdb";
        public int ServerPort = 93126;
        public string pipeName= "cjmonitorPipe";
        public static NamedPipeServerStream pipeServer;
        public static StreamReader sr;
        public static StreamWriter sw;
        public CJMonitor()
        {
            getConf();
            //try
            //{
            //    pipeServer = new NamedPipeServerStream("cjmonitorPipe", PipeDirection.InOut);
            //    pipeServer.WaitForConnection(); 
            //    sr = new StreamReader(pipeServer);
            //    sw = new StreamWriter(pipeServer);
            //}
            //catch (Exception ex)
            //{
            //    writeLog("Error S041", ex.Message);
            //}
        }
        private void getConf()
        {
            xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(confFile);
                rootNode = xmlDoc.DocumentElement;
            }
            catch (Exception)
            {
                this.Status = new KiVs(-1, "配置文件加载失败");
                CJMonitor.writeLog("error", "配置文件加载失败");
            }
            if (Status.Key < 0)
            {
                return;
            }
            try
            {
                pipeName =rootNode.SelectSingleNode("Server").SelectSingleNode("PipeName").Value;
            }
            catch (Exception)
            {
                pipeName = "cjmonitorPipe";
            }
            XmlNodeList folderNodes;
            folderNodes = rootNode.SelectNodes("Folder");
            foreach (XmlNode node in folderNodes)
            {
                string path = node.Attributes["path"].Value ;
                string filter = node.Attributes["filter"].Value;
                string[] fs = filter.Split('|');
                string standDir = node.Attributes["standDir"].Value;
                string backupDir = node.Attributes["backDir"].Value;
                this.AddFolder(path, fs.ToList<string>(),standDir,backupDir);
            }
        }
        public void setConf()
        {
            foreach (XmlNode node in rootNode.SelectNodes("Folder"))
            {
                rootNode.RemoveChild(node);
            }
            foreach (CJFolder fold in folders)
            {
                XmlElement folderNode = xmlDoc.CreateElement("Folder");
                folderNode.SetAttribute("path", fold.DirPath);
                string filterTmp = "";
                foreach (string str in fold.Filter)
                {
                    if (filterTmp == "")
                    {
                        filterTmp = str;
                    }
                    else
                    {
                        filterTmp += "|" + str;
                    }
                }
                folderNode.SetAttribute("filter", filterTmp);
                folderNode.SetAttribute("standDir", fold.StandDir);
                folderNode.SetAttribute("backDir", fold.BackupDir);
                rootNode.AppendChild(folderNode);
            }
            xmlDoc.Save(confFile);
        }
        public void AddFolder(string path,List<string> filter,string standdir,string backupdir)
        {
            CJFolder newfolder = new CJFolder(path,filter,standdir,backupdir);
            newfolder.FileChangeEvent +=
                new FileSystemEventHandler(fileSystemWatcher_EventHandle_Change);
            newfolder.FileCreateEvent +=
                new FileSystemEventHandler(fileSystemWatcher_EventHandle_Create);
            newfolder.FileDeleteEvent +=
                new FileSystemEventHandler(fileSystemWatcher_EventHandle_Delete);
            newfolder.FileRenameEvent +=
                new RenamedEventHandler(fileSystemWatcher_EventHandle_Rename);
            folders.Add(newfolder);
            setConf();
        }

        private void fileSystemWatcher_EventHandle_Change(object sender, FileSystemEventArgs e)  //文件增删改时被调用的处理方法
        {
            string str = e.ChangeType.ToString();
            string DirName = Path.GetDirectoryName(str);
            if (MsgSend != null)
            {
                MsgEvent ev = new MsgEvent();
                ev.Type = e.ChangeType.ToString();
                ev.Msg.Add(e.Name.ToString());
                ev.Msg.Add(e.FullPath.ToString());
                MsgSend(this, ev);
            }
        }
        private void fileSystemWatcher_EventHandle_Create(object sender, FileSystemEventArgs e)  //文件增删改时被调用的处理方法
        {
            string str = e.ChangeType.ToString();
            string DirName = Path.GetDirectoryName(str);
            if (MsgSend != null)
            {
                MsgEvent ev = new MsgEvent();
                ev.Type = e.ChangeType.ToString();
                ev.Msg.Add(e.Name.ToString());
                ev.Msg.Add(e.FullPath.ToString());
                MsgSend(this, ev);
            }
        }
        private void fileSystemWatcher_EventHandle_Delete(object sender, FileSystemEventArgs e)  //文件增删改时被调用的处理方法
        {
            string str = e.ChangeType.ToString();
            string DirName = Path.GetDirectoryName(str);
            if (MsgSend != null)
            {
                MsgEvent ev = new MsgEvent();
                ev.Type = e.ChangeType.ToString();
                ev.Msg.Add(e.Name.ToString());
                ev.Msg.Add(e.FullPath.ToString());
                MsgSend(this, ev);
            }
        }
        private void fileSystemWatcher_EventHandle_Rename(object sender, RenamedEventArgs e)   //文件重命名时被调用的处理方法
        {
            string str = e.ChangeType.ToString();
            string DirName = Path.GetDirectoryName(str);
            if (MsgSend != null)
            {
                MsgEvent ev = new MsgEvent();
                ev.Type = e.ChangeType.ToString();
                ev.Msg.Add(e.OldName.ToString());
                ev.Msg.Add(e.OldName.ToString());
                ev.Msg.Add(e.Name.ToString());
                MsgSend(this, ev);
            }
        }

        public void startAll()
        {
            foreach (CJFolder folder in folders)
            {
                folder.fileWatcher.EnableRaisingEvents = true;
            }
        }
        public void stopAll()
        {
            foreach (CJFolder folder in folders)
            {
                folder.fileWatcher.EnableRaisingEvents = false;
            }
        }

        public static void writeLog(string type, string msg)
        {
            StreamWriter logw;
            try
            {
                logw = File.AppendText(logPath);
            }
            catch (Exception ex)
            {
                logw = File.CreateText(logPath);
            }
            try
            {
                logw.WriteLine(DateTime.Now.ToString() +
                    "." + DateTime.Now.Millisecond.ToString() +":【" + type + "】. " + msg);
                logw.Close();
                sendLog( type,  msg);
            }
            catch (Exception)
            {
                logw.Close();
            }
        }
        public static void sendLog(string type, string msg)
        {
            //if (sr.ReadLine() == "Listening")
            //{
            //    sw.WriteLine("【" + type + "】" + DateTime.Now.ToString() +
            //        "." + DateTime.Now.Millisecond.ToString() + "#$#" + msg);
            //}
        }
    }

    public class MsgEvent : EventArgs
    {
        public EventArgs EventMsg;
        public List<string> Msg =new List<string>();
        public string Type;
        public string ShowControl;
        public int Num=0;
        public MsgEvent(){}
        public MsgEvent(string msg)
        {
            this.Msg.Add(msg);
        }
    }
}
