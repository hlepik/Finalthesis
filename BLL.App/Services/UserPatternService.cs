namespace BLL.App.Services;
public class UserPatternService: BaseEntityService<IAppUnitOfWork, IUserPatternRepository, BLLAppDTO.UserPattern, DALAppDTO.UserPattern>, IUserPatternService
    {

        public UserPatternService(IAppUnitOfWork serviceUow, IUserPatternRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new UserPatternMapper(mapper))
        {
        }
    }
