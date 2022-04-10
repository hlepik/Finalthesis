using DAL.App.DTO;

namespace DAL.App.EF.Repositories;

public class PatternInstructionRepository :
    BaseRepository<PatternInstruction, Domain.App.PatternInstruction, AppDbContext>,
    IPatternInstructionRepository
{
    public PatternInstructionRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new PatternInstructionMapper(mapper))
    {
    }
    public async Task<IEnumerable<DAL.App.DTO.PatternInstruction>?> GetAllByInstructionId(Guid id)
    {
        var query = CreateQuery(default);


        var resQuery = query
            .Select(p => new DAL.App.DTO.PatternInstruction()
            {
                Id = p.Id,
                InstructionId = p.InstructionId,
                Step = p.Step,
                Description = p.Description,
                Title = p.Title,
                PictureName = p.PictureName,
                
             

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
            string Path = "wwwroot/Pictures/" + l.PictureName;
            FileInfo file = new FileInfo(Path);
            if (file.Exists)
            {
                file.Delete();
            }
            RepoDbSet.Remove(l);
        }

    }
}