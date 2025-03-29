using System;

class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
    }

    public override int RecordPoints()
    {
        if (_IsComplete) return 0;

        _timesCompleted++;
        if (_timesCompleted >= _targetCount)
        {
            _IsComplete = true;
            return _points + _bonus;
        }
        return _points;
    }

    public override string GetStatus()
    {
        return _IsComplete ? $"[X] Completed {_timesCompleted}/{_targetCount}" : $"[ ] Completed {_timesCompleted}/{_targetCount}";
    }

    public override string ToCSV()
    {
        return $"{this.GetType().Name},{_name},{_description},{_points},{_IsComplete},{_timesCompleted},{_targetCount},{_bonus}";
    }

    public static ChecklistGoal FromCSV(string[] parts)
    {
        var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[6]), int.Parse(parts[7]));
        goal._IsComplete = bool.Parse(parts[4]);
        goal._timesCompleted = int.Parse(parts[5]);
        return goal;
    }
}