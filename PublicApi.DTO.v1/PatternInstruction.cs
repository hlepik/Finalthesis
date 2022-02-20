namespace PublicApi.DTO.v1;

public class PatternInstruction
{
    public string? Title { get; set; }
    public string Description { get; set; } = default!;
    public int Step { get; set; }
    public IEnumerable? Pictures { get; set; }
    public Guid InstructionId { get; set; }
}