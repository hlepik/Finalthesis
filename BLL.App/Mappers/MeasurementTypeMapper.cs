namespace BLL.App.Mappers;

public class MeasurementTypeMapper : BaseMapper<DTO.MeasurementType, DAL.App.DTO.MeasurementType>,
    IBaseMapper<DTO.MeasurementType, DAL.App.DTO.MeasurementType>

{
    public MeasurementTypeMapper(IMapper mapper) : base(mapper)
    {
    }
}