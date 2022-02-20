namespace DAL.App.EF.Mappers;
public class PatternMapper: BaseMapper<DTO.Pattern, Domain.App.Pattern>, IBaseMapper<DTO.Pattern, Domain.App.Pattern>
    {
        public PatternMapper(IMapper mapper) : base(mapper)
        {
        }
    }
