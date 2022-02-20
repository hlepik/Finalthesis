namespace DAL.App.EF.Repositories;
public class SubCategoryRepository : BaseRepository<DAL.App.DTO.SubCategory, Domain.App.SubCategory, AppDbContext>,
        ISubCategoryRepository
    {

        public SubCategoryRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new SubCategoryMapper(mapper))
        {
        }
    }
