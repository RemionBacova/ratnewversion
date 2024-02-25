using MongoDB.Driver;
using RatServer.DataLayer.Interfaces.Base;
using RatServer.DataLayer.Interfaces.Client;
using RatServer.DataLayer.Repositories.Base;

namespace RatServer.DataLayer.Repositories.Client
{
    public class ClientRepository : Repository<Models.Client.Client>, IClientRepository, IRepository<Models.Client.Client>
    {
        public ClientRepository(DataContext context)
            : base(context, "Client")
        {
            CreateIndex(new CreateIndexOptions
            {
                Unique = true
            }, new IndexKeysDefinitionBuilder<Models.Client.Client>().Ascending((Models.Client.Client p) => p.clientId));
        }

    }
}
