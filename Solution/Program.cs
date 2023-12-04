namespace Solution;

public static class Program
{
    private static bool HandleRepeat()
    {
        // Console repeat message
        return Console.ReadKey(true).Key == ConsoleKey.Enter;
    }
    
    public static void Main()
    {
        // Console start message
        
        do
        {
            BodyCycle.Run();
        } while (HandleRepeat());
    }
}