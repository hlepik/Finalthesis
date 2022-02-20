using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IUnitService : IBaseEntityService<Unit, global::DAL.App.DTO.Unit>,
    IUnitRepositoryCustom<Unit>
{
}