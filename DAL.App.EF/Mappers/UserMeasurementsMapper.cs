using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class UserMeasurementsMapper : BaseMapper<UserMeasurements, Domain.App.UserMeasurements>,
    IBaseMapper<UserMeasurements, Domain.App.UserMeasurements>
{
    public UserMeasurementsMapper(IMapper mapper) : base(mapper)
    {
    }
}