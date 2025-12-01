using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.model.groups;

namespace Models.model.sublease
{
    public class Sublease
    {
        public int Id { get; set; }
        public int GroupId { get; private set; }
        public Group Group { get; private set; } = new Group();
        public string Address { get; private set; } = "Address";
        public string ContractNumber { get; private set; } = "ContractNumber";
        public DateTime ContractSigningDate { get; private set; }
        public DateTime AktDate { get; private set; }
        public DateTime ContractEndDate { get; private set; }
        public DateTime ContractEndDate2 { get; private set; }
        public double RentalFee { get; private set; }
        public double RentalFee2 { get; private set; }
        public bool? Done { get; set; } = false;

        public ICollection<PathToPDFFilesSublease> PathToPdfFiles_Sublease { get; } = new List<PathToPDFFilesSublease>();
        public ICollection<SubleaseNotes> SubleaseNotes { get; } = new List<SubleaseNotes>();
    }
}