using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using App.DAL.Contracts.Repositories.Identity;
using App.DAL.Repositories;
using App.DAL.Repositories.Identity;
using App.Domain;
using AutoMapper;
using Base.DAL.EF;

namespace App.DAL
{
    public class AppUnitOfWork : BaseUnitOfWork<ApplicationDbContext>, IAppUnitOfWork
    {
        protected IMapper? Mapper;

        public AppUnitOfWork(ApplicationDbContext uowDbContext, IMapper mapper) : base(uowDbContext)
        {
        }

        // public IAppUserRepository AppUser => GetRepository(() => new AppUserRepository(UowDbContext));

        public IAllowedUserRepository AllowedUsers => GetRepository(() => new AllowedUserRepository(UowDbContext, Mapper!));
        public IAnswerFileRepository AnswerFiles => GetRepository(() => new AnswerFileRepository(UowDbContext, Mapper!));
        public ICategoryRepository Categories => GetRepository(() => new CategoryRepository(UowDbContext, Mapper!));
        public IFileTypeRepository FileTypes => GetRepository(() => new FileTypeRepository(UowDbContext, Mapper!));
        public IMaterialRepository Materials => GetRepository(() => new MaterialRepository(UowDbContext, Mapper!));
        public IQuizAnswerRepository QuizAnswers => GetRepository(() => new QuizAnswerRepository(UowDbContext, Mapper!));
        public IQuizMaterialRepository QuizMaterials => GetRepository(() => new QuizMaterialRepository(UowDbContext, Mapper!));
        public IQuizQuestionRepository QuizQuestions => GetRepository(() => new QuizQuestionRepository(UowDbContext, Mapper!));
        public IQuizRepository Quizzes => GetRepository(() => new QuizRepository(UowDbContext, Mapper!));
        public IQuizTypeRepository QuizTypes => GetRepository(() => new QuizTypeRepository(UowDbContext, Mapper!));
        public ITakeAnswerRepository TakeAnswers => GetRepository(() => new TakeAnswerRepository(UowDbContext, Mapper!));
        public ITakeRepository Takes => GetRepository(() => new TakeRepository(UowDbContext, Mapper!));
        public IAppUserRepository AppUsers => GetRepository(() => new AppUserRepository(UowDbContext, Mapper!));
    }
}