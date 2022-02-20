using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class SubCategoryMapper : BaseMapper<SubCategory, Domain.App.SubCategory>,
    IBaseMapper<SubCategory, Domain.App.SubCategory>
{
    public SubCategoryMapper(IMapper mapper) : base(mapper)
    {
    }
}