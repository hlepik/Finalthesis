namespace DAL.App.EF.Repositories;
public class UnitRepository : BaseRepository<DAL.App.DTO.Unit, Domain.App.Unit, AppDbContext>, IUnitRepository
    {

        public UnitRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new UnitMapper(mapper))
        {
        }
    }
