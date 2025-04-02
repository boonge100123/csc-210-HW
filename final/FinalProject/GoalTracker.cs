// GoalTracker.cs
public class GoalTracker
{
    private List<Goal> goals = new();

    public void AddGoal(Goal goal) => goals.Add(goal);
    public void DisplayGoals()
    {
        foreach (var goal in goals)
            Console.WriteLine($"Goal: {goal.Type} | {goal.Progress} (x{goal.Modifier})/{goal.Target} | Completed: {goal.Evaluate()}");
    }
}