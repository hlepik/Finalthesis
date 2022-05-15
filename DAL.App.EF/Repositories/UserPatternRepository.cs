using DAL.App.DTO;
using PublicApi.DTO.v1;
using UserPattern = DAL.App.DTO.UserPattern;

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
            .Include(p => p.Instruction)
            .Select(p => new DAL.App.DTO.UserPattern()
            {
                Id = p.Id,
                InstructionId = p.InstructionId,
                StepCount = p.StepCount,
                HasDone = p.HasDone,
                AppUserId = p.AppUserId,


            }).FirstOrDefaultAsync(m => m.InstructionId == id);

        return await resQuery;
    }

    public override async Task<IEnumerable<DAL.App.DTO.UserPattern>> GetAllAsync(Guid userId = default, bool noTracking = true)
    {

        var query = CreateQuery(userId, noTracking);


        var  resQuery = query
            .Include(x => x.Instruction).Select(x=> new DAL.App.DTO.UserPattern()
            {
                Id = x.Id,
                AppUserId = x.AppUserId,
                InstructionId = x.InstructionId,
                HasDone = x.HasDone,
                StepCount = x.StepCount,
                InstructionDescription = x.Instruction!.Description,
                InstructionTitle = x.Instruction.Name,
                InstructionCategory = x.Instruction.Category!.Name


            }).OrderBy(p => p.InstructionTitle);


        return await resQuery.ToListAsync();
    }
    public void RemoveByInstructionId(Guid? id)
    {
        var query = CreateQuery();

        query = query
            .Where(x => x.InstructionId == id || x.Id == id);

        foreach (var l in query)
        {
            RepoDbSet.Remove(l);
        }

    }
}