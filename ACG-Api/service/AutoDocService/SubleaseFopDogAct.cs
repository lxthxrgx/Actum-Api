using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACG_Api.model.XPath;
using ACG_Api.model.DTO;

namespace ACG_Api.service.AutoDocService
{
    public class SubleaseFopDogAct
    {
        public void SubleaseFopDogActCreate(DTOSubleaseFopDogAct subleaseData)
        {
            XPath xpathSublease = new XPath("/home/ltx/Documents/Sublease.docx");
            xpathSublease.WriteXmlTree("ContractNumber", subleaseData.ContractNumber);
            xpathSublease.WriteXmlTree("CreationDate", subleaseData.CreationDate.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("PipSublessor", subleaseData.PipSublessor);
            xpathSublease.WriteXmlTree("PipsSublessor", subleaseData.PipsSublessor);
            xpathSublease.WriteXmlTree("rnokppSublessor", subleaseData.rnokppSublessor);
            xpathSublease.WriteXmlTree("Edruofop", subleaseData.Edruofop);
            xpathSublease.WriteXmlTree("addressSublessor", subleaseData.addressSublessor);
            xpathSublease.WriteXmlTree("RoomArea", subleaseData.RoomArea.ToString());
            xpathSublease.WriteXmlTree("RoomAreaText", subleaseData.RoomAreaText);
            xpathSublease.WriteXmlTree("RoomAreaAddress", subleaseData.RoomAreaAddress);
            xpathSublease.WriteXmlTree("subleaseDopContractNumber", subleaseData.subleaseDopContractNumber);
            xpathSublease.WriteXmlTree("subleaseDopStartDate", subleaseData.subleaseDopStartDate.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("subleaseDopName", subleaseData.subleaseDopName);
            xpathSublease.WriteXmlTree("subleaseDopRnokpp", subleaseData.subleaseDopRnokpp);
            xpathSublease.WriteXmlTree("StrokDii", subleaseData.EndContractData.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("Pricing", subleaseData.Pricing.ToString());
            xpathSublease.WriteXmlTree("PricingText", subleaseData.PricingText);
            xpathSublease.WriteXmlTree("BanckAccount", subleaseData.BanckAccount);
            
            xpathSublease.Save($"{subleaseData.NumberGroup} - {subleaseData.NameGroup} - договір");

            XPath xpathSublease2 = new XPath("/home/ltx/Documents/Sublease2.docx");
            xpathSublease2.WriteXmlTree("CreationDate", subleaseData.CreationDate.ToString("dd.MM.yyyy"));
            xpathSublease2.WriteXmlTree("PipSublessor", subleaseData.PipSublessor);
            xpathSublease2.WriteXmlTree("PipsSublessor", subleaseData.PipsSublessor);
            xpathSublease2.WriteXmlTree("rnokppSublessor", subleaseData.rnokppSublessor);
            xpathSublease.WriteXmlTree("Edruofop", subleaseData.Edruofop);
            xpathSublease2.WriteXmlTree("addressSublessor", subleaseData.addressSublessor);

            xpathSublease2.WriteXmlTree("subleaseDopContractNumber", subleaseData.subleaseDopContractNumber);
            xpathSublease2.WriteXmlTree("subleaseDopStartDate", subleaseData.subleaseDopStartDate.ToString("dd.MM.yyyy"));

            xpathSublease2.WriteXmlTree("RoomArea", subleaseData.RoomArea.ToString());
            xpathSublease2.WriteXmlTree("RoomAreaText", subleaseData.RoomAreaText);
            xpathSublease2.WriteXmlTree("RoomAreaAddress", subleaseData.RoomAreaAddress);
            xpathSublease2.WriteXmlTree("BanckAccount", subleaseData.BanckAccount);

            xpathSublease2.Save($"{subleaseData.NumberGroup} - {subleaseData.NameGroup} - акт");
        }
        
    }
}