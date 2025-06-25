using ACG_Api.model.XPath;
using ACG_Api.model.DTO;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ACG_Api.Controllers.AutoDocController.tov
{
    [ApiController]
    [Route("api/[controller]")]
    public class sublease_tov_dog_act : ControllerBase
    {
        private readonly Func<string, XPath> _xPathFactory;
        private readonly SubleseTovDog _SubtovDog;
        private readonly ILogger<sublease_tov_dog_act> _logger;

        public sublease_tov_dog_act(Func<string, XPath> xPathFactory, SubleseTovDog subtovDog, ILogger<sublease_tov_dog_act> logger)
        {
            _logger = logger;
            _xPathFactory = xPathFactory;
            _SubtovDog = subtovDog;
        }


        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseTovDog data)
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            _logger.LogInformation("User data: {UserData}", json);
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