namespace BLL.App.Services;
public class PatternService: BaseEntityService<IAppUnitOfWork, IPatternRepository, BLLAppDTO.Pattern, DALAppDTO.Pattern>, IPatternService
    {
        public PatternService(IAppUnitOfWork serviceUow, IPatternRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PatternMapper(mapper))
        {
        }

    }
