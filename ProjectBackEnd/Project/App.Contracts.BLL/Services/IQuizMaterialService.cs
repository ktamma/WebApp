using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface IQuizMaterialService: IBaseEntityService<App.BLL.DTO.QuizMaterial, App.DAL.DTO.QuizMaterial>, IQuizMaterialRepositoryCustom<App.DAL.DTO.QuizMaterial>
{
    
}