using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class InstructionMapper : BaseMapper<Instruction, Domain.App.Instruction>,
    IBaseMapper<Instruction, Domain.App.Instruction>
{
    public InstructionMapper(IMapper mapper) : base(mapper)
    {
    }
}