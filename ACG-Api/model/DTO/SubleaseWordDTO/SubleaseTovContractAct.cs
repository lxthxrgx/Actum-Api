using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACG_Api.model.XPath;

namespace ACG_Api.model.DTO.SubleaseWordDTO
{
    public class SubleaseTovContractActDTO<T>
    {
        public void XmlAddTextByClass(T DataToAdd, string Path)
        {
            List<object> dataStorage = new List<object>();
            if(DataToAdd != null)
            {
                dataStorage.Add(DataToAdd);
            }

            XPathProcessor xpathSublease = new XPathProcessor("/home/ltx/Documents/Sublease-Fop/SubleaseDogFop.docx");

        }
    }
}