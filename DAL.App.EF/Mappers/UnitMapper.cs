using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class UnitMapper : BaseMapper<Unit, Domain.App.Unit>, IBaseMapper<Unit, Domain.App.Unit>
{
    public UnitMapper(IMapper mapper) : base(mapper)
    {
    }
}