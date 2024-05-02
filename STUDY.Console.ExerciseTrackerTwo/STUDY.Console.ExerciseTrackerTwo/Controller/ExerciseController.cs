using STUDY.ConsoleProjects.ExerciseTrackerTwo.Data;

namespace STUDY.ConsoleProjects.ExerciseTrackerTwo.Controller;
public class ExerciseController
{
    public static void ViewAllExerciseEntries()
    {
        using (var context = new ExerciseDbContext())
        {
            var exercises = context.Exercises.ToList();
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
                Console.WriteLine("No exercise entries found.");
            }
        }
    }
    public static void ViewSpecificExerciseEntry()
    {
        throw new NotImplementedException();
    }
    public static void AddExerciseEntry()
    {
        throw new NotImplementedException();
    }
    public static void UpdateExerciseEntry()
    {
        throw new NotImplementedException();
    }   
    public static void DeleteExerciseEntry()
    {
        throw new NotImplementedException();
    }
}
