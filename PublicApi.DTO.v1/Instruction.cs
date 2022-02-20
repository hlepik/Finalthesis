namespace PublicApi.DTO.v1;
public class Instruction
    {
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string Name { get; set; } = default!;
        public int TotalStep { get; set; }
        public IEnumerable<PatternInstruction>? PatternInstructions { get; set; }
        public Guid SubCategoryId { get; set;}
    }
