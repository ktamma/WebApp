using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface IQuizRepository: IBaseRepository<Quiz>
{
    
}public interface IQuizRepositoryCustom<TEntity>
{
}