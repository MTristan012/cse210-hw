using System;

class Program
{
    static void Main(string[] args)
    {
        /* 
            In this version the date and time of the note is saved, the csv format is requested to save and also the mood. 
        */
        
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Entry entry = new Entry(theJournal);

        while (true)
        {
            entry.Display(promptGenerator);
        }
    }
}
