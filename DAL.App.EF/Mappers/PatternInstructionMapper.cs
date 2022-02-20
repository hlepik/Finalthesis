using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class PatternInstructionMapper : BaseMapper<PatternInstruction, Domain.App.PatternInstruction>,
    IBaseMapper<PatternInstruction, Domain.App.PatternInstruction>
{
    public PatternInstructionMapper(IMapper mapper) : base(mapper)
    {
    }
}