namespace BLL.App.DTO;
public class Picture: DomainEntityId
    {
        public string Url { get; set; } = default!;
        public Guid PatternInstructionId { get; set;}
    }
