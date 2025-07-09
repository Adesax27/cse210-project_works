using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Data Analyst";
        job1._company = "Amazon";
        job1._startYear = 2016;
        job1._endYear = 2018;

        Job job2 = new Job();
        job2._jobTitle = "Chief Tech Officer";
        job2._company = "Tesla";
        job2._startYear = 2019;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Ademola Okunjoyo";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}