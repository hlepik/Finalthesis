using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IPictureService : IBaseEntityService<Picture, global::DAL.App.DTO.Picture>,
    IPictureRepositoryCustom<Picture>
{
}