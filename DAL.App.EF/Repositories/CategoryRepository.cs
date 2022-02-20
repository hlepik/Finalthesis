using DAL.App.DTO;

namespace DAL.App.EF.Repositories;

public class CategoryRepository : BaseRepository<Category, Domain.App.Category, AppDbContext>,
    ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new CategoryMapper(mapper))
    {
    }
}