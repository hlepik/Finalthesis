namespace Contracts.BLL.App.Services;
public interface IPictureService:  IBaseEntityService< BLLAppDTO.Picture, DALAppDTO.Picture>,
        IPictureRepositoryCustom<BLLAppDTO.Picture>
    {

    }

