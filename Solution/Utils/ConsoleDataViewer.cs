using LibDispensary;
using Solution.CustomExceptions;

namespace Solution.Utils;

public static class ConsoleDataViewer
{
    private enum DataViewType
    {
        Top,
        Bottom
    }
    
    public static void Run(List<Dispensary> dispensaryList)
    {
        var dataViewType = GetDataViewType();
        int dataViewCount = GetDataViewCount(dispensaryList.Count);
        var elementsToShow = GetElementsToShow(dispensaryList, dataViewType, dataViewCount);
        Show(elementsToShow);
    }

    private static DataViewType GetDataViewType()
    {
        Console.WriteLine("Select view type (top / bottom):");
        string? dataViewTypeAsString = Console.ReadLine();
        if (dataViewTypeAsString == null) { throw new ArgumentNullException(nameof(dataViewTypeAsString)); }

        var dataViewType = dataViewTypeAsString switch
        {
            "top" => DataViewType.Top,
            "bottom" => DataViewType.Bottom,
            _ => throw new DataViewTypeException()
        };

        return dataViewType;
    }

    private static int GetDataViewCount(int countOfAll)
    {
        Console.WriteLine($"Select view count (1 - {countOfAll}) :");
        string? dataViewCountAsString = Console.ReadLine();
        
        if (dataViewCountAsString == null) { throw new ArgumentNullException(nameof(dataViewCountAsString)); }
        if (!int.TryParse(dataViewCountAsString, out int dataViewCount))
        {
            throw new FormatException("Wrong input of number");
        }
        if (dataViewCount < 1 || dataViewCount > countOfAll)
        {
            throw new ArgumentOutOfRangeException($"Value not in 1 - {countOfAll} range");
        }

        return dataViewCount;
    }

    private static List<Dispensary> GetElementsToShow(List<Dispensary> dispensaryList, 
        DataViewType dataViewType, int dataViewCount)
    {
        var processedList = dataViewType switch
        {
            DataViewType.Top => dispensaryList.GetRange(0, dataViewCount),
            DataViewType.Bottom => dispensaryList.GetRange(dispensaryList.Count - dataViewCount, dataViewCount),
            _ => throw new Exception()
        };

        return processedList;
    }

    private static void Show(List<Dispensary> elementsToShow)
    {
        foreach (var element in elementsToShow)
        {
            Console.WriteLine(element.ToString());
        }
    }
}