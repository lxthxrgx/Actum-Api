using System;
using System.IO;
using System.IO.Compression;
using System.Xml;

namespace ACG_Api.model.XPath
{
    public class XPath
    {
        const string DocxPath = "/home/ltx/Documents/Sublease.docx";

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

            string dataXml = xPath.DocxToXml(DocxPath);

            doc.Load(new StringReader(dataXml));
        
            var nsManager = new XmlNamespaceManager(doc.NameTable);
            nsManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");


            var paragraphs = doc.SelectNodes("//w:sdt[w:*]", nsManager);
            if (paragraphs is not null)
            {
                foreach (XmlNode node in paragraphs)
                    Console.WriteLine(node.OuterXml);
            }

            return "";
        }
    }
}