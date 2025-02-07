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
            var data = await _context.D4
                   .Select(x => new { x.Id, x.NumberGroup, x.NameGroup ,x.EndAktDate})
                   .ToListAsync();

            var pdfDataList = new List<PdfData>();

            foreach (var item in data)
            {
                
                var pdfData = new PdfData
                {
                    Id = item.Id,
                    NumberGroup = item.NumberGroup,
                    NameGroup = item.NameGroup,
                    Status = item.EndAktDate < DateTime.Now ? "old" : "actual",
                };
                pdfDataList.Add(pdfData);
            }
            return Ok(pdfDataList);
        }

        [HttpGet("getpdflink")]
        public IActionResult GetPdfLink(int id)
        {
            var data = _context.PdfFilePath_Sublease
                        .Where(s => s._4DId == id)
                        .Select(x => x.PathToPdfFile_Sublease)
                        .ToList();
            if (data == null)
            {
                return NotFound("Файл не найден.");
            }

            var UrlToSend = new List<string>();

            foreach(var itemdata in data)
            {
                var normalizedPath = ChangePath.Change(itemdata);
                var dataForUrl = _context.D4.Where(s => s.Id == id).Select(x => new { x.NumberGroup, x.NameGroup }).FirstOrDefault();
                var path = $"{dataForUrl.NumberGroup}-{dataForUrl.NameGroup}/PDF Суборенда/{Path.GetFileName(itemdata)}";

                var fileName = Path.GetFileName(normalizedPath);
                string fileUrl = $"{Request.Scheme}://{Request.Host}/pdf/{path}";

                UrlToSend.Add(fileUrl);
            }

            return Ok(UrlToSend);
        }

    }
}
