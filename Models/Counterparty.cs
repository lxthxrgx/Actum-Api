using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Counterparty
    {
        public int Id {get; set;}
        public int GroupId { get; set; }
        public required Group Group { get; set; }

        public required string Fullname {get; set;}
        public required string ShortName {get; set;}
        public required string Address {get; set;}
        public required string Edryofop {get; set;}
        public required string BanckAccount {get; set;}
        public required string Director {get; set;}
        public required string ShortNameDirector {get; set;}
        public required string ResPerson {get; set;}
        public required string Phone {get; set;}
        public required string Email {get; set;}
        public required string Status {get; set;}
    }
}