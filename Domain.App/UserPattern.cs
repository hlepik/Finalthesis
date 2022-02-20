namespace Domain.App;
public class UserPattern: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Boolean HasDone{ get; set; } = false;
        public int StepCount { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid InstructionId { get; set;}
        public Instruction? Instruction { get; set; }
    }
