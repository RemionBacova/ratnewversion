using MongoDB.Driver;
using RatServer.DataLayer.Interfaces.Base;
using RatServer.DataLayer.Interfaces.Client;
using RatServer.DataLayer.Repositories.Base;

namespace RatServer.DataLayer.Repositories.Client
{
    public class ClientValuesRepository : Repository<Models.Client.ClientValues>, IClientValuesRepository, IRepository<Models.Client.ClientValues>
    {
        public ClientValuesRepository(DataContext context)
            : base(context, "ClientValues")
        {
            CreateIndex(new CreateIndexOptions
            {
                Unique = true
            }, new IndexKeysDefinitionBuilder<Models.Client.ClientValues>().Ascending((Models.Client.ClientValues p) => p.id));
        }

    }
}
