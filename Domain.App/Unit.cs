namespace Domain.App;
public class Unit: DomainEntityId
    {
        [MinLength(2), MaxLength(128)]

        public string Name { get; set; } = default!;
        public ICollection<BodyMeasurements>? BodyMeasurements { get; set; }

    }