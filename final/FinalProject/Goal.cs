// Goal.cs
public class Goal
{
    public string Type { get; set; }
    public int Target { get; set; }
    public int Progress { get; set; }
    public double Modifier { get; set; } = 1.0;

    public bool Evaluate() => Progress * Modifier >= Target;
}