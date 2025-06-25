using Microsoft.AspNetCore.Mvc;
using ACG_Api.model;
using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;
using ACG_Api.model.XPath;
using ACG_Api.model.DTO;
using ACG_Api.service.AutoDocService;
using System.Text.Json;

namespace ACG_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Ping : ControllerBase
    {
        public Ping(){}

        [HttpGet]
        public string Get()
        {
            return "Pong";
        }
    }
}