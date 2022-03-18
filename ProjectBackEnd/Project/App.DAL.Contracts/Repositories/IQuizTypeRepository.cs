using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface IQuizTypeRepository: IBaseRepository<QuizType>
{
    
}public interface IQuizTypeRepositoryCustom<TEntity>
{
}