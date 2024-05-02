using STUDY.ConsoleProjects.ExerciseTrackerFour.Data;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Models;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Service;
internal class ExerciseService : IExerciseService
{
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
        using (var context = new ExerciseDbContext())
        {
            Console.WriteLine("Enter the start time of the exercise (yyyy-MM-dd HH:mm:ss):");
            DateTime startTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the end time of the exercise (yyyy-MM-dd HH:mm:ss):");
            DateTime endTime = DateTime.Parse(Console.ReadLine());

            // Calculate duration
            TimeSpan duration = endTime - startTime;

            // Create exercise object
            var exercise = new Exercise
            {
                StarTime = startTime,
                EndTime = endTime,
                Duration = duration.ToString(@"hh\:mm\:ss")
            };

            // Add exercise to database
            context.Exercises.Add(exercise);
            context.SaveChanges();

            Console.WriteLine("Exercise entry added successfully.");
        }
    }     

    public void UpdateExerciseEntry()
    {
        Console.WriteLine("Enter the ID of the exercise entry you want to update:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid ID:");
        }

        using (var context = new ExerciseDbContext())
        {
            // Find the exercise entry with the given ID
            var exercise = context.Exercises.Find(id);
            if (exercise == null)
            {
                Console.WriteLine($"Exercise entry with ID {id} not found.");
                return;
            }

            // Ask the user for new start and end times
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

            // Update the properties of the exercise entry
            exercise.StarTime = newStartTime;
            exercise.EndTime = newEndTime;

            // Save changes to the database
            context.SaveChanges();

            Console.WriteLine($"Exercise entry with ID {id} updated successfully.");
        }
    }
    public void DeleteExerciseEntry()
    {
        Console.WriteLine("Enter the ID of the exercise entry you want to delete:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid ID:");
        }

        using (var context = new ExerciseDbContext())
        {
            // Find the exercise entry with the given ID
            var exercise = context.Exercises.Find(id);
            if (exercise == null)
            {
                Console.WriteLine($"Exercise entry with ID {id} not found.");
                return;
            }

            // Confirm deletion with the user
            Console.WriteLine($"Are you sure you want to delete exercise entry with ID {id}? (yes/no)");
            string confirmation = Console.ReadLine().Trim().ToLower();
            if (confirmation != "yes")
            {
                Console.WriteLine("Deletion canceled.");
                return;
            }

            // Remove the exercise entry from the database
            context.Exercises.Remove(exercise);
            context.SaveChanges();

            Console.WriteLine($"Exercise entry with ID {id} deleted successfully.");
        }
    }
}
