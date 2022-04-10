using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.App;

public class Instruction : DomainEntityId
{
    public DateTime DateAdded { get; set; } = DateTime.Now;

    [MinLength(2)]
    [MaxLength(2000)]
    public string Name { get; set; } = default!;
    [MinLength(2)]
    [MaxLength(200)]
    public string? FileName { get; set; }

    [NotMapped]
    public IFormFile? PatternFile { get; set; }
    [NotMapped]

    public IFormFile? MainPicture { get; set; }
    [MinLength(2)]
    [MaxLength(200)]
    public string? MainPictureName { get; set; }

    public int TotalStep { get; set; }
    [MinLength(2)]
    [MaxLength(20000)]
    public string Description { get; set; } = default!;
    public ICollection<PatternInstruction>? PatternInstructions { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public IEnumerable<BodyMeasurement>? BodyMeasurements{ get; set; }
    public ICollection<ExtraSize>? ExtraSizes{ get; set; }

}