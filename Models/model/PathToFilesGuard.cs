using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.model
{
    public class PathToFilesGuard
    {
         public int Id { get; set; }
        public int GuardId { get; set; }
        public Guard GuardTable { get; set; } = new Guard();
        public string PathToServerFiles { get; set; } = "PathToServerFiles";
        public DateTime CheckTime { get; set; }
    }
}