using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACG_Class.Model.NewClass
{
    interface ID1
    {
        string NameGroup {get; set;}
    }

    public class _1D : ID1
    {
        public int Id {get; set;}

        public ICollection<_2D> NumberGroup { get; } = new List<_2D>();
        public string NameGroup {get; set;}

        public string Fullname {get; set;}
        public string Address {get; set;}
        public string Edryofop {get; set;}
        public string BanckAccount {get; set;}
        public string Director {get; set;}
        public string ResPerson {get; set;}
        public string Phone {get; set;}
        public string Email {get; set;}
        public string Status {get; set;}
    }
}