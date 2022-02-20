using BLL.App.DTO;

namespace BLL.App.Services;

public class CategoryService :
    BaseEntityService<IAppUnitOfWork, ICategoryRepository, Category, DAL.App.DTO.Category>, ICategoryService
{
    public CategoryService(IAppUnitOfWork serviceUow, ICategoryRepository serviceRepository, IMapper mapper) : base(
        serviceUow, serviceRepository, new CategoryMapper(mapper))
    {
    }
}