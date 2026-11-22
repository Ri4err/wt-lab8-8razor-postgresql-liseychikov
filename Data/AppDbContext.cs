using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_liseychikov.Models;

namespace wt_lab8_8razor_postgresql_liseychikov.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskModel> Tasks => Set<TaskModel>();
}