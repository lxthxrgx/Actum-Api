using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACG_Class.Model.NewClass
{
    interface I2D
    {
        int Id { get; set; }
        int NumberGroup { get; set; }
    }

    interface I2DOtherInfo
    {
        string? Pibs { get; set; }
        string Address { get; set; }
        double? Area { get; set; }
        bool? isAlert { get; set; }
        DateTime? DateCloseDepartment { get; set; }
    }


    public class _2D : I2D, I2DOtherInfo
    {
        public int Id { get; set; }
        public int NumberGroup { get; set; }

        public int Id_D1 {get; set;}
        public _1D D1 {get; set;}

        public string? Pibs { get; set; }
        public string Address { get; set; }
        public double? Area { get; set; }
        public bool? isAlert { get; set; } = false;
        public DateTime? DateCloseDepartment { get; set; }
    }
}
