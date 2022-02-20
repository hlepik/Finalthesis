namespace BLL.App.Services;
public class CategoryService :
        BaseEntityService<IAppUnitOfWork, ICategoryRepository, BLLAppDTO.Category, DALAppDTO.Category>, ICategoryService
    {
        public CategoryService(IAppUnitOfWork serviceUow, ICategoryRepository serviceRepository, IMapper mapper) : base(
            serviceUow, serviceRepository, new CategoryMapper(mapper))
        {
        }
    }
