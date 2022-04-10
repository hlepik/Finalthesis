namespace PublicApi.DTO.v1;

public class Category
{
    public Guid Id { get; set; }
    [MinLength(2)]
    [MaxLength(500)]
    public string Name { get; set; } = default!;
}