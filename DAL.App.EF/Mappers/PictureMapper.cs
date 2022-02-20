using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class PictureMapper : BaseMapper<Picture, Domain.App.Picture>, IBaseMapper<Picture, Domain.App.Picture>
{
    public PictureMapper(IMapper mapper) : base(mapper)
    {
    }
}