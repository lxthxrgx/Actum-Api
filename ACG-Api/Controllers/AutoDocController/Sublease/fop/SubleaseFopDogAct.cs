using ACG_Api.model.XPath;
using ACG_Api.model.DTO.SubleaseWord.Fop;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ACG_Api.components.ILogger;

namespace ACG_Api.Controllers.AutoDocController.Sublease.fop
{
    [ApiController]
    [Route("api/[controller]")]
    public class sublease_fop_dog_act : ControllerBase
    {
        private readonly Func<string, XPath> _xPathFactory;
        private readonly SubleaseFopDogAct _SubFopDog;
        private readonly ILogger<sublease_fop_dog_act> _logger;

        public sublease_fop_dog_act(Func<string, XPath> xPathFactory, SubleaseFopDogAct subFopDog, ILogger<sublease_fop_dog_act> logger)
        {
            _logger = logger;
            _xPathFactory = xPathFactory;
            _SubFopDog = subFopDog;
        }

        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseFopDogAct data)
        {
            _logger.LogInformation("User data: {UserData}", JsonUTF8.JsonOptions(data));
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