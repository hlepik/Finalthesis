namespace BLL.App.DTO;

public class MeasurementType: DomainEntityId
{
    public string Name { get; set; } = default!;
    public string DbName { get; set; } = default!;

    public ICollection<UserMeasurements>? InstructionMeasurementTypes { get; set; }


}