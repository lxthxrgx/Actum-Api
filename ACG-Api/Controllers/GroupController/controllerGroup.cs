using Microsoft.AspNetCore.Mvc;
using ACG_Class.Model.NewModel;
using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if( id == null)
                return StatusCode(400, new {error = "id can't be null"});
            
            var dataToSend = await _newcontext.Groups.FirstOrDefaultAsync(x => x.Id == id);

            if (dataToSend != null)
                return Ok(dataToSend);
            else
                return StatusCode(400, new {error ="not found data by this Id"});
        }

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
        public async Task<IActionResult> Put(int id, [FromBody] Group value)
        {
            if(id == null)
                return StatusCode(400, new {error = "ID can't be null"});

            if(value == null)
                return StatusCode(400, new {error = "Data can't be null"});

            try
            {
                var dataToUpdate = await _newcontext.Groups.FirstOrDefaultAsync(x => x.Id == id);
                dataToUpdate.NumberGroup = value.NumberGroup;
                dataToUpdate.NameGroup = value.NameGroup;
                dataToUpdate.Pibs = value.Pibs;
                dataToUpdate.Address = value.Address;
                dataToUpdate.Area = value.Area;
                dataToUpdate.isAlert = value.isAlert;
                dataToUpdate.DateCloseDepartment = value.DateCloseDepartment;
                dataToUpdate.IsDeleted = value.IsDeleted;
                if(value.IsDeleted == true)
                    dataToUpdate.DeleteTime = DateTime.UtcNow;
                    dataToUpdate.DeletedBy = value.DeletedBy;
                
                await _newcontext.SaveChangesAsync();
                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(500, new {error =$"Can't update data. Error: {ex.Message}" });
            }          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == null)
                return StatusCode(400, new {error = "data can't be null"});

            var dataToDelete = await _newcontext.Groups.FirstOrDefaultAsync(x => x.Id == id);

            _newcontext.Groups.Remove(dataToDelete);
            await _newcontext.SaveChangesAsync();

            return Ok();
        }

    }
}
