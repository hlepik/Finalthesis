using BLL.App.DTO;

namespace BLL.App.Services;

public class InstructionService :
    BaseEntityService<IAppUnitOfWork, IInstructionRepository, Instruction, DAL.App.DTO.Instruction>, IInstructionService
{
    public InstructionService(IAppUnitOfWork serviceUow, IInstructionRepository serviceRepository, IMapper mapper) :
        base(serviceUow, serviceRepository, new InstructionMapper(mapper))
    {
    }
}