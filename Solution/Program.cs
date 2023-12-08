namespace Solution;

public static class Program
{
    private static bool HandleRepeat()
    {
        Console.WriteLine("Press Enter to continue");
        return Console.ReadKey(true).Key == ConsoleKey.Enter;
    }
    
    public static void Main()
    {
        do
        {
            BodyCycle.Run();
        } while (HandleRepeat());
    }
}