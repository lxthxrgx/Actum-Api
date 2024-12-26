using ACG_Api2.Middleware;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using ACG_Class.Model.ServerError;
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
            try
            {
                berror.SetKievTime();
                await _telegramBot.SendErrorMessage($"✅ Test \nClass: {GetType().Name} \nName Method: {nameof(Server)} \nTime: {berror.Date} \nError message: Test Error");
            }
            catch(Exception ex) 
            {
                await _telegramBot.SendErrorMessage(ServerError.MessageFromServer(ex, GetType().Name, nameof(Server)));
            }
            return Ok(new { success = true, message = "Error message sent successfully" });
        }

        [HttpPost("Client")]
        public async Task<IActionResult> Client([FromBody] BodyError berror)
        {
            try
            {
                berror.SetKievTime();
                await _telegramBot.SendErrorMessage($"✅ Test \nClass: {GetType().Name} \nName Method: {nameof(Client)} \nTime: {berror.Date} \nError message: Test Error");
            }
            catch (Exception ex)
            {
                await _telegramBot.SendErrorMessage(ServerError.MessageFromClient(ex, GetType().Name, nameof(Client)));
            }
            return Ok(new { success = true, message = "Error message sent successfully" });
        }
    }
}
