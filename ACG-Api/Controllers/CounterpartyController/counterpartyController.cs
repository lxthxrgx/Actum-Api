// using Microsoft.AspNetCore.Mvc;
// using Actum_Api.model;
// using Actum_Api.Database;
// using Microsoft.EntityFrameworkCore;

// namespace Actum_Api.Controllers.CounterpartyController
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class counterpartyController : ControllerBase
//     {
//         private readonly DatabaseModel _newcontext;
//         public counterpartyController(DatabaseModel newcontext)
//         {
//             _newcontext = newcontext;
//         }

//         [HttpGet]
//         public async Task<IActionResult> Get()
//         {
//             return Ok(await _newcontext.Counterparty.Include(e=>e.Group).ToListAsync());
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetById(int id)
//         {
//             if (id == 0)
//                 return StatusCode(400, new { error = "id cant be 0" });

//             var counterpartyDataById = await _newcontext.Counterparty.FirstOrDefaultAsync(x => x.Id == id);

//             if (counterpartyDataById == null)
//                 return StatusCode(400, new { error = "no data by this id" });

//             return Ok(counterpartyDataById);
//         }

//         [HttpPost]
//         public async Task<IActionResult> Post([FromBody] List<Counterparty> data)
//         {
//             if (data == null)
//                 return StatusCode(400, new { error = "Counterparty data can't be null", error_data = data });

//            using var transaction = await _newcontext.Database.BeginTransactionAsync();
//            try
//            {
//                foreach (var dataToAdd in data)
//                {
//                    if(dataToAdd.Id_Group == 0)
//                    {
//                        var mainAdd = new Group{
//                            Id = 0,
//                            NumberGroup = dataToAdd.Group.NumberGroup,
//                            NameGroup = dataToAdd.Group.NameGroup
//                        };
//                        await _newcontext.Groups.AddAsync(mainAdd);
//                        await _newcontext.SaveChangesAsync();
           
//                        dataToAdd.Group = mainAdd;
//                        dataToAdd.Id_Group = mainAdd.Id;
//                    }
//                    else
//                    {
//                        var DataById = await _newcontext.Groups.FirstOrDefaultAsync(x => x.Id == dataToAdd.Id_Group);
//                        dataToAdd.Group = DataById;
//                    }
                   
//                    _newcontext.Counterparty.Add(dataToAdd);
//                }
           
//                await _newcontext.SaveChangesAsync();
//                await transaction.CommitAsync();
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                await transaction.RollbackAsync();
//                Console.WriteLine($"Error: {ex.Message}");
//                return StatusCode(500, new { error = $"Internal Error: {ex.Message}", innerException = ex.InnerException?.Message });
//            }
           
//         }


//         [HttpPut("{id}")]
//         public void Put(int id, [FromBody] string value)
//         {

//         }

//         [HttpDelete("{id}")]
//         public void Delete(int id)
//         {
//         }
//     }
// }
