using System.Collections;
using BLL.App.DTO;
using ExtraSize = DAL.App.DTO.ExtraSize;

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
    public async Task<BLLAppDTO.BodyMeasurements?> GetByInstructionId(Guid id, Guid userId, bool noTracking = true)
    {
        return Mapper.Map(await ServiceRepository.GetByInstructionId(id,  userId, noTracking));

    }

}