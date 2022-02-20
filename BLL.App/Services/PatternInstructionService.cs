using BLL.App.DTO;

namespace BLL.App.Services;

public class PatternInstructionService :
    BaseEntityService<IAppUnitOfWork, IPatternInstructionRepository, PatternInstruction,
        DAL.App.DTO.PatternInstruction>, IPatternInstructionService
{
    public PatternInstructionService(IAppUnitOfWork serviceUow, IPatternInstructionRepository serviceRepository,
        IMapper mapper) : base(serviceUow, serviceRepository, new PatternInstructionMapper(mapper))
    {
    }
}