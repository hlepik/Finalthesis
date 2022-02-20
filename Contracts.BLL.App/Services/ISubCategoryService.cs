namespace Contracts.BLL.App.Services;
public interface ISubCategoryService:  IBaseEntityService< BLLAppDTO.SubCategory, DALAppDTO.SubCategory>,
        ISubCategoryRepositoryCustom<BLLAppDTO.SubCategory>
    {

    }

