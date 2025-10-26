// using Microsoft.AspNetCore.Mvc;
// using Actum_Api.model;
// using Actum_Api.service;

// namespace Actum_Api.Controllers.GuardController
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class guardController : ControllerBase
//     {
//         private readonly GuardService _guardService;

//         public guardController(GuardService guardService)
//         {
//             _guardService = guardService;
//         }

//         [HttpGet]
//         public async Task<IActionResult> Get()
//         {
//             var data = await _guardService.Get();
//             return Ok(data);
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetById(int Id)
//         {
//             var data = await _guardService.GetById(Id);
//             return Ok(data);
//         }
//     }
// }