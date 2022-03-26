namespace PublicApi.DTO.v1;

public class Instruction
{
    public Guid Id { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.Now;
    public string Name { get; set; } = default!;
    public string? FileName { get; set; }

    public IFormFile? PatternFile { get; set; }

    public int TotalStep { get; set; }
    public IEnumerable<PatternInstruction>? PatternInstructions { get; set; }
    public Guid SubCategoryId { get; set; }
}