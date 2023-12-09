using Solution.Utils;

namespace Solution;

public static class Program
{
    private static bool HandleRepeat()
    {
        ConsoleManager.WriteLine("Press Q to exit...");
        return Console.ReadKey(true).Key != ConsoleKey.Q;
    }
    
    [STAThread]
    public static void Main()
    {
        do
        {
            BodyCycle.Run();
        } while (HandleRepeat());
    }
}