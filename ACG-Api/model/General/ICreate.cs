﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actum_Api.model.General
{
    interface ICreate
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
    }
}
