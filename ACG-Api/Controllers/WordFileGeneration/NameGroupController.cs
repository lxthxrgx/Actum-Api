using ACG_Class.Database;
using ACG_Class.Model.ModelMemory.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ACG_Api.Controllers.WordFileGeneration
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameGroupController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public NameGroupController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/<NameGroupController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            int a = await _context.D4.Where(x => x.Id == id).Select(e => e.NumberGroup).Distinct().SingleOrDefaultAsync();
            if(a is 0)
            {
                return StatusCode(400, new { error = "Такого Id немає." });
            }
            else
            {
                var b = await _context.D2.Where(e => e.NumberGroup == a).Select(x => x.NameGroup).FirstOrDefaultAsync();
                return StatusCode(200, b);
            }
        }

        //// GET api/<NameGroupController>/5
        //[HttpGet("{id}")]
        //public string GetById(int id)
        //{
        //    return "value";
        //}

        //// POST api/<NameGroupController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<NameGroupController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<NameGroupController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
