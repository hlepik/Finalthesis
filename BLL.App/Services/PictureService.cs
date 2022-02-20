using BLL.App.DTO;

namespace BLL.App.Services;

public class PictureService : BaseEntityService<IAppUnitOfWork, IPictureRepository, Picture, DAL.App.DTO.Picture>,
    IPictureService
{
    public PictureService(IAppUnitOfWork serviceUow, IPictureRepository serviceRepository, IMapper mapper) : base(
        serviceUow, serviceRepository, new PictureMapper(mapper))
    {
    }
}