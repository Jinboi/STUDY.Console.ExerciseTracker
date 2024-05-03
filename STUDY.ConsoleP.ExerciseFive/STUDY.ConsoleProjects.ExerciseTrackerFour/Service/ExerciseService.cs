using STUDY.ConsoleProjects.ExerciseTrackerFour.Data;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Data.Repository;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Models;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Service;
internal class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }
    public void ViewAllExerciseEntries()
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
    public void ViewSpecificExerciseEntry()
    {
        using (var context = new ExerciseDbContext())
        {
            Console.WriteLine("Enter the ID of the exercise entry you want to view:");
            int id = int.Parse(Console.ReadLine());

            var exercise = context.Exercises.FirstOrDefault(e => e.Id == id);
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
                Console.WriteLine($"Exercise entry with ID {id} not found.");
            }
        }
    }
    public void AddExerciseEntry()
    {        
        Console.WriteLine("Enter the start time of the exercise (yyyy-MM-dd HH:mm:ss):");
        DateTime startTime = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter the end time of the exercise (yyyy-MM-dd HH:mm:ss):");
        DateTime endTime = DateTime.Parse(Console.ReadLine());

        // Calculate duration
        TimeSpan duration = endTime - startTime;          

        Exercise exercise = new Exercise
        {
            StarTime = startTime,
            EndTime = endTime,
            Duration = duration.ToString(@"hh\:mm\:ss")
        };

        _exerciseRepository.AddExerciseEntry(exercise);

        Console.WriteLine("AddedExerciseEntry");
    }     
    public void UpdateExerciseEntry()
    {
        Console.WriteLine("Enter the ID of the exercise entry you want to update:");
        int exerciseId;
        while (!int.TryParse(Console.ReadLine(), out exerciseId))
        {
            Console.WriteLine("Invalid input. Please enter a valid ID:");
        }      
         
        Console.WriteLine("Enter the new start time (yyyy-MM-dd HH:mm:ss):");
        DateTime newStartTime;
        while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out newStartTime))
        {
            Console.WriteLine("Invalid input. Please enter a valid start time (yyyy-MM-dd HH:mm:ss):");
        }

        Console.WriteLine("Enter the new end time (yyyy-MM-dd HH:mm:ss):");
        DateTime newEndTime;
        while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out newEndTime))
        {
            Console.WriteLine("Invalid input. Please enter a valid end time (yyyy-MM-dd HH:mm:ss):");
        }

        TimeSpan newDuration = newEndTime - newStartTime;

        Exercise newExercise = new Exercise
        {
            StarTime = newStartTime,
            EndTime = newEndTime,
            Duration = newDuration.ToString(@"hh\:mm\:ss")
        };

        _exerciseRepository.UpdateExerciseEntry(exerciseId, newExercise);

        Console.WriteLine($"Exercise entry with ID {exerciseId} updated successfully.");        
    }
    public void DeleteExerciseEntry()
    {
        Console.WriteLine("Enter the ID of the exercise entry you want to delete:");
        int exerciseId;
        while (!int.TryParse(Console.ReadLine(), out exerciseId))
        {
            Console.WriteLine("Invalid input. Please enter a valid ID:");
        }       

        Console.WriteLine($"Are you sure you want to delete exercise entry with ID {exerciseId}? (yes/no)");
        string confirmation = Console.ReadLine().Trim().ToLower();
        if (confirmation != "yes")
        {
            _exerciseRepository.DeleteExerciseEntry(exerciseId);
            return;
        }          

        Console.WriteLine($"Exercise entry with ID {exerciseId} deleted successfully.");        
    }
}
