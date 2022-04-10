using BLL.App.DTO;

namespace BLL.App.Mappers;

public class ExtraSizeMapper : BaseMapper<ExtraSize, DAL.App.DTO.ExtraSize>, IBaseMapper<ExtraSize, DAL.App.DTO.ExtraSize>

{
    public ExtraSizeMapper(IMapper mapper) : base(mapper)
    {
    }
}