namespace Domain.App;

public class BodyMeasurement : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
{
    public float NeckSize { get; set; } //1 kaelaümbermõõt
    public float ChestGirth { get; set; } //2 RINNAümbermõõt
    public float WaistGirth { get; set; } //3 vööümbermõõt
    public float UpperHipGirth { get; set; } //4 ülemine puus
    public float WaistLengthFirst { get; set; } // 5 lühem puusa kõrgus
    public float HipGirth { get; set; } // 6 puusa ümbermõõt
    public float WaistLengthSec { get; set; } // 7 puusa pikkus pikem
    public float UpperArmGirth { get; set; } // 8 käe ümbermõõt
    public float WristGirth { get; set; } //9 randme ümbermõõt
    public float FrontLength { get; set; } // 10 Esipikkus
    public float ThighGirth { get; set; } // 11 reie ümbermõõt
    public float KneeGirth { get; set; } // 12 põlve ümbermõõt
    public float CalfGirth { get; set; } // 13sääre ümbermõõt
    public float AnkleGirth { get; set; } //14 jala ümbermõõt
    public float InsideLegLength { get; set; } // 15 jala sisemise külje pikkus
    public float ArmLength { get; set; } //16 käe pikkus
    public float ShoulderLength { get; set; } // 17 õla pikkus
    public float ArmholeLength { get; set; } // 18 Käeaugukaare sügavus
    public float BackWidth { get; set; } // 19 selja laius
    public float WaistHeight { get; set; } // 20 puusa kõrgus, vb see pole parim sõna
    public float BackLength { get; set; } // 21 selja pikkus
    public float ChestHeight { get; set; } //22 rinna kõrgus
    public float ButtockHeight { get; set; } //23 istmiku kõrgus
    public float Length { get; set; } // üldpikkus
    public float? InTake { get; set; } // sissevõte
    public Guid UnitId { get; set; }
    public Unit? Unit { get; set; }
    public AppUser? AppUser { get; set; }
    public Guid AppUserId { get; set; }
    public Guid? InstructionId { get; set; }
    public Instruction? Instruction { get; set; }
}