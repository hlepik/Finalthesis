using BLL.App.DTO;
using BodyMeasurements = DAL.App.DTO.BodyMeasurements;

namespace BLL.App.Services;

public class ExtraSizeService : BaseEntityService<IAppUnitOfWork, IExtraSizeRepository, ExtraSize, DAL.App.DTO.ExtraSize>,
    IExtraSizeService
{
    public ExtraSizeService(IAppUnitOfWork serviceUow, IExtraSizeRepository serviceRepository, IMapper mapper) : base(
        serviceUow, serviceRepository, new ExtraSizeMapper(mapper))
    {
    }
    public async Task<IEnumerable<BLLAppDTO.ExtraSize>?> GetAllByInstructionId(Guid id)
    {
        return (await ServiceRepository.GetAllByInstructionId(id))!.Select(x => Mapper.Map(x)!);

    }
    public void RemoveByInstructionId(Guid? id)
    {
        ServiceRepository.RemoveByInstructionId(id);
    }
    
}