using App.DAL;
using App.Domain;
using Microsoft.EntityFrameworkCore;
#pragma warning disable 1591

namespace WebApp;

public static class AppDataHelper
{
    public static void SetupAppData(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
    {
        using var serviceScope = app.
            ApplicationServices.
            GetRequiredService<IServiceScopeFactory>().
            CreateScope();

        using var context = serviceScope
            .ServiceProvider.GetService<ApplicationDbContext>();

        if (context == null)
        {
            throw new ApplicationException("Problem in services. No db context.");
        }
        
        // TODO - Check database state
        // can't connect - wrong address
        // can't connect - wrong user/pass
        // can connect - but no database
        // can connect - there is database

        if (configuration.GetValue<bool>("DataInitialization:DropDatabase"))
        {
            context.Database.EnsureDeleted();
        }
        if (configuration.GetValue<bool>("DataInitialization:MigrateDatabase"))
        {
            context.Database.Migrate();
        }
        if (configuration.GetValue<bool>("DataInitialization:SeedIdentity"))
        {
            // TODO
        }
        if (configuration.GetValue<bool>("DataInitialization:SeedData"))
        {
            // var f = new FooBar
            // {
            //     Name =
            //     {
            //         ["en"] = "english",
            //         ["et"] = "estonian",
            //         ["ru"] = "russian",
            //     }
            // };
            // context.FooBars.Add(f);
            context.SaveChanges();
        }
    }
    
}