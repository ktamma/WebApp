using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class QuizTypeService:BaseEntityService<IAppUnitOfWork, IQuizTypeRepository, App.BLL.DTO.QuizType, App.DAL.DTO.QuizType>, IQuizTypeService
{
    public QuizTypeService(IAppUnitOfWork serviceUow, IQuizTypeRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new QuizTypeMapper(mapper))
    {
    }
}