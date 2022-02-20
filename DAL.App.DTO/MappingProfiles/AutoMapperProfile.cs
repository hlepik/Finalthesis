namespace DAL.App.DTO.MappingProfiles;
public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DAL.App.DTO.BodyMeasurements, Domain.App.BodyMeasurement>().ReverseMap();
            CreateMap<DAL.App.DTO.Category, Domain.App.Category>().ReverseMap();
            CreateMap<DAL.App.DTO.Instruction, Domain.App.Instruction>().ReverseMap();
            CreateMap<DAL.App.DTO.PatternInstruction, Domain.App.PatternInstruction>().ReverseMap();
            CreateMap<DAL.App.DTO.Pattern, Domain.App.Pattern>().ReverseMap();
            CreateMap<DAL.App.DTO.Picture, Domain.App.Picture>().ReverseMap();
            CreateMap<DAL.App.DTO.SubCategory, Domain.App.SubCategory>().ReverseMap();
            CreateMap<DAL.App.DTO.Unit, Domain.App.Unit>().ReverseMap();
            CreateMap<DAL.App.DTO.UserPattern, Domain.App.UserPattern>().ReverseMap();
            CreateMap<DAL.App.DTO.Identity.AppUser, AppUser>().ReverseMap();
            CreateMap<DAL.App.DTO.Identity.AppRole, AppRole>().ReverseMap();

        }
    }
