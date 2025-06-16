using Microsoft.AspNetCore.Mvc;
using ACG_Api.model;
using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;
using ACG_Api.model.XPath;
using ACG_Api.model.DTO;
using ACG_Api.service.AutoDocService;

namespace ACG_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Ping
    {
        private readonly XPath _xpath;
        private readonly SubleseTovDog _SubtovDog;

        public Ping(XPath xPath, SubleseTovDog SubtovDog)
        {
            _xpath = xPath;
            _SubtovDog = SubtovDog;
        }

        [HttpGet]
        public string Get()
        {
            return "Pong";
        }

        [HttpPost("TestTree")]
        public string GetTestXmlTree([FromBody]DTOSubleaseTovDog data)
        {
            Console.WriteLine(data.ContractNumber);
            Console.WriteLine(data.CreationDate);
            Console.WriteLine(data.PipSublessor);
            Console.WriteLine(data.rnokppSublessor);
            Console.WriteLine(data.addressSublessor);
            Console.WriteLine(data.PipDirector);
            Console.WriteLine(data.PipsDirector);
            Console.WriteLine(data.RoomArea);
            Console.WriteLine(data.RoomAreaText);
            Console.WriteLine(data.RoomAreaAddress);
            Console.WriteLine(data.subleaseDopContractNumber);
            Console.WriteLine(data.subleaseDopStartDate);
            Console.WriteLine(data.subleaseDopName);
            Console.WriteLine(data.subleaseDopRnokpp);
            Console.WriteLine(data.StrokDii);
            Console.WriteLine(data.Pricing);
            Console.WriteLine(data.PricingText);
            Console.WriteLine(data.BanckAccount);
            try
            {
                _SubtovDog.SubleseTovDogWord(data);
                return "Saved";
            }catch(Exception ex)
            {
                Console.Write(ex.Message);
                return ex.Message;
            }
           

        }
    }

    
}