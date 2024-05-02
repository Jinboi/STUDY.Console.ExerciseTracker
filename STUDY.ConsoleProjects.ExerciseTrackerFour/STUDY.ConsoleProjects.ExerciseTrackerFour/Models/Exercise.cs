﻿namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Models;
internal class Exercise
{
    public int Id { get; set; }
    public DateTime StarTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Duration { get; set; } = null!;
}
