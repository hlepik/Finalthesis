namespace BLL.App.Mappers;
public class UserPatternMapper: BaseMapper<BLL.App.DTO.UserPattern, DAL.App.DTO.UserPattern>, IBaseMapper<BLL.App.DTO.UserPattern, DAL.App.DTO.UserPattern>

    {
        public UserPatternMapper(IMapper mapper) : base(mapper)
        {
        }
    }
