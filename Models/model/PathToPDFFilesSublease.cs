using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.model
{
    public class PathToPDFFilesSublease
    {
         public int Id { get; set; }
        public int SubleaseId { get; set; }
        public Sublease SubleaseTable { get; set; } = new Sublease();
        public string PathToPdfFile { get; set; } = "PathToPdfFile_Sublease";
    }
}