using Domain.App;

namespace DAL.App.EF;
public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<BodyMeasurement> BodyMeasurements { get; set; } = default!;
        public DbSet<Instruction> Instructions { get; set; } = default!;
        public DbSet<PatternInstruction> PatternInstructions { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Picture> Pictures { get; set; } = default!;
        public DbSet<SubCategory> SubCategories { get; set; } = default!;
        public DbSet<UserPattern> UserPatterns { get; set; } = default!;
        public DbSet<Unit> Units { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            // disable cascade delete initially for everything
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

    }
