using Solution.CustomExceptions;

namespace Solution.Utils;

public static class OriginalDataHandler
{
    private const string correctHeaderRow = "ROWNUM;FullName;ShortName;AdmArea;District;PostalCode;" +
                              "Address;ChiefName;ChiefPosition;ChiefGender;ChiefPhone;" +
                              "PublicPhone;Fax;Email;CloseFlag;CloseReason;CloseDate;" +
                              "ReopenDate;WorkingHours;ClarificationOfWorkingHours;" +
                              "Specialization;BeneficialDrugPrescriptions;ExtraInfo;" +
                              "POINT_X;POINT_Y;GLOBALID;";
    
    /// <summary>
    /// Checks for correct number of rows.
    /// </summary>
    /// <param name="rows">Original rows with data.</param>
    public static void CheckRowsNumber(List<string> rows)
    {
        if (rows.Count < 1) { throw new EmptyInputRowsException(); }
    }
    
    /// <summary>
    /// Gets header of file.
    /// </summary>
    /// <param name="rows">Original rows of file.</param>
    /// <returns>Header.</returns>
    public static string GetOriginalHeader(List<string> rows) => rows[0];
    
    /// <summary>
    /// Checks if header format is correct.
    /// </summary>
    /// <param name="header">Header.</param>
    public static void CheckHeader(string header)
    {
        if (header != correctHeaderRow) { throw new IncorrectHeaderFormatException(); }
    }
    
    /// <summary>
    /// Gets list of original rows without header.
    /// </summary>
    /// <param name="rows">All original rows.</param>
    /// <returns>List of original rows without header.</returns>
    public static List<string> GetOriginalDataRowsList(List<string> rows)
    {
        return rows.GetRange(1, rows.Count - 1).ToList();
    }
}
