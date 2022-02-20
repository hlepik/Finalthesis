using BLL.App.DTO;

namespace BLL.App.Mappers;

public class PictureMapper : BaseMapper<Picture, DAL.App.DTO.Picture>, IBaseMapper<Picture, DAL.App.DTO.Picture>

{
    public PictureMapper(IMapper mapper) : base(mapper)
    {
    }
}