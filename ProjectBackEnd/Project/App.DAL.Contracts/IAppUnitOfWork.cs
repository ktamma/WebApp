using App.DAL.Contracts.Repositories;
using App.DAL.Contracts.Repositories.Identity;
using Base.Contracts.DAL;

namespace App.DAL.Contracts
{
    public interface IAppUnitOfWork: IBaseUnitOfWork
    {
        IAllowedUserRepository AllowedUsers { get; }
        IAnswerFileRepository AnswerFiles { get; }
        ICategoryRepository Categories { get; }
        IFileTypeRepository FileTypes { get; }
        IMaterialRepository Materials { get; }
        IQuizAnswerRepository QuizAnswers { get; }
        IQuizMaterialRepository QuizMaterials { get; }
        IQuizQuestionRepository QuizQuestions { get; }
        IQuizRepository Quizzes { get; }
        IQuizTypeRepository QuizTypes { get; }
        ITakeAnswerRepository TakeAnswers { get; }
        ITakeRepository Takes { get; }
        IAppUserRepository AppUsers { get; }
        
    }
}