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
    private static int CyclesLeft = CyclesTillLongBreak; 

    private const int FocusDuration = 25 * 60;
    private const int ShortBreakDuration = 5 * 60;
    private const int LongBreakDuration = 15 * 60;
    private const int CyclesTillLongBreak = 4;
    
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
        switch (CurrentPhase)
        {
            case Phase.Focus:
                CurrentPhase = CyclesLeft > 1 ? Phase.ShortBreak : Phase.LongBreak;
                SecondsLeft = CyclesLeft > 1 ? ShortBreakDuration : LongBreakDuration;
                break;
            case Phase.ShortBreak:
                CurrentPhase = Phase.Focus;
                SecondsLeft = FocusDuration;
                CyclesLeft--;
                break;
            case Phase.LongBreak:
                CurrentPhase = Phase.Focus;
                SecondsLeft = FocusDuration;
                CyclesLeft = CyclesTillLongBreak;
                break;
        }
    }

    private static void PlayAlarm()
    {
        
    }
}
