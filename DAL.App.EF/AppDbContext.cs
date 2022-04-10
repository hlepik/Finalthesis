using DAL.App.DTO;
using Domain.App;
using Category = Domain.App.Category;
using ExtraSize = Domain.App.ExtraSize;
using Instruction = Domain.App.Instruction;
using MeasurementType = Domain.App.MeasurementType;
using PatternInstruction = Domain.App.PatternInstruction;
using SubCategory = Domain.App.SubCategory;
using Unit = Domain.App.Unit;
using UserMeasurements = Domain.App.UserMeasurements;
using UserPattern = Domain.App.UserPattern;

namespace DAL.App.EF;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<BodyMeasurement> BodyMeasurements { get; set; } = default!;
    public DbSet<ExtraSize> ExtraSizes { get; set; } = default!;
    public DbSet<MeasurementType> MeasurementTypes { get; set; } = default!;
    public DbSet<UserMeasurements> InstructionMeasurementTypes { get; set; } = default!;

    public DbSet<Instruction> Instructions { get; set; } = default!;
    public DbSet<PatternInstruction> PatternInstructions { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<SubCategory> SubCategories { get; set; } = default!;
    public DbSet<UserPattern> UserPatterns { get; set; } = default!;
    public DbSet<Unit> Units { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // disable cascade delete initially for everything
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
    }
}