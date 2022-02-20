using DAL.App.DTO;

namespace DAL.App.EF.Repositories;

public class PictureRepository : BaseRepository<Picture, Domain.App.Picture, AppDbContext>,
    IPictureRepository
{
    public PictureRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new PictureMapper(mapper))
    {
    }
}