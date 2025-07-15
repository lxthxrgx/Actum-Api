using ACG_Api.model.XPath;
using Microsoft.AspNetCore.Mvc;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using ACG_Api.model.DTO.SubleaseWordReq.Tov;
using ACG_Api.components.ILogger;

namespace ACG_Api.Controllers.AutoDocController.tov
{
    [ApiController]
    [Route("api/[controller]")]
    public class sublease_tov_termination : ControllerBase
    {
        private readonly Func<string, XPathProcessor> _xPathFactory;
        private readonly SubleaseTovTermination _SubtovTerm;
        private readonly ILogger<sublease_tov_termination> _logger;

        public sublease_tov_termination(Func<string, XPathProcessor> xPathFactory, SubleaseTovTermination SubtovTerm, ILogger<sublease_tov_termination> logger){
            _logger = logger;
            _xPathFactory = xPathFactory;
            _SubtovTerm = SubtovTerm;
        }
        
        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseTermination data)
        {
            _logger.LogInformation("User data SubtovTerm: {UserData}", JsonUTF8.JsonOptions(data));
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