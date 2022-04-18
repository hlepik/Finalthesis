using DAL.App.DTO;

namespace DAL.App.EF.Repositories;

public class ExtraSizeRepository : BaseRepository<ExtraSize, Domain.App.ExtraSize, AppDbContext>,
    IExtraSizeRepository
{
    public ExtraSizeRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new ExtraSizeMapper(mapper))
    {
    }
    public async Task<IEnumerable<DAL.App.DTO.ExtraSize>?> GetAllByInstructionId(Guid id)
    {
        var query = CreateQuery(default);


        var resQuery = query
            .Select(p => new DAL.App.DTO.ExtraSize()
            {
                Id = p.Id,
                InstructionId = p.InstructionId,
                Extra = p.Extra,
                Name = p.Name

            }).Where(p => p.InstructionId == id);

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
