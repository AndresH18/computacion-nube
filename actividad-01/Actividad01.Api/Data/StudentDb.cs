using Microsoft.EntityFrameworkCore;
using Shared.Data;

namespace Actividad01.Api.Data;

public class StudentDb(DbContextOptions<StudentDb> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(b =>
        {
            b.HasKey(s => s.Id);
        });
    }
}