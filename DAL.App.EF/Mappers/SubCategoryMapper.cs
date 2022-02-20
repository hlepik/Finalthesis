namespace DAL.App.EF.Mappers;
public class SubCategoryMapper: BaseMapper<DTO.SubCategory, Domain.App.SubCategory>, IBaseMapper<DTO.SubCategory, Domain.App.SubCategory>
    {
        public SubCategoryMapper(IMapper mapper) : base(mapper)
        {
        }
    }
