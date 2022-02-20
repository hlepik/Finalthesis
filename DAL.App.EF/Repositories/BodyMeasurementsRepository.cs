using DAL.App.DTO;
using Domain.App;

namespace DAL.App.EF.Repositories;

public class BodyMeasurementsRepository :
    BaseRepository<BodyMeasurements, BodyMeasurement, AppDbContext>,
    IBodyMeasurementsRepository
{
    public BodyMeasurementsRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new BodyMeasurementsMapper(mapper))
    {
    }
}