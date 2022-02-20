using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class PatternMapper : BaseMapper<Pattern, Domain.App.Pattern>, IBaseMapper<Pattern, Domain.App.Pattern>
{
    public PatternMapper(IMapper mapper) : base(mapper)
    {
    }
}