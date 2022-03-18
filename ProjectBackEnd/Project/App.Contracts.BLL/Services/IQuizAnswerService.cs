using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface IQuizAnswerService: IBaseEntityService<App.BLL.DTO.QuizAnswer, App.DAL.DTO.QuizAnswer>, IQuizAnswerRepositoryCustom< App.DAL.DTO.QuizAnswer>
{
    
}