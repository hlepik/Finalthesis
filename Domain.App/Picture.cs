namespace Domain.App;
public class Picture: DomainEntityId
    {
        [MinLength(2), MaxLength(500)]

        public string Url { get; set; } = default!;
        public Guid PatternInstructionId { get; set;}
        public PatternInstruction? PatternInstruction { get; set; }
    }
