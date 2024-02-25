using Microsoft.AspNetCore.Mvc;
using RatServer.Core.Filters;
using System;
using System.Threading.Tasks;

namespace RatServer.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenShareController : ControllerBase
    {
        static protected string ScreenSelected;
        public ScreenShareController()
        {

        }


        [HttpPost(nameof(SetMyScreen))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetMyScreen([FromBody]Screen screen)
        {
            try
            {
                ScreenSelected = screen.b;
                return Ok( true);
            }
            catch(Exception ex)
            {
                return Ok(false);
            }
         
        }
        [HttpGet(nameof(GetMyScreen))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> GetMyScreen()
        {
            if (ScreenSelected != null)
            {
                if (ScreenSelected.Length > 0)
                    return Ok( ScreenSelected);
                else
                    return Ok("");
            }
            else
                  return Ok("");
        }
    }

    public class Screen
    {
        public string b { get; set; }
    }
}
