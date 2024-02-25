using MongoDB.Driver;
using RatServer.DataLayer.Models.EntityBase.Base;
using System.Linq;


namespace RatServer.DataLayer.Interfaces.Base
{
    public interface IRepositoryBase<TEntity, TContext, TEntityKey>
    where TContext : DataContext
    where TEntity : IEntity<TEntityKey>
    {
        IMongoCollection<TEntity> Collection { get; }
        string CollectionName { get; }
        IQueryable<TEntity> List { get; }
    }


}