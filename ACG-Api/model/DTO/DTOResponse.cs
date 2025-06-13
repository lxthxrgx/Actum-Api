using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACG_Api.model.DTO
{
    public class DTOResponse
    {
        int statusCode {get; set;}
        string message {get; set;} = "";
    }
}