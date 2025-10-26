using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actum_Api.model.DTO.SubleaseWordReq.Tov
{
    public class DTOSubleaseTermination
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
        public DateTime EndContractData {get; set;}
        public float RoomArea {get; set;}
        public string RoomAreaText {get; set;} = "RoomAreaText";
        public string RoomAreaAddress {get; set;} = "RoomAreaAddress";
        public string BanckAccount {get; set;} = "BanckAccount";
    }
}