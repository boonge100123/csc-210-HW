using System;

abstract class Goal
{
    protected int _points;
    protected bool _IsComplete;
    protected string _name;
    protected string _description;

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
        return _IsComplete ? "[X]" : "[ ]";
    }

    public override string ToString()
    {
        return $"{GetStatus()} Name: {_name}, Description: {_description}, Points: {_points}";
    }

    public virtual string ToCSV()
    {
        return $"{this.GetType().Name},{_name},{_description},{_points},{_IsComplete}";
    }

    public static Goal FromCSV(string csvLine)
    {
        string[] parts = csvLine.Split(',');
        if (parts.Length < 5) return null;

        string type = parts[0];

        return type switch
        {
            "SimpleGoal" => new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])) { _IsComplete = bool.Parse(parts[4]) },
            "EternalGoal" => new EternalGoal(parts[1], parts[2], int.Parse(parts[3])),
            "ChecklistGoal" => ChecklistGoal.FromCSV(parts),
            _ => null,
        };
    }
}