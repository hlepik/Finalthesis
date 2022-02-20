using BLL.App.DTO;

namespace BLL.App.Services;

public class UserPatternService :
    BaseEntityService<IAppUnitOfWork, IUserPatternRepository, UserPattern, DAL.App.DTO.UserPattern>, IUserPatternService
{
    public UserPatternService(IAppUnitOfWork serviceUow, IUserPatternRepository serviceRepository, IMapper mapper) :
        base(serviceUow, serviceRepository, new UserPatternMapper(mapper))
    {
    }
}