using BLL.App.DTO;

namespace BLL.App.Mappers;

public class UnitMapper : BaseMapper<Unit, DAL.App.DTO.Unit>, IBaseMapper<Unit, DAL.App.DTO.Unit>

{
    public UnitMapper(IMapper mapper) : base(mapper)
    {
    }
}