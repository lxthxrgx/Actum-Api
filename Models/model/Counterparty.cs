using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.model
{
    public class Counterparty
    {
        public int Id {get; set;}
        public int GroupId { get; set; }
        public required Groups GroupTable { get; set; }

        public string Fullname { get; private set; } = "Fullname";
        public  string ShortName {get; private set; } = "ShortName";
        public  string Address {get; private set; } = "Address";
        public  string BanckAccount {get; private set; } = "BanckAccount";
        public  string Director {get; private set; } = "Director";
        public  string ShortNameDirector {get; private set; } = "ShortNameDirector";
        public  string ResPerson {get; private set; } = "ResPerson";
        public  string Phone {get; private set;} = "Phone";
        public  string Email {get; private set; } = "Email";
        public  string Status {get; private set; } = "Status";
    }

    public class CounterpartyFop : Counterparty
    {
        public  string Edryofop {get; private set; } = "Edryofop";
    }
        public class CounterpartyLLC : Counterparty
    {
        public  string Rnokpp {get; private set; } = "Rnokpp";
    }
}