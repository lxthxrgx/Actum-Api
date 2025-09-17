using ACG_Api.model.XPath;
using Microsoft.AspNetCore.Mvc;
using ACG_Api.service.AutoDocService.sublease.fop;
using System.Text.Json;
using ACG_Api.model.DTO.SubleaseWordReq.Fop;
using ACG_Api.components.ILogger;

namespace ACG_Api.Controllers.AutoDocController.Sublease.fop
{
    [ApiController]
    [Route("api/sublease/[controller]")]
    public class Fop : ControllerBase
    {
        private readonly Func<string, XPathProcessor> _xPathFactory;

        private readonly SubleaseFopReturnAct _SubFopReturn;
        private readonly SubleaseFopTermination _SubFopTerm;
        private readonly SubleaseFopDogAct _SubFopDog;

        private readonly ILogger<Fop> _logger;
        public Fop
        (
        Func<string, XPathProcessor> xPathFactory,
        SubleaseFopReturnAct SubFopReturn,
        SubleaseFopTermination SubFopTerm,
        SubleaseFopDogAct subFopDog,
        ILogger<Fop> logger
        )
        {
            _logger = logger;
            _xPathFactory = xPathFactory;

            _SubFopReturn = SubFopReturn;
            _SubFopTerm = SubFopTerm;
            _SubFopDog = subFopDog;
        }

        [HttpPost("ReturnAct")]
        public string GetTestXmlTree([FromBody]DTOSubleaseFopReturnAct data)
        {
            _logger.LogInformation("SubtovTerm: {UserData}", JsonUTF8.JsonOptions(data));
            try
            {
                _SubFopReturn.SubleaseFopReturnActCreate(data);
                return "Saved";
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка: {Message}", ex.Message);
                return ex.Message;
            }
        }

        [HttpPost("Termination")]
        public string GetTestXmlTree([FromBody]DTOSubleaseFopTermination data)
        {
            _logger.LogInformation("SubleaseFopTermination: {UserData}", JsonUTF8.JsonOptions(data));
            try
            {
                _SubFopTerm.SubleaseFopTerminationCreate(data);
                return "Saved";
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка: {Message}", ex.Message);
                return ex.Message;
            }
        }

        [HttpPost("ContractAct")]
        public string GetTestXmlTree([FromBody]DTOSubleaseFopDogAct data)
        {
            _logger.LogInformation("ContractAct: {UserData}", JsonUTF8.JsonOptions(data));
            try
            {
                _SubFopDog.SubleaseFopDogActCreate(data);
                return "Saved";
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка: {Message}", ex.Message);
                return ex.Message;
            }
        }
    }
}