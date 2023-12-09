using Solution.Utils;

namespace Solution;

public static class Program
{
    /// <summary>
    /// Handles pressed key.
    /// </summary>
    /// <returns>State of case if pressed key is Q</returns>
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