namespace DAL.App.DTO;

public class Instruction : DomainEntityId

{
    public DateTime DateAdded { get; set; } = DateTime.Now;
    public string Name { get; set; } = default!;
    public IFormFile? PatternFile { get; set; }
    public string? FileName { get; set; }

    public int TotalStep { get; set; }
    public ICollection<PatternInstruction>? PatternInstructions { get; set; }
    public Guid SubCategoryId { get; set; }
    public SubCategory? SubCategory { get; set; }
}