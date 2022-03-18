using System.Security.Authentication;
using Base.Contracts.DAL.Mappers;
using Base.Contracts.DAL.Repositories;
using Base.Contracts.Domain;
using Contracts.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Base.DAL.EF.Repositories
{
    public class BaseRepository<TDalEntity, TDomainEntity, TDbContext> :
        BaseRepository<TDalEntity, TDomainEntity, Guid, TDbContext>,
        IBaseRepository<TDalEntity>
        where TDalEntity : class, IDomainEntityId
        where TDomainEntity : class, IDomainEntityId
        where TDbContext : DbContext

    {
        public BaseRepository(TDbContext dbContext, IBaseMapper<TDalEntity, TDomainEntity> mapper) : base(dbContext,
            mapper)
        {
        }
    }

    public class
        BaseRepository<TDalEntity, TDomainEntity, TKey, TDbContext> : IBaseRepository<TDalEntity, TKey>
        where TDalEntity : class, IDomainEntityId<TKey>
        where TDomainEntity : class, IDomainEntityId<TKey>
        where TKey : IEquatable<TKey>
        where TDbContext : DbContext

    {
        protected readonly TDbContext RepoDbContext;
        protected readonly DbSet<TDomainEntity> RepoDbSet;
        protected readonly IBaseMapper<TDalEntity, TDomainEntity> Mapper;

        public BaseRepository(TDbContext dbContext, IBaseMapper<TDalEntity, TDomainEntity> mapper)
        {
            RepoDbContext = dbContext;
            RepoDbSet = dbContext.Set<TDomainEntity>();
            Mapper = mapper;
        }

        public IQueryable<TDomainEntity> CreateQuery(TKey? userId, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();


            if (userId != null && typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TDomainEntity)))
            {
                // ReSharper disable once SuspiciousTypeConversion.Global
                query = query.Where(e => ((IDomainAppUserId<TKey>)e).AppUserId.Equals(userId));
            }

            if (noTracking)
            {
                //return await RepoDbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id .Equals(id));
                query = query.AsNoTracking();
            }

            return query;
        }

        public virtual async Task<IEnumerable<TDalEntity>> GetAllAsync(TKey? userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resQuery = query.Select(domainEntity => Mapper.Map(domainEntity));
            var res = await resQuery.ToListAsync();

            return res!;
        }


        public virtual async Task<TDalEntity?> FirstOrDefaultAsync(TKey id, TKey? userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            return await query.Select(d => Mapper.Map(d)).FirstOrDefaultAsync(e => e!.Id.Equals(id));
        }

        public virtual TDalEntity Add(TDalEntity entity)
        {
            return Mapper.Map(RepoDbSet.Add(Mapper.Map(entity)!).Entity)!;
        }

        public virtual TDalEntity Update(TDalEntity entity)
        {
            return Mapper.Map(RepoDbSet.Update(Mapper.Map(entity)!).Entity)!;
        }

        public virtual TDalEntity Remove(TDalEntity entity, TKey? userId = default)
        {
            if (userId != null && !userId.Equals(default) &&
                typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TDomainEntity)) &&
                !((IDomainAppUserId<TKey>)entity).AppUserId.Equals(userId))
            {
                throw new AuthenticationException(
                    $"Bad user id inside entity {typeof(TDalEntity).Name} to be deleted.");
                // TODO: load entity from the db, check that userId inside entity is correct.
            }

            return Mapper.Map(RepoDbSet.Remove(Mapper.Map(entity)!).Entity)!;
        }

        public virtual async Task<TDalEntity> RemoveAsync(TKey id, TKey? userId)
        {
            var entity = await FirstOrDefaultAsync(id, userId);
            if (entity == null)
            {
                throw new NullReferenceException("Entity with id {id} not found");
            }

            return Remove(entity!, userId);
        }

        public virtual async Task<bool> ExistsAsync(TKey id, TKey? userId)
        {
            if (userId == null || userId.Equals(default))
                // no ownership control, userId was null or default
                return await RepoDbSet.AnyAsync(e => e.Id.Equals(id));

            // we have userid and it is not null or default (null or 0) - so we should check for appuserid also
            // does the entity actually implement the correct interface
            if (!typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TDomainEntity)))
                throw new AuthenticationException(
                    $"Entity {typeof(TDomainEntity).Name} does not implement required interface: {typeof(IDomainAppUserId<TKey>).Name} for AppUserId check");
            return await RepoDbSet.AnyAsync(e =>
                e.Id.Equals(id) && ((IDomainAppUserId<TKey>)e).AppUserId.Equals(userId));
        }


        public virtual async Task<TDalEntity?> FirstOrDefaultAsync(TKey id, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();
            if (noTracking)
            {
                //return await RepoDbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id .Equals(id));
                query = query.AsNoTracking();
            }

            return await query.Select(d => Mapper.Map(d)).FirstOrDefaultAsync(e => e!.Id.Equals(id));
        }


        public virtual async Task<IEnumerable<TDalEntity>> GetAllAsync(bool noTracking = true)
        {
            /*if (noTracking)
            {
                return await RepoDbSet.AsNoTracking().ToListAsync();
            }
    
            return await RepoDbSet.ToListAsync();*/

            var query = RepoDbSet.AsQueryable();
            var resQuery = query.Select(domainEntity => Mapper.Map(domainEntity));
            var res = await resQuery.ToListAsync();

            return res!;
        }


        public virtual TDalEntity Remove(TDalEntity entity)
        {
            return Mapper.Map(RepoDbSet.Remove(Mapper.Map(entity)!).Entity)!;
        }

        public virtual async Task<TDalEntity> RemoveAsync(TKey id)
        {
            var entity = await FirstOrDefaultAsync(id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return Mapper.Map(RepoDbSet.Remove(Mapper.Map(entity)!).Entity)!;
        }

        public virtual async Task<bool> ExistsAsync(TKey id)
        {
            return await RepoDbSet.AnyAsync(e => e.Id.Equals(id));
        }
    }
}