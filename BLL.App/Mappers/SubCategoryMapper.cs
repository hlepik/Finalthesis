using BLL.App.DTO;

namespace BLL.App.Mappers;

public class SubCategoryMapper : BaseMapper<SubCategory, DAL.App.DTO.SubCategory>,
    IBaseMapper<SubCategory, DAL.App.DTO.SubCategory>

{
    public SubCategoryMapper(IMapper mapper) : base(mapper)
    {
    }
}