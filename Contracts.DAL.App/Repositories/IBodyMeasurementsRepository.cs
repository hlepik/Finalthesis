using System.Collections;

namespace Contracts.DAL.App.Repositories;

public interface IBodyMeasurementsRepository : IBaseRepository<BodyMeasurements>,
    IBodyMeasurementsRepositoryCustom<BodyMeasurements>
{
}

public interface IBodyMeasurementsRepositoryCustom<TEntity>
{
    Task<TEntity?> FirstOrDefaultUserMeasurementsAsync(Guid id,
        bool noTracking = true);
    Task<TEntity?> GetByInstructionId(Guid id, Guid userId,
        bool noTracking = true);


}