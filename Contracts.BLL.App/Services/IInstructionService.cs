namespace Contracts.BLL.App.Services;
public interface IInstructionService:  IBaseEntityService< BLLAppDTO.Instruction, DALAppDTO.Instruction>,
        IInstructionRepositoryCustom<BLLAppDTO.Instruction>
    {

    }

