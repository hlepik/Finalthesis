using DAL.App.DTO;

namespace DAL.App.EF.Repositories;

public class UserMeasurementsRepository : BaseRepository<UserMeasurements, Domain.App.UserMeasurements, AppDbContext>,
    IUserMeasurementsRepository
{
    public UserMeasurementsRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new UserMeasurementsMapper(mapper))
    {
    }
   
}