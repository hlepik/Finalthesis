namespace PublicApi.DTO.v1;

public class Unit
{
    public string Name { get; set; } = default!;
    public IEnumerable? BodyMeasurements { get; set; }
}