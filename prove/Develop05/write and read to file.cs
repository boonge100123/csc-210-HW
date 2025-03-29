using System;

class FileHandler
{
    private List<Goal> Goals = new List<Goal>();
    private string _filePath;
    private int _score = 0;

    public FileHandler(string filePath)
    {
        _filePath = filePath;
    }

    public void SetFilePath(string filePath)
    {
        _filePath = filePath;
        Goals.Clear();
        Console.WriteLine($"Active file has been changed to {_filePath}.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public int GetScore() => _score;

    public void AddPoints(int points)
    {
        _score += points;
    }

    public void RecordGoalEvent(int index)
    {
        if (index < 0 || index >= Goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        int earnedPoints = Goals[index].RecordPoints();
        AddPoints(earnedPoints);
        Console.WriteLine($"You earned {earnedPoints} points!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            writer.WriteLine($"SCORE,{_score}");
            foreach (Goal goal in Goals)
                writer.WriteLine(goal.ToCSV());
        }
        Console.WriteLine("Goals saved successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void LoadGoals()
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("No file found to load goals.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Goals.Clear();
        string[] lines = File.ReadAllLines(_filePath);
        foreach (string line in lines)
        {
            if (line.StartsWith("SCORE,"))
            {
                _score = int.Parse(line.Split(',')[1]);
                continue;
            }

            Goal goal = Goal.FromCSV(line);
            if (goal != null) Goals.Add(goal);
        }
        Console.WriteLine("Goals loaded successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void ListGoals()
    {
        Console.WriteLine("Current Goals:");
        for (int i = 0; i < Goals.Count; i++)
            Console.WriteLine($"{i + 1}. {Goals[i]}");
    }

    public void RemoveGoal(int index)
    {
        if (index < 0 || index >= Goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
        Goals.RemoveAt(index);
        Console.WriteLine("Goal removed successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}