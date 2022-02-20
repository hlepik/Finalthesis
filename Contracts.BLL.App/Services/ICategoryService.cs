namespace Contracts.BLL.App.Services;

public interface ICategoryService:  IBaseEntityService< BLLAppDTO.Category, DALAppDTO.Category>,
        ICategoryRepositoryCustom<BLLAppDTO.Category>
    {

    }

