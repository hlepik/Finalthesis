namespace DAL.App.EF.Mappers;
public class PictureMapper: BaseMapper<DTO.Picture, Domain.App.Picture>, IBaseMapper<DTO.Picture, Domain.App.Picture>
    {
        public PictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
