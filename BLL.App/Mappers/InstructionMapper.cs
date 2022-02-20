using BLL.App.DTO;

namespace BLL.App.Mappers;

public class InstructionMapper : BaseMapper<Instruction, DAL.App.DTO.Instruction>,
    IBaseMapper<Instruction, DAL.App.DTO.Instruction>

{
    public InstructionMapper(IMapper mapper) : base(mapper)
    {
    }
}