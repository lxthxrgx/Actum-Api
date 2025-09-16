using Microsoft.AspNetCore.Mvc;
using ACG_Api.model.XPath;

namespace ACG_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Ping : ControllerBase
    {
        public Ping() { }

        [HttpGet]
        public string Get()
        {
            return "Pong";
        }

        [HttpGet("GetNumInName")]
        public void GetNumInName(){
            CheckFolder checkFolder = new CheckFolder();
            checkFolder.CheckFiles("/home/ltx/Documents/DOCX-Work/1test.docx");
        }
    }
}