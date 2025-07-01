using ACG_Api.model.XPath;
using ACG_Api.model.DTO.SubleaseWord.Fop;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ACG_Api.Controllers.AutoDocController.Sublease.fop
{
    [ApiController]
    [Route("api/[controller]")]
    public class sublease_fop_termination : ControllerBase
    {
        private readonly Func<string, XPath> _xPathFactory;
        private readonly SubleaseFopTermination _SubFopTerm;
        private readonly ILogger<sublease_fop_termination> _logger;

        public sublease_fop_termination(Func<string, XPath> xPathFactory, SubleaseFopTermination SubFopTerm, ILogger<sublease_fop_termination> logger)
        {
            _logger = logger;
            _xPathFactory = xPathFactory;
            _SubFopTerm = SubFopTerm;
        }


        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseFopTermination data)
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            _logger.LogInformation("User data: {UserData}", json);
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
    }
}