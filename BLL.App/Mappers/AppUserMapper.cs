using BLL.App.DTO.Identity;

namespace BLL.App.Mappers;


public class AppUserMapper : BaseMapper<AppUser, DAL.App.DTO.Identity.AppUser>, IBaseMapper<AppUser, DAL.App.DTO.Identity.AppUser>

{
    public AppUserMapper(IMapper mapper) : base(mapper)
    {
    }
}