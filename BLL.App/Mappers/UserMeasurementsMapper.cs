using BLL.App.DTO;

namespace BLL.App.Mappers;

public class UserMeasurementsMapper: BaseMapper<UserMeasurements, DAL.App.DTO.UserMeasurements>,
    IBaseMapper<UserMeasurements, DAL.App.DTO.UserMeasurements>

{
    public UserMeasurementsMapper(IMapper mapper) : base(mapper)
    {
    }
}