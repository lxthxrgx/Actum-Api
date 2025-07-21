using ACG_Api.model.XPath;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACG_Api.service.AutoDocService.GetTree
{
    [Route("api/[controller]")]
    [ApiController]
    public class gettree : ControllerBase
    {
        public gettree() { }

        [HttpGet]
        public IActionResult GetXmlTree()
        {
            XPathProcessor xPath = new XPathProcessor("C:\\Users\\wetqw\\Desktop\\1_Дог_ суборенда_ТОВ.docx");
            xPath.TestXmlTreeLinq();
            return (StatusCode(200, ""));
        }
    }
}
