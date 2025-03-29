using System;

abstract class Goal
{
    protected int _points;
    protected bool _IsComplete;
    protected string _name;
    protected string _description;
    protected List<Goal> Goals = new List<Goal>();
    protected string _filePath;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _IsComplete = false;
    }

    public abstract int RecordPoints();

    public virtual string GetStatus()
    {
        return _IsComplete ? "Complete" : "Incomplete";
    }

    public override string ToString()
    {
        return $"Name: {_name}, Description: {_description}, Points: {_points}, Status: {GetStatus()}";
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public virtual void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            foreach (Goal goal in Goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.ToString()}");
            }
        }
    }
}