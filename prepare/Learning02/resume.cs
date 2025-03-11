using System;
using System.Collections.Generic;

class Resume
{
    private string _name;
    private List<Job> _jobs = new List<Job>();

    public Resume(string name, List<Job> jobs)
    {
        _name = name;
        _jobs = jobs;
    }

public void DisplayResume()
    {
        Console.WriteLine($"Resume for {_name}");
        foreach (Job job in _jobs)
        {
            job.DisplayJob();
        }
    }
}
