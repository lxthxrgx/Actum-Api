using Microsoft.AspNetCore.Mvc;

namespace DocGenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            

            ESign eSign = new ESign();
            eSign.SignFile("/home/ltx/Documents/DOCX-Work/test_cer.docx","/home/ltx/mycert.pfx", "123456");
            return Ok();
        }
    }
}
