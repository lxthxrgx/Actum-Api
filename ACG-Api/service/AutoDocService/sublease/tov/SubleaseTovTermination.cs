using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACG_Api.model.XPath;
using ACG_Api.model.DTO.SubleaseWordReq.Tov;
using ACG_Api.config;

namespace ACG_Api.service.AutoDocService.sublease.tov
{
    public class SubleaseTovTermination
    {
        public void SybleaseTovTerminationCreate(DTOSubleaseTermination subleaseData)
        {
            XPathProcessor xpathSublease = new XPathProcessor(ConfigHelper.Configuration["PathToTemplates:SubleaseTovTermination"]);
            xpathSublease.WriteXmlTree("ContractNumber", subleaseData.ContractNumber);
            xpathSublease.WriteXmlTree("CreationContractDate", subleaseData.CreationContractDate.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("CreationDate", subleaseData.CreationDate.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("PipSublessor", subleaseData.PipSublessor);
            xpathSublease.WriteXmlTree("rnokppSublessor", subleaseData.rnokppSublessor);
            xpathSublease.WriteXmlTree("addressSublessor", subleaseData.addressSublessor);
            xpathSublease.WriteXmlTree("PipDirector", subleaseData.PipDirector);
            xpathSublease.WriteXmlTree("PipsDirector", subleaseData.PipsDirector);
            xpathSublease.WriteXmlTree("EndContractData", subleaseData.EndContractData.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("RoomArea", subleaseData.RoomArea.ToString());
            xpathSublease.WriteXmlTree("RoomAreaText", subleaseData.RoomAreaText);
            xpathSublease.WriteXmlTree("RoomAreaAddress", subleaseData.RoomAreaAddress);
            xpathSublease.WriteXmlTree("BanckAccount", subleaseData.BanckAccount);
            xpathSublease.Save($"{subleaseData.NumberGroup}-{subleaseData.NameGroup}-припинення");
        }
    }
}