using DAL.App.DTO;

namespace DAL.App.EF.Repositories;

public class MeasurementTypeRepository: BaseRepository<MeasurementType, Domain.App.MeasurementType, AppDbContext>,
    IMeasurementTypeRepository
{
    public MeasurementTypeRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new MeasurementTypeMapper(mapper))
    {
    }

}