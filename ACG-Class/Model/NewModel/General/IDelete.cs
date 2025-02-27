using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACG_Class.Model.NewModel.General
{
    interface IDelete
    {
        bool IsDeleted { get; set; }
        DateTime DeleteTime { get; set; }
        string DeletedBy { get; set; }
    }
}
