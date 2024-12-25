using ACG_Api2.Middleware;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ACG_Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramBotErrorController : ControllerBase
    {
        private readonly TelegramBot _telegramBot;

        public TelegramBotErrorController(TelegramBot telegramBot)
        {
            _telegramBot = telegramBot;
        }

        public class BodyError
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Error { get; set; }
            public DateTime Date { get; set; }

            public void SetKievTime()
            {
                TimeZoneInfo kievTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");

                Date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, kievTimeZone);
            }

        }

        // GET: api/<TBErrorController>
        [HttpPost("Server")]
        public async Task<IActionResult> Server([FromBody] BodyError berror)
        {
            berror.SetKievTime();
            string message = $"⚠️ Server error ⚠️ \nName: {berror.Name} \nDate: {berror.Date} \nError message: {berror.Error}";
            await _telegramBot.SendErrorMessage(message);
            return Ok(new { success = true, message = "Error message sent successfully" });
        }

        [HttpPost("Client")]
        public async Task<IActionResult> Client([FromBody] BodyError berror)
        {
            string message = $"❗ Client error ❗" +
                             $"Name: {berror.Name}" +
                             $"Date: {berror.Date}" +
                             $"Error message: {berror.Error}";

            await _telegramBot.SendErrorMessage(message);
            return Ok(new { success = true, message = "Error message sent successfully" });
        }
    }
}
