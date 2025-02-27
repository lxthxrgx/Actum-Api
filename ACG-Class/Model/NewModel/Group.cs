using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACG_Class.Model.NewModel.General;

namespace ACG_Class.Model.NewModel
{
    interface I2D
    {
        int Id { get; set; }
        int NumberGroup { get; set; }
        string NameGroup { get; set; }
    }

    interface I2DOtherInfo
    {
        string? Pibs { get; set; }
        string Address { get; set; }
        double? Area { get; set; }
        bool? isAlert { get; set; }
        DateTime? DateCloseDepartment { get; set; }
    }


    public class Group : I2D, I2DOtherInfo, IDelete, ICreate
    {
        public int Id { get; set; }
        public int NumberGroup { get; set; }
        public string NameGroup { get; set; }
        public string? Pibs { get; set; }
        public string Address { get; set; }
        public double? Area { get; set; }
        public bool? isAlert { get; set; } = false;
        public DateTime? DateCloseDepartment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "";
        public bool IsDeleted { get; set; } = false;
        public DateTime DeleteTime { get; set; }
        public string DeletedBy { get; set; } = "";

        public ICollection<Counterparty> Counterparty { get; } = new List<Counterparty>();
        public ICollection<Guard> Guard { get; } = new List<Guard>();
    }
}
