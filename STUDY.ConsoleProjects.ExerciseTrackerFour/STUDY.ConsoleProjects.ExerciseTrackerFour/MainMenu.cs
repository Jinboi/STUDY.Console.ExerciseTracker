﻿using Spectre.Console;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Controller;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Service;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour;
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
        var exerciseService = new ExerciseService();
        var exerciseController = new ExerciseController(exerciseService);

        while (true)
        {
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
                    exerciseController.ViewAllExerciseEntries();
                    break;
                case MenuOption.ViewSpecificExerciseEntry:
                    exerciseController.ViewSpecificExerciseEntry();
                    break;
                case MenuOption.AddExerciseEntry:
                    exerciseController.AddExerciseEntry();
                    break;
                case MenuOption.UpdateExerciseEntry:
                    exerciseController.UpdateExerciseEntry();
                    break;
                case MenuOption.DeleteExerciseEntry:
                    exerciseController.DeleteExerciseEntry();
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