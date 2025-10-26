using Microsoft.AspNetCore.Mvc;
using Actum_Api.model.XPath;

namespace Actum_Api.Controllers
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