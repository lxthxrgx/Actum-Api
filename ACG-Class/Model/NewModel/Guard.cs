using ACG_Class.Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACG_Class.Model.NewModel.General;

namespace ACG_Class.Model.NewModel
{
    public class Guard : IDelete, ICreate
    {
        public int Id { get; set; }
        public int Id_Group { get; set; }
        public required Group Group { get; set; }
        public required string Address { get; set; }
        public required string OhronnaComp { get; set; }
        public required string NumDog { get; set; }
        public string? NumDog2 { get; set; }
        public DateTime StrokDii { get; set; }
        public DateTime? StrokDii2 { get; set; }
        public string? ResPerson { get; set; }
        public string? Phone { get; set; }

        public ICollection<PDF_Guard> PDF_Guard { get; } = new List<PDF_Guard>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "";
        public bool IsDeleted { get; set; } = false;
        public DateTime DeleteTime { get; set; }
        public string DeletedBy { get; set; } = "";
    }

    public class PDF_Guard
    {
        public int Id { get; set; }

        public int Id_Guard { get; set; }
        public required Guard Guard { get; set; }
        public string? PathTOServerFiles { get; set; }
    }
}
