using BLL.App.DTO;

namespace BLL.App.Services;

public class UserMeasurementsService: BaseEntityService<IAppUnitOfWork, IUserMeasurementsRepository, UserMeasurements, DAL.App.DTO.UserMeasurements>,
    IUserMeasurementsService
{
    public UserMeasurementsService(IAppUnitOfWork serviceUow, IUserMeasurementsRepository serviceRepository, IMapper mapper) : base(
        serviceUow, serviceRepository, new UserMeasurementsMapper(mapper))
    {
    }
}