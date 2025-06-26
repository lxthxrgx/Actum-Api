using ACG_Api.model.XPath;
using Microsoft.AspNetCore.Mvc;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using ACG_Api.model.DTO;

namespace ACG_Api.Controllers.AutoDocController.tov
{
    [ApiController]
    [Route("api/[controller]")]
    public class sublease_tov_return_act : ControllerBase
    {
        private readonly Func<string, XPath> _xPathFactory;
        private readonly SubleaseTovReturnAct _SubTovReturn;
        private readonly ILogger<sublease_tov_return_act> _logger;
        public sublease_tov_return_act(Func<string, XPath> xPathFactory, SubleaseTovReturnAct SubTovReturn, ILogger<sublease_tov_return_act> logger){
            _logger = logger;
            _xPathFactory = xPathFactory;
            _SubTovReturn = SubTovReturn;
        }

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseTovreturnACt data)
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            _logger.LogInformation("User data SubtovTerm: {UserData}", json);
            try
            {
                _SubTovReturn.SubleaseTovReturnActCreate(data);
                return "Saved";
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка: {Message}", ex.Message);
                return ex.Message;
            }
        }
    }
}