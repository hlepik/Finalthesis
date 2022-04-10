namespace DAL.App.DTO;

public class PatternInstruction : DomainEntityId
{
    public string? Title { get; set; }
    public string Description { get; set; } = default!;
    public int Step { get; set; }

    public IFormFile? Picture { get; set; }
    [MinLength(2)]
    [MaxLength(200)]
    public string? PictureName { get; set; } 
    public Guid InstructionId { get; set; }
    public Instruction? Instruction { get; set; }
}