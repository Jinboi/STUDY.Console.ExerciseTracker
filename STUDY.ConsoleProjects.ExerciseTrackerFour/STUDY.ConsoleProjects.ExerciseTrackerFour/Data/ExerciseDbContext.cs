using Microsoft.EntityFrameworkCore;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Models;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Data;
internal class ExerciseDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\LocalDBDemo; Database = exerciseTrackerDb; Trusted_Connection = true; TrustServerCertificate = true;");
    }
}
