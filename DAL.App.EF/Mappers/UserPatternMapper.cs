namespace DAL.App.EF.Mappers;
public class UserPatternMapper: BaseMapper<DTO.UserPattern, Domain.App.UserPattern>, IBaseMapper<DTO.UserPattern, Domain.App.UserPattern>
    {
        public UserPatternMapper(IMapper mapper) : base(mapper)
        {
        }
    }
