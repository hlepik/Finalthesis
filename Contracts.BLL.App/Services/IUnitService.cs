namespace Contracts.BLL.App.Services;
public interface IUnitService:  IBaseEntityService< BLLAppDTO.Unit, DALAppDTO.Unit>,
        IUnitRepositoryCustom<BLLAppDTO.Unit>
    {

    }

