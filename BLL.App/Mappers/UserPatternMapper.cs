using BLL.App.DTO;

namespace BLL.App.Mappers;

public class UserPatternMapper : BaseMapper<UserPattern, DAL.App.DTO.UserPattern>,
    IBaseMapper<UserPattern, DAL.App.DTO.UserPattern>

{
    public UserPatternMapper(IMapper mapper) : base(mapper)
    {
    }
}