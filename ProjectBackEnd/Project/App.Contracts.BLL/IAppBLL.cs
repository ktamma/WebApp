using App.Contracts.BLL.IdentityService;
using App.Contracts.BLL.Services;
using Base.Contracts.BLL;

namespace App.Contracts.BLL;

public interface IAppBLL: IBaseBLL
{
    IAllowedUserService AllowedUsers { get; }
    IAnswerFileService AnswerFiles { get; }
    ICategoryService Categories { get; }
    IFileTypeService FileTypes { get; }
    IMaterialService Materials { get; }
    IQuizAnswerService QuizAnswers { get; }
    IQuizMaterialService QuizMaterials { get; }
    IQuizQuestionService QuizQuestions { get; }
    IQuizService Quizzes { get; }
    IQuizTypeService QuizTypes { get; }
    ITakeAnswerService TakeAnswers { get; }
    ITakeService Takes { get; }
    IAppUserService AppUsers { get; }
}