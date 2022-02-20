namespace BLL.App.DTO;
public class PatternInstruction: DomainEntityId
    {
        public string? Title { get; set; }
        public string Description { get; set; } = default!;
        public int Step { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
        public Guid InstructionId { get; set;}
    }
