using BLL.App.DTO;

namespace BLL.App.Services;

public class UserPatternService :
    BaseEntityService<IAppUnitOfWork, IUserPatternRepository, UserPattern, DAL.App.DTO.UserPattern>, IUserPatternService
{
    public UserPatternService(IAppUnitOfWork serviceUow, IUserPatternRepository serviceRepository, IMapper mapper) :
        base(serviceUow, serviceRepository, new UserPatternMapper(mapper))
    {
    }
    public async Task<UserPattern?> GetByInstructionId(Guid id, Guid? userId,  bool noTracking = true)
    {
        return Mapper.Map(await ServiceRepository.GetByInstructionId(id, userId, noTracking))!;
    }
}