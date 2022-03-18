using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface ITakeRepository: IBaseRepository<Take>
{
    
}public interface ITakeRepositoryCustom<TEntity>
{
}