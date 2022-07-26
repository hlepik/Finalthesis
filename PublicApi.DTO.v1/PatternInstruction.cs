using System.ComponentModel.DataAnnotations.Schema;

namespace PublicApi.DTO.v1;

public class PatternInstruction

{
    public Guid Id { get; set; }
    [MinLength(2)]
    [MaxLength(500)]
    public string? Title { get; set; }
    [MinLength(2)]
    [MaxLength(20000)]
    public string Description { get; set; } = default!;
    public int Step { get; set; }
    [NotMapped]
    public IFormFile? Picture { get; set; }
    [MinLength(2)]
    [MaxLength(200)]
    public string? PictureName { get; set; }
    public Guid InstructionId { get; set; }
    
    
}