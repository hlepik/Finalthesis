using Microsoft.EntityFrameworkCore.Design;

namespace DAL.App.EF;

public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var connectionStr =

            "Server=localhost,11433;User Id=SA;Password=Bad.Pass.1;Database=hlepik;MultipleActiveResultSets=true";
        optionsBuilder.UseSqlServer(connectionStr);

        return new AppDbContext(optionsBuilder.Options);
    }
}