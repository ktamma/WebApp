using Base.Contracts.BLL.Mappers;
using Base.Contracts.BLL.Services;
using Base.Contracts.DAL;
using Base.Contracts.DAL.Repositories;
using Base.Contracts.Domain;

namespace Base.BLL.Services
{
    public class BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalentity>
        : BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalentity, Guid>,
            IBaseEntityService<TBllEntity, TDalentity>
        where TBllEntity : class, IDomainEntityId
        where TDalentity : class, IDomainEntityId
        where TUnitOfWork : IBaseUnitOfWork
        where TRepository : IBaseRepository<TDalentity>
    {
        public BaseEntityService(TUnitOfWork serviceUow, TRepository serviceRepository,
            IBaseMapper<TBllEntity, TDalentity> mapper) : base(serviceUow, serviceRepository, mapper)
        {
        }
    }

    public class
        BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalentity, TKey> : IBaseEntityService<TBllEntity,
            TDalentity, TKey>
        where TBllEntity : class, IDomainEntityId<TKey>
        where TDalentity : class, IDomainEntityId<TKey>
        where TKey : IEquatable<TKey>
        where TUnitOfWork : IBaseUnitOfWork
        where TRepository : IBaseRepository<TDalentity, TKey>
    {
        protected TUnitOfWork ServiceUow;
        protected TRepository ServiceRepository;
        protected IBaseMapper<TBllEntity, TDalentity> Mapper;

        public BaseEntityService(TUnitOfWork serviceUow, TRepository serviceRepository,
            IBaseMapper<TBllEntity, TDalentity> mapper)
        {
            ServiceUow = serviceUow;
            ServiceRepository = serviceRepository;
            Mapper = mapper;
        }

        public TBllEntity Add(TBllEntity entity)
        {
            return Mapper.Map(ServiceRepository.Add(Mapper.Map(entity)!))!;
        }

        public TBllEntity Update(TBllEntity entity)
        {
            return Mapper.Map(ServiceRepository.Update(Mapper.Map(entity)!))!;
        }

        public TBllEntity Remove(TBllEntity entity, TKey? userId)
        {
            return Mapper.Map(ServiceRepository.Remove(Mapper.Map(entity)!, userId))!;
        }

        public TBllEntity Remove(TBllEntity entity)
        {
            return Mapper.Map(ServiceRepository.Remove(Mapper.Map(entity)!))!;
        }

        public async Task<IEnumerable<TBllEntity>> GetAllAsync(TKey userId, bool noTracking = true)
        {
            return (await ServiceRepository.GetAllAsync(userId, noTracking)).Select(entity => Mapper.Map(entity))!;
        }

        public async Task<TBllEntity?> FirstOrDefaultAsync(TKey id, TKey userId, bool noTracking = true)
        {
            return Mapper.Map(await ServiceRepository.FirstOrDefaultAsync(id, userId, noTracking));
        }

        public async Task<bool> ExistsAsync(TKey id, TKey userId)
        {
            return await ServiceRepository.ExistsAsync(id, userId);
        }

        public async Task<TBllEntity> RemoveAsync(TKey id, TKey userId)
        {
            return Mapper.Map(await ServiceRepository.RemoveAsync(id, userId))!;
        }

        public async Task<IEnumerable<TBllEntity>> GetAllAsync(bool noTracking = true)
        {
            return (await ServiceRepository.GetAllAsync(noTracking)).Select(entity => Mapper.Map(entity))!;
        }

        public async Task<TBllEntity?> FirstOrDefaultAsync(TKey id, bool noTracking = true)
        {
            return Mapper.Map(await ServiceRepository.FirstOrDefaultAsync(id, noTracking));
        }

        public async Task<bool> ExistsAsync(TKey id)
        {
            return await ServiceRepository.ExistsAsync(id);
        }

        public async Task<TBllEntity> RemoveAsync(TKey id)
        {
            return Mapper.Map(await ServiceRepository.RemoveAsync(id))!;
        }
    }
}