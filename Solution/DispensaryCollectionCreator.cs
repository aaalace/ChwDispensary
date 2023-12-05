using LibDispensary;
using Solution.CustomExceptions;

namespace Solution;

public static class DispensaryCollectionCreator
{
    public static List<Dispensary> GetDispensaryObjectsList(List<string> rows)
    {
        return rows.Select(GetDispensaryObject).ToList();
    }
    
    private static Dispensary GetDispensaryObject(string row, int ind)
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
        
        return new Dispensary(rowNum: listBuilder[0], fullName: listBuilder[1],
            shortName: listBuilder[2], admArea: listBuilder[3],
            district: listBuilder[4], postalCode: listBuilder[5],
            address: listBuilder[6], chiefName: listBuilder[7],
            chiefPosition: listBuilder[8], chiefGender: listBuilder[9],
            chiefPhone: listBuilder[10], publicPhone: listBuilder[11],
            fax: listBuilder[12], email: listBuilder[13],
            closeFlag: listBuilder[14], closeReason: listBuilder[15],
            closeDate: listBuilder[16], reopenDate: listBuilder[17],
            workingHours: listBuilder[18], clarificationOfWorkingHours: listBuilder[19],
            specialization: listBuilder[20], beneficialDrugPrescriptions: listBuilder[21],
            extraInfo: listBuilder[22], pointX: listBuilder[23],
            pointY: listBuilder[24], globalId: listBuilder[25]);
    }
}