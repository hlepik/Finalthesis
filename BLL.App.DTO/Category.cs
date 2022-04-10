namespace BLL.App.DTO;

public class Category : DomainEntityId
{
    public string Name { get; set; } = default!;
    public ICollection<Instruction>? Instructions { get; set; }
}