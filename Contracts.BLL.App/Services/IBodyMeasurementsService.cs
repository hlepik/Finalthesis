using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IBodyMeasurementsService : IBaseEntityService<BodyMeasurements, global::DAL.App.DTO.BodyMeasurements>,
    IBodyMeasurementsRepositoryCustom<BodyMeasurements>
{
}