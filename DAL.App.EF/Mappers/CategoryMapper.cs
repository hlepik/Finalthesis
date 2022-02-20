namespace DAL.App.EF.Mappers;
public class CategoryMapper: BaseMapper<DTO.Category, Domain.App.Category>, IBaseMapper<DTO.Category, Domain.App.Category>
    {
        public CategoryMapper(IMapper mapper) : base(mapper)
        {
        }
    }
