using Microsoft.EntityFrameworkCore.Design;

namespace DAL.App.EF;

public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var connectionStr =
            "Server=localhost,5432;User Id=hlepik;Password=hlepik_finalthesis;Database=postgres-hlepik";
        optionsBuilder.UseNpgsql(connectionStr);

        return new AppDbContext(optionsBuilder.Options);
    }
}