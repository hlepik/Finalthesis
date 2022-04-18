using BLL.App.DTO;
using BodyMeasurements = DAL.App.DTO.BodyMeasurements;

namespace BLL.App.Services;

public class InstructionService :
    BaseEntityService<IAppUnitOfWork, IInstructionRepository, Instruction, DAL.App.DTO.Instruction>, IInstructionService
{
    public InstructionService(IAppUnitOfWork serviceUow, IInstructionRepository serviceRepository, IMapper mapper) :
        base(serviceUow, serviceRepository, new InstructionMapper(mapper))
    {
    }
    public async Task<IEnumerable<BLLAppDTO.Instruction>> GetAllByCategory(Guid id,  bool noTracking = true)
    {
        return (await ServiceRepository.GetAllByCategory(id,  noTracking)).Select(x => Mapper.Map(x)!);
    }
    

    public async Task<Instruction?> FirstOrDefaultDtoAsync(Guid id,  bool noTracking = true)
    {
        return Mapper.Map(await ServiceRepository.FirstOrDefaultDtoAsync(id,  noTracking))!;
    }
    

    public async Task<IEnumerable<BLLAppDTO.Instruction>> GetLastInsertedAsync(Guid userId,  bool noTracking = true)
    {
        return (await ServiceRepository.GetLastInsertedAsync(userId, noTracking)).Select(x => Mapper.Map(x)!);

    }
    public async Task<IEnumerable<BLLAppDTO.Instruction?>> GetSearchResult(string searchInput, Guid? categoryId)
    {
        return (await ServiceRepository.GetSearchResult(searchInput, categoryId)).Select(x => Mapper.Map(x)!);

    }

    public void CalculateMeasurements(Guid id)
    {
        
    }
}