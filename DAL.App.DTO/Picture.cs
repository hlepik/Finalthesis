

namespace DAL.App.DTO;

public class Picture : DomainEntityId
{
    public IFormFile? ImageFile { get; set; } = default!;
    public string? FileName { get; set; }

    public Guid PatternInstructionId { get; set; }
    public PatternInstruction? PatternInstruction { get; set; }
}