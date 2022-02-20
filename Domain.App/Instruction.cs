namespace Domain.App;

public class Instruction : DomainEntityId
{
    public DateTime DateAdded { get; set; } = DateTime.Now;

    [MinLength(2)]
    [MaxLength(20000)]
    public string Name { get; set; } = default!;

    public int TotalStep { get; set; }
    public ICollection<PatternInstruction>? PatternInstructions { get; set; }
    public Guid SubCategoryId { get; set; }
    public SubCategory? SubCategory { get; set; }
}