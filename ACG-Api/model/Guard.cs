using System.Data;
using System.Text.RegularExpressions;
using ACG_Api.model.General;

namespace ACG_Api.model
{
    public interface IGuard
    {

    }

    public class Guard
    {
        public int Id {get; set;}
        public int Id_Group { get; set; }
        public required Group Group {get; set;}

        public string Address {get; set;} = "Адреса";
        public string SecurityCompany {get; set;} = "Охоронна компанія";
        public string Contacts {get; set;} = "Контакти";
    }
}