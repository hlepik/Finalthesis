namespace BLL.App.DTO;

public class UserPattern : DomainEntityId
{
    public bool HasDone { get; set; } = false;
    public int StepCount { get; set; }
    public string? InstructionTitle { get; set; }
    public string? InstructionCategory { get; set; }
    public string? InstructionDescription { get; set; }
    public Guid AppUserId { get; set; }
    public Guid InstructionId { get; set; }
}
