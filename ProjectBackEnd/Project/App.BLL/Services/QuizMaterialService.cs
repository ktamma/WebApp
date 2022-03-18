using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class QuizMaterialService:BaseEntityService<IAppUnitOfWork, IQuizMaterialRepository, App.BLL.DTO.QuizMaterial, App.DAL.DTO.QuizMaterial>, IQuizMaterialService
{
    public QuizMaterialService(IAppUnitOfWork serviceUow, IQuizMaterialRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new QuizMaterialMapper(mapper))
    {
    }
}