using BLL.App.DTO;

namespace BLL.App.Services;

public class PatternService : BaseEntityService<IAppUnitOfWork, IPatternRepository, Pattern, DAL.App.DTO.Pattern>,
    IPatternService
{
    public PatternService(IAppUnitOfWork serviceUow, IPatternRepository serviceRepository, IMapper mapper) : base(
        serviceUow, serviceRepository, new PatternMapper(mapper))
    {
    }
}