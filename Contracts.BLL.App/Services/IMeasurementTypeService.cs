using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IMeasurementTypeService : IBaseEntityService<MeasurementType, global::DAL.App.DTO.MeasurementType>,
    IMeasurementTypeRepositoryCustom<MeasurementType>
{
}