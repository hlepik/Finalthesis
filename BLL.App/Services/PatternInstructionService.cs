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
    public async Task<IEnumerable<BLLAppDTO.PatternInstruction>?> GetAllByInstructionId(Guid id)
    {
        return (await ServiceRepository.GetAllByInstructionId(id))!.Select(x => Mapper.Map(x))!;

    }
    public void RemoveByInstructionId(Guid? id)
    {
        ServiceRepository.RemoveByInstructionId(id);
    }

}