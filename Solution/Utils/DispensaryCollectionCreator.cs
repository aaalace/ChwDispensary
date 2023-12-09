using LibDispensary;
using Solution.CustomExceptions;

namespace Solution.Utils;

public static class DispensaryCollectionCreator
{
    /// <summary>
    /// Creates list of Dispensary objects.
    /// </summary>
    /// <param name="rows">List of original rows.</param>
    /// <returns>List of Dispensary rows.</returns>
    public static List<Dispensary> GetDispensaryObjectsList(List<string> rows)
    {
        return rows.Select(CreateDispensaryObject).ToList();
    }
    
    /// <summary>
    /// Created Dispensary object.
    /// </summary>
    /// <param name="row">Original row.</param>
    /// <param name="ind">Index of original row.</param>
    /// <returns>Dispensary object.</returns>
    private static Dispensary CreateDispensaryObject(string row, int ind)
    {
        var listBuilder = new List<string>();
        int rowNumberInFile = ind + 2;
        
        if (row[^2..] != '"' + ";") { throw new IncorrectRowFormatException(rowNumberInFile); }
        int indOfFirstSep = row.IndexOf(';');
        if (row[indOfFirstSep..(indOfFirstSep + 2)] != ";" + '"')
        {
            throw new IncorrectRowFormatException(rowNumberInFile);
        }
        
        listBuilder.Add(row[..indOfFirstSep]);

        string sep = '"' + ";" + '"';
        string rowFromSecondEl = row[(indOfFirstSep + 2)..^2];
        listBuilder.AddRange(rowFromSecondEl.Split(sep).ToList());
        
        if (listBuilder.Count != 26) { throw new IncorrectRowElementsNumberException(rowNumberInFile); }
        
        return new Dispensary(listBuilder);
    }
}