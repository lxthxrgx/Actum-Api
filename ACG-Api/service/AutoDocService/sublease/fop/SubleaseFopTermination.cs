using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actum_Api.model.DTO.SubleaseWordReq.Fop;
using Actum_Api.model.XPath;
using Actum_Api.config;

namespace Actum_Api.service.AutoDocService.sublease.fop
{
    public class SubleaseFopTermination
    {
        public void SubleaseFopTerminationCreate(DTOSubleaseFopTermination subleaseData)
        {
            XPathProcessor xpathSublease = new XPathProcessor(ConfigHelper.Configuration["PathToTemplates:SubleaseFopTermination"]);
            xpathSublease.WriteXmlTree("ContractNumber", subleaseData.ContractNumber);
            xpathSublease.WriteXmlTree("CreationContractDate", subleaseData.CreationContractDate.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("CreationDate", subleaseData.CreationDate.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("PipSublessor", subleaseData.PipSublessor);
            xpathSublease.WriteXmlTree("PipsSublessor", subleaseData.PipSublessor);
            xpathSublease.WriteXmlTree("rnokppSublessor", subleaseData.rnokppSublessor);
            xpathSublease.WriteXmlTree("Edruofop", subleaseData.Edruofop);
            xpathSublease.WriteXmlTree("addressSublessor", subleaseData.addressSublessor);

            xpathSublease.WriteXmlTree("EndContractData", subleaseData.EndContractData.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("RoomArea", subleaseData.RoomArea.ToString());
            xpathSublease.WriteXmlTree("RoomAreaText", subleaseData.RoomAreaText);
            xpathSublease.WriteXmlTree("RoomAreaAddress", subleaseData.RoomAreaAddress);
            xpathSublease.WriteXmlTree("BanckAccount", subleaseData.BanckAccount);
            xpathSublease.Save($"{subleaseData.NumberGroup}-{subleaseData.NameGroup}-припинення");
        }
    }
}