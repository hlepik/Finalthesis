namespace Domain.App;

public class ExtraSize : DomainEntityId
{
    [MinLength(2)]
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public float Extra { get; set; }
    public Guid InstructionId { get; set; }
    public Instruction? Instruction { get; set; }

}