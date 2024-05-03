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
    public void DeleteExerciseEntry(int exerciseId)
    {
        var exercise = _context.Exercises.Find(exerciseId);
        if (exercise != null)
        {
            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
        }
        else
        {
            return;
        }
    }
    public void UpdateExerciseEntry(int exerciseId, Exercise newExercise)
    {
        var oldExercise = _context.Exercises.Find(exerciseId);
        if (oldExercise != null)
        {
            oldExercise.StarTime = newExercise.StarTime;
            oldExercise.EndTime = newExercise.EndTime;
            oldExercise.Duration = newExercise.Duration;
        }
        else
        {
            return;
        }

        _context.SaveChanges();
    }
    public void ViewAllExerciseEntries()
    {        
            var exercises = _context.Exercises.ToList();

            if (exercises.Any())
            {
                foreach (var exercise in exercises)
                {
                    TimeSpan duration = exercise.EndTime - exercise.StarTime;
                    Console.WriteLine($@"
                            Id: {exercise.Id}, 
                            StartTime: {exercise.StarTime}, 
                            EndTime: {exercise.EndTime}, 
                            Duration: {duration}");
                }
            }
            else
            {
                return;
            }        
    }
    public void ViewSpecificExerciseEntry(int exerciseId)
    {
        var exercise = _context.Exercises.FirstOrDefault(e => e.Id == exerciseId);
        if (exercise != null)
        {
            TimeSpan duration = exercise.EndTime - exercise.StarTime;
            Console.WriteLine($@"
                    Id: {exercise.Id}, 
                    StartTime: {exercise.StarTime}, 
                    EndTime: {exercise.EndTime}, 
                    Duration: {duration}");
        }
        else
        {
            return;
        }
    }
}
