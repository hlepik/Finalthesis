using BLL.App.DTO;

namespace BLL.App.Mappers;

public class BodyMeasurementsMapper : BaseMapper<BodyMeasurements, DAL.App.DTO.BodyMeasurements>,
    IBaseMapper<BodyMeasurements, DAL.App.DTO.BodyMeasurements>

{
    public BodyMeasurementsMapper(IMapper mapper) : base(mapper)
    {
    }
}