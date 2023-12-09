using System.Text;

namespace Solution.Utils;

public static class FileOpener
{
    /// <summary>
    /// Gets all file lines.
    /// </summary>
    /// <returns>All file lines.</returns>
    public static List<string> GetFileLines()
    {
        string fileName = GetFileName();
        
        var rows = File.ReadAllLines(fileName, encoding: Encoding.UTF8).ToList();

        return rows;
    }
    
    /// <summary>
    /// Gets filename.
    /// </summary>
    /// <returns>Filename.</returns>
    private static string GetFileName()
    {
        ConsoleManager.WriteLine("Input filename");
        string? fileName = Console.ReadLine();
        if (fileName == null) { throw new ArgumentNullException(nameof(fileName)); }

        return fileName;
    }
}