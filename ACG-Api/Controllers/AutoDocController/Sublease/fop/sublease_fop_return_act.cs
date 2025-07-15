using ACG_Api.model.XPath;
using Microsoft.AspNetCore.Mvc;
using ACG_Api.service.AutoDocService;
using System.Text.Json;
using ACG_Api.model.DTO.SubleaseWordReq.Fop;
using ACG_Api.components.ILogger;

namespace ACG_Api.Controllers.AutoDocController.Sublease.fop
{
    [ApiController]
    [Route("api/[controller]")]
    public class sublease_fop_return_act : ControllerBase
    {
        private readonly Func<string, XPathProcessor> _xPathFactory;
        private readonly SubleaseFopReturnAct _SubFopReturn;
        private readonly ILogger<sublease_fop_return_act> _logger;
        public sublease_fop_return_act(Func<string, XPathProcessor> xPathFactory, SubleaseFopReturnAct SubFopReturn, ILogger<sublease_fop_return_act> logger){
            _logger = logger;
            _xPathFactory = xPathFactory;
            _SubFopReturn = SubFopReturn;
        }

        [HttpPost("create")]
        public string GetTestXmlTree([FromBody]DTOSubleaseFopReturnAct data)
        {
            _logger.LogInformation("User data SubtovTerm: {UserData}", JsonUTF8.JsonOptions(data));
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