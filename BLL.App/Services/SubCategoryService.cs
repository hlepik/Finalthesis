namespace BLL.App.Services;
public class SubCategoryService: BaseEntityService<IAppUnitOfWork, ISubCategoryRepository, BLLAppDTO.SubCategory, DALAppDTO.SubCategory>, ISubCategoryService
    {

        public SubCategoryService(IAppUnitOfWork serviceUow, ISubCategoryRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new SubCategoryMapper(mapper))
        {
        }

    }
