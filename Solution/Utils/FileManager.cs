using System.Text;

namespace Solution.Utils;

public static class FileManager
{
    public static List<string> GetFileLines()
    {
        string fileName = GetFileName();
        
        var rows = File.ReadAllLines(fileName, encoding: Encoding.UTF8).ToList();

        return rows;
    }
    
    private static string GetFileName()
    {
        Console.WriteLine("Input file name");
        string? fileName = Console.ReadLine();
        if (fileName == null) { throw new ArgumentNullException(nameof(fileName)); }

        return fileName;
    }
}