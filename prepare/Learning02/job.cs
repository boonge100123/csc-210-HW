using System;

class Job
{
    private string _company; // Fields
    private string _jobTitle;
    private int _startYear;
    private int _endYear;

    public Job(string company, string jobTitle, int startYear, int endYear) // Constructor
    {
        _company = company; // Assigning values to fields
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = endYear;
    }

    public void DisplayJob() // Method
    {
        Console.WriteLine($"Job: {_jobTitle} at {_company} from {_startYear} to {_endYear}");
    }
}
