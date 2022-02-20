using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class UserPatternMapper : BaseMapper<UserPattern, Domain.App.UserPattern>,
    IBaseMapper<UserPattern, Domain.App.UserPattern>
{
    public UserPatternMapper(IMapper mapper) : base(mapper)
    {
    }
}