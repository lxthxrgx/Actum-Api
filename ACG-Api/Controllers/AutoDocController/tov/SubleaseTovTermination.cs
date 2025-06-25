using ACG_Api.model.XPath;
using Microsoft.AspNetCore.Mvc;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using ACG_Api.model.DTO;

namespace ACG_Api.Controllers.AutoDocController.tov
{
    [ApiController]
    [Route("api/[controller]")]
    public class subleasetovtermination : ControllerBase
    {
        private readonly Func<string, XPath> _xPathFactory;
        private readonly SubleaseTovTermination _SubtovTerm;
        private readonly ILogger<subleasedogtov> _logger;

        public subleasetovtermination(Func<string, XPath> xPathFactory, SubleaseTovTermination SubtovTerm, ILogger<subleasedogtov> logger){
            _logger = logger;
            _xPathFactory = xPathFactory;
            _SubtovTerm = SubtovTerm;
        }
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseTermination data)
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            _logger.LogInformation("User data SubtovTerm: {UserData}", json);
            try
            {
                _SubtovTerm.SybleaseTovTerminationCreate(data);
                return "Saved";
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка: {Message}", ex.Message);
                return ex.Message;
            }
        }
    }
}