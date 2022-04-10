using DAL.App.DTO;

namespace DAL.App.EF.Repositories;

public class UserPatternRepository : BaseRepository<UserPattern, Domain.App.UserPattern, AppDbContext>,
    IUserPatternRepository
{
    public UserPatternRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new UserPatternMapper(mapper))
    {
    }
    
    public async Task<UserPattern?> GetByInstructionId(Guid id, Guid? userId = default,
        bool noTracking = true)
    {
        var query = CreateQuery(default, noTracking);

        var resQuery = query
            .Select(p => new DAL.App.DTO.UserPattern()
            {
                Id = p.Id,
                InstructionId = p.InstructionId,
                StepCount = p.StepCount,
                HasDone = p.HasDone,
                AppUserId = p.AppUserId

            }).FirstOrDefaultAsync(m => m.InstructionId == id);

        return await resQuery;
    }
}