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
    public async Task<BLLAppDTO.BodyMeasurements?> FirstOrDefaultUserMeasurementsAsync(Guid id,  bool noTracking = true)
    {
        return Mapper.Map(await ServiceRepository.FirstOrDefaultUserMeasurementsAsync(id,  noTracking));

    }
}