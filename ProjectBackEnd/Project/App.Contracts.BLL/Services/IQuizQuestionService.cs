using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface IQuizQuestionService: IBaseEntityService<App.BLL.DTO.QuizQuestion, App.DAL.DTO.QuizQuestion>, IQuizQuestionRepositoryCustom<App.DAL.DTO.QuizQuestion>
{
    
}