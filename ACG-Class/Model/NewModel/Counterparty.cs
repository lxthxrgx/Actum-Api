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
        public Group Group { get; set; }

        public string Fullname {get; set;}
        public string Address {get; set;}
        public string Edryofop {get; set;}
        public string BanckAccount {get; set;}
        public string Director {get; set;}
        public string ResPerson {get; set;}
        public string Phone {get; set;}
        public string Email {get; set;}
        public string Status {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "";
        public bool IsDeleted { get; set; } = false;
        public DateTime DeleteTime { get; set; }
        public string DeletedBy { get; set; } = "";
    }
}