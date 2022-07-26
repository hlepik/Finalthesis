namespace Domain.App;

public class Unit : DomainEntityId
{
    [MinLength(2)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
[MinLength(2)]
    [MaxLength(128)]
    public string ShortName { get; set; } = default!;
    public ICollection<BodyMeasurement>? BodyMeasurements { get; set; }
}