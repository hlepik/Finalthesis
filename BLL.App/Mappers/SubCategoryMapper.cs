namespace BLL.App.Mappers;
public class SubCategoryMapper: BaseMapper<BLL.App.DTO.SubCategory, DAL.App.DTO.SubCategory>, IBaseMapper<BLL.App.DTO.SubCategory, DAL.App.DTO.SubCategory>

    {
        public SubCategoryMapper(IMapper mapper) : base(mapper)
        {
        }
    }
