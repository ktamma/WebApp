using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class QuizAnswerService:BaseEntityService<IAppUnitOfWork, IQuizAnswerRepository, App.BLL.DTO.QuizAnswer, App.DAL.DTO.QuizAnswer>, IQuizAnswerService
{
    public QuizAnswerService(IAppUnitOfWork serviceUow, IQuizAnswerRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new QuizAnswerMapper(mapper))
    {
    }
}