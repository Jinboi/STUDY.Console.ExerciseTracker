using STUDY.ConsoleProjects.ExerciseTrackerFour.Models;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Data.Repository;
internal class ExerciseRepository : IExerciseRepository
{
    private readonly ExerciseDbContext _context;
    public ExerciseRepository(ExerciseDbContext context)
    {
        _context = context;
    }
    public void AddExerciseEntry(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        _context.SaveChanges();
    }

    public void DeleteExerciseEntry()
    {
        throw new NotImplementedException();
    }

    public void UpdateExerciseEntry()
    {
        throw new NotImplementedException();
    }

    public void ViewAllExerciseEntries()
    {
        throw new NotImplementedException();
    }

    public void ViewSpecificExerciseEntry()
    {
        throw new NotImplementedException();
    }
}
