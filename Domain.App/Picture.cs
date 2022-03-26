using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.App;

public class Picture : DomainEntityId
{
    public string? FileName { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
    public Guid PatternInstructionId { get; set; }
    public PatternInstruction? PatternInstruction { get; set; }
}