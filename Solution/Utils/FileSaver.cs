using System.Text;
using LibDispensary;

namespace Solution.Utils;

public static class FileSaver
{
    private enum SavingMode
    {
        New,
        RewriteExisting,
        AddToExisting,
        Cancel
    }
    
    /// <summary>
    /// Manages options how to save file.
    /// </summary>
    /// <param name="dispensaryListToSave">List of objects to save.</param>
    /// <param name="header">Original header to save.</param>
    public static void Save(List<Dispensary> dispensaryListToSave, string header)
    {
        var savingMode = GetSavingMode();
        if (savingMode == SavingMode.Cancel)
        {
            return;
        }
        
        var path = GetFilePath();

        switch (savingMode)
        {
            case SavingMode.New:
                SaveNew(path, dispensaryListToSave, header);
                break;
            case SavingMode.RewriteExisting:
                SaveRewriteExisting(path, dispensaryListToSave, header);
                break;
            case SavingMode.AddToExisting:
                SaveAddToExiting(path, dispensaryListToSave, header);
                break;
            default:
                throw new ArgumentException("Error in saving action");
        }
    }

    /// <summary>
    /// Gets user's choice of saving mode.
    /// </summary>
    /// <returns>Saving mode.</returns>
    private static SavingMode GetSavingMode()
    {
        ConsoleManager.WriteLine("Select number of option to save data");
        ConsoleManager.WriteLine("1 - create new file", color: ConsoleColor.Green);
        ConsoleManager.WriteLine("2 - rewrite existing file", color: ConsoleColor.Green);
        ConsoleManager.WriteLine("3 - add rows to existing file", color: ConsoleColor.Green);
        ConsoleManager.WriteLine("4 - cancel saving", color: ConsoleColor.Green);
        string? inputType = Console.ReadLine();
        if (inputType == null) { throw new ArgumentNullException(nameof(inputType)); }

        var savingMode = inputType switch
        {
            "1" => SavingMode.New,
            "2" => SavingMode.RewriteExisting,
            "3" => SavingMode.AddToExisting,
            "4" => SavingMode.Cancel,
            _ => throw new ArgumentException("Wrong saving option")
        };

        return savingMode;
    }
    
    /// <summary>
    /// Gets path of file where to save data.
    /// </summary>
    /// <returns></returns>
    private static string GetFilePath()
    {
        ConsoleManager.WriteLine("Input path to save");
        string? path = Console.ReadLine();
        if (path == null) { throw new ArgumentNullException(nameof(path)); }

        return path;
    }

    /// <summary>
    /// Save data in new file.
    /// </summary>
    /// <param name="path">Path where to save.</param>
    /// <param name="dispensaryList">Data to save.</param>
    /// <param name="header">Header for saving data.</param>
    private static void SaveNew(string path, List<Dispensary> dispensaryList, string header)
    {
        if (File.Exists(path))
        {
            ConsoleManager.WriteLine("File already exists, it will be rewrited", color: ConsoleColor.DarkRed);
            SaveRewriteExisting(path, dispensaryList, header);
            return;
        }
        
        path = ToCsvFormat(path);
        WriteFromStart(path, dispensaryList, header);
        
        return;
        
        string ToCsvFormat(string remakePath)
        {
            if (!remakePath.Contains(".csv")) { remakePath += ".csv"; }

            return remakePath;
        }
    }

    /// <summary>
    /// Rewrites file with current data.
    /// </summary>
    /// <param name="path">Path where to save.</param>
    /// <param name="dispensaryList">Data to save.</param>
    /// <param name="header">Header for saving data.</param>
    private static void SaveRewriteExisting(string path, List<Dispensary> dispensaryList, string header)
    {
        if (!File.Exists(path))
        {
            ConsoleManager.WriteLine("File not exists, it will be created", color: ConsoleColor.DarkRed);
            SaveNew(path, dispensaryList, header);
            return;
        }
        
        WriteFromStart(path, dispensaryList, header);
    }

    /// <summary>
    /// Adds data to existing file.
    /// </summary>
    /// <param name="path">Path where to save.</param>
    /// <param name="dispensaryList">Data to save.</param>
    /// <param name="header">Header for saving data.</param>
    private static void SaveAddToExiting(string path, List<Dispensary> dispensaryList, string header)
    {
        if (!File.Exists(path))
        {
            ConsoleManager.WriteLine("File not exists, it will be created", color: ConsoleColor.DarkRed);
            SaveNew(path, dispensaryList, header);
            return;
        }
        
        using StreamWriter file = new(path, append: true);
        foreach (var disp in dispensaryList)
        {
            file.WriteLine(ParseDataRow(disp));
        }
        file.Close();
    }

    /// <summary>
    /// Writes rows to file starting from first.
    /// </summary>
    /// <param name="path">Path where to save.</param>
    /// <param name="dispensaryList">Data to save.</param>
    /// <param name="header">Header for saving data.</param>
    private static void WriteFromStart(string path, List<Dispensary> dispensaryList, string header)
    {
        var linesToWrite = new List<string> { header };
        linesToWrite = linesToWrite.Concat(dispensaryList.Select(ParseDataRow).ToList()).ToList();
        File.WriteAllLines(path, linesToWrite);
    }

    /// <summary>
    /// Parses data from object to correct format of row in file.
    /// </summary>
    /// <param name="dispensary">Object with data.</param>
    /// <returns>Row with correct format.</returns>
    private static string ParseDataRow(Dispensary dispensary)
    {
        const char sym = '"';
        var sb = new StringBuilder();
        
        sb.Append($"{dispensary.DataList[0]};");
        foreach (var field in dispensary.DataList.GetRange(1, dispensary.DataList.Count - 1))
        {
            sb.Append($"{sym}{field}{sym};");
        }

        return sb.ToString();
    }
}