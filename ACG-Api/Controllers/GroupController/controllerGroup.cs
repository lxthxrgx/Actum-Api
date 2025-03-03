using Microsoft.AspNetCore.Mvc;
using ACG_Class.Model.NewModel;
using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ACG_Api.Controllers.GroupController
{
    [Route("api/[controller]")]
    [ApiController]
    public class controllerGroup : ControllerBase
    {
        private readonly NewDatabaseModel _newcontext;
        public controllerGroup(NewDatabaseModel newcontext)
        {
            _newcontext = newcontext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _newcontext.Groups.ToListAsync());
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetById(int id)
        // {
        
        // }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Group data)
        {
            if(data == null)
                return StatusCode(400, new {error = "data cant be null"});

            await _newcontext.AddAsync(data);
            await _newcontext.SaveChangesAsync();
            return Ok();
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
