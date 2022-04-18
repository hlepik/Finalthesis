namespace DAL.App.DTO;

public class UserPattern : DomainEntityId
{
    public bool HasDone { get; set; } 
    public int StepCount { get; set; }
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public Guid InstructionId { get; set; }
    public Instruction? Instruction { get; set; }
    public string? InstructionTitle { get; set; }
    public string? InstructionCategory { get; set; }
    public string? InstructionDescription { get; set; }
}
