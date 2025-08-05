using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.model.groups;

namespace Models.model.counterparty
{
    public class Counterparty
    {
        public int Id {get; set;}
        public int GroupId { get; set; }
        public required Groups GroupTable { get; set; }

        public string Fullname { get; private set; } = "Fullname";
        public  string ShortName {get; private set; }
        public  string Address {get; private set; }
        public  string Edryofop {get; private set; }
        public  string BanckAccount {get; private set; }
        public  string Director {get; private set; }
        public  string ShortNameDirector {get; private set; }
        public  string ResPerson {get; private set; }
        public  string Phone {get; private set;}
        public  string Email {get; private set; }
        public  string Status {get; private set; }
    }
}