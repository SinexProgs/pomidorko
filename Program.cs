using System.Media;

namespace pomidorko;

enum Phase
{
    Focus,
    ShortBreak,
    LongBreak
}

class Program
{
    private static readonly SoundPlayer AlarmPlayer = new("alarm.wav");
    
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
        Console.WriteLine("<Помидорке>");
        Console.WriteLine("Enter - Запустить таймер");
        Console.WriteLine("Esc - Остановить таймер");
        Console.WriteLine("Space - Пропустить фазу в цикле");
        Console.WriteLine();
        while (true)
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        Start();
                        break;
                    case ConsoleKey.Escape:
                        Stop();
                        break;
                    case ConsoleKey.Spacebar:
                        SwitchPhase();
                        break;
                }
            }

            if (Running)
            {
                SecondsLeft--;
                if (SecondsLeft < 0)
                {
                    SwitchPhase();
                    PlayAlarm();
                }
            }
            
            string phaseName = CurrentPhase switch
            {
                Phase.Focus      => "Работа",
                Phase.ShortBreak => "Короткий перерыв",
                Phase.LongBreak  => "Длинный перерыв",
                _                => string.Empty
            };
            int minutesLeft = SecondsLeft / 60;
            int secondsLeft = SecondsLeft % 60;
            Console.Write($"\r{phaseName}: {minutesLeft:D2}:{secondsLeft:D2}               ");
            
            Thread.Sleep(1000);
        }
    }

    private static void Start()
    {
        CurrentPhase = Phase.Focus;
        SecondsLeft = FocusDuration;
        CyclesLeft = CyclesTillLongBreak;
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
        AlarmPlayer.Play();
    }
}
