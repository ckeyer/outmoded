using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XML_CLass
{
    class Program
    {
        //string str = "<?xml version=\"1.0\" encoding=\"utf-8\" ?> <birthday>  <NO1>    <type>类型1</type>    <date>时间1</date>    <title>信息1</title>    <name>姓名1</name>  </NO1>  <NO2>    <type>类型2</type>    <date>时间2</date>    <title>信息2</title>    <name>姓名2</name>  </NO2></birthday>";
        
        static void Main(string[] args)
        {
            Console.WriteLine("fuck");
            Program p = new Program();
            //p.test();
            CJNetXml cj = new CJNetXml();
            cj.DoTest1();
            Console.ReadLine();
        }

        void test()
        {
            XmlDocument dom = new XmlDocument();
            //dom.LoadXml(str);
            dom.Load("H:/code/C#/XML_CLass/XML_CLass/data.xml");//装载XML文档 
            //遍历所有节点 
            int num = 0;
            foreach (XmlElement birthday in dom.DocumentElement.ChildNodes)
            {
                //读取数据 
                string type = birthday.SelectSingleNode("type").InnerText;
                string type_type = "";
                if (birthday.SelectSingleNode("type").Attributes[0] != null)
                {
                     type_type= birthday.SelectSingleNode("type").Attributes[0].Value;
                }
                
                string date = birthday.SelectSingleNode("date").InnerText;
                string title = birthday.SelectSingleNode("title").InnerText;
                string name = birthday.SelectSingleNode("name").InnerText;
                if (birthday.SelectSingleNode("name").Attributes["type"] != null)
                {
                    Console.WriteLine( birthday.SelectSingleNode("name").Attributes["sex"].Value);
                }
                Console.WriteLine(type);
                Console.WriteLine(type_type);
                Console.WriteLine(date);
                Console.WriteLine(title);
                Console.WriteLine(name);
                //num++;
                ////装载示例，将新建的节点添加到TreeView 
                //TreeNode node = new TreeNode(text, data, image);//create a new node 
                //treeView.Nodes.Add(node);
                ////编辑示例:将当前节点的生日更改为当前日期 
                //birthday.SelectSingleNode("date").InnerText = DateTime.Now.ToString();
                ////删除示例：将当前节点删除 
                //birthday.ParentNode.RemoveChild(birthday);
            }
            //dom.Save();
        }
    }
}
