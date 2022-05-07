namespace BLL.App.DTO;

public class Instruction : DomainEntityId
{
    public DateTime DateAdded { get; set; } = DateTime.Now;
    public string Name { get; set; } = default!;
    public IFormFile? PatternFile { get; set; }
    public string? FileName { get; set; }
    public string Description { get; set; } = default!;
    public string? MainPictureName { get; set; }

    public IFormFile? MainPicture { get; set; }
    public int TotalStep { get; set; }
    public IEnumerable<PatternInstruction>? PatternInstructions { get; set; }
    public IEnumerable<BodyMeasurements>? BodyMeasurements{ get; set; }

    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public string? CircleSkirtType {  get; set; }

    public string? CategoryName { get; set; }
    public IEnumerable<ExtraSize>? ExtraSizes{ get; set; }





}