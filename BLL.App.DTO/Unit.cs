namespace BLL.App.DTO;

public class Unit : DomainEntityId
{
    public string Name { get; set; } = default!;
    public ICollection<BodyMeasurements>? BodyMeasurements { get; set; }
}