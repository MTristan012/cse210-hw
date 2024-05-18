public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts;
    private int _count;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _usedPrompts = new List<string>();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt(_prompts, _usedPrompts);
        Console.WriteLine(prompt);
        ShowSpinner(3);

        Console.WriteLine("Start listing items now:");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }

        _count = items.Count;
        Console.WriteLine($"You listed {_count} items.");

        DisplayEndingMessage();
        LogActivity();
    }

    private string GetRandomPrompt(List<string> prompts, List<string> usedPrompts)
    {
        if (usedPrompts.Count == prompts.Count)
        {
            usedPrompts.Clear();
        }

        var availablePrompts = new List<string>(prompts);
        availablePrompts.RemoveAll(p => usedPrompts.Contains(p));

        Random random = new Random();
        string selectedPrompt = availablePrompts[random.Next(availablePrompts.Count)];
        usedPrompts.Add(selectedPrompt);

        return selectedPrompt;
    }
}