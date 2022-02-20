namespace DAL.App.EF.Repositories;
public class UserPatternRepository : BaseRepository<DAL.App.DTO.UserPattern, Domain.App.UserPattern, AppDbContext>,
        IUserPatternRepository
    {

        public UserPatternRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new UserPatternMapper(mapper))
        {
        }
    }
