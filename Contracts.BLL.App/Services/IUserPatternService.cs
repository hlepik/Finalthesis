using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IUserPatternService : IBaseEntityService<UserPattern, global::DAL.App.DTO.UserPattern>,
    IUserPatternRepositoryCustom<UserPattern>
{
}