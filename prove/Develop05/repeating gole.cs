using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordPoints()
    {
        return _points;
    }

    public override string GetStatus()
    {
        return "Eternal";
    }
}