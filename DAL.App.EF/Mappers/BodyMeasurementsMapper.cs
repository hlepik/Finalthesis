namespace DAL.App.EF.Mappers;
public class BodyMeasurementsMapper : BaseMapper<DTO.BodyMeasurements, Domain.App.BodyMeasurement>,
        IBaseMapper<DTO.BodyMeasurements, Domain.App.BodyMeasurement>
    {
        public BodyMeasurementsMapper(IMapper mapper) : base(mapper)
        {
        }
    }
