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
        calculatedMeasurements.InstructionId = instruction.Id;
        calculatedMeasurements.AppUserId = userId;
        if (instruction.CategoryName == ECategories.Seelikud.ToString())
        {
            calculatedMeasurements = GetSkirtMeasurements(instruction,  userMeasurements, extraSizes);

        }else if (instruction.CategoryName == ECategories.Kleidid.ToString())
        {

            calculatedMeasurements = GetSkirtMeasurements(instruction, userMeasurements, extraSizes);
            calculatedMeasurements =
                GetShirtMeasurements(instruction, userMeasurements, extraSizes, calculatedMeasurements);
        }


        return calculatedMeasurements;
    }

    public BodyMeasurements GetSkirtMeasurements(Instruction instruction, BLL.App.DTO.BodyMeasurements userMeasurements, IEnumerable<BLL.App.DTO.ExtraSize> extraSizes)
    {

        var calculatedMeasurements = new BodyMeasurements();

        if (extraSizes != null)
        {
            var hasWaistGirth = extraSizes?.Where(x => x.Name == EMeasurements.waistGirth.ToString()).FirstOrDefault();
            var hasHipGirth = extraSizes?.Where(x => x.Name == EMeasurements.hipGirth.ToString()).FirstOrDefault();


            if (instruction.CircleSkirtType == ECircleSkirtType.FullCircle.ToString() && hasWaistGirth != null)
            {
                foreach (var size in extraSizes!)
                {
                    if (size.Name == EMeasurements.waistGirth.ToString())
                    {

                        calculatedMeasurements.WaistGirth = (float)((userMeasurements.WaistGirth + hasWaistGirth.Extra) / 6.28);
;                    }
                }
            }
            else if(instruction.CircleSkirtType == ECircleSkirtType.HalfCircle.ToString() && hasWaistGirth != null)
            {
                calculatedMeasurements.WaistGirth = (float) ((2 * userMeasurements.WaistGirth + hasWaistGirth.Extra) / 6.28 );

            }
            else if(instruction.CircleSkirtType == ECircleSkirtType.QuarterCircle.ToString() && hasWaistGirth != null)
            {
                calculatedMeasurements.WaistGirth = (float) (( 4 *userMeasurements.WaistGirth + hasWaistGirth.Extra)  / 6.28);

            }
            else if(hasWaistGirth != null && hasHipGirth != null)
            {
                calculatedMeasurements.WaistGirth = (userMeasurements.WaistGirth + hasWaistGirth.Extra) / 2;
                calculatedMeasurements.HipGirth = (userMeasurements.HipGirth + hasHipGirth.Extra) / 2;
                calculatedMeasurements.InTake = (calculatedMeasurements.HipGirth + hasHipGirth.Extra) -
                                                (calculatedMeasurements.WaistGirth + hasWaistGirth.Extra) - 1;
                calculatedMeasurements.WaistLengthFirst = userMeasurements.WaistLengthFirst;
            }

        }
        return calculatedMeasurements;

    }
     public BodyMeasurements GetShirtMeasurements(Instruction instruction, BLL.App.DTO.BodyMeasurements userMeasurements, IEnumerable<BLL.App.DTO.ExtraSize> extraSizes, DAL.App.DTO.BodyMeasurements bodyMeasurement)
    {


        if (extraSizes != null)
        {
            var hasChestGirth = extraSizes?.Where(x => x.Name == EMeasurements.chestGirth.ToString()).FirstOrDefault();
            var hasArmholeLength = extraSizes?.Where(x => x.Name == EMeasurements.armholeLength.ToString()).FirstOrDefault();
            var hasArmholeWidth = extraSizes?.Where(x => x.Name == EMeasurements.armHoleWidth.ToString()).FirstOrDefault();
            var hasBackLength = extraSizes?.Where(x => x.Name == EMeasurements.backLength.ToString()).FirstOrDefault();
            var hasBackWidth = extraSizes?.Where(x => x.Name == EMeasurements.backWidth.ToString()).FirstOrDefault();
            var hasChestHeight = extraSizes?.Where(x => x.Name == EMeasurements.chestHeight.ToString()).FirstOrDefault();
            var hasWaistGirth = extraSizes?.Where(x => x.Name == EMeasurements.waistGirth.ToString()).FirstOrDefault();
            var hasHipGirth = extraSizes?.Where(x => x.Name == EMeasurements.hipGirth.ToString()).FirstOrDefault();



            if (hasBackLength != null)
            {
                bodyMeasurement.BackLength = (userMeasurements.BackLength  + hasBackLength.Extra);
            }
            if (hasArmholeLength != null)
            {
                bodyMeasurement.ArmholeLength = userMeasurements.ArmholeLength + hasArmholeLength.Extra;
            }
            if (hasArmholeWidth  != null && hasChestGirth != null)
            {
                if (userMeasurements.Length > 164)
                {
                    bodyMeasurement.ArmHoleWidth = (float)(((userMeasurements.ChestGirth / 2)  + hasChestGirth.Extra) / 4 - 1.5);

                }
                else
                {
                    bodyMeasurement.ArmHoleWidth = ((userMeasurements.ChestGirth / 2) + hasChestGirth.Extra) / 3 - 6;

                }
            }
            if (hasBackWidth != null && bodyMeasurement.ArmHoleWidth != null)
            {
                bodyMeasurement.BackWidth = (float)(((userMeasurements.BackLength / 2 + hasBackWidth.Extra) / 2 - 1) +
                                                    bodyMeasurement.ArmHoleWidth)!;
            }

            if (hasChestGirth != null)
            {
                bodyMeasurement.ChestGirth = (float)((userMeasurements.ChestGirth / 2 + hasChestGirth.Extra) -
                                                     (userMeasurements.BackWidth / 2 + bodyMeasurement.ArmHoleWidth))!;
            }
            if (hasChestHeight != null)
            {
                bodyMeasurement.ChestHeight = userMeasurements.ChestHeight;
            }
            if (instruction.CircleSkirtType != "" )
            {
                bodyMeasurement.InTake = ((userMeasurements.ChestGirth + hasChestGirth!.Extra) / 2 -
                                          (userMeasurements.WaistGirth + hasWaistGirth!.Extra) / 2)  - 1;
            }




        }
        return bodyMeasurement;

    }

}