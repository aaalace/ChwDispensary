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
    
    public static void Save(List<Dispensary> dispensaryListToSave, string header)
    {
        var savingMode = GetSavingMode();
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
            case SavingMode.Cancel:
                break;
            default:
                throw new ArgumentException("Error in saving action");
        }
    }

    private static SavingMode GetSavingMode()
    {
        Console.WriteLine("Select number of option to save data");
        Console.WriteLine("1 - create new file");
        Console.WriteLine("2 - rewrite existing file");
        Console.WriteLine("3 - add rows to existing file");
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
    
    private static string GetFilePath()
    {
        Console.WriteLine("Input path to save");
        string? path = Console.ReadLine();
        if (path == null) { throw new ArgumentNullException(nameof(path)); }

        return path;
    }

    private static void SaveNew(string path, List<Dispensary> dispensaryList, string header)
    {
        if (File.Exists(path)) { Console.WriteLine("File already exists, it will be rewrited"); }

        path = ToCsvFormat(path);
        
        WriteFromStart(path, dispensaryList, header);
        
        return;

        string ToCsvFormat(string remakePath)
        {
            if (!remakePath.Contains(".csv")) { remakePath += ".csv"; }

            return remakePath;
        }
    }

    private static void SaveRewriteExisting(string path, List<Dispensary> dispensaryList, string header)
    {
        if (!File.Exists(path)) { Console.WriteLine("File not exists, it will be created"); }
        WriteFromStart(path, dispensaryList, header);
    }

    private static void SaveAddToExiting(string path, List<Dispensary> dispensaryList, string header)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("File not exists, it will be created");
            WriteFromStart(path, dispensaryList, header);
            return;
        }
        
        using StreamWriter file = new(path, append: true);
        foreach (var disp in dispensaryList)
        {
            file.WriteLine(ParseDataRow(disp));
        }
        file.Close();
    }

    private static void WriteFromStart(string path, List<Dispensary> dispensaryList, string header)
    {
        var linesToWrite = new List<string>() { header };
        linesToWrite = linesToWrite.Concat(dispensaryList.Select(ParseDataRow).ToList()).ToList();
        File.WriteAllLines(path, linesToWrite);
    }

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