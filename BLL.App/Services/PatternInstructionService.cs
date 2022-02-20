namespace BLL.App.Services;
public class PatternInstructionService: BaseEntityService<IAppUnitOfWork, IPatternInstructionRepository, BLLAppDTO.PatternInstruction, DALAppDTO.PatternInstruction>, IPatternInstructionService
    {
        public PatternInstructionService(IAppUnitOfWork serviceUow, IPatternInstructionRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PatternInstructionMapper(mapper))
        {
        }

    }
