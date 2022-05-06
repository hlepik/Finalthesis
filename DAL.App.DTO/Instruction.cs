namespace DAL.App.DTO;

public class Instruction : DomainEntityId

{
    public DateTime DateAdded { get; set; } = DateTime.Now;
    public string Name { get; set; } = default!;
    public IFormFile? PatternFile { get; set; }
    public string? FileName { get; set; }
    public string Description { get; set; } = default!;
    public string? MainPictureName { get; set; }
    public string? CategoryName { get; set; }
    public Boolean IsFullCircleSkirt {  get; set; }
    public Boolean IsHalfCircleSkirt {  get; set; }
    public Boolean IsQuarterCircleSkirt {  get; set; }

    public IFormFile? MainPicture { get; set; }

    public int TotalStep { get; set; }
    public ICollection<PatternInstruction>? PatternInstructions { get; set; }
    public ICollection<BodyMeasurements>? BodyMeasurements{ get; set; }
    public ICollection<ExtraSize>? ExtraSizes{ get; set; }

    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }




}