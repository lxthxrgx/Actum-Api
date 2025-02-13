using Microsoft.AspNetCore.Mvc;
using ACG_Class.Model.NewClass;
using ACG_Class.Database;

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
        public IEnumerable<string> Get()
        {
             
        }

        [HttpGet("{id}")]
        public string GetById(int id)
        {
            
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
