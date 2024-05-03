using STUDY.ConsoleProjects.ExerciseTrackerFour.Models;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Data.Repository;
internal interface IExerciseRepository
{
    void ViewAllExerciseEntries();
    void ViewSpecificExerciseEntry();
    void AddExerciseEntry(Exercise exercise);
    void UpdateExerciseEntry();
    void DeleteExerciseEntry();
}
