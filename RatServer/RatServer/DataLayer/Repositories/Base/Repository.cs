using MongoDB.Bson;
using MongoDB.Driver;
using RatServer.DataLayer.Interfaces.Base;
using RatServer.DataLayer.Models.EntityBase.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RatServer.DataLayer.Repositories.Base
{
    public class Repository<TEntity, TContext, TEntityKey> : RepositoryBase<TEntity, TContext, TEntityKey>, IRepository<TEntity, TEntityKey> where TContext : DataContext
        where TEntity : IEntity<TEntityKey>

    {
        protected bool _isLocalDev = false;
        public Repository(TContext context) : this(context, null)
        {

        }

        public Repository(TContext context, string collectionName) : base(context, collectionName)
        {
            _config = context.Config;
            if (_config != null)
            {
                _isLocalDev = IsLocalDev();
            }
        }
        private bool IsLocalDev()
        {
            try
            {
                return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == _config.GetSection("Misc:LocalDevelopmentEnvironmentName").Value.ToLower();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void CreateIndex(CreateIndexOptions options, IndexKeysDefinition<TEntity> indexDefinition)
        {
            CreateIndexModel<TEntity> indexModel = new(indexDefinition, options);
            _ = Collection.Indexes.CreateOneAsync(indexModel);
        }

        public virtual async Task<List<BsonDocument>> AggregateAsync(PipelineDefinition<TEntity, BsonDocument> pipeline, AggregateOptions options = null, IClientSessionHandle session = null)
        {
            List<BsonDocument> result = session != null && !_isLocalDev
                ? (await Collection.AggregateAsync(session, pipeline, options)).ToList()
                : (await Collection.AggregateAsync(pipeline, options)).ToList();
            return result;
        }

        public virtual async Task DeleteAsync(TEntityKey eId, IClientSessionHandle session = null)
        {
            _ = session != null && !_isLocalDev
                ? await Collection.DeleteOneAsync(session, i => i.id.Equals(eId))
                : await Collection.DeleteOneAsync(i => i.id.Equals(eId));
        }

        public virtual async Task<TEntity> FindByIdAsync(TEntityKey id, IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.Find(session, u => u.id.Equals(id)).FirstOrDefaultAsync()
                : await Collection.Find(u => u.id.Equals(id)).FirstOrDefaultAsync();


        }

        public virtual async Task<TEntity> FindByIdProjectionAsync(TEntityKey id, ProjectionDefinition<TEntity> projectionCondition)
        {
            return await Collection.Find(u => u.id.Equals(id)).Project<TEntity>(projectionCondition).FirstOrDefaultAsync();
        }

    }


    public class Repository<TEntity, TContext> : Repository<TEntity, TContext, string>, IRepository<TEntity> where TContext : DataContext
        where TEntity : IEntity<string>
    {
        private readonly FindOptions options = new() { Collation = new Collation("en", strength: CollationStrength.Secondary) };

        public Repository(TContext context, string collectionName) : base(context, collectionName)
        {

        }

        public Repository(TContext context) : this(context, null)
        {
        }

        public virtual async Task<TEntity> InsertAsync(TEntity e, IClientSessionHandle session)
        {
            if (e == null) { throw new ArgumentNullException(nameof(e)); }


            if (session != null && !_isLocalDev)
            {
                await Collection.InsertOneAsync(session, e);
            }
            else
            {
                await Collection.InsertOneAsync(e);
            }

            return e;
        }

        public virtual async Task UpdateAsync(Expression<Func<TEntity, bool>> filterFunc, UpdateDefinition<TEntity> updateDefinition, IClientSessionHandle session = null)
        {
            _ = session != null && !_isLocalDev
                ? await Collection.UpdateOneAsync<TEntity>(session, filterFunc, updateDefinition)
                : await Collection.UpdateOneAsync<TEntity>(filterFunc, updateDefinition);

        }

        public virtual async Task<ReplaceOneResult> ReplaceAsync(TEntity e, IClientSessionHandle session = null)
        {

            return session != null && !_isLocalDev
                ? await Collection.ReplaceOneAsync(session, i => i.id.Equals(e.id), e, new ReplaceOptions { IsUpsert = true })
                : await Collection.ReplaceOneAsync(i => i.id.Equals(e.id), e, new ReplaceOptions { IsUpsert = true });

        }

        public virtual async Task DeleteAsync(TEntity e, IClientSessionHandle session = null)
        {
            _ = session != null && !_isLocalDev
                ? await Collection.DeleteOneAsync(session, i => i.id.Equals(e.id))
                : await Collection.DeleteOneAsync(i => i.id.Equals(e.id));
        }

        public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterFunc,
                                                            IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.Find(session, filterFunc, options).FirstOrDefaultAsync()
                : await Collection.Find(filterFunc, options).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterFunc, ProjectionDefinition<TEntity> projectionCondition, IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.Find(session, filterFunc).Project<TEntity>(projectionCondition).FirstOrDefaultAsync()
                : await Collection.Find(filterFunc).Project<TEntity>(projectionCondition).FirstOrDefaultAsync();


        }

        public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterFunc, string projectionCondition, IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.Find(session, filterFunc).Project<TEntity>(projectionCondition).FirstOrDefaultAsync()
                : await Collection.Find(filterFunc).Project<TEntity>(projectionCondition).FirstOrDefaultAsync();

        }

        public virtual async Task<TEntity> FindOneAsync(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> projectionCondition, IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.Find(session, filter).Project<TEntity>(projectionCondition).FirstOrDefaultAsync()
                : await Collection.Find(filter).Project<TEntity>(projectionCondition).FirstOrDefaultAsync();


        }

        public Task<TEntity> FindOneMaxAsync(SortDefinition<TEntity> sort)
        {
            return Collection.Find(x => true).Limit(1).Sort(sort).FirstOrDefaultAsync();
        }

        public Task<TEntity> FindOneMaxAsync(Expression<Func<TEntity, bool>> filter, SortDefinition<TEntity> sort)
        {
            return Collection.Find(filter).Limit(1).Sort(sort).FirstOrDefaultAsync();
        }


        public virtual async Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> filterFunc
                                                            , IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.Find(session, filterFunc, options).ToListAsync()
                : await Collection.Find(filterFunc, options).ToListAsync();

        }

        public virtual async Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> filterFunc, ProjectionDefinition<TEntity> projectionCondition, SortDefinition<TEntity> sortCondition)
        {
            return projectionCondition != null
                ? await Collection.Find(filterFunc, options).Project<TEntity>(projectionCondition).Sort(sortCondition).ToListAsync()
                : await Collection.Find(filterFunc, options).Sort(sortCondition).ToListAsync();

        }
        public virtual async Task<List<TEntity>> FindManyProjectionAsync(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> projectionCondition)
        {
            return await Collection.Find(filter, options).Project<TEntity>(projectionCondition).ToListAsync();
        }

        public virtual async Task<List<TEntity>> FindManyProjectionAsync(Expression<Func<TEntity, bool>> filterFunc, ProjectionDefinition<TEntity> projectionCondition, IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.Find(session, filterFunc, options).Project<TEntity>(projectionCondition).ToListAsync()
                : await Collection.Find(filterFunc, options).Project<TEntity>(projectionCondition).ToListAsync();
        }
        public virtual async Task<List<TEntity>> FindManyProjectionAsync(Expression<Func<TEntity, bool>> filterFunc, string projectionCondition)
        {
            return await Collection.Find(filterFunc).Project<TEntity>(projectionCondition).ToListAsync();
        }

        public virtual async Task<List<TEntity>> FindManyAsync(FilterDefinition<TEntity> filter, IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.Find(session, filter, options).ToListAsync()
                : await Collection.Find(filter, options).ToListAsync();

        }

        public virtual async Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> filterFunc, SortDefinition<TEntity> sortCondition, IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.Find(session, filterFunc, options).Sort(sortCondition).ToListAsync()
                : await Collection.Find(filterFunc, options).Sort(sortCondition).ToListAsync();

        }

        public virtual async Task<List<TEntity>> FindManyAsync(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> projectionCondition, SortDefinition<TEntity> sortCondition)
        {
            return projectionCondition != null
                ? await Collection.Find(filter, options).Project<TEntity>(projectionCondition).Sort(sortCondition).ToListAsync()
                : await Collection.Find(filter, options).Sort(sortCondition).ToListAsync();

        }
        public virtual async Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> filterFunc, int limit, int skip)
        {
            return await Collection.Find(filterFunc).Limit(limit).Skip(skip).ToListAsync();
        }
        public virtual async Task<List<TEntity>> FindManySortedAsync(FilterDefinition<TEntity> filter, SortDefinition<TEntity> sortCondition)
        {
            return await Collection.Find(filter, options).Sort(sortCondition).ToListAsync();
        }
        public virtual async Task<List<TEntity>> FindManySortedAsync(Expression<Func<TEntity, bool>> filterFunc, SortDefinition<TEntity> sortCondition)
        {
            return await Collection.Find(filterFunc, options).Sort(sortCondition).ToListAsync();
        }



        public virtual Task<long> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return Collection.CountDocumentsAsync(filter);
        }

        public virtual async Task<List<TEntity>> FindDistinctAsync(dynamic field, Expression<Func<TEntity, bool>> filter = null)
        {
            IAsyncCursor<TEntity> cursor = filter == null ? (IAsyncCursor<TEntity>)Collection.Distinct<TEntity>(field, "{}") : (IAsyncCursor<TEntity>)Collection.Distinct<TEntity>(field, filter);
            return await cursor.ToListAsync();
        }

        public async Task<TEntity> FindOneAndUpdateAsync(Expression<Func<TEntity, bool>> filter, UpdateDefinition<TEntity> updateDefinition,
                                                           FindOneAndUpdateOptions<TEntity, TEntity> options = null, IClientSessionHandle session = null)
        {
            return session != null && !_isLocalDev
                ? await Collection.FindOneAndUpdateAsync(session, filter, updateDefinition, options)
                : await Collection.FindOneAndUpdateAsync(filter, updateDefinition, options);
        }


        public virtual async Task DeleteManyAsync(Expression<Func<TEntity, bool>> filterFunc, IClientSessionHandle session = null)
        {
            _ = session != null && !_isLocalDev
                ? await Collection.DeleteManyAsync(session, filterFunc)
                : await Collection.DeleteManyAsync(filterFunc);
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities, IClientSessionHandle session = null)
        {
            FilterDefinitionBuilder<TEntity> filterBuilder = Builders<TEntity>.Filter;

            IEnumerable<ReplaceOneModel<TEntity>> updates = entities
               .Select(d =>
               {
                   FilterDefinition<TEntity> filter = filterBuilder.Where(x => x.id == d.id);
                   return new ReplaceOneModel<TEntity>(filter, d) { IsUpsert = true };
               });

            //TODO Session transactions are not working
            _ = session != null && !_isLocalDev ? await Collection.BulkWriteAsync(session, updates) : await Collection.BulkWriteAsync(updates);
        }

        public virtual async Task<UpdateResult> UpdateManyAsync(Expression<Func<TEntity, bool>> filter,
                                                           UpdateDefinition<TEntity> updateDefinition,
                                                           IClientSessionHandle session = null)

        {
            return session != null && !_isLocalDev
                ? await Collection.UpdateManyAsync(session, filter, updateDefinition, new UpdateOptions { IsUpsert = true })
                : await Collection.UpdateManyAsync(filter, updateDefinition, new UpdateOptions { IsUpsert = true });

        }


        public virtual async Task<UpdateResult> UpdateManyAsync(FilterDefinition<TEntity> filter,
                                                          UpdateDefinition<TEntity> updateDefinition,
                                                          bool IsUpsert,
                                                          IClientSessionHandle session = null)

        {
            return session != null && !_isLocalDev
                ? await Collection.UpdateManyAsync(session, filter, updateDefinition, new UpdateOptions { IsUpsert = IsUpsert })
                : await Collection.UpdateManyAsync(filter, updateDefinition, new UpdateOptions { IsUpsert = IsUpsert });

        }

        public virtual IEnumerable<TEntity> FindManyStream(Expression<Func<TEntity, bool>> filter, int limit = -1, int skip = -1)
        {
            FindOptions<TEntity> options = new()
            {
                //BatchSize = 1,
                NoCursorTimeout = false,
                AllowPartialResults = true,
            };
            if (limit > 0)
            {
                options.Limit = limit;
            }

            if (skip > -1)
            {
                options.Skip = skip;
            }

            using IAsyncCursor<TEntity> cursor = Collection.FindSync(filter, options);
            while (cursor.MoveNext())
            {
                IEnumerable<TEntity> batch = cursor.Current;
                foreach (TEntity document in batch)
                {
                    yield return document;
                }
            }
        }

        public async Task InsertManyAsyncGeneric(List<object> data, IClientSessionHandle session = null)
        {
            List<TEntity> list = data.Select(x => (TEntity)x).ToList();
            //foreach (object item in data)
            //{
            //    TEntity result = (TEntity)item;
            //    list.Add(result);
            //}

            if (session != null && !_isLocalDev)
            {
                await Collection.InsertManyAsync(session, list);
            }
            else
            {
                await Collection.InsertManyAsync(list);
            }

        }

        public async Task InsertManyAsync(IEnumerable<TEntity> data, IClientSessionHandle session = null)
        {
            if (session != null && !_isLocalDev)
            {
                await Collection.InsertManyAsync(session, data);
            }
            else
            {
                await Collection.InsertManyAsync(data);
            }

        }
    }

    public class Repository<TEntity> : Repository<TEntity, DataContext>
        where TEntity : IEntity<string>
    {
        public Repository(DataContext context) : base(context)
        {

        }

        public Repository(DataContext context, string collectionName) : base(context, collectionName)
        {
        }

    }
}

