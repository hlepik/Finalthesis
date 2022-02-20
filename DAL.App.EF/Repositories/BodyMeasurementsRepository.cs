namespace DAL.App.EF.Repositories;
public class BodyMeasurementsRepository :
        BaseRepository<DAL.App.DTO.BodyMeasurements, Domain.App.BodyMeasurements, AppDbContext>,
        IBodyMeasurementsRepository
    {

        public BodyMeasurementsRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new BodyMeasurementsMapper(mapper))
        {
        }
    }
