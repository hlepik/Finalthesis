using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IUserMeasurementsService: IBaseEntityService<UserMeasurements, global::DAL.App.DTO.UserMeasurements>,
    IInstructionMeasurementTypeRepositoryCustom<UserMeasurements>
{
}