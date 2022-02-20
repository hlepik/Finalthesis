namespace DAL.App.EF.Mappers;
public class BodyMeasurementsMapper : BaseMapper<DTO.BodyMeasurements, Domain.App.BodyMeasurements>,
        IBaseMapper<DTO.BodyMeasurements, Domain.App.BodyMeasurements>
    {
        public BodyMeasurementsMapper(IMapper mapper) : base(mapper)
        {
        }
    }
