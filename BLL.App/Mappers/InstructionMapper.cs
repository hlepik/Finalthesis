namespace BLL.App.Mappers;
public class InstructionMapper: BaseMapper<BLL.App.DTO.Instruction, DAL.App.DTO.Instruction>, IBaseMapper<BLL.App.DTO.Instruction, DAL.App.DTO.Instruction>

    {
        public InstructionMapper(IMapper mapper) : base(mapper)
        {
        }
    }
