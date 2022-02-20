using BLL.App.DTO;

namespace Contracts.BLL.App.Services;

public interface ISubCategoryService : IBaseEntityService<SubCategory, global::DAL.App.DTO.SubCategory>,
    ISubCategoryRepositoryCustom<SubCategory>
{
}