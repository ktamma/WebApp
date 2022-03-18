using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface ITakeAnswerRepository: IBaseRepository<TakeAnswer>
{
    
}public interface ITakeAnswerRepositoryCustom<TEntity>
{
}