using BLL.App.DTO.Identity;

namespace BLL.App.DTO.MappingProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BodyMeasurements, DAL.App.DTO.BodyMeasurements>().ReverseMap();
        CreateMap<Category, DAL.App.DTO.Category>().ReverseMap();
        CreateMap<Instruction, DAL.App.DTO.Instruction>().ReverseMap();
        CreateMap<ExtraSize, DAL.App.DTO.ExtraSize>().ReverseMap();
        CreateMap<PatternInstruction, DAL.App.DTO.PatternInstruction>().ReverseMap();
        CreateMap<SubCategory, DAL.App.DTO.SubCategory>().ReverseMap();
        CreateMap<Unit, DAL.App.DTO.Unit>().ReverseMap();
        CreateMap<UserPattern, DAL.App.DTO.UserPattern>().ReverseMap();
        CreateMap<MeasurementType, DAL.App.DTO.MeasurementType>().ReverseMap();
        CreateMap<UserMeasurements, DAL.App.DTO.UserMeasurements>().ReverseMap();

        CreateMap<AppUser, DAL.App.DTO.Identity.AppUser>().ReverseMap();
        CreateMap<AppRole, DAL.App.DTO.Identity.AppRole>().ReverseMap();
    }
}