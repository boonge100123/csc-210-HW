using System;

class SimpleGole : Goal
{
    public SimpleGole(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordPoints()
    {
        if(!_IsComplete)
        {
            _IsComplete = true;
            return _points;
        }
        return 0;
    }

    
}