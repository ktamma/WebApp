using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface IQuizTypeService: IBaseEntityService<App.BLL.DTO.QuizType, App.DAL.DTO.QuizType>, IQuizTypeRepositoryCustom<App.DAL.DTO.QuizType>
{
    
}