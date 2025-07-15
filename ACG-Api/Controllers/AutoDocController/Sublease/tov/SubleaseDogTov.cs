using ACG_Api.model.XPath;
using ACG_Api.model.DTO.SubleaseWordReq.Tov;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ACG_Api.components.ILogger;

namespace ACG_Api.Controllers.AutoDocController.tov
{
    [ApiController]
    [Route("api/[controller]")]
    public class sublease_tov_dog_act : ControllerBase
    {
        private readonly Func<string, XPathProcessor> _xPathFactory;
        private readonly SubleseTovDog _SubtovDog;
        private readonly ILogger<sublease_tov_dog_act> _logger;

        public sublease_tov_dog_act(Func<string, XPathProcessor> xPathFactory, SubleseTovDog subtovDog, ILogger<sublease_tov_dog_act> logger)
        {
            _logger = logger;
            _xPathFactory = xPathFactory;
            _SubtovDog = subtovDog;
        }

        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseTovDog data)
        {
            _logger.LogInformation("User data: {UserData}", JsonUTF8.JsonOptions(data));
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
    }
}