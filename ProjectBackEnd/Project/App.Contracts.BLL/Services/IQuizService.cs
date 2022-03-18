using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface IQuizService: IBaseEntityService<App.BLL.DTO.Quiz, App.DAL.DTO.Quiz>, IQuizRepositoryCustom<App.DAL.DTO.Quiz>
{
    
}