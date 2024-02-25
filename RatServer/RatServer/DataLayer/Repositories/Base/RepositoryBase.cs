using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using RatServer.DataLayer.Interfaces.Base;
using RatServer.DataLayer.Models.EntityBase.Base;
using System.Linq;

namespace RatServer.DataLayer.Repositories.Base
{
    public class RepositoryBase<TEntity, TContext, TEntityKey> : IRepositoryBase<TEntity, TContext, TEntityKey>
        where TContext : DataContext
        where TEntity : IEntity<TEntityKey>
    {
        public string CollectionName { get; }
        public IMongoClient Client { get; }

        public IMongoCollection<TEntity> Collection { get; }

        protected IConfiguration _config;

        public IQueryable<TEntity> List => Collection.AsQueryable();

        public RepositoryBase(TContext context) : this(context, null)
        {
            _config = context.Config;
        }

        public RepositoryBase(TContext context, string collectionName)
        {
            CollectionName = collectionName ?? typeof(TEntity).Name + "s";
            TContext _context = context;
            Client = context.Client;
            Collection = _context.Database.GetCollection<TEntity>(CollectionName);
        }

        public IMongoClient GetClient()
        {
            return Client;
        }

        public ObjectId GetObjectId(string id)
        {
            return ObjectId.Parse(id);
        }
    }
}
