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
            public string Name { get; set; }
            public required string Error { get; set; }
            public DateTime Date { get; set; }

            public void SetKievTime()
            {
                TimeZoneInfo kievTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");

                Date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, kievTimeZone);
            }

        }

        public class BodyErrorClient
        {
            public required string Error {get; set;}
            public DateTime Date {get; set;}

           public void SetKievTime()
            {
                TimeZoneInfo kievTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");

                Date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, kievTimeZone);
            }
        }

        // TEST CONTROLLERS START
        // GET: api/<TBErrorController>
        [HttpPost("ServerTest")]
        public async Task<IActionResult> ServertTest([FromBody] BodyError berror)
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

        [HttpPost("ClientTest")]
        public async Task<IActionResult> ClientTest([FromBody] BodyError berror)
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
        // TEST CONTROLLERS END

        //CONTROLLERS FOR PROD START

        [HttpPost("Server")]
        public async Task<IActionResult> Server([FromBody] BodyError berror)
        {
            try
            {
                berror.SetKievTime();
                await _telegramBot.SendErrorMessage($"❗SERVER ERROR \nClass: {GetType().Name} \nName Method: {nameof(Server)} \nTime: {berror.Date} \nError message: {berror.Error}");
            }
            catch (Exception ex)
            {
                await _telegramBot.SendErrorMessage(ServerError.MessageFromServer(ex, GetType().Name, nameof(Server)));
            }
            return Ok(new { success = true, message = "Error message sent successfully" });
        }

[HttpPost("Client")]
public async Task<IActionResult> Client([FromBody] BodyErrorClient berror)
{
    if (berror == null || string.IsNullOrEmpty(berror.Error))
    {
        // Если запрос не содержит данных или данные некорректны, возвращаем ошибку 400 (Bad Request)
        return BadRequest(new { success = false, message = "Invalid data in request" });
    }

    try
    {
        berror.SetKievTime();
        await _telegramBot.SendErrorMessage($"⚠️ CLIENT ERROR \nTime: {berror.Date} \nError message: {berror.Error}");
    }
    catch (Exception ex)
    {
        await _telegramBot.SendErrorMessage(ServerError.MessageFromClient(ex, GetType().Name, nameof(Client)));
        return StatusCode(500, new { success = false, message = "Internal server error" });
    }

    return Ok(new { success = true, message = "Error message sent successfully" });
}


        //CONTROLLERS FOR PROD END
    }
}
