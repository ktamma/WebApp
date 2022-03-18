using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.DAL;

public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5444;Username=postgres;Password=postgres;database=DistributedProject");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}