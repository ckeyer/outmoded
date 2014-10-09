using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XML_CLass
{
    class CJNetXml
    {
        const string HeaderXML = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n";
        const string DefaultConf = @"<cjstudio type="+"\"fuckker\""+@">
    <Project>
        <Name>XML测试</Name>
        <Version>v1.0</Version>
        <Author>CJ_Studio</Author>
        <Date>2014-4-1 下午</Date>
    </Project>
    <Config>
        <MaxWidth>150</MaxWidth>
        <MinWidth>50</MinWidth>
        <MaxHeight>120</MaxHeight>
        <MinHeight>40</MinHeight>
        <IsSignal>Y</IsSignal>
        <IsBest>Y</IsBest>
    </Config>
</cjstudio>";
        public XmlDocument xmlDoc;
        public CJNetXml()
        {
            xmlDoc = new XmlDocument();
            Console.WriteLine(HeaderXML + DefaultConf);
            xmlDoc.LoadXml(HeaderXML + DefaultConf);
            //xmlDoc.Load(HeaderXML + DefaultConf);
        }

        public void DoTest1()
        {
            XmlElement rootNode = xmlDoc.DocumentElement;
            string tmppp= rootNode.GetAttribute("type");
            if (String.Equals(tmppp, "fucKER", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("fuckkkkkkkkkkkkkkkkkkkkk");
            Console.WriteLine("");
            Console.WriteLine(tmppp);
            Console.WriteLine("");
            XmlNode node = rootNode.SelectSingleNode("Project");
            if (node != null)
            {
                Console.WriteLine(node.SelectSingleNode("Name").InnerText);
                Console.WriteLine(node.SelectSingleNode("Version").InnerText);
            }
            node = rootNode.SelectSingleNode("Config");
            if (node != null)
            {
                Console.WriteLine(node.SelectSingleNode("MaxHeight").InnerText);
                Console.WriteLine(node.SelectSingleNode("MinWidth").InnerText);
                Console.WriteLine(node.SelectSingleNode("IsBest").InnerText);
                XmlElement tmp = (XmlElement)node.SelectSingleNode("IsBest");
                tmp.SetAttribute("something", "We will do it better");
            }
            foreach (XmlNode nd in rootNode.ChildNodes)
            {
                nd.SelectNodes("Project");
            }
            xmlDoc.Save("test.xml");
        }
    }
}
