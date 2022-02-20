namespace DAL.App.EF.Mappers;
public class InstructionMapper: BaseMapper<DTO.Instruction, Domain.App.Instruction>, IBaseMapper<DTO.Instruction, Domain.App.Instruction>
    {
        public InstructionMapper(IMapper mapper) : base(mapper)
        {
        }
    }
