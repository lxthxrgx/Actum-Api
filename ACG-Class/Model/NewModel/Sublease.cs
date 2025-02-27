using ACG_Class.Model.NewModel;

namespace ACG_Class.Model.NewModel
{
    public class Sublease
    {
        public int Id { get; set; }

        public int Id_Group { get; set; }
        public required Group Group { get; set; }

        public required string Address { get; set; }
        public required string DogovirSuborendu { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime EndAktDate { get; set; }
        public required string Suma { get; set; }
        public string? Suma2 { get; set; }
        public DateTime AktDate { get; set; }

        public ICollection<PDF_Sublease> PDF_Sublease { get; } = new List<PDF_Sublease>();

        public bool? Done { get; } = false;
    }

    public class PDF_Sublease
    {
        public int Id { get; set; }
        public int Id_Sublease { get; set; }
        public required Sublease Sublease { get; set; }
        public string? PathToPdfFile_Sublease { get; set; }

    }
}