using BLL.App.DTO;

namespace BLL.App.Services;

public class MeasurementTypeService: BaseEntityService<IAppUnitOfWork, IMeasurementTypeRepository, MeasurementType, DAL.App.DTO.MeasurementType>,
    IMeasurementTypeService
{
    public MeasurementTypeService(IAppUnitOfWork serviceUow, IMeasurementTypeRepository serviceRepository, IMapper mapper) : base(
        serviceUow, serviceRepository, new MeasurementTypeMapper(mapper))
    {
    }
}