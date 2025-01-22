using ACG_Class.Database;
using Microsoft.EntityFrameworkCore;
using ACG_Class.Model.Word.AdditionalCode;
using ACG_Class.Model.Class;
using System.IO;
using System;

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

        string GetDataCounterpartyTov();
    }

    interface IGroupsTov
    { 
        double? Area { get; set; }
        string NameGroup { get; set; }
        string DepartmentAddress { get; set; }
        string GetDataGroupsTov();
    }

    interface ISubleaseTov
    {
        int NumberGroup { get; set; }
        DateTime AktDate { get; set; }
        DateTime EndAktDate { get; set; }
        DateTime DateTime { get; set; }
        string AgreementContract { get; set; }
        double Sum { get; set; }
        string GetDataSubleaseTov();
    }

    interface ISubleaseDop
    {
        string SubleaseDopNum { get; set; }
        DateTime? subleaseDopDate { get; set; }
        string subleaseDopName { get; set; }
        string subleaseDopRnokppLastData { get; set; }
        string subleaseDopstatus { get; set; }
        string GetDataSubleaseDopTov();
    }

    public class Tov : BasicEntity, IGroupsTov, ISubleaseTov,ICounterpartyTov, ISubleaseDop
    {
        public int Id { get; set; }
        private readonly DataBaseContext _context;
        public Tov(int id, DataBaseContext context)
        {
            Id = id;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            GetNumberGroup();
            GetNameGroup();
        }
        public string FullName { get; set; }
        public string Rnokpp { get; set; }
        public string Edryofop { get; set; }
        public string BanckAccount { get; set; }
        public string Address { get; set; }
        public string Director { get; set; }
        public string ShortDirector { get; set; }

        public double? Area { get; set; }
        public string NameGroup { get; set; }
        public string DepartmentAddress { get; set; }

        public int NumberGroup { get; set; }
        public DateTime AktDate { get; set; }
        public DateTime EndAktDate { get; set; }
        public DateTime DateTime { get; set; }
        public string AgreementContract { get; set; }
        public double Sum { get; set; }

        public string SubleaseDopNum { get; set; }
        public DateTime? subleaseDopDate { get; set; }
        public string subleaseDopName { get; set; }
        public string subleaseDopRnokppLastData { get; set; }
        public string subleaseDopstatus { get; set; }

        public override int GetNumberGroup()
        {
            var GetNumberGroup = _context.D4.Where(x => x.Id == Id).Select(e => e.NumberGroup).SingleOrDefault();
            if (GetNumberGroup != 0)
            {
                NumberGroup = GetNumberGroup;
                return NumberGroup;
            }
            else
            {
                return GetNumberGroup;
            }
        }

        public override string GetNameGroup()
        {
            if (NumberGroup == 0)
            {
                return "Invalid NumberGroup";
            }

            var GetNameGroup = _context.D2
           .Where(e => e.NumberGroup == NumberGroup)
           .Select(x => x.NameGroup)
           .FirstOrDefault();

            if (!string.IsNullOrEmpty(GetNameGroup))
            {
                NameGroup = GetNameGroup;
                return NameGroup;
            }
            else
            {
                return "No NameGroup found.";
            }
        }

        public string GetDataCounterpartyTov()
        {
            var counterpartyData = _context.D1
            .Where(p => p.NameGroup == NameGroup)
            .Select(p => new
            {
                p.Fullname,
                p.rnokpp,
                p.edryofop_Data,
                p.BanckAccount,
                p.address,
                p.Director
            })
            .FirstOrDefault();

            if (counterpartyData == null)
                return "Counterparty data not found.";

            FullName = counterpartyData.Fullname;
            Rnokpp = counterpartyData.rnokpp;
            Edryofop = counterpartyData.edryofop_Data;
            BanckAccount = counterpartyData.BanckAccount;
            Address = counterpartyData.address;
            Director = counterpartyData.Director;
            ShortDirector = ShortName.GetShortenedName(Director);

            if (FullName == null || Rnokpp == null || Edryofop == null || BanckAccount == null 
               || Address == null || Director == null || ShortDirector == null )
            {
                return $"FullName: {FullName}, Rnokpp: {Rnokpp}, Edryofop: {Edryofop}, BanckAccount: {BanckAccount}" +
                       $", Address: {Address}, Director: {Director}, ShortDirector: {ShortDirector}";
            }

            return "Data retrieved successfully.";
        }

        public string GetDataGroupsTov()
        {
            var GroupData = _context.D2.Where(x=>x.NumberGroup == NumberGroup)
                .Select(a => new
                {
                    a.area,
                    a.address
                })
                .FirstOrDefault();

            if (GroupData == null)
            {
                return "GroupData data not found.";
            }

            Area = GroupData.area;
            DepartmentAddress = GroupData.address;

            if(Area == 0 || string.IsNullOrEmpty(DepartmentAddress))
            {
                return $"Area: {Area}, Department Address: {DepartmentAddress}";
            }

            return "Data retrieved successfully.";
        }

        public string GetDataSubleaseTov()
        {
            var DataSublease = _context.D4.Where(e => e.Id == Id)
                .Select(d => new { d.AktDate, d.EndAktDate, d.DateTime, d.DogovirSuborendu, d.Suma }).FirstOrDefault();

            if (DataSublease == null)
            {
                return "DataSublease data not found.";
            }

            AktDate = DataSublease.AktDate;
            EndAktDate = DataSublease.EndAktDate;
            DateTime = DataSublease.DateTime;
            AgreementContract = DataSublease.DogovirSuborendu;
            Sum = Convert.ToDouble(DataSublease.Suma);

            if(AktDate == null || EndAktDate == null || DateTime == null || string.IsNullOrEmpty(AgreementContract) || Sum == 0) 
            {
                return $"AktDate: {AktDate}, EndAktDate: {EndAktDate},DateTime: {DateTime},AgreementContract: {AgreementContract},Sum: {Sum},";
            }

            return "Data retrieved successfully.";
        }

        public string GetDataSubleaseDopTov()
        {
            var SubleaseDopData = _context.D2.Where(e => e.NumberGroup == NumberGroup)
                .Select(d => new {
                    d.SubleaseDop.Num,
                    d.SubleaseDop.Date,
                    d.SubleaseDop.Name,
                    d.SubleaseDop.rnokpp,
                    d.SubleaseDop.status,
                }).FirstOrDefault();

            if (SubleaseDopData == null)
            {
                return "SubleaseDopData data not found.";
            }

            SubleaseDopNum = SubleaseDopData.Num;
            subleaseDopDate = SubleaseDopData.Date;
            subleaseDopName = SubleaseDopData.Name;
            subleaseDopRnokppLastData = SubleaseDopData.rnokpp;
            subleaseDopstatus = SubleaseDopData.status;

            if(string.IsNullOrEmpty(SubleaseDopNum) || subleaseDopDate == null || string.IsNullOrEmpty(subleaseDopName)
            || string.IsNullOrEmpty(subleaseDopRnokppLastData) || string.IsNullOrEmpty(subleaseDopstatus))
            {
                return $"SubleaseDopNum: {SubleaseDopNum}, subleaseDopDate: {subleaseDopDate},subleaseDopName: {subleaseDopName}," +
                       $"subleaseDopRnokppLastData: {subleaseDopRnokppLastData},subleaseDopstatus: {subleaseDopstatus},";
            }

            return "Data retrieved successfully.";
        }

        public virtual void PrintData()
        {
            Console.WriteLine(FullName);
            Console.WriteLine(Rnokpp);
            Console.WriteLine(Edryofop);
            Console.WriteLine(BanckAccount);
            Console.WriteLine(Address);
            Console.WriteLine(Director);
            Console.WriteLine(ShortDirector);
            Console.WriteLine(Area);
            Console.WriteLine(NameGroup);
            Console.WriteLine(DepartmentAddress);
            Console.WriteLine(NumberGroup);
            Console.WriteLine(AktDate);
            Console.WriteLine(EndAktDate);
            Console.WriteLine(DateTime);
            Console.WriteLine(AgreementContract);
            Console.WriteLine(Sum);
            Console.WriteLine(SubleaseDopNum);
            Console.WriteLine(subleaseDopDate);
            Console.WriteLine(subleaseDopName);
            Console.WriteLine(subleaseDopRnokppLastData);
            Console.WriteLine(subleaseDopstatus);
        }
        public override void GenerateWordDocument()
        {
            
        }
    }
}
