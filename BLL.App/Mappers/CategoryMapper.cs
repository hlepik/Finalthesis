using BLL.App.DTO;

namespace BLL.App.Mappers;

public class CategoryMapper : BaseMapper<Category, DAL.App.DTO.Category>, IBaseMapper<Category, DAL.App.DTO.Category>

{
    public CategoryMapper(IMapper mapper) : base(mapper)
    {
    }
}