using System;

class Program
{
    static void Main()
    {

        //Create a list of jobs
        List<Job> jobs = new List<Job>();

        // Create first job
        Job job1 = new Job("Microsoft", "Software Engineer", 2010, 2015);
        jobs.Add(job1);

        // Create second job
        Job job2 = new Job("Google", "Software Engineer", 2015, 2020);
        jobs.Add(job2);

        // Create resume and add jobs
        Resume myResume = new Resume("Allison Rose", jobs);

        // Display the resume
    myResume.DisplayResume();
    }
}
