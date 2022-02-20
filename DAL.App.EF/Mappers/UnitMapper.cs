namespace DAL.App.EF.Mappers;
public class UnitMapper: BaseMapper<DTO.Unit, Domain.App.Unit>, IBaseMapper<DTO.Unit, Domain.App.Unit>
    {
        public UnitMapper(IMapper mapper) : base(mapper)
        {
        }
    }
