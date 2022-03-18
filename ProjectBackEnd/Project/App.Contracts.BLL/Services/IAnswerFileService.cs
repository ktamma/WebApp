using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface IAnswerFileService: IBaseEntityService<App.BLL.DTO.AnswerFile, App.DAL.DTO.AnswerFile>, IAnswerFileRepositoryCustom<App.DAL.DTO.AnswerFile>
{
    
}