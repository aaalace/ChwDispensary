namespace Solution.Utils;

public static class ConsoleManager
{
    public static void WriteLine(string line, ConsoleColor color = ConsoleColor.DarkYellow)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(line);
        Console.ResetColor();
    }
}