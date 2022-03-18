using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface ITakeAnswerService: IBaseEntityService<App.BLL.DTO.TakeAnswer, App.DAL.DTO.TakeAnswer>, ITakeAnswerRepositoryCustom<App.DAL.DTO.TakeAnswer>
{
    
}