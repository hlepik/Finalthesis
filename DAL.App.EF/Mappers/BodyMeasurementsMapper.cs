using DAL.App.DTO;
using Domain.App;

namespace DAL.App.EF.Mappers;

public class BodyMeasurementsMapper : BaseMapper<BodyMeasurements, BodyMeasurement>,
    IBaseMapper<BodyMeasurements, BodyMeasurement>
{
    public BodyMeasurementsMapper(IMapper mapper) : base(mapper)
    {
    }
}