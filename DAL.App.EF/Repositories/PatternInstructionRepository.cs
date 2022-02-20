namespace DAL.App.EF.Repositories;
public class PatternInstructionRepository :
        BaseRepository<DAL.App.DTO.PatternInstruction, Domain.App.PatternInstruction, AppDbContext>,
        IPatternInstructionRepository
    {

        public PatternInstructionRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new PatternInstructionMapper(mapper))
        {
        }
    }
