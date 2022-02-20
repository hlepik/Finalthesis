namespace Contracts.BLL.App.Services;
public interface IPatternService:  IBaseEntityService< BLLAppDTO.Pattern, DALAppDTO.Pattern>,
        IPatternRepositoryCustom<BLLAppDTO.Pattern>
    {

    }

