namespace BLL.App.Services;
public class InstructionService: BaseEntityService<IAppUnitOfWork, IInstructionRepository, BLLAppDTO.Instruction, DALAppDTO.Instruction>, IInstructionService
    {
        public InstructionService(IAppUnitOfWork serviceUow, IInstructionRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new InstructionMapper(mapper))
        {
        }
    }
