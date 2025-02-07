using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACG_Class.SuppCode;

namespace ACG_NUnitTest.Test
{
    public class TestDdeleteSpace
    {
        [TestCase(" UA183052990000026002006404043\r\nАТ КБ \"ПриватБанк\"")]
        public void GetClearString(string Test)
        {
            var result = DeleteSpace.Deletespace(Test);
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo("UA183052990000026002006404043 АТ КБ \"ПриватБанк\""));
        }
    }    
}
