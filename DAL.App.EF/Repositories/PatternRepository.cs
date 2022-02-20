using DAL.App.DTO;

namespace DAL.App.EF.Repositories;

public class PatternRepository : BaseRepository<Pattern, Domain.App.Pattern, AppDbContext>,
    IPatternRepository
{
    public PatternRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new PatternMapper(mapper))
    {
    }
}