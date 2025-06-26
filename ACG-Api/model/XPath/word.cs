using System.IO.Compression;
using System.Text;
using System.Xml;
using ACG_Api.model.Test;

namespace ACG_Api.model.XPath
{
    public class XPath
    {
        // const string original = "/home/ltx/Documents/Sublease.docx";
        string output = "/home/ltx/Documents/";

        // string original = "C:\\Users\\wetqw\\Desktop\\Sublease.docx";
        // string output = "C:\\Users\\wetqw\\Desktop\\Test.docx";

        private XmlDocument doc;
        private XmlNamespaceManager nsManager;
        private string _pathToTemplate;

        public XPath(string pathToTemplate)
        {
            _pathToTemplate = pathToTemplate;
            string dataXml = DocxToXml(_pathToTemplate);

            doc = new XmlDocument();
            doc.LoadXml(dataXml);

            nsManager = new XmlNamespaceManager(doc.NameTable);
            nsManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
        }

        public string DocxToXml(string pathToDocx)
        {
            using (ZipArchive archive = ZipFile.OpenRead(pathToDocx))
            {
                var entry = archive.GetEntry("word/document.xml");
                if (entry == null) throw new Exception("word/document.xml not found!");

                using (var reader = new StreamReader(entry.Open()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public void GetXmlTree()
        {
            XPath xPath = new (_pathToTemplate);

            string dataXml = xPath.DocxToXml(_pathToTemplate);

            doc.Load(new StringReader(dataXml));
        
            nsManager = new XmlNamespaceManager(doc.NameTable);
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
                        if (alias?.Attributes?["w:val"] != null)
                        {
                            Console.WriteLine("Alias: " + alias.Attributes?["w:val"]?.Value);
                        }

                        var tag = sdtPr.SelectSingleNode("w:tag", nsManager);
                        if (tag?.Attributes?["w:val"] != null)
                        {
                            Console.WriteLine("Tag: " + tag?.Attributes?["w:val"]?.Value);
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
        }

        public List<TestXmlTree> GetXmlTreeForTest()
        {
            var testList = new List<TestXmlTree>();

            XPath xPath = new XPath(_pathToTemplate);
            string dataXml = xPath.DocxToXml(_pathToTemplate);

            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(dataXml));

            XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
            nsManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");

            var paragraphs = doc.SelectNodes("//w:sdt[w:*]", nsManager);

            if (paragraphs != null)
            {
                foreach (XmlNode node in paragraphs)
                {
                    TestXmlTree test = new TestXmlTree();

                    XmlNode? sdtPr = node.SelectSingleNode("w:sdtPr", nsManager);
                    if (sdtPr != null)
                    {
                        var alias = sdtPr.SelectSingleNode("w:alias", nsManager);
                        test.Alias = alias?.Attributes?["w:val"]?.Value;

                        var tag = sdtPr.SelectSingleNode("w:tag", nsManager);
                        test.Tag = tag?.Attributes?["w:val"]?.Value;
                    }

                    XmlNode? sdtContent = node.SelectSingleNode("w:sdtContent", nsManager);
                    if (sdtContent != null)
                    {
                        var textNode = sdtContent.SelectSingleNode(".//w:t", nsManager);
                        test.Text = textNode?.InnerText;
                    }

                    testList.Add(test);
                }
            }

            return testList;
        }

        public void WriteXmlTree(string Tag, string Value)
        {
            var paragraphs = doc.SelectNodes("//w:sdt[w:*]", nsManager);

            if (paragraphs != null)
            {
                foreach (XmlNode node in paragraphs)
                {
                    XmlNode? sdtPr = node.SelectSingleNode("w:sdtPr", nsManager);

                    if (sdtPr != null)
                    {
                        var tag = sdtPr.SelectSingleNode("w:tag", nsManager);
                        if (tag?.Attributes?["w:val"]?.Value == Tag)
                        {
                            XmlNode? sdtContent = node.SelectSingleNode("w:sdtContent", nsManager);
                            if (sdtContent != null)
                            {
                                var textNode = sdtContent.SelectSingleNode(".//w:t", nsManager);
                                if (textNode != null)
                                {
                                    textNode.InnerText = Value;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Save(string nameFile)
        {
            string updatedXml;
            using (var stringWriter = new Utf8StringWriter())
            using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings
            {
                Indent = false,
                Encoding = new UTF8Encoding(false)
            }))
            {
                doc.Save(xmlWriter);
                updatedXml = stringWriter.ToString();
            }

            SaveXmlToDocx(_pathToTemplate, updatedXml, output + nameFile + ".docx");
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => new UTF8Encoding(false);
        }

        public string GetModifiedXml(XmlDocument doc)
        {
            using (var sw = new StringWriter())
            using (var xw = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true }))
            {
                doc.Save(xw);
                return sw.ToString();
            }
        }

        public void SaveXmlToDocx(string originalDocxPath, string modifiedXml, string outputDocxPath)
        {
            using (FileStream fs = new FileStream(outputDocxPath, FileMode.Create))
            using (ZipArchive originalArchive = ZipFile.Open(originalDocxPath, ZipArchiveMode.Read))
            using (ZipArchive newArchive = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                foreach (var entry in originalArchive.Entries)
                {
                    if (entry.FullName == "word/document.xml")
                    {
                        var newEntry = newArchive.CreateEntry("word/document.xml");
                        using (var entryStream = newEntry.Open())
                        using (var writer = new StreamWriter(entryStream))
                        {
                            writer.Write(modifiedXml);
                        }
                    }
                    else
                    {
                        var newEntry = newArchive.CreateEntry(entry.FullName);
                        using (var entryStream = newEntry.Open())
                        using (var originalStream = entry.Open())
                        {
                            originalStream.CopyTo(entryStream);
                        }
                    }
                }
            }
        }
    }
}