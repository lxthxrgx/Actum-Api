using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACG_Api.model.General
{
    interface IDelete
    {
        bool IsDeleted { get; set; }
        DateTime DeleteTime { get; set; }
        string DeletedBy { get; set; }
    }
}
