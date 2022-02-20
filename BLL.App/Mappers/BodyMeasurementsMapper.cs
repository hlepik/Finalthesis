namespace BLL.App.Mappers;
public class BodyMeasurementsMapper: BaseMapper<BLL.App.DTO.BodyMeasurements, DAL.App.DTO.BodyMeasurements>, IBaseMapper<BLL.App.DTO.BodyMeasurements, DAL.App.DTO.BodyMeasurements>

    {
        public BodyMeasurementsMapper(IMapper mapper) : base(mapper)
        {
        }
    }
