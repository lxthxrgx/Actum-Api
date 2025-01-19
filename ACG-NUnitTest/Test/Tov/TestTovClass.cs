using ACG_Class.Database;
using ACG_Class.Model.Word;
using Microsoft.EntityFrameworkCore;

namespace ACG_NUnitTest
{
    public class TestsGroups
    {
        private Tov _tov;
        private DataBaseContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseSqlite("Data Source=C:\\ACG\\DataBase\\Prod.db")
                .Options;

            _context = new DataBaseContext(options);
            _tov = new Tov(241, _context);
        }

        [Test]
        public void TestGetNumberById()
        {
            var result = _tov.GetNumberGroup();
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void TestGetNameById()
        {
            var result = _tov.GetNameGroup();
            Assert.That(result, Is.EqualTo("Юзик"));
        }

        [TearDown]
        public void TearDown()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}