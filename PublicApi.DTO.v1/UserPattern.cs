namespace PublicApi.DTO.v1;

public class UserPattern
{
    public Guid Id { get; set; }
    public bool HasDone { get; set; } = false;
    public int StepCount { get; set; }
    public Guid AppUserId { get; set; }
    public Guid InstructionId { get; set; }
}