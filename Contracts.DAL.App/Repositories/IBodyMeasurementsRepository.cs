using System.Collections;
using ExtraSize = BLL.App.DTO.ExtraSize;
using Instruction = BLL.App.DTO.Instruction;

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

    Task<TEntity?> CalculateUserMeasurements(Instruction instruction, BLL.App.DTO.BodyMeasurements userMeasurements,
        Guid userId, IEnumerable<ExtraSize> extraSizes, bool noTracking = true);

}