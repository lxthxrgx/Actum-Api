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
    }
}