using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACG_Class.Model.NewModel.General;

namespace ACG_Class.Model.NewModel
{
    public class Counterparty : IDelete, ICreate
    {
        public int Id {get; set;}

        public int Id_Group { get; set; }
        public required Group Group { get; set; }

        public required string Fullname {get; set;}
        public required string Address {get; set;}
        public required string Edryofop {get; set;}
        public required string BanckAccount {get; set;}
        public required string Director {get; set;}
        public required string ResPerson {get; set;}
        public required string Phone {get; set;}
        public required string Email {get; set;}
        public required string Status {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public required string CreatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DeleteTime { get; set; } = DateTime.UtcNow;
        public required string DeletedBy { get; set; }
    }
}