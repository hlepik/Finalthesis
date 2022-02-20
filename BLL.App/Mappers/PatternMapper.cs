namespace BLL.App.Mappers;
public class PatternMapper: BaseMapper<BLL.App.DTO.Pattern, DAL.App.DTO.Pattern>, IBaseMapper<BLL.App.DTO.Pattern, DAL.App.DTO.Pattern>

    {
        public PatternMapper(IMapper mapper) : base(mapper)
        {
        }
    }
