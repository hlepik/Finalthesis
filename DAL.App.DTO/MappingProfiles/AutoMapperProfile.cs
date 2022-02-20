using Domain.App;

namespace DAL.App.DTO.MappingProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BodyMeasurements, BodyMeasurement>().ReverseMap();
        CreateMap<Category, Domain.App.Category>().ReverseMap();
        CreateMap<Instruction, Domain.App.Instruction>().ReverseMap();
        CreateMap<PatternInstruction, Domain.App.PatternInstruction>().ReverseMap();
        CreateMap<Pattern, Domain.App.Pattern>().ReverseMap();
        CreateMap<Picture, Domain.App.Picture>().ReverseMap();
        CreateMap<SubCategory, Domain.App.SubCategory>().ReverseMap();
        CreateMap<Unit, Domain.App.Unit>().ReverseMap();
        CreateMap<UserPattern, Domain.App.UserPattern>().ReverseMap();
        CreateMap<AppUser, AppUser>().ReverseMap();
        CreateMap<AppRole, AppRole>().ReverseMap();
    }
}