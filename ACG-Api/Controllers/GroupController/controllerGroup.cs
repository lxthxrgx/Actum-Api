using Microsoft.AspNetCore.Mvc;
using Models.model;
using Actum_Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Actum_Api.Controllers.ControllerGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class groupController : ControllerBase
    {
        private readonly DatabaseModel _newcontext;
        public groupController(DatabaseModel newcontext)
        {
            _newcontext = newcontext;
        }

        [HttpGet("GETcontollerGroup")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _newcontext.Groups.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 0)
                return StatusCode(400, new { error = "id can't be null" });

            var dataToSend = await _newcontext.Groups.FirstOrDefaultAsync(x => x.Id == id);

            if (dataToSend != null)
                return Ok(dataToSend);
            else
                return StatusCode(400, new { error = "not found data by this Id" });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Groups> data)
        {
            if (data == null)
                return StatusCode(400, new { error = "data cant be null" });
            foreach (var value in data)
            {
                await _newcontext.AddAsync(value);
            }
            await _newcontext.SaveChangesAsync();
            return Ok();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] Groups value)
        //{
        //    if (id < 0)
        //        return StatusCode(400, new { error = "ID can't be null" });

        //    if (value == null)
        //        return StatusCode(400, new { error = "Data can't be null" });

        //    try
        //    {
        //        var dataToUpdate = await _newcontext.Groups.FirstOrDefaultAsync(x => x.Id == id);
        //        dataToUpdate.Pibs = value.Pibs;
        //        dataToUpdate.Address = value.Address;
        //        dataToUpdate.Area = value.Area;
        //        dataToUpdate.isAlert = value.isAlert;
        //        dataToUpdate.DateCloseDepartment = value.DateCloseDepartment;
        //        dataToUpdate.IsDeleted = value.IsDeleted;
        //        if (value.IsDeleted == true)
        //            dataToUpdate.DeleteTime = DateTime.UtcNow;
        //        dataToUpdate.DeletedBy = value.DeletedBy;

        //        await _newcontext.SaveChangesAsync();
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { error = $"Can't update data. Error: {ex.Message}" });
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
                return StatusCode(400, new { error = "data can't be null" });

            var dataToDelete = await _newcontext.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if (dataToDelete != null)
            {
                _newcontext.Groups.Remove(dataToDelete);
                await _newcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return StatusCode(400, "Null data to delete, check Id");
            }
        }

    }
}
