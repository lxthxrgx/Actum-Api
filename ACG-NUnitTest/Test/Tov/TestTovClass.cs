// using ACG_Class.Database;
// using ACG_Class.Model.Word;
// using Microsoft.EntityFrameworkCore;

// namespace ACG_NUnitTest
// {
//     public class TestsGroups
//     {
//         private Tov _tov;
//         private DataBaseContext _context;

//         [SetUp]
//         public void Setup()
//         {
           
//         }

//         [TestCase(1, 295)]
//         [TestCase(2, 199)]
//         [TestCase(3, 239)]
//         [TestCase(4, 7)]
//         [TestCase(5, 102)]
//         [TestCase(6, 87)]
//         [TestCase(7, 120)]
//         [TestCase(8, 33)]
//         [TestCase(9, 222)]
//         [TestCase(10, 179)]
//         public void CreateCase(int id, int expectedNumberGroup)
//         {
//             var options = new DbContextOptionsBuilder<DataBaseContext>()
//                .UseSqlite("Data Source=C:\\ACG\\DataBase\\Test.db")
//                .Options;

//             _context = new DataBaseContext(options);
//             _tov = new Tov(id, _context);

//             var actualNumberGroup = _tov.GetNumberGroup();
//             Console.WriteLine($"Testing Id: {id}, Expected: {expectedNumberGroup}, Actual: {actualNumberGroup}");
//             Assert.That(actualNumberGroup, Is.EqualTo(expectedNumberGroup));
//         }

//         //[TestCase(295)]
//         //[TestCase(199)]
//         //[TestCase(239)]
//         //[TestCase(7)]
//         //[TestCase(102)]
//         //[TestCase(87)]
//         //[TestCase(120)]
//         //[TestCase(33)]
//         //[TestCase(222)]
//         //[TestCase(179)]
//         //public void TestGetNumberById(int numberGroup)
//         //{
//         //    var result = _tov.GetNumberGroup();
//         //    Assert.That(result, Is.EqualTo(numberGroup));
//         //}

//         [TestCase(1, "Гнатюк")]
//         [TestCase(2, "Захарчук")]
//         [TestCase(3, "Гнатюк")]
//         [TestCase(4, "Микитюк")]
//         [TestCase(5, "Захарчук (Віктор)")]
//         [TestCase(6, "Пономарчук")]
//         [TestCase(7, "Гнатюк (Олег)")]
//         [TestCase(8, "Пономарчук")]
//         [TestCase(9, "Шинкаренко")]
//         [TestCase(10, "Микитюк")]
//         public void TestGetNameById(int id, string nameGroup)
//         {
//             var options = new DbContextOptionsBuilder<DataBaseContext>()
//                .UseSqlite("Data Source=C:\\ACG\\DataBase\\Test.db")
//                .Options;

//             _context = new DataBaseContext(options);
//             _tov = new Tov(id, _context);

//             var result = _tov.GetNameGroup();
//             Assert.That(result, Is.EqualTo(nameGroup));
//         }

//         [TestCase(1, "Data retrieved successfully.")]
//         [TestCase(2, "Data retrieved successfully.")]
//         [TestCase(3, "Data retrieved successfully.")]
//         [TestCase(4, "Data retrieved successfully.")]
//         [TestCase(5, "Data retrieved successfully.")]
//         [TestCase(6, "Data retrieved successfully.")]
//         [TestCase(7, "Data retrieved successfully.")]
//         [TestCase(8, "Data retrieved successfully.")]
//         [TestCase(9, "Data retrieved successfully.")]
//         [TestCase(10, "Data retrieved successfully.")]
//         [Test]
//         public void GetDataCounterpartyTovByNameGroup(int id, string NameGroup)
//         {
//             var options = new DbContextOptionsBuilder<DataBaseContext>()
//               .UseSqlite("Data Source=C:\\ACG\\DataBase\\Test.db")
//               .Options;

//             _context = new DataBaseContext(options);
//             _tov = new Tov(id, _context);

//             _tov.NameGroup = NameGroup;
//             var result = _tov.GetDataCounterpartyTov();
//             Assert.That(result, Is.EqualTo("Data retrieved successfully."));
//         }

//         //[Test]
//         //public void GetDataGroupsTovByNameGroup()
//         //{
//         //    var result = _tov.GetDataGroupsTov();
//         //    Assert.That(result, Is.EqualTo("Data retrieved successfully."));
//         //}

//         //[Test]
//         //public void GetDataSubleaseTovByNameGroup()
//         //{
//         //    var result = _tov.GetDataSubleaseTov();
//         //    Assert.That(result, Is.EqualTo("Data retrieved successfully."));
//         //}

//         //[Test]
//         //public void GetDataSubleaseDopTovByNameGroup()
//         //{
//         //    var result = _tov.GetDataSubleaseDopTov();
//         //    Assert.That(result, Is.EqualTo("Data retrieved successfully."));
//         //}

//         [TearDown]
//         public void TearDown()
//         {
//             if (_context != null)
//             {
//                 _context.Dispose();
//             }
//         }
//     }
// }