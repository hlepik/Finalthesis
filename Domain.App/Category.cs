namespace Domain.App;

public class Category : DomainEntityId
{
    [MinLength(2)]
    [MaxLength(500)]
    public string Name { get; set; } = default!;

    public ICollection<Instruction>? Instructions { get; set; }
}