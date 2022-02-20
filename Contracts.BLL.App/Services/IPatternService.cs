using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface IPatternService : IBaseEntityService<Pattern, global::DAL.App.DTO.Pattern>,
    IPatternRepositoryCustom<Pattern>
{
}