using Microsoft.EntityFrameworkCore;

namespace BOULICAUT_RAFFORT_Calendar.Models;

public class TodoContext : DbContext
{
    public DbSet<Evenement> Evenements { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evenement>().ToTable("evenements");
        modelBuilder.Entity<TaskItem>().ToTable("tasks");

        // 💡 Mapping colonne
        modelBuilder.Entity<TaskItem>()
            .Property(t => t.EvenementId)
            .HasColumnName("evenement_id");

        modelBuilder.Entity<TaskItem>()
            .Property(t => t.Date_Echeance)
            .HasColumnName("date_echeance");
    }
}