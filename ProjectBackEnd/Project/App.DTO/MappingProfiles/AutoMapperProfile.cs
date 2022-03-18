using AutoMapper;

namespace App.DTO.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<App.DTO.v1.AllowedUser, App.BLL.DTO.AllowedUser>().ReverseMap();
            CreateMap<App.DTO.v1.AnswerFile, App.BLL.DTO.AnswerFile>().ReverseMap();
            CreateMap<App.DTO.v1.Category, App.BLL.DTO.Category>().ReverseMap();
            CreateMap<App.DTO.v1.FileType, App.BLL.DTO.FileType>().ReverseMap();
            CreateMap<App.DTO.v1.Material, App.BLL.DTO.Material>().ReverseMap();
            CreateMap<App.DTO.v1.Quiz, App.BLL.DTO.Quiz>().ReverseMap();
            CreateMap<App.DTO.v1.QuizAnswer, App.BLL.DTO.QuizAnswer>().ReverseMap();
            CreateMap<App.DTO.v1.QuizType, App.BLL.DTO.QuizType>().ReverseMap();
            CreateMap<App.DTO.v1.QuizMaterial, App.BLL.DTO.QuizMaterial>().ReverseMap();
            CreateMap<App.DTO.v1.QuizQuestion, App.BLL.DTO.QuizQuestion>().ReverseMap();
            CreateMap<App.DTO.v1.Take, App.BLL.DTO.Take>().ReverseMap();
            CreateMap<App.DTO.v1.TakeAnswer, App.BLL.DTO.TakeAnswer>().ReverseMap();
            
            // CreateMap<App.DAL.DTO.Identity.AppUser, App.Domain.Identity.AppUser>().ReverseMap();
            // CreateMap<App.DAL.DTO.Identity.AppRole, App.Domain.Identity.AppRole>().ReverseMap();

        }
    }
}