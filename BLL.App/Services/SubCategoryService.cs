using BLL.App.DTO;

namespace BLL.App.Services;

public class SubCategoryService :
    BaseEntityService<IAppUnitOfWork, ISubCategoryRepository, SubCategory, DAL.App.DTO.SubCategory>, ISubCategoryService
{
    public SubCategoryService(IAppUnitOfWork serviceUow, ISubCategoryRepository serviceRepository, IMapper mapper) :
        base(serviceUow, serviceRepository, new SubCategoryMapper(mapper))
    {
    }
}