using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IInstructionService : IBaseEntityService<Instruction, global::DAL.App.DTO.Instruction>,
    IInstructionRepositoryCustom<Instruction>
{
}