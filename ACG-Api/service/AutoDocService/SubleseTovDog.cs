using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACG_Api.model.DTO;
using ACG_Api.model.XPath;

namespace ACG_Api.service.AutoDocService
{
    public class SubleseTovDog
    {
        public void SubleseTovDogWord(DTOSubleaseTovDog subleaseData)
        {
            XPath xpath = new XPath();
            xpath.WriteXmlTree("ContractNumber", subleaseData.ContractNumber);
            xpath.WriteXmlTree("CreationDate", subleaseData.CreationDate.ToString("dd.mm.yyyy"));
            xpath.WriteXmlTree("PipSublessor", subleaseData.PipSublessor);
            xpath.WriteXmlTree("rnokppSublessor", subleaseData.rnokppSublessor);
            xpath.WriteXmlTree("addressSublessor", subleaseData.addressSublessor);
            xpath.WriteXmlTree("PipDirector", subleaseData.PipDirector);
            xpath.WriteXmlTree("PipsDirector", subleaseData.PipsDirector);
            xpath.WriteXmlTree("RoomArea", subleaseData.RoomArea.ToString());
            xpath.WriteXmlTree("RoomAreaText", subleaseData.RoomAreaText);
            xpath.WriteXmlTree("RoomAreaAddress", subleaseData.RoomAreaAddress);
            xpath.WriteXmlTree("subleaseDopContractNumber", subleaseData.subleaseDopContractNumber);
            xpath.WriteXmlTree("subleaseDopStartDate", subleaseData.subleaseDopStartDate.ToString("dd.mm.yyyy"));
            xpath.WriteXmlTree("subleaseDopName", subleaseData.subleaseDopName);
            xpath.WriteXmlTree("subleaseDopRnokpp", subleaseData.subleaseDopRnokpp);
            xpath.WriteXmlTree("StrokDii", subleaseData.StrokDii.ToString("dd.mm.yyyy"));
            xpath.WriteXmlTree("Pricing", subleaseData.Pricing.ToString());
            xpath.WriteXmlTree("PricingText", subleaseData.PricingText);
            xpath.WriteXmlTree("BanckAccount", subleaseData.BanckAccount);
            xpath.Save();
        }
    }
}