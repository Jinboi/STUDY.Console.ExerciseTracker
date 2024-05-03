using STUDY.ConsoleProjects.ExerciseTrackerFour.Models;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Service;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Data.Repository;
internal interface IExerciseRepository
{
    void ViewAllExerciseEntries();
    void ViewSpecificExerciseEntry();
    void AddExerciseEntry(Exercise exercise);
    void UpdateExerciseEntry(int exerciseId, Exercise newExercise);
    void DeleteExerciseEntry(int exerciseId);
}
