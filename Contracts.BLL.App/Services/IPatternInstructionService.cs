namespace Contracts.BLL.App.Services;

public interface IPatternInstructionService:  IBaseEntityService< BLLAppDTO.PatternInstruction, DALAppDTO.PatternInstruction>,
        IPatternInstructionRepositoryCustom<BLLAppDTO.PatternInstruction>
    {

    }

