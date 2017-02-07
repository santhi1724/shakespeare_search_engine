using System;
using System.Xml;
using System.IO;

namespace SimplifiedXMLWritter
{
    class Program
    {
        static void Main(string[] args)
        {
            //upload file
            string xml = File.ReadAllText("S:/MIS 546/assignment1/a_and_c.xml");
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Ignore;
            XmlReader rdr = XmlReader.Create(new System.IO.StringReader(xml), settings);
            int countTitle = 0;

            XmlDocument doc = new XmlDocument();
            //add tags add and doc
            XmlNode startNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(startNode);
            
            XmlNode addNode = doc.CreateElement("add");
            doc.AppendChild(addNode);
            XmlNode docNode = doc.CreateElement("doc");
            // doc.AppendChild(docNode);
            addNode.AppendChild(docNode);
            //insert filed name and value
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Element)
                {

                    if (rdr.LocalName.ToUpper() == "TITLE" && countTitle == 0)
                    {
                        
                        // Console.WriteLine(rdr.LocalName);
                        XmlNode titleField = doc.CreateElement("field");
                        XmlAttribute name = doc.CreateAttribute("name");
                        name.Value = "id";
                        titleField.Attributes.Append(name);
                        titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                        docNode.AppendChild(titleField);
                        countTitle = 1;
                    }
                    if (rdr.LocalName.ToUpper() == "LINE")
                    {

                        XmlNode titleField = doc.CreateElement("field");
                        XmlAttribute name = doc.CreateAttribute("name");
                        name.Value = "features";
                        titleField.Attributes.Append(name);
                        titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                        docNode.AppendChild(titleField);
                    }
                    /*   if (rdr.LocalName.ToUpper() == "PLAY")
                       {
                          =
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "play";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                     /*  if (rdr.LocalName.ToUpper() == "PERSONA")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "persona";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "P")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "p";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "PERSONAE")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "personae";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "FM")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "FM";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "GRPDESCR")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "grpdescr";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "PGROUP")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "pgroup";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }

                       if (rdr.LocalName.ToUpper() == "ACT")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "act";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "SCNDESCR")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "scndescr";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "PLAYSUBT")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "playsubt";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "SCENE")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "scene";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "STAGEDIR")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "STAGEDIR";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "SPEECH")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "speech";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "SPEAKER")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "speaker";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "PROLOGUE")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "prologue";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "SUBTITLE")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "subtitle";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "EPILOGUE")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "epilogue";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "INDUCT")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "induct";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }
                       if (rdr.LocalName.ToUpper() == "SUBHEAD")
                       {
                           // Console.WriteLine(rdr.LocalName);
                           XmlNode titleField = doc.CreateElement("field");
                           XmlAttribute name = doc.CreateAttribute("name");
                           name.Value = "subhead";
                           titleField.Attributes.Append(name);
                           titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                           docNode.AppendChild(titleField);
                       }*/
                }

            }
            //save the file

            doc.Save("S:/MIS 546/assignment1/a_and_c.xml");
            Console.ReadLine();
        }
    }
}
