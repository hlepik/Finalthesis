using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class CategoryMapper : BaseMapper<Category, Domain.App.Category>, IBaseMapper<Category, Domain.App.Category>
{
    public CategoryMapper(IMapper mapper) : base(mapper)
    {
    }
}