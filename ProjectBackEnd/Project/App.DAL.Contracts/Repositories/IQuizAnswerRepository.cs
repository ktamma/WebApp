using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface IQuizAnswerRepository: IBaseRepository<QuizAnswer>
{
    
}public interface IQuizAnswerRepositoryCustom<TEntity>
{
}