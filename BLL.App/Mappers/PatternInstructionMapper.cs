using BLL.App.DTO;

namespace BLL.App.Mappers;

public class PatternInstructionMapper : BaseMapper<PatternInstruction, DAL.App.DTO.PatternInstruction>,
    IBaseMapper<PatternInstruction, DAL.App.DTO.PatternInstruction>

{
    public PatternInstructionMapper(IMapper mapper) : base(mapper)
    {
    }
}