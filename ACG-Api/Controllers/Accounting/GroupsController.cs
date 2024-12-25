using Microsoft.AspNetCore.Mvc;
using ACG_Class.Database;
using ACG_Class.Model.Class;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ACG_Api.Controllers.Accounting
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public GroupsController(DataBaseContext contex)
        {
            _context = contex;
        }

        // GET: api/<GroupsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<_2D>>> Get()
        {
           var dataFromD2 = await _context.D2.Distinct().ToListAsync();
            var data = dataFromD2.Select(d => new DataForGroups
            {
                NumberGroup = d.NumberGroup,
                NameGroup = d.NameGroup,
                Address = d.address
            }).ToList();
            return Ok(data);
        }

        // GET api/<GroupsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GroupsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GroupsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GroupsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
