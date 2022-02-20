namespace BLL.App.Services;
public class BodyMeasurementsService :
        BaseEntityService<IAppUnitOfWork, IBodyMeasurementsRepository, BLLAppDTO.BodyMeasurements, DALAppDTO.BodyMeasurements>, IBodyMeasurementsService
    {
        public BodyMeasurementsService(IAppUnitOfWork serviceUow, IBodyMeasurementsRepository serviceRepository, IMapper mapper) : base(
            serviceUow, serviceRepository, new BodyMeasurementsMapper(mapper))
        {
        }
    }
