namespace BLL.App.Services;
public class PictureService: BaseEntityService<IAppUnitOfWork, IPictureRepository, BLLAppDTO.Picture, DALAppDTO.Picture>, IPictureService
    {
        public PictureService(IAppUnitOfWork serviceUow, IPictureRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PictureMapper(mapper))
        {
        }
    }
