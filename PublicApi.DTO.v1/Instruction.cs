using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;

namespace PublicApi.DTO.v1;

public class Instruction
{
    public Guid Id { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.Now;
    [MinLength(2)]
    [MaxLength(2000)]
    public string Name { get; set; } = default!;
    [MinLength(2)]
    [MaxLength(20000)]
    public string Description { get; set; } = default!;
    [MinLength(2)]
    [MaxLength(200)]
    public string? FileName { get; set; }
    [NotMapped]

    public IFormFile? PatternFile { get; set; }
    [NotMapped]
    [MinLength(2)]
    [MaxLength(200)]
    public string? MainPictureName { get; set; }
    public IFormFile? MainPicture { get; set; }
    public int TotalStep { get; set; }

    public IEnumerable<PatternInstruction>? PatternInstructions { get; set; }
    public Guid CategoryId { get; set; }
    [MinLength(2)]
    [MaxLength(200)]
    public string? CategoryName { get; set; }
   
    public IEnumerable<BodyMeasurement>? BodyMeasurements{ get; set; }

    public IEnumerable<ExtraSize>? ExtraSizes{ get; set; }

}