using Microsoft.AspNetCore.Mvc;
using ACG_Api.model;
using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;
using ACG_Api.model.XPath;


namespace ACG_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Ping
    {
        private readonly XPath _xpath;

        public Ping(XPath xPath)
        {
            _xpath = xPath;
        }

        [HttpGet]
        public string Get()
        {
            return "Pong";
        }

        [HttpGet("TestTree")]
        public string GetTestXmlTree()
        {
            return _xpath.GetXmlTree();
        }
    }

    
}