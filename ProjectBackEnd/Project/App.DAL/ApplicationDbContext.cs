using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.DAL;

public class ApplicationDbContext:IdentityDbContext<AppUser, AppRole, Guid>
{
    public DbSet<AnswerFile> AnswerFiles { get; set; } = default!;
    public DbSet<AllowedUser> AllowedUsers { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<FileType> FileTypes { get; set; } = default!;
    public DbSet<Material> Materials { get; set; } = default!;
    public DbSet<Quiz> Quizzes { get; set; } = default!;
    public DbSet<QuizAnswer> QuizAnswers { get; set; } = default!;
    public DbSet<QuizMaterial> QuizMaterials { get; set; } = default!;
    public DbSet<QuizQuestion> QuizQuestions { get; set; } = default!;
    public DbSet<QuizType> QuizTypes { get; set; } = default!;
    public DbSet<Take> Takes { get; set; } = default!;
    public DbSet<TakeAnswer> TakeAnswers { get; set; } = default!;


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public override int SaveChanges()
    {
        FixEntities(this);
        
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        FixEntities(this);
        
        return base.SaveChangesAsync(cancellationToken);
    }


    private void FixEntities(ApplicationDbContext context)
    {
        var dateProperties = context.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(DateTime))
            .Select(z => new
            {
                ParentName = z.DeclaringEntityType.Name,
                PropertyName = z.Name
            });

        var editedEntitiesInTheDbContextGraph = context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
            .Select(x => x.Entity);
        

        foreach (var entity in editedEntitiesInTheDbContextGraph)
        {
            var entityFields = dateProperties.Where(d => d.ParentName == entity.GetType().FullName);

            foreach (var property in entityFields)
            {
                var prop = entity.GetType().GetProperty(property.PropertyName);

                if (prop == null)
                    continue;

                var originalValue = prop.GetValue(entity) as DateTime?;
                if (originalValue == null)
                    continue;

                prop.SetValue(entity, DateTime.SpecifyKind(originalValue.Value, DateTimeKind.Utc));
            }
        }
    }

}