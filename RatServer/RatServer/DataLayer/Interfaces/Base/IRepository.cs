using MongoDB.Bson;
using MongoDB.Driver;
using RatServer.DataLayer.Models.EntityBase.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RatServer.DataLayer.Interfaces.Base
{
    public interface IRepository<TEntity, TEntityKey> where TEntity : IEntity<TEntityKey>
    {
        Task DeleteAsync(TEntityKey eId, IClientSessionHandle session = null);
        Task<TEntity> FindByIdAsync(TEntityKey id, IClientSessionHandle session = null);

    }

    public interface IRepository<TEntity> where TEntity : IEntity<string>
    {
        Task<TEntity> InsertAsync(TEntity e, IClientSessionHandle session = null);
        Task InsertManyAsyncGeneric(List<object> data, IClientSessionHandle session = null);
        Task InsertManyAsync(IEnumerable<TEntity> data, IClientSessionHandle session = null);
        Task<ReplaceOneResult> ReplaceAsync(TEntity e, IClientSessionHandle session = null);

        Task UpdateAsync(Expression<Func<TEntity, bool>> filterFunc, UpdateDefinition<TEntity> updateDefinition, IClientSessionHandle session = null);

        Task DeleteAsync(TEntity e, IClientSessionHandle session = null);

        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterFunc, IClientSessionHandle session = null);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterFunc, ProjectionDefinition<TEntity> projectionCondition, IClientSessionHandle session = null);

        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterFunc, string projectionCondition, IClientSessionHandle session = null);

        Task<TEntity> FindOneAsync(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> projectionCondition, IClientSessionHandle session = null);
        Task<TEntity> FindOneMaxAsync(SortDefinition<TEntity> sort);
        Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> filterFunc, SortDefinition<TEntity> sortCondition, IClientSessionHandle session = null);

        Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> filterFunc, IClientSessionHandle session = null);

        Task<List<TEntity>> FindManyAsync(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> projectionCondition, SortDefinition<TEntity> sortCondition);
        Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> filterFunc, ProjectionDefinition<TEntity> projectionCondition, SortDefinition<TEntity> sortCondition);

        Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> filterFunc, int limit, int skip);

        Task<List<TEntity>> FindManyAsync(FilterDefinition<TEntity> filter, IClientSessionHandle session = null);
        Task<List<TEntity>> FindManySortedAsync(Expression<Func<TEntity, bool>> filterFunc, SortDefinition<TEntity> sortCondition);

        Task<List<TEntity>> FindManySortedAsync(FilterDefinition<TEntity> filter, SortDefinition<TEntity> sortCondition);

        Task<List<TEntity>> FindManyProjectionAsync(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> projectionCondition);

        Task<List<TEntity>> FindManyProjectionAsync(Expression<Func<TEntity, bool>> filterFunc, ProjectionDefinition<TEntity> projectionCondition, IClientSessionHandle session = null);

        Task<List<TEntity>> FindManyProjectionAsync(Expression<Func<TEntity, bool>> filterFunc, string projectionCondition);
        Task<long> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> filterFunc, IClientSessionHandle session = null);
        Task UpdateManyAsync(IEnumerable<TEntity> entities, IClientSessionHandle session = null);

        Task<UpdateResult> UpdateManyAsync(Expression<Func<TEntity, bool>> filter,
                                 UpdateDefinition<TEntity> updateDefinition,
                                 IClientSessionHandle session = null
                                 );

        Task<UpdateResult> UpdateManyAsync(FilterDefinition<TEntity> filter,
                                                           UpdateDefinition<TEntity> updateDefinition,
                                                           bool IsUpsert,
                                                           IClientSessionHandle session = null);

        IMongoClient GetClient();
        IEnumerable<TEntity> FindManyStream(Expression<Func<TEntity, bool>> filter, int limit = -1, int skip = -1);
        Task<List<BsonDocument>> AggregateAsync(PipelineDefinition<TEntity, BsonDocument> pipeline, AggregateOptions options = null, IClientSessionHandle session = null);


    }
}