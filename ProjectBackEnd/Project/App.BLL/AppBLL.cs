using App.BLL.Services;
using App.BLL.Services.Identity;
using App.Contracts.BLL;
using App.Contracts.BLL.IdentityService;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using AutoMapper;
using Base.BLL;

namespace App.BLL;

public class AppBLL: BaseBLL<IAppUnitOfWork>, IAppBLL
{
    protected IMapper Mapper;

    public AppBLL(IAppUnitOfWork uow, IMapper mapper) : base(uow)
    {
        Mapper = mapper;
    }

    public IAllowedUserService AllowedUsers  => GetService<IAllowedUserService>(() => new AllowedUserService(Uow, Uow.AllowedUsers, Mapper));
    public IAnswerFileService AnswerFiles => GetService<IAnswerFileService>(() => new AnswerFileService(Uow, Uow.AnswerFiles, Mapper));
    public ICategoryService Categories => GetService<ICategoryService>(() => new CategoryService(Uow, Uow.Categories, Mapper));
    public IFileTypeService FileTypes => GetService<IFileTypeService>(() => new FileTypeService(Uow, Uow.FileTypes, Mapper));
    public IMaterialService Materials => GetService<IMaterialService>(() => new MaterialService(Uow, Uow.Materials, Mapper));
    public IQuizAnswerService QuizAnswers => GetService<IQuizAnswerService>(() => new QuizAnswerService(Uow, Uow.QuizAnswers, Mapper));
    public IQuizMaterialService QuizMaterials => GetService<IQuizMaterialService>(() => new QuizMaterialService(Uow, Uow.QuizMaterials, Mapper));
    public IQuizQuestionService QuizQuestions => GetService<IQuizQuestionService>(() => new QuizQuestionService(Uow, Uow.QuizQuestions, Mapper));
    public IQuizService Quizzes => GetService<IQuizService>(() => new QuizService(Uow, Uow.Quizzes, Mapper));
    public IQuizTypeService QuizTypes => GetService<IQuizTypeService>(() => new QuizTypeService(Uow, Uow.QuizTypes, Mapper));
    public ITakeAnswerService TakeAnswers => GetService<ITakeAnswerService>(() => new TakeAnswerService(Uow, Uow.TakeAnswers, Mapper));
    public ITakeService Takes => GetService<ITakeService>(() => new TakeService(Uow, Uow.Takes, Mapper));
    public IAppUserService AppUsers  => GetService<IAppUserService>(() => new AppUserService(Uow, Uow.AppUsers, Mapper));
}