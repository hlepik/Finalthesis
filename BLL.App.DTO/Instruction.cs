namespace BLL.App.DTO;

public class Instruction : DomainEntityId
{
    public DateTime DateAdded { get; set; } = DateTime.Now;
    public string Name { get; set; } = default!;
    public int TotalStep { get; set; }
    public ICollection<PatternInstruction>? PatternInstructions { get; set; }
    public Guid SubCategoryId { get; set; }
}