using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class TakeAnswerService:BaseEntityService<IAppUnitOfWork, ITakeAnswerRepository, App.BLL.DTO.TakeAnswer, App.DAL.DTO.TakeAnswer>, ITakeAnswerService
{
    public TakeAnswerService(IAppUnitOfWork serviceUow, ITakeAnswerRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new TakeAnswerMapper(mapper))
    {
    }
}