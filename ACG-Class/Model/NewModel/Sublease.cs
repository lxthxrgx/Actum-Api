using ACG_Class.Model.NewModel;

namespace ACG_Class.Model.NewModel
{
    public class Sublease
    {
        public int Id { get; set; }

        public int Id_Group { get; set; }
        public Group Group { get; set; }

        public string address { get; set; }
        public string DogovirSuborendu { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime EndAktDate { get; set; }
        public string Suma { get; set; }
        public string? Suma2 { get; set; }
        public DateTime AktDate { get; set; }

        public ICollection<PDF_Sublease> PDF_Sublease { get; } = new List<PDF_Sublease>();

        public bool? Done { get; } = false;
    }

    public class PDF_Sublease
    {
        public int Id { get; set; }
        public int Id_Sublease { get; set; }
        public Sublease Sublease { get; set; }
        public string? PathToPdfFile_Sublease { get; set; }

    }
}