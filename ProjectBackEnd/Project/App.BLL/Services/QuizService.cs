using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class QuizService:BaseEntityService<IAppUnitOfWork, IQuizRepository, App.BLL.DTO.Quiz, App.DAL.DTO.Quiz>, IQuizService
{
    public QuizService(IAppUnitOfWork serviceUow, IQuizRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new QuizMapper(mapper))
    {
    }
}