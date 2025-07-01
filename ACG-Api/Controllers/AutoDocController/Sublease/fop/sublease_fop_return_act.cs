using ACG_Api.model.XPath;
using Microsoft.AspNetCore.Mvc;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using ACG_Api.model.DTO.SubleaseWord.Fop;

namespace ACG_Api.Controllers.AutoDocController.Sublease.fop
{
    [ApiController]
    [Route("api/[controller]")]
    public class sublease_fop_return_act : ControllerBase
    {
        private readonly Func<string, XPath> _xPathFactory;
        private readonly SubleaseFopReturnAct _SubFopReturn;
        private readonly ILogger<sublease_fop_return_act> _logger;
        public sublease_fop_return_act(Func<string, XPath> xPathFactory, SubleaseFopReturnAct SubFopReturn, ILogger<sublease_fop_return_act> logger){
            _logger = logger;
            _xPathFactory = xPathFactory;
            _SubFopReturn = SubFopReturn;
        }

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseFopReturnAct data)
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            _logger.LogInformation("User data SubtovTerm: {UserData}", json);
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
    }
}