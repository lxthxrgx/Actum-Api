using ACG_Class.Database;
using ACG_Class.Model.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACG_Api.Controllers.pdfview
{
    interface IPdfData
    {
        int Id { get; set; }
        int NumberGroup { get; set; }
        string NameGroup { get; set; }
        string Status { get; set; }
    }

    public class PdfData : IPdfData
    {
        public int Id { get; set; }
        public int NumberGroup { get; set; }
        public string NameGroup { get; set; }
        public string Status { get; set; }
    }

    public static class ChangePath
    { 
        public static string Change(string oldPath)
        {
            if (string.IsNullOrEmpty(oldPath))
            {
                return null;
            }
            string stableData = oldPath.Replace("\\", "/");
            return stableData;
        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class pdfviewController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public pdfviewController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDataForView()
        {
            var data = await _context.D5
                   .Select(x => new { x.Id, x.NumberGroup, x.NameGroup})
                   .ToListAsync();

            var pdfDataList = new List<PdfData>();

            foreach (var item in data)
            {
                
                var pdfData = new PdfData
                {
                    Id = item.Id,
                    NumberGroup = item.NumberGroup,
                    NameGroup = item.NameGroup,
                };
                pdfDataList.Add(pdfData);
            }
            return Ok(pdfDataList);
        }

        [HttpGet("getpdflink")]
        public IActionResult GetPdfLink(int id)
        {
            var data = _context.pathToFilesGuard
                        .Where(s => s._5dId == id)
                        .Select(x => x.PathTOServerFiles)
                        .ToList();
            if (data == null)
            {
                return NotFound("Файл не найден.");
            }

            var UrlToSend = new List<string>();

            foreach(var itemdata in data)
            {
                var normalizedPath = ChangePath.Change(itemdata).Trim();
                var dataForUrl = _context.D5.Where(s => s.Id == id).Select(x => new { x.NumberGroup, x.NameGroup }).FirstOrDefault();
                var path = $"{dataForUrl.NumberGroup}-{dataForUrl.NameGroup}/Охорона/{Path.GetFileName(itemdata)}";

                var fileName = Path.GetFileName(normalizedPath);
                string fileUrl = $"{Request.Scheme}://{Request.Host}/pdf/{path}";

                UrlToSend.Add(fileUrl);
            }

            return Ok(UrlToSend);
        }

    }
}
