using Microsoft.AspNetCore.Mvc;
using ACG_Class.Model.NewClass;
using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;

namespace ACG_Api.Controllers.Counterparty
{
    [Route("api/[controller]")]
    [ApiController]
    public class counterpartyController : ControllerBase
    {
        private readonly NewDatabaseModel _newcontext;
        public counterpartyController(NewDatabaseModel newcontext)
        {
            _newcontext = newcontext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _newcontext.Counterparty.Include(e=>e.NumberGroup).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
                return StatusCode(400, new { error = "id cant be 0" });

            var counterpartyDataById = await _newcontext.Counterparty.FirstOrDefaultAsync(x => x.Id == id);

            if (counterpartyDataById == null)
                return StatusCode(400, new { error = "no data by this id" });

            return Ok(counterpartyDataById);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
