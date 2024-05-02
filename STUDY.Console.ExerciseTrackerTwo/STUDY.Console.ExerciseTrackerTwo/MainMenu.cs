using Spectre.Console;
using STUDY.ConsoleProjects.ExerciseTrackerTwo.Controller;

namespace STUDY.ConsoleProjects.ExerciseTrackerTwo;
internal class MainMenu
{
    public enum MenuOption
    {
        ViewAllExerciseEntries,
        ViewSpecificExerciseEntry,
        AddExerciseEntry,
        UpdateExerciseEntry,
        DeleteExerciseEntry,
        Quit
    }
    public static void ShowMainMenu()
    {      
        while (true)
        {
            Console.WriteLine("what");
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOption>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        MenuOption.ViewAllExerciseEntries,
                        MenuOption.ViewSpecificExerciseEntry,
                        MenuOption.AddExerciseEntry,
                        MenuOption.UpdateExerciseEntry,
                        MenuOption.DeleteExerciseEntry,
                        MenuOption.Quit));

            switch (choice)
            {
                case MenuOption.ViewAllExerciseEntries:
                    ExerciseController.ViewAllExerciseEntries();
                    break;
                case MenuOption.ViewSpecificExerciseEntry:
                    ExerciseController.ViewSpecificExerciseEntry();
                    break;
                case MenuOption.AddExerciseEntry:
                    ExerciseController.AddExerciseEntry();
                    break;
                case MenuOption.UpdateExerciseEntry:
                    ExerciseController.UpdateExerciseEntry();
                    break;
                case MenuOption.DeleteExerciseEntry:
                    ExerciseController.DeleteExerciseEntry();
                    break;
                case MenuOption.Quit:
                    Environment.Exit(0);
                    break;
                default:
                    AnsiConsole.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
        

}
