namespace BLL.App.DTO;

public class SubCategory : DomainEntityId
{
    public string Name { get; set; } = default!;
    public Guid CategoryId { get; set; }

    public ICollection<Instruction>? Instructions { get; set; }
}