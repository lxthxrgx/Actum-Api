using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACG_Api.model.XPath;
using ACG_Api.model.DTO.SubleaseWordReq.Fop;
using ACG_Api.config;

namespace ACG_Api.service.AutoDocService.sublease.fop
{
    public class SubleaseFopReturnAct
    {
        public void SubleaseFopReturnActCreate(DTOSubleaseFopReturnAct subleaseData)
        {
            XPathProcessor xpathSublease = new XPathProcessor(ConfigHelper.Configuration["PathToTemplates:SubleaseFopReturnAct"]);
            xpathSublease.WriteXmlTree("ContractNumber", subleaseData.ContractNumber);
            xpathSublease.WriteXmlTree("CreationContractDate", subleaseData.CreationContractDate.ToString("dd.MM.yyyy"));
            xpathSublease.WriteXmlTree("CreationDate", subleaseData.CreationDate.ToString("dd.MM.yyyy"));

            xpathSublease.WriteXmlTree("PipSublessor", subleaseData.PipSublessor);
            xpathSublease.WriteXmlTree("PipsSublessor", subleaseData.PipsSublessor);
            xpathSublease.WriteXmlTree("rnokppSublessor", subleaseData.rnokppSublessor);
            xpathSublease.WriteXmlTree("Edruofop", subleaseData.Edruofop);
            xpathSublease.WriteXmlTree("addressSublessor", subleaseData.addressSublessor);

            xpathSublease.WriteXmlTree("RoomArea", subleaseData.RoomArea.ToString());
            xpathSublease.WriteXmlTree("RoomAreaText", subleaseData.RoomAreaText);
            xpathSublease.WriteXmlTree("RoomAreaAddress", subleaseData.RoomAreaAddress);
            xpathSublease.WriteXmlTree("BanckAccount", subleaseData.BanckAccount);

            xpathSublease.Save($"{subleaseData.NumberGroup}-{subleaseData.NameGroup}-повернення");
        }
    }
}