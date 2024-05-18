public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts;
    private List<string> _usedQuestions;

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _usedPrompts = new List<string>();
        _usedQuestions = new List<string>();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt(_prompts, _usedPrompts);
        Console.WriteLine(prompt);
        ShowSpinner(3);

        int elapsed = 0;

        while (elapsed < _duration)
        {
            string question = GetRandomPrompt(_questions, _usedQuestions);
            Console.WriteLine(question);
            ShowSpinner(5);
            elapsed += 5;
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