namespace DAL.App.DTO;

public class BodyMeasurements : DomainEntityId
{
    public float NeckSize { get; set; }
    public float ChestGirth { get; set; }
    public float WaistGirth { get; set; }
    public float UpperHipGirth { get; set; }
    public float WaistLengthFirst { get; set; }
    public float HipGirth { get; set; }
    public float WaistLengthSec { get; set; }
    public float UpperArmGirth { get; set; }
    public float WristGirth { get; set; }
    public float FrontLength { get; set; }
    public float ThighGirth { get; set; }
    public float KneeGirth { get; set; }
    public float CalfGirth { get; set; }
    public float AnkleGirth { get; set; }
    public float InsideLegLength { get; set; }
    public float ArmLength { get; set; }
    public float ShoulderLength { get; set; }
    public float ArmholeLength { get; set; }
    public float BackWidth { get; set; }
    public float WaistHeight { get; set; }
    public float BackLength { get; set; }
    public float ChestHeight { get; set; }
    public float ButtockHeight { get; set; }
    public float Length { get; set; }
    public float? InTake { get; set; }
    public float? ArmHoleWidth { get; set; }
    public Guid? UnitId { get; set; }
    public Unit? Unit { get; set; }
    public Guid? InstructionId { get; set; }
    public Instruction? Instruction { get; set; }
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}