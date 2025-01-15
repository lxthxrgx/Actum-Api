using ACG_Class.Database;
using ACG_Class.Model.Class;
using Microsoft.EntityFrameworkCore;

namespace ACG_Api.Controllers.WordFileGeneration
{
    public interface ICounterparty
    {
        public string NameGroup { get; set; } // 
        public string Fullname { get; set; } // 
        public string rnokpp { get; set; } //
        public string address_counterparty { get; set; } // 
        public string edryofop_Data { get; set; } //
        public string BanckAccount { get; set; } // 
        public string? Director { get; set; } //
        public string? Status_Counterparty { get; set; }
    }

    public interface IGroup
    {
        public int NumberGroup { get; set; }
        public string NameGroup { get; set; } //
        public string? PIBS { get; set; } //
        public string address_department { get; set; } //
        public double? area { get; set; } // 
        //public int? SubleaseDopId { get; set; }
        //public SubleaseDop? SubleaseDop { get; set; }
    }

    public interface ISublease
    {
        public string DogovirSuborendu { get; set; } // 
        public DateTime DateTime { get; set; } //
        public DateTime EndAktDate { get; set; } //
        public string Suma { get; set; } //
        public DateTime AktDate { get; set; } //

        //public ICollection<PdfFilePath_Sublease> PathToPdfFiles_Sublease { get; } = new List<PdfFilePath_Sublease>();

        //public bool? Done { get; set; }

    }

    public interface ISubleaseDate
    {
        
    }

    public abstract class BasicEntity
    {
        private readonly DataBaseContext _context;
        public BasicEntity(DataBaseContext context)
        {
            _context = context;
        }
        public BasicEntity() { }
        public BasicEntity(int Id)
        {
            this.Id = Id;
        }

        public int Id;
        public int NumberGroup { get; set; }
        public string NameGroup { get; set; }
        public string Fullname { get; set; }
        public string rnokpp { get; set; } 
        public string address_counterparty { get; set; } 
        public string edryofop_Data { get; set; }
        public string BanckAccount { get; set; }
        public string? Director { get; set; }
        public string? Status_Counterparty { get; set; }
        public string? PIBS { get; set; }
        public string address_department { get; set; } 
        public double? area { get; set; }
        public string DogovirSuborendu { get; set; } 
        public DateTime DateTime { get; set; }
        public DateTime EndAktDate { get; set; }
        public string Suma { get; set; }
        public DateTime AktDate { get; set; }

        //public int GetNumberGroup()
        //{
        //    return _context.D4.Where(a => a.Id == Id).Select(x => x.NumberGroup).Distinct().SingleOrDefault();
        //}

        //public async Task<string> GetNameGroup()
        //{
        //    return await _context.D2.Where(x => x.NumberGroup == GetNumberGroup()).Select(e => e.NameGroup).FirstOrDefaultAsync();
        //}

        //public async void GetDataForCounterparty(int id)
        //{
        //    //int GetNumberGroupByIdGroups = await _context.D4.Where(a => a.Id == id).Select(x => x.NumberGroup).Distinct().SingleOrDefaultAsync();
        //    //string GetNamebyIdGroups = await _context.D2.Where(x => x.NumberGroup == GetNumberGroupByIdGroups).Select(e => e.NameGroup).FirstOrDefaultAsync();

        //    //NumberGroup = GetNumberGroupByIdGroups;
        //    //NameGroup = GetNamebyIdGroups;



        //}
        
        //public void NormalizationData()
        //{

        //}
    }
}
