// Goal.cs
public class Goal
{
    public string Type { get; set; }         // Daily, Weekly, etc.
    public string Unit { get; set; }         // Pages, Chapters, Books
    public int Target { get; set; }          // Goal value
    public int Progress { get; set; }        // How far they've come

    public bool Evaluate() => Progress >= Target;

    public string GetProgressReport()
    {
        double percent = ((double)Progress / Target) * 100;
        percent = Math.Min(100, percent);
        return $"{Progress}/{Target} {Unit} ({percent:F1}% complete)";
    }

    public void UpdateProgress(int amount)
    {
        Progress += amount;
    }
}
