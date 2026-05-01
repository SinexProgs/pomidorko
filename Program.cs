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
        
    }

    private static void Stop()
    {
        
    }

    private static void SwitchPhase()
    {
        switch ((int)CurrentPhase)
        {
            case 0:
                CurrentPhase = CyclesLeft > 1 ? (Phase)1 : (Phase)2;
                SecondsLeft = CyclesLeft > 1 ? ShortBreakDuration : LongBreakDuration;
                break;
            case 1:
                CurrentPhase = (Phase)0;
                SecondsLeft = FocusDuration;
                CyclesLeft--;
                break;
            case 2:
                CurrentPhase = (Phase)0;
                SecondsLeft = FocusDuration;
                CyclesLeft = CyclesTillLongBreak;
                break;
        }
    }

    private static void PlayAlarm()
    {
        
    }
}