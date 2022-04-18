using System.Linq;
using DAL.App.DTO;
using Microsoft.AspNetCore.Http.Internal;

namespace DAL.App.EF.Repositories;

public class InstructionRepository : BaseRepository<Instruction, Domain.App.Instruction, AppDbContext>,
    IInstructionRepository
{
    public InstructionRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new InstructionMapper(mapper))
    {
    }
    public async Task<IEnumerable<DAL.App.DTO.Instruction>> GetAllByCategory(Guid id,  bool noTracking = true)
    {
        var query = CreateQuery(default, noTracking);


        var resQuery = query
            .Include(p => p.Category)
            .Select(p => new DAL.App.DTO.Instruction()
            {
                Id = p.Id,
                DateAdded = p.DateAdded,
                MainPicture = p.MainPicture,
                CategoryId = p.CategoryId,
                MainPictureName = p.MainPictureName,
                Name = p.Name,
                Description = p.Description
                

            }).Where(p => p.CategoryId == id);

        return await resQuery.ToListAsync();
    }
    public override async Task<IEnumerable<DAL.App.DTO.Instruction>> GetAllAsync(Guid userId = default, bool noTracking = true)
    {

        var query = CreateQuery(userId, noTracking);

        
           var  resQuery = query
                .Include(x => x.Category).Select(x=> new Instruction()
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    TotalStep = x.TotalStep + 1,
                    Description = x.Description,
                    DateAdded = x.DateAdded,
                    CategoryName = x.Category!.Name,
                    MainPictureName = x.MainPictureName,
                    Name = x.Name,
                    FileName = x.FileName
                    
                }).OrderBy(p => p.DateAdded);


        return await resQuery.ToListAsync();
    }
    public async Task<IEnumerable<DAL.App.DTO.Instruction>> GetLastInsertedAsync(Guid userId = default, bool noTracking = true)
    {

        var query = CreateQuery(userId, noTracking);

        
        var  resQuery = query
            .Include(x => x.Category).Select(x=> new Instruction()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                TotalStep = x.TotalStep,
                Description = x.Description,
                DateAdded = x.DateAdded,
                CategoryName = x.Category!.Name,
                MainPictureName = x.MainPictureName,
                Name = x.Name,
                FileName = x.FileName
                    
            }).OrderBy(p => p.DateAdded).Take(10);


        return await resQuery.ToListAsync();
    }

    public async Task<Instruction?> FirstOrDefaultDtoAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(default, noTracking);


        var resQuery = query
            .Select(p => new DAL.App.DTO.Instruction()
            {

                Id = p.Id,
                MainPicture = p.MainPicture,
                MainPictureName = p.MainPictureName,
                FileName = p.FileName,
                Name = p.Name,
                PatternFile = p.PatternFile,
                Description = p.Description,
                DateAdded = p.DateAdded
               

            }).FirstOrDefaultAsync(m => m.Id == id);

        return await resQuery;
    }

    public async Task<IEnumerable<DAL.App.DTO.Instruction?>> GetSearchResult(string searchInput, Guid? categoryId)
    {

        var query = CreateQuery();

        if (categoryId != Guid.Empty)
        {
            query = query.Where(x => x.CategoryId == categoryId);
        }
        
        var  resQuery = query
            .Include(x => x.Category).Select(x=> new Instruction()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                TotalStep = x.TotalStep,
                Description = x.Description,
                DateAdded = x.DateAdded,
                CategoryName = x.Category!.Name,
                MainPictureName = x.MainPictureName,
                Name = x.Name,
                FileName = x.FileName
                    
            }).Where(x => x.Name.Contains(searchInput) || x.Description.Contains(searchInput));


        return await resQuery.ToListAsync();
    }

    public void CalculateMeasurements(Guid id)
    {
        var mar = "olen siin";
        var query = CreateQuery(default);

        query = query.Include(x => x.PatternInstructions);

        var resQuery = query
            .Select(p => new DAL.App.DTO.Instruction()
            {
                Id = p.Id,
                Name = p.Name,
                DateAdded = p.DateAdded,
                CategoryId = p.CategoryId,
                Description = p.Description,
                TotalStep = p.TotalStep,
                FileName = p.FileName,
                MainPictureName = p.MainPictureName,

          
            }).FirstOrDefaultAsync(m => m.Id == id);
        var measurements = new Domain.App.BodyMeasurement();

        RepoDbContext.BodyMeasurements.Add(measurements);
  
    }

   
}