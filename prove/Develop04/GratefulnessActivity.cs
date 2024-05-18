public class GratefulnessActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts;

    public GratefulnessActivity() : base("Gratefulness", "This activity will help you reflect on the things you are grateful for in your life.")
    {
        _prompts = new List<string>
        {
            "What are you grateful for today?",
            "Who in your life are you grateful for?",
            "What is a recent event that made you feel grateful?",
            "What is a personal achievement you are grateful for?",
            "What is a small thing that you often overlook but are grateful for?"
        };

        _usedPrompts = new List<string>();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt(_prompts, _usedPrompts);
        Console.WriteLine(prompt);
        ShowSpinner(3);

        Console.WriteLine("Reflect on this prompt and write down your thoughts:");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string reflection = Console.ReadLine();
        }

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