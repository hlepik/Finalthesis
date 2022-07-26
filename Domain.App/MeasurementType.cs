﻿namespace Domain.App;

public class MeasurementType: DomainEntityId
{
    [MinLength(2)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    [MinLength(2)]
    [MaxLength(128)]
    public string DbName { get; set; } = default!;
 
    public ICollection<UserMeasurements>? InstructionMeasurementTypes { get; set; }

}