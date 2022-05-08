namespace DAL.App.DTO;

public class ExtraSize : DomainEntityId
{
    public string Name { get; set; } = default!;
    public float Extra { get; set; }
    public Guid InstructionId { get; set; }
    public Instruction? Instruction { get; set; }
}