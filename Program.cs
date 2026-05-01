namespace pomidorko;

enum Phase
{
    Focus,
    ShortBreak,
    LongBreak
}

class Program
{
    private static Phase CurrentPhase = Phase.Focus;
    private static int SecondsLeft = FocusDuration;
    private static bool Running = false;

    private const int FocusDuration = 25 * 60;
    private const int ShortBreakDuration = 5 * 60;
    private const int LongBreakDuration = 15 * 60;
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    private static void Start()
    {
        CurrentPhase = Phase.Focus;
        SecondsLeft = FocusDuration;
        Running = true;
    }

    private static void Stop()
    {
        Running = false;
    }

    private static void SwitchPhase()
    {
        
    }

    private static void PlayAlarm()
    {
        
    }
}
