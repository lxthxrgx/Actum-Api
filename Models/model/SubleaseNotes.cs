using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.model
{
    public class SubleaseNotes
    {
        public int Id { get; private set; }
        public int SubleaseId { get; private set; }
        public Sublease SubleaseTable { get; private set; } = new Sublease();
        public string? PathToPdfFile_Sublease { get; private set; }
    }
}