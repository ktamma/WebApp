using AutoMapper;

namespace App.DAL.DTO.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<App.DAL.DTO.AllowedUser, App.Domain.AllowedUser>().ReverseMap();
            CreateMap<App.DAL.DTO.AnswerFile, App.Domain.AnswerFile>().ReverseMap();
            CreateMap<App.DAL.DTO.Category, App.Domain.Category>().ReverseMap();
            CreateMap<App.DAL.DTO.FileType, App.Domain.FileType>().ReverseMap();
            CreateMap<App.DAL.DTO.Material, App.Domain.Material>().ReverseMap();
            CreateMap<App.DAL.DTO.Quiz, App.Domain.Quiz>().ReverseMap();
            CreateMap<App.DAL.DTO.QuizAnswer, App.Domain.QuizAnswer>().ReverseMap();
            CreateMap<App.DAL.DTO.QuizType, App.Domain.QuizType>().ReverseMap();
            CreateMap<App.DAL.DTO.QuizMaterial, App.Domain.QuizMaterial>().ReverseMap();
            CreateMap<App.DAL.DTO.QuizQuestion, App.Domain.QuizQuestion>().ReverseMap();
            CreateMap<App.DAL.DTO.Take, App.Domain.Take>().ReverseMap();
            CreateMap<App.DAL.DTO.TakeAnswer, App.Domain.TakeAnswer>().ReverseMap();
            
            CreateMap<App.DAL.DTO.Identity.AppUser, App.Domain.Identity.AppUser>().ReverseMap();
            CreateMap<App.DAL.DTO.Identity.AppRole, App.Domain.Identity.AppRole>().ReverseMap();

        }
    }
}