namespace PublicApi.DTO.v1;

public class Picture
{
    public Guid Id { get; set; }
    public string? FileName { get; set; }

    public IFormFile? ImageFile { get; set; } = default!;
    public Guid PatternInstructionId { get; set; }
}