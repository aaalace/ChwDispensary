using Solution.CustomExceptions;

namespace Solution;

public static class OriginalDataHandler
{
    private const string correctHeaderRow = "ROWNUM;FullName;ShortName;AdmArea;District;PostalCode;" +
                              "Address;ChiefName;ChiefPosition;ChiefGender;ChiefPhone;" +
                              "PublicPhone;Fax;Email;CloseFlag;CloseReason;CloseDate;" +
                              "ReopenDate;WorkingHours;ClarificationOfWorkingHours;" +
                              "Specialization;BeneficialDrugPrescriptions;ExtraInfo;" +
                              "POINT_X;POINT_Y;GLOBALID;";
    
    public static void CheckRowsNumber(List<string> rows)
    {
        if (rows.Count < 1) { throw new EmptyInputRowsException(); }
    }

    public static void CheckHeader(string row)
    {
        if (row != correctHeaderRow) { throw new IncorrectHeaderFormatException(); }
    }

    public static string GetOriginalHeader(List<string> rows) => rows[0];
    
    public static List<string> GetOriginalDataRowsList(List<string> rows)
    {
        return rows.GetRange(1, rows.Count - 1).ToList();
    }
}
