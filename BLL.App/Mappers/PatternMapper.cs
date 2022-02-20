using BLL.App.DTO;

namespace BLL.App.Mappers;

public class PatternMapper : BaseMapper<Pattern, DAL.App.DTO.Pattern>, IBaseMapper<Pattern, DAL.App.DTO.Pattern>

{
    public PatternMapper(IMapper mapper) : base(mapper)
    {
    }
}