namespace DAL.App.EF.Repositories;
public class CategoryRepository : BaseRepository<DAL.App.DTO.Category, Domain.App.Category, AppDbContext>,
        ICategoryRepository
    {

        public CategoryRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new CategoryMapper(mapper))
        {
        }
    }
