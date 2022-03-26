using DAL.App.DTO;
using Domain.App;

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
}