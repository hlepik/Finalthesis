using BLL.App.DTO;

namespace BLL.App.Services;

public class BodyMeasurementsService :
    BaseEntityService<IAppUnitOfWork, IBodyMeasurementsRepository, BodyMeasurements, DAL.App.DTO.BodyMeasurements>,
    IBodyMeasurementsService
{
    public BodyMeasurementsService(IAppUnitOfWork serviceUow, IBodyMeasurementsRepository serviceRepository,
        IMapper mapper) : base(
        serviceUow, serviceRepository, new BodyMeasurementsMapper(mapper))
    {
    }
}