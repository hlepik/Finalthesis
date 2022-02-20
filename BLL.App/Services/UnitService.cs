namespace BLL.App.Services;
public class UnitService: BaseEntityService<IAppUnitOfWork, IUnitRepository, BLLAppDTO.Unit, DALAppDTO.Unit>, IUnitService
    {
        public UnitService(IAppUnitOfWork serviceUow, IUnitRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new UnitMapper(mapper))
        {
        }

    }
