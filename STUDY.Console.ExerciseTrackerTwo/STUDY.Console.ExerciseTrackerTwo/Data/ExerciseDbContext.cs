using Microsoft.EntityFrameworkCore;
using STUDY.ConsoleProjects.ExerciseTrackerTwo.Models;

namespace STUDY.ConsoleProjects.ExerciseTrackerTwo.Data;
internal class ExerciseDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\LocalDBDemo; Database = exerciseTrackerDb; Trusted_Connection = true; TrustServerCertificate = true;");
    }
}
