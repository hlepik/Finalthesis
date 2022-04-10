using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IExtraSizeService : IBaseEntityService<ExtraSize, global::DAL.App.DTO.ExtraSize>,
    IExtraSizeRepositoryCustom<ExtraSize>
{
}