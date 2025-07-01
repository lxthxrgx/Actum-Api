using ACG_Api.model.XPath;
using ACG_Api.model.DTO.SubleaseWord.Fop;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

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


        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseFopDogAct data)
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            _logger.LogInformation("User data: {UserData}", json);
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