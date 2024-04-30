using Spectre.Console;
class Program
{
    static void Main(string[] args)
    {
        var menu = new MenuSelection();
        menu.DisplayMenu();
    }
}

class MenuSelection
{
    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to Exercise Tracker Menu");

            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What would you like to do?")
                        .AddChoices(@"View All Exercise Tracker Entries",
                            "View Specific Exercise Tracker Entry",
                            "Add Exercise Tracker Entry",
                            "Update Exercise Tracker Entry",
                            "Delete Exercise Tracker Entry",
                            "Quit"));

                switch (choice)
                {
                    case "View All Exercise Tracker Entries":
                        AnsiConsole.WriteLine("Invalid choice. Please try again.");
                        break;
                    case "View Specific Exercise Tracker Entry":
                        AnsiConsole.WriteLine("Invalid choice. Please try again.");
                        break;
                    case "Add Exercise Tracker Entry":
                        AnsiConsole.WriteLine("Invalid choice. Please try again.");
                        break;
                    case "Update Exercise Tracker Entry":
                        AnsiConsole.WriteLine("Invalid choice. Please try again.");
                        break;
                    case "Delete Exercise Tracker Entry":
                        AnsiConsole.WriteLine("Invalid choice. Please try again.");
                        break;
                    case "Quit":
                        Environment.Exit(0);
                        break;
                    default:
                        AnsiConsole.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}