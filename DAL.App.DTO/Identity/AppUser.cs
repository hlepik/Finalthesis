namespace DAL.App.DTO.Identity;
public class AppUser : IdentityUser<Guid>
    {
        [StringLength(128, MinimumLength = 1)]
        public string Firstname { get; set; } = default!;
        [StringLength(128, MinimumLength = 1)]
        public string Lastname { get; set; } = default!;

        public ICollection<BodyMeasurements>? BodyMeasurements { get; set; }
        public ICollection<UserPattern>? UserPatterns { get; set; }


        // public string FullName => Firstname + " " + Lastname;
        // public string FullNameEmail => FullName + " (" + Email + ")";

    }
