using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Linq;

namespace ACG_Api.model.XPath
{
    public class XPath
    {
        const string DocxPath = "/home/ltx/Documents/Sublease.docx";

        string a = "D:\\Projects\\CSharp\\ACG\\ACG\\wwwroot\\word\\1_Дог_ суборенда_ТОВ.docx";

        public string DocxToXml(string pathToDocx)
        {
            string xmlContent;

            using (ZipArchive archive = ZipFile.OpenRead(pathToDocx))
            {
                var entry = archive.GetEntry("word/document.xml");

                if (entry == null)
                {
                    Console.WriteLine("Файл word/document.xml не найден в .docx архиве.");
                    return "";
                }

                using (var reader = new StreamReader(entry.Open()))
                {
                    xmlContent = reader.ReadToEnd();
                    return xmlContent;
                }
            }
        }

        public string GetXmlTree()
        {
            XmlDocument doc = new XmlDocument();
            XPath xPath = new ();

            string dataXml = xPath.DocxToXml(a);

            doc.Load(new StringReader(dataXml));
        
            var nsManager = new XmlNamespaceManager(doc.NameTable);
            nsManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");


            var paragraphs = doc.SelectNodes("//w:sdt[w:*]", nsManager);

            if (paragraphs is not null)
            {
                foreach (XmlNode node in paragraphs)
                {
                    XmlNode? sdtPr = node.SelectSingleNode("w:sdtPr", nsManager);

                    if (sdtPr != null)
                    {
                        var alias = sdtPr.SelectSingleNode("w:alias", nsManager);
                        if (alias?.Attributes["w:val"] != null)
                        {
                            Console.WriteLine("Alias: " + alias.Attributes["w:val"].Value);
                        }

                        var tag = sdtPr.SelectSingleNode("w:tag", nsManager);
                        if (tag?.Attributes["w:val"] != null)
                        {
                            Console.WriteLine("Tag: " + tag.Attributes["w:val"].Value);
                        }
                    }

                    XmlNode? sdtContent = node.SelectSingleNode("w:sdtContent", nsManager);
                    if (sdtContent != null)
                    {
                        var textNode = sdtContent.SelectSingleNode(".//w:t", nsManager);
                        if (textNode != null)
                        {
                            Console.WriteLine("Text: " + textNode.InnerText);
                        }
                    }
                }

            }
            return "";
        }
    }
}