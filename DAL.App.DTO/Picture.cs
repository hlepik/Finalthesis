namespace DAL.App.DTO;

public class Picture : DomainEntityId
{
    public string Url { get; set; } = default!;
    public Guid PatternInstructionId { get; set; }
    public PatternInstruction? PatternInstruction { get; set; }
}