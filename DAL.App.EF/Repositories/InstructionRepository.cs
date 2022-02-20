namespace DAL.App.EF.Repositories;
public class InstructionRepository : BaseRepository<DAL.App.DTO.Instruction, Domain.App.Instruction, AppDbContext>,
        IInstructionRepository
    {

        public InstructionRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new InstructionMapper(mapper))
        {
        }
    }
