using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Groups
    {
        public int Id { get; private set; }
        public int NumberGroup {get; private set;}
        public string NameGroup { get; private set; } = "NameGroup";
        public string Address { get; private set; } = "Адреса";
        public double? Area { get; private set; } = 1.0;
        public bool? isAlert { get; private set; } = false;
        public DateTime? DateCloseDepartment { get; private set; } = DateTime.MinValue;
        public ICollection<Counterparty> Counterparty { get; private set; } = new List<Counterparty>();
        public ICollection<Guard> Guard { get; private set; } = new List<Guard>();
        public ICollection<Sublease> Sublease { get; private set; } = new List<Sublease>();
    }
}