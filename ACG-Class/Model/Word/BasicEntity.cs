using ACG_Class.Database;
using ACG_Class.Model.Class;
using Microsoft.EntityFrameworkCore;

namespace ACG_Class.Model.Word
{
    public abstract class BasicEntity
    {
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


    }
}
