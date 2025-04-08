using Microsoft.EntityFrameworkCore;
using BOULICAUT_RAFFORT_Calendar.Models;

namespace BOULICAUT_RAFFORT_Calendar.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    public DbSet<Evenement> evenements { get; set; }
    public DbSet<TaskItem> tasks { get; set; }
}