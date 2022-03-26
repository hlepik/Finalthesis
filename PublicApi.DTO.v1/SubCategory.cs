namespace PublicApi.DTO.v1;

public class SubCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid CategoryId { get; set; }

    public IEnumerable<Instruction>? Instructions { get; set; }
}