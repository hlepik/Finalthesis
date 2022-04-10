using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class ExtraSizeMapper : BaseMapper<ExtraSize, Domain.App.ExtraSize>, IBaseMapper<ExtraSize, Domain.App.ExtraSize>
{
    public ExtraSizeMapper(IMapper mapper) : base(mapper)
    {
    }
}