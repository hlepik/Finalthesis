namespace BLL.App.DTO;

public class Picture : DomainEntityId
{
    public string? FileName { get; set; }

    public IFormFile? ImageFile { get; set; } = default!;
    public Guid PatternInstructionId { get; set; }
}