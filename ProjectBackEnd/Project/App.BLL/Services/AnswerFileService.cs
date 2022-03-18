using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class AnswerFileService:BaseEntityService<IAppUnitOfWork, IAnswerFileRepository, App.BLL.DTO.AnswerFile, App.DAL.DTO.AnswerFile>, IAnswerFileService
{
    public AnswerFileService(IAppUnitOfWork serviceUow, IAnswerFileRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new AnswerFileMapper(mapper))
    {
    }
}