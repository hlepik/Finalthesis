using DAL.App.DTO;

namespace DAL.App.EF.Repositories;

public class UnitRepository : BaseRepository<Unit, Domain.App.Unit, AppDbContext>, IUnitRepository
{
    public UnitRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new UnitMapper(mapper))
    {
    }
}