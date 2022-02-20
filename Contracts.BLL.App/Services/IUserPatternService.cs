namespace Contracts.BLL.App.Services;
public interface IUserPatternService:  IBaseEntityService<BLLAppDTO.UserPattern, DALAppDTO.UserPattern>,
        IUserPatternRepositoryCustom<BLLAppDTO.UserPattern>
    {

    }
