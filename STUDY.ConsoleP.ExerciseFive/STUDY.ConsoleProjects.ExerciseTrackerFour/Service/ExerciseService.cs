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
        _exerciseRepository.ViewAllExerciseEntries();

        Console.WriteLine("View All Exercise Entries completed");

    }
    public void ViewSpecificExerciseEntry()
    {        
        Console.WriteLine("Enter the ID of the exercise entry you want to view:");
        int exerciseId = int.Parse(Console.ReadLine());

        _exerciseRepository.ViewSpecificExerciseEntry(exerciseId);        
    }
    public void AddExerciseEntry()
    {        
        Console.WriteLine("Enter the start time of the exercise (yyyy-MM-dd HH:mm:ss):");
        DateTime startTime = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter the end time of the exercise (yyyy-MM-dd HH:mm:ss):");
        DateTime endTime = DateTime.Parse(Console.ReadLine());

        TimeSpan duration = endTime - startTime;          

        Exercise exercise = new Exercise
        {
            StarTime = startTime,
            EndTime = endTime,
            Duration = duration.ToString(@"hh\:mm\:ss")
        };

        _exerciseRepository.AddExerciseEntry(exercise);

        Console.WriteLine("Added Exercise Entry");
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
