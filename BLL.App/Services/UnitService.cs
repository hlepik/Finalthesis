using BLL.App.DTO;

namespace BLL.App.Services;

public class UnitService : BaseEntityService<IAppUnitOfWork, IUnitRepository, Unit, DAL.App.DTO.Unit>, IUnitService
{
    public UnitService(IAppUnitOfWork serviceUow, IUnitRepository serviceRepository, IMapper mapper) : base(serviceUow,
        serviceRepository, new UnitMapper(mapper))
    {
    }
}