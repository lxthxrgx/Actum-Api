using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using ACG_Api.model.Test;
using Microsoft.Extensions.Options;

namespace ACG_Api.model.XPath
{
    public class PathSettings
    {
        public string PathToFolder { get; set; } = "";
    }
    public class XPathProcessor
    {
        private readonly string _filePath;
        private XmlDocument doc;
        private XmlNamespaceManager nsManager;
        private readonly string _pathToTemplate;

        public XPathProcessor(string pathToTemplate)
        {
            _pathToTemplate = pathToTemplate;
            string dataXml = DocxToXml(_pathToTemplate);

              var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            _filePath = config["PathToSaveAgreements:PathToFolder"] ?? " ";

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
            XPathProcessor xPath = new (_pathToTemplate);

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

        public void TestXmlTreeLinq()
        {
            XPathProcessor xPath = new(_pathToTemplate);

            string dataXml = xPath.DocxToXml(_pathToTemplate);

            XDocument doc = XDocument.Parse(dataXml);

            XNamespace w = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

            var sdtElements = doc.Descendants(w + "sdt");

            var results = sdtElements
                .Where(sdt => sdt.Elements(w + "sdtPr").Any())
                .Select(sdt =>
                {
                    var sdtPr = sdt.Element(w + "sdtPr");
                    var alias = sdtPr?.Element(w + "alias")?.Attribute(w + "val")?.Value;
                    var tag = sdtPr?.Element(w + "tag")?.Attribute(w + "val")?.Value;

                    var contentText = sdt
                        .Element(w + "sdtContent")?
                        .Descendants(w + "t")
                        .Select(t => t.Value)
                        .Aggregate(string.Empty, (a, b) => a + b);

                    return new
                    {
                        Alias = alias,
                        Tag = tag,
                        Text = contentText
                    };
                });

            foreach (var item in results)
            {
                Console.WriteLine($"Alias: {item.Alias}");
                Console.WriteLine($"Tag: {item.Tag}");
                Console.WriteLine($"Text: {item.Text}");
                Console.WriteLine("-----");
            }
        }

        public List<TestXmlTree> GetXmlTreeForTest()
        {
            var testList = new List<TestXmlTree>();

            XPathProcessor xPath = new XPathProcessor(_pathToTemplate);
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

            SaveXmlToDocx(_pathToTemplate, updatedXml, _filePath + nameFile + ".docx");
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