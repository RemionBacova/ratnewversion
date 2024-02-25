using Microsoft.AspNetCore.Mvc;
using RatServer.Core.Filters;
using RatServer.Interfaces;
using System.Threading.Tasks;

namespace RatServer.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService fileService;
        public FileController(IFileService fileService)
        {
            this.fileService = fileService;

        }

        [HttpGet(nameof(ClearFile))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> ClearFile()
        {
            fileService.ClearFile();
            return Ok(true);
        }

        [HttpPost(nameof(SetFile))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetFile([FromBody] File file)
        {
            fileService.SetFile(file);
            return Ok(true);
        }

        [HttpGet(nameof(GetFile))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> GetFile()
        {
            return Ok(fileService.GetFile());
        }
    }

    public class File
    {
        public string fileName { get; set; }
        public byte[] bytes { get; set; }
    }
}
