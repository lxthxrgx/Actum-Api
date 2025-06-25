using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACG_Api.model.DTO
{
    public class DTOSubleaseTovreturnACt
    {
        public int NumberGroup {get; set;}
        public string NameGroup {get; set;} = "NameGroup";
        public string ContractNumber {get; set;} = "ContractNumber";
        public DateTime CreationContractDate {get; set;}
        public DateTime CreationDate {get; set;}
        public string PipSublessor {get; set;} = "PipSublessor";
        public string rnokppSublessor {get; set;} = "rnokpp";
        public string addressSublessor {get; set;} = "addressSublessor";
        public string PipDirector {get; set;} = "PipDirector";
        public string PipsDirector {get; set;} = "PipsDirector";
        public float RoomArea {get; set;}
        public string RoomAreaText {get; set;} = "RoomAreaText";
        public string RoomAreaAddress {get; set;} = "RoomAreaAddress";
        public string BanckAccount {get; set;} = "BanckAccount";
    }
}