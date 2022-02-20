namespace DAL.App.EF.Mappers;
public class PatternInstructionMapper: BaseMapper<DTO.PatternInstruction, Domain.App.PatternInstruction>, IBaseMapper<DTO.PatternInstruction, Domain.App.PatternInstruction>
    {
        public PatternInstructionMapper(IMapper mapper) : base(mapper)
        {
        }
    }
