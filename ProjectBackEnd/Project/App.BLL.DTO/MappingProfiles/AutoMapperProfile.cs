using AutoMapper;

namespace App.BLL.DTO.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AllowedUser, App.DAL.DTO.AllowedUser>().ReverseMap();
            CreateMap<AnswerFile, App.DAL.DTO.AnswerFile>().ReverseMap();
            CreateMap<Category, App.DAL.DTO.Category>().ReverseMap();
            CreateMap<FileType, App.DAL.DTO.FileType>().ReverseMap();
            CreateMap<Material, App.DAL.DTO.Material>().ReverseMap();
            CreateMap<Quiz, App.DAL.DTO.Quiz>().ReverseMap();           
            CreateMap<Quiz, App.DAL.DTO.QuizType>().ReverseMap();

            
            CreateMap<QuizAnswer, App.DAL.DTO.QuizAnswer>().ReverseMap();
            CreateMap<QuizMaterial, App.DAL.DTO.QuizMaterial>().ReverseMap();
            CreateMap<QuizQuestion, App.DAL.DTO.QuizQuestion>().ReverseMap();
            CreateMap<Take, App.DAL.DTO.Take>().ReverseMap();
            CreateMap<TakeAnswer, App.DAL.DTO.TakeAnswer>().ReverseMap();

            CreateMap<Identity.AppUser, App.DAL.DTO.Identity.AppUser>().ReverseMap();
            CreateMap<Identity.AppRole, App.DAL.DTO.Identity.AppRole>().ReverseMap();
        }
    }
}