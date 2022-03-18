using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface IFileTypeRepository: IBaseRepository<FileType>
{
    
}public interface IFileTypeRepositoryCustom<TEntity>
{
}