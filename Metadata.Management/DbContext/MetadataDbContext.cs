using Microsoft.EntityFrameworkCore;

public class MetadataDbContext : DbContext
{
    public MetadataDbContext(DbContextOptions<MetadataDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your database model here
        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Form>().HasData(
            new Form { Id = 1, Name = "Form 1", Description = "Description for Form 1" },
            new Form { Id = 2, Name = "Form 2", Description = "Description for Form 2" }
        );
    }

    // Define your DbSets here
    public DbSet<Form> Forms { get; set; }
}