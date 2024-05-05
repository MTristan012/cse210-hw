using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Entry entry = new Entry(theJournal);

        while (true)
        {
            entry.Display(promptGenerator);
        }
    }
}
