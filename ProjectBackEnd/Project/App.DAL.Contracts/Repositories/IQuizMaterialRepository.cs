using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface IQuizMaterialRepository: IBaseRepository<QuizMaterial>
{
    
}public interface IQuizMaterialRepositoryCustom<TEntity>
{
}