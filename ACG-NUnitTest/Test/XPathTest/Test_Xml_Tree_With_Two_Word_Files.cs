using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using ACG_Api.model.Test;
using ACG_Api.model.XPath;

namespace ACG_NUnitTest.Test.XPathTest
{
    public class TestXmlTree : IEquatable<TestXmlTree>
    {
        public string? Alias { get; set; }
        public string? Tag { get; set; }
        public string? Text { get; set; }

        public bool Equals(TestXmlTree? other)
        {
            if (other == null) return false;
            return Alias == other.Alias && Tag == other.Tag && Text == other.Text;
        }

        public override bool Equals(object? obj) => Equals(obj as TestXmlTree);

        public override int GetHashCode()
        {
            return HashCode.Combine(Alias, Tag, Text);
        }
    }

    [TestFixture]
    public class Test_Xml_Tree_With_Two_Word_Files
    {
        private XPath _xpath;
        private XPath _xpathOriginal;
        [SetUp]
        public void Setup()
        {
            _xpath = new XPath("");
            _xpathOriginal = new XPath("");
        }

        [Test]
        public void Compare_Word_Files_Should_Be_Equal()
        {
            var list1 = _xpath.GetXmlTreeForTest();
            var list2 = _xpathOriginal.GetXmlTreeForTest();

            Assert.That(list1.Count, Is.EqualTo(list2.Count), "Кількість елементів не співпадає");

            for (int i = 0; i < list1.Count; i++)
            {
                Assert.That(list1[i], Is.EqualTo(list2[i]), $"Відмінність у елементі #{i + 1}");
            }
        }
    }
}