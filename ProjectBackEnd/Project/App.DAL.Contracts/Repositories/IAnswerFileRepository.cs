using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface IAnswerFileRepository: IBaseRepository<AnswerFile>
{
    
}
public interface IAnswerFileRepositoryCustom<TEntity>
{
}