namespace Assignment3.Entities;
public class KanbanContext : DbContext
{

    public DbSet<Task> tasks => Set<Task>();
    public DbSet<User> users => Set<User>();
    public DbSet<Tag> tags => Set<Tag>();

    public KanbanContext(DbContextOptions<KanbanContext> options)
        : base(options)
        { 
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        //modelBuilder.Entity<Task>()
        //.HasIndex(t => t.title).IsRequired();
        modelBuilder.Entity<Task>()
        .Property(s => s.state).HasColumnType("nvarchar(10)");

        modelBuilder.Entity<Task>()
        .Property(t => t.Title).HasMaxLength(100);

        modelBuilder.Entity<User>()
        .Property(u => u.Name).HasMaxLength(100);

        modelBuilder.Entity<User>()
        .Property(e => e.Email).HasMaxLength(100);

        modelBuilder.Entity<User>()
        .HasIndex(u => u.Email).IsUnique();

        modelBuilder.Entity<Tag>()
        .Property(t => t.Name).HasMaxLength(50);


    }


}
