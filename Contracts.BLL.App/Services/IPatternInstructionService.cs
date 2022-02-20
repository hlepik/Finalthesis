using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IPatternInstructionService :
    IBaseEntityService<PatternInstruction, global::DAL.App.DTO.PatternInstruction>,
    IPatternInstructionRepositoryCustom<PatternInstruction>
{
}