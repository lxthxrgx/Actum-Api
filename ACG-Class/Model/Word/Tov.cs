using ACG_Class.Database;
using Microsoft.EntityFrameworkCore;
using ACG_Class.Model.Word.AdditionalCode;
using ACG_Class.Model.Class;

namespace ACG_Class.Model.Word
{
    interface ICounterpartyTov
    {
        string FullName { get; set; }
        string Rnokpp { get; set; }
        string Edryofop { get; set; }
        string BanckAccount { get; set; }
        string Address { get; set; }
        string Director { get; set; }
        string ShortDirector { get; set; }
    }

    interface IGroupsTov
    { 
        double Area { get; set; }
        string NameGroup { get; set; }
        string DepartmentAddress { get; set; }
    }

    interface ISubleaseTov
    {
        int NumberGroup { get; set; }
        DateTime AktDate { get; set; }
        DateTime EndAktDate { get; set; }
        DateTime DateTime { get; set; }
        string AgreementContract { get; set; }
        double Sum { get; set; }
    }

    public class Tov : BasicEntity
    {
        private readonly DataBaseContext _context;
        public Tov(int id)
        {
            Id = id;
        }
        public Tov(DataBaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Id { get; set; }
        public string AgreementNumber { get; set; }
        public DateTime Datetime { get; set; }
        public string FullName { get; set; }
        public string Edryofop { get; set; }
        public string Rnokpp { get; set; }
        public string CounterpaertyAddress { get; set; }
        public string BanckAccount { get; set; }
        public double? DepartmentArea { get; set; }
        public string DepartmentAddress { get; set; }
        public DateTime EndAktDate { get; set; }

        public string _director;
        public string _shortDirector;

        public int? SubleaseDopId { get; set; }
        public SubleaseDop? SubleaseDop { get; set; }

        public string SubleaseDopNum;
        public DateTime? subleaseDopDate;
        public string subleaseDopName;
        public string subleaseDopRnokppLastData;
        public string subleaseDopstatus;

        //const string dirPath = CreateDirectoryForDoc($"{NumberGroup}-{NameGroup}");
        //const string path_dog = await wordDoc.CopyOriginalFile(LoadSettingSublease("sublease-agreement-tov", "sublease-tov"), $"{RenameGog(DogovirSuborendu)}-{relatedDataNameGroup}-договір-ТОВ", dirPath);


        public int GetNumberGroupById()
        {
            var GetNumberGroup = _context.D4.Where(x => x.Id == Id).Select(e => e.NumberGroup).SingleOrDefault();
            if (GetNumberGroup != 0)
            {
                NumberGroup = GetNumberGroup;
                return GetNumberGroup;
            }
            else
            {
                return 0;
            }
        }

        public string GetNameGroupByNameberGroup()
        {
            var GetNameGroup =  _context.D2.Where(e => e.NumberGroup == GetNumberGroupById())
                .Select(x => x.NameGroup).SingleOrDefault();

            if (!string.IsNullOrEmpty(GetNameGroup))
            {
                NameGroup = GetNameGroup;
                return GetNameGroup;
            }
            else
            {
                return string.Empty;
            }
        }

        public string Director()
        {
            var GetDirectorFullName = _context.D1.Where(p => p.NameGroup == NameGroup)
                .Select(x => x.Director)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(GetDirectorFullName))
            {
                _director = GetDirectorFullName;
                return GetDirectorFullName;
            }
            else
            {
                return string.Empty;
            }

        }

        public string ShortDirector()
        {
            if (!string.IsNullOrEmpty(Director()))
            {
                _shortDirector = ShortName.GetShortenedName(Director());
                return ShortName.GetShortenedName(Director());
            }
            else
            {
                return string.Empty;
            }
        }

        public string AreaToText(double Number)
        {
            return Num_To_Text.NumberToText(Convert.ToDouble(Number));
        }
        public string SumToText(double Sum)
        {
            return Num_To_Text.SumToText(Convert.ToDouble(Sum));
        }

        public async void GetData()
        {
            AgreementNumber = _context.D4
                .Where(e => e.Id == Id)
                .Select(x => x.DogovirSuborendu)
                .SingleOrDefault();

            Datetime = _context.D4
                .Where(e => e.Id == Id)
                .Select(x => x.DateTime)
                .SingleOrDefault();

            FullName = await _context.D1
            .Where(p => p.NameGroup == NameGroup)
            .Select(x => x.Fullname)
            .FirstOrDefaultAsync();

            Edryofop = await _context.D1
            .Where(p => p.NameGroup == GetNameGroupByNameberGroup())
            .Select(x => x.edryofop_Data)
            .FirstOrDefaultAsync();

            Rnokpp = await _context.D1
            .Where(p => p.NameGroup == GetNameGroupByNameberGroup())
            .Select(x => x.rnokpp)
            .FirstOrDefaultAsync();

            CounterpaertyAddress = await _context.D1
            .Where(p => p.NameGroup == NameGroup)
            .Select(x => x.address)
            .FirstOrDefaultAsync();

            BanckAccount = await _context.D1
            .Where(p => p.NameGroup == NameGroup)
            .Select(x => x.BanckAccount)
            .FirstOrDefaultAsync();

            DepartmentArea = await _context.D2
            .Where(p => p.NumberGroup == GetNumberGroupById())
            .Select(x => x.area)
            .FirstOrDefaultAsync();

            DepartmentAddress = await _context.D4
            .Where(p => p.NumberGroup == GetNumberGroupById())
            .Select(x => x.address)
            .FirstOrDefaultAsync();

            EndAktDate = await _context.D4
            .Where(p => p.NumberGroup == GetNumberGroupById())
            .Select(x => x.EndAktDate)
            .FirstOrDefaultAsync();

            _director = Director();

            _shortDirector = ShortDirector();

            SubleaseDopNum = await _context.D2
            .Where(p => p.NumberGroup == GetNumberGroupById())
            .Select(p => p.SubleaseDop.Num)
            .FirstOrDefaultAsync();

            subleaseDopDate = await _context.D2
                .Where(p => p.NumberGroup == GetNumberGroupById())
                .Select(p => p.SubleaseDop.Date)
            .FirstOrDefaultAsync();

            subleaseDopName = await _context.D2
            .Where(p => p.NumberGroup == GetNumberGroupById())
            .Select(p => p.SubleaseDop.Name)
            .FirstOrDefaultAsync();

            subleaseDopRnokppLastData = await _context.D2
            .Where(p => p.NumberGroup == GetNumberGroupById())
            .Select(p => p.SubleaseDop.rnokpp)
            .FirstOrDefaultAsync();

            subleaseDopstatus = await _context.D2
            .Where(p => p.NumberGroup == GetNumberGroupById())
             .Select(p => p.SubleaseDop.status)
            .FirstOrDefaultAsync();
        }

        public void GenerateWord()
        {
            //var b = WordHelper.AddTextToContentControl(path_dog,
            //               DogovirSuborendu,
            //               DateTime.ToString("dd/MM/yyyy"),
            //               relatedDataFullname,
            //               relatedDataedryofop_Data,
            //               relatedDataList.ToString(),
            //               relatedDataarea.ToString(),
            //               address,
            //               EndAktDate.ToString("dd/MM/yyyy"),
            //               relatedDataaddress,
            //               null,
            //               relatedDataBanckAccount,
            //               relatedDataPIBS,
            //               Num_To_Text.NumberToText(Convert.ToDouble(relatedDataarea)),
            //               Num_To_Text.SumToText(Convert.ToDouble(Suma)),
            //               Doublezero(Convert.ToDouble(Suma)),
            //               null,
            //               Director,
            //               PIBSDirector,
            //               subleaseDopNum ?? "____",
            //               subleaseDopDate?.ToString("dd/MM/yyyy") ?? "____",
            //               subleaseDopName ?? "____",
            //               subleaseDopRnokppLastData ?? "____",
            //               subleaseDopstatus ?? "____");
        }
    }
}
