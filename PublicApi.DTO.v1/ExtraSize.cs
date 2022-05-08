namespace PublicApi.DTO.v1;

public class ExtraSize
{
    public Guid Id { get; set; }

    [MinLength(2)]
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public float Extra { get; set; }
    public Guid InstructionId { get; set; }
}