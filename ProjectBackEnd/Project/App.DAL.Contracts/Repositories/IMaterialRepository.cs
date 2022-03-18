using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface IMaterialRepository: IBaseRepository<Material>
{
    
}public interface IMaterialRepositoryCustom<TEntity>
{
}