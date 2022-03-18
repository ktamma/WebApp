using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface IQuizQuestionRepository: IBaseRepository<QuizQuestion>
{
    
}public interface IQuizQuestionRepositoryCustom<TEntity>
{
}