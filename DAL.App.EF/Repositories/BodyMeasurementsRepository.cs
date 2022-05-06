using DAL.App.DTO;
using DAL.App.EF.Enums;
using Domain.App;
using Category = Domain.App.Category;
using ExtraSize = DAL.App.DTO.ExtraSize;
using Instruction = BLL.App.DTO.Instruction;

namespace DAL.App.EF.Repositories;

public class BodyMeasurementsRepository :
    BaseRepository<BodyMeasurements, BodyMeasurement, AppDbContext>,
    IBodyMeasurementsRepository
{
    public BodyMeasurementsRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new BodyMeasurementsMapper(mapper))
    {

    }
    public async Task<DAL.App.DTO.BodyMeasurements?> FirstOrDefaultUserMeasurementsAsync(Guid id,  bool noTracking = true)
    {
        var query = CreateQuery(default, noTracking);


        var resQuery = query
            .Select(p => new DAL.App.DTO.BodyMeasurements()
            {

                Id = p.Id,
                NeckSize = p.NeckSize,
                Length = p.Length,
                AppUserId = p.AppUserId,
                UnitId = p.UnitId,
                ChestGirth = p.ChestGirth,
                ChestHeight = p.ChestHeight,
                WaistGirth = p.WaistGirth,
                UpperArmGirth = p.UpperArmGirth,
                UpperHipGirth = p.UpperHipGirth,
                WaistHeight = p.WaistHeight,
                WaistLengthFirst = p.WaistLengthFirst,
                WaistLengthSec = p.WaistLengthSec,
                WristGirth = p.WristGirth,
                BackWidth = p.BackWidth,
                BackLength = p.BackLength,
                ButtockHeight = p.ButtockHeight,
                ArmLength = p.ArmLength,
                FrontLength = p.FrontLength,
                InsideLegLength = p.InsideLegLength,
                AnkleGirth = p.AnkleGirth,
                ArmholeLength = p.ArmholeLength,
                CalfGirth = p.CalfGirth,
                ShoulderLength = p.ShoulderLength,
                HipGirth = p.HipGirth,
                KneeGirth = p.KneeGirth,
                ThighGirth = p.ThighGirth,

            }).FirstOrDefaultAsync(m => m.AppUserId == id);

        return await resQuery;
    }
    public async Task<DAL.App.DTO.BodyMeasurements?> GetByInstructionId(Guid id, Guid userId,  bool noTracking = true)
    {
        var query = CreateQuery(default, noTracking);


        var resQuery = query
            .Select(p => new DAL.App.DTO.BodyMeasurements()
            {

                Id = p.Id,
                NeckSize = p.NeckSize,
                Length = p.Length,
                AppUserId = p.AppUserId,
                UnitId = p.UnitId,
                ChestGirth = p.ChestGirth,
                ChestHeight = p.ChestHeight,
                WaistGirth = p.WaistGirth,
                UpperArmGirth = p.UpperArmGirth,
                UpperHipGirth = p.UpperHipGirth,
                WaistHeight = p.WaistHeight,
                WaistLengthFirst = p.WaistLengthFirst,
                WaistLengthSec = p.WaistLengthSec,
                WristGirth = p.WristGirth,
                BackWidth = p.BackWidth,
                BackLength = p.BackLength,
                ButtockHeight = p.ButtockHeight,
                ArmLength = p.ArmLength,
                FrontLength = p.FrontLength,
                InsideLegLength = p.InsideLegLength,
                AnkleGirth = p.AnkleGirth,
                ArmholeLength = p.ArmholeLength,
                CalfGirth = p.CalfGirth,
                ShoulderLength = p.ShoulderLength,
                HipGirth = p.HipGirth,
                KneeGirth = p.KneeGirth,
                ThighGirth = p.ThighGirth,
                InstructionId = p.InstructionId

            }).FirstOrDefaultAsync(m => m.AppUserId == userId && m.InstructionId == id);

        return await resQuery;
    }



    public async Task<DAL.App.DTO.BodyMeasurements?> CalculateUserMeasurements(BLL.App.DTO.Instruction instruction,BLL.App.DTO.BodyMeasurements userMeasurements, Guid userId, IEnumerable<BLL.App.DTO.ExtraSize> extraSizes,  bool noTracking = true)
    {
        var query = CreateQuery(default, noTracking);

        var calculatedMeasurements = new BodyMeasurements();
        if (instruction.CategoryName == ECategories.Kleidid.ToString())
        {
            calculatedMeasurements = GetDressMeasurements(instruction,  userMeasurements, extraSizes);


        }


        return calculatedMeasurements;
    }

    public BodyMeasurements GetDressMeasurements(Instruction instruction, BLL.App.DTO.BodyMeasurements userMeasurements, IEnumerable<BLL.App.DTO.ExtraSize> extraSizes)
    {

        var calculatedMeasurements = new BodyMeasurements();

        if (extraSizes != null)
        {
            var hasWaistGirth = extraSizes?.Where(x => x.Name == EMeasurements.waistGirth.ToString()).FirstOrDefault();
            var hasHipGirth = extraSizes?.Where(x => x.Name == EMeasurements.hipGirth.ToString()).FirstOrDefault();

            if (instruction.IsFullCircleSkirt && hasWaistGirth != null)
            {
                foreach (var size in extraSizes!)
                {
                    if (size.Name == EMeasurements.waistGirth.ToString())
                    {
                        calculatedMeasurements.WaistGirth = (userMeasurements.WaistGirth - 2) % 6;
                    }
                }
            }
            else if(instruction.IsHalfCircleSkirt && hasWaistGirth != null)
            {
                calculatedMeasurements.WaistGirth = 2 *( userMeasurements.WaistGirth - 2) % 6;

            }
            else if(instruction.IsQuarterCircleSkirt && hasWaistGirth != null)
            {
                calculatedMeasurements.WaistGirth = 4 *( userMeasurements.WaistGirth - 2) % 6;

            }
            else if(hasWaistGirth != null && hasHipGirth != null)
            {
                calculatedMeasurements.WaistGirth = userMeasurements.WaistGirth % 2;
                calculatedMeasurements.HipGirth = userMeasurements.HipGirth % 2;
                calculatedMeasurements.InTake = calculatedMeasurements.WaistGirth - calculatedMeasurements.HipGirth;
            }

        }



        return calculatedMeasurements;

    }

}