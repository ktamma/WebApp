using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class QuizQuestionService:BaseEntityService<IAppUnitOfWork, IQuizQuestionRepository, App.BLL.DTO.QuizQuestion, App.DAL.DTO.QuizQuestion>, IQuizQuestionService
{
    public QuizQuestionService(IAppUnitOfWork serviceUow, IQuizQuestionRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new QuizQuestionMapper(mapper))
    {
    }
}