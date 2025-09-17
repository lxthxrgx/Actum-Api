using ACG_Api.model.XPath;
using ACG_Api.model.DTO.SubleaseWordReq.Tov;
using ACG_Api.service.AutoDocService.sublease.tov;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ACG_Api.components.ILogger;

namespace ACG_Api.Controllers.AutoDocController.tov
{
    [ApiController]
    [Route("api/sublease/[controller]")]
    public class AutoDocTov : ControllerBase
    {
        private readonly Func<string, XPathProcessor> _xPathFactory;

        private readonly SubleseTovDog _SubtovDog;
        private readonly SubleaseTovReturnAct _SubTovReturn;
        private readonly SubleaseTovTermination _SubtovTerm;

        private readonly ILogger<AutoDocTov> _logger;

        public AutoDocTov(
            Func<string, XPathProcessor> xPathFactory,
            SubleseTovDog subtovDog,
            ILogger<AutoDocTov> logger,
            SubleaseTovTermination SubtovTerm,
            SubleaseTovReturnAct SubTovReturn
            )
        {
            _logger = logger;
            _xPathFactory = xPathFactory;

            _SubtovDog = subtovDog;
            _SubTovReturn = SubTovReturn;
            _SubtovTerm = SubtovTerm;
        }

        [HttpPost("ContractAct")]
        public string GetTestXmlTree([FromBody]DTOSubleaseTovDog data)
        {
            _logger.LogInformation("ContractAct: {UserData}", JsonUTF8.JsonOptions(data));
            try
            {
                _SubtovDog.SubleseTovDogWord(data);
                return "Saved";
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка: {Message}", ex.Message);
                return ex.Message;
            }
        }

        [HttpPost("ReturnAct")]
        public string GetTestXmlTree([FromBody] DTOSubleaseTovreturnACt data)
        {
            _logger.LogInformation("ReturnAct: {UserData}", JsonUTF8.JsonOptions(data));
            try
            {
                _SubTovReturn.SubleaseTovReturnActCreate(data);
                return "Saved";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка: {Message}", ex.Message);
                return ex.Message;
            }
        }

        [HttpPost("Termination")]
        public string GetTestXmlTree([FromBody] DTOSubleaseTermination data)
        {
            _logger.LogInformation("Termination: {UserData}", JsonUTF8.JsonOptions(data));
            try
            {
                _SubtovTerm.SybleaseTovTerminationCreate(data);
                return "Saved";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка: {Message}", ex.Message);
                return ex.Message;
            }
        }
    }
}