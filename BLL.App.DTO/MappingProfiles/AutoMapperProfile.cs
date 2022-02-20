using BLL.App.DTO.Identity;

namespace BLL.App.DTO.MappingProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BodyMeasurements, DAL.App.DTO.BodyMeasurements>().ReverseMap();
        CreateMap<Category, DAL.App.DTO.Category>().ReverseMap();
        CreateMap<Instruction, DAL.App.DTO.Instruction>().ReverseMap();
        CreateMap<Pattern, DAL.App.DTO.Pattern>().ReverseMap();
        CreateMap<PatternInstruction, DAL.App.DTO.PatternInstruction>().ReverseMap();
        CreateMap<Picture, DAL.App.DTO.Picture>().ReverseMap();
        CreateMap<SubCategory, DAL.App.DTO.SubCategory>().ReverseMap();
        CreateMap<Unit, DAL.App.DTO.Unit>().ReverseMap();
        CreateMap<UserPattern, DAL.App.DTO.UserPattern>().ReverseMap();
        CreateMap<AppUser, DAL.App.DTO.Identity.AppUser>().ReverseMap();
        CreateMap<AppRole, DAL.App.DTO.Identity.AppRole>().ReverseMap();
    }
}