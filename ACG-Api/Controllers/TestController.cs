using Microsoft.AspNetCore.Mvc;
using ACG_Api.model;
using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;


namespace ACG_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Ping
    {
        [HttpGet]
        public string Get()
        {
            return "Pong";
        }
    }
}