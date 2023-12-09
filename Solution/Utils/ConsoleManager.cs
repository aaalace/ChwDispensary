namespace Solution.Utils;

public static class ConsoleManager
{
    /// <summary>
    /// Custom "Console.WriteLine()" with color setter.
    /// </summary>
    /// <param name="line">String to print.</param>
    /// <param name="color">Color of line.</param>
    public static void WriteLine(string line, ConsoleColor color = ConsoleColor.DarkYellow)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(line);
        Console.ResetColor();
    }
}