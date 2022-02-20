using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface ICategoryService : IBaseEntityService<Category, global::DAL.App.DTO.Category>,
    ICategoryRepositoryCustom<Category>
{
}