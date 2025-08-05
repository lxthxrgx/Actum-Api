using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.model.groups;

namespace Models.model.guard
{
    public class Guard
    {
         public int Id { get; private set; }
        public int GroupId { get; private set; }
        public Groups GroupTable {get; private set; }
        public string address { get; private set; }
        public string OhronnaComp { get; private set; }
        public string NumDog { get; private set; }
        public string NumDog2 { get; private set; }
        public DateTime StrokDii { get; private set; }
        public DateTime? StrokDii2 { get; private set; }
        public string? ResPerson { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }

        public ICollection<PathToFilesGuard> PathToFilesGuard { get; } = new List<PathToFilesGuard>();
    }
}