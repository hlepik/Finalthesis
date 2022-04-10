using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class MeasurementTypeMapper: BaseMapper<MeasurementType, Domain.App.MeasurementType>,
    IBaseMapper<MeasurementType, Domain.App.MeasurementType>
{
    public MeasurementTypeMapper(IMapper mapper) : base(mapper)
    {
    }
}