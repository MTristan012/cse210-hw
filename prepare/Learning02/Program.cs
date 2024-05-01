using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Automatization Assistant";
        job1._company = "Grupo Victor";
        job1._startYear = 2021;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Software Developer";
        job2._company = "Ingeaa";
        job2._startYear = 2023;
        job2._endYear = 2030;

        Resume myResume = new Resume();
        myResume._name = "Tristan Perea";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}