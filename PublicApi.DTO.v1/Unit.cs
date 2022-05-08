namespace PublicApi.DTO.v1;

public class Unit
{
    public Guid Id { get; set; }
    [MinLength(2)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    [MinLength(2)]
    [MaxLength(128)]
    public string ShortName { get; set; } = default!;
}