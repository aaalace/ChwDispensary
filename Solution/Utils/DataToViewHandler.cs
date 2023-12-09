﻿using Solution.CustomExceptions;
using Solution.DispensaryForm;
using LibDispensary;

namespace Solution.Utils;

public static class DataToViewHandler
{
    private enum DataViewType
    {
        Top,
        Bottom
    }
    
    public static void Show(List<Dispensary> dispensaryListToShow, string header)
    {
        if (dispensaryListToShow.Count == 0)
        {
            ConsoleManager.WriteLine("Empty set of objects", color: ConsoleColor.DarkRed);
            return;
        }
        
        try
        {
            var customForm = new CustomForm(dispensaryListToShow, header);
            ConsoleManager.WriteLine("Close opened window to continue console work...");
            customForm.ShowDialog();
        }
        catch (Exception)
        {
            ConsoleManager.WriteLine("Error in showing data in form. Here is console view:", 
                color: ConsoleColor.Yellow);
            ConsoleManager.WriteLine(header, color: ConsoleColor.White);
            foreach (var element in dispensaryListToShow)
            {
                ConsoleManager.WriteLine(element.ToString(), color: ConsoleColor.White);
            }
        }
    }
    
    public static void ParseAndShow(List<Dispensary> dispensaryList, string header)
    {
        var dataViewType = GetDataViewType();
        int dataViewCount = GetDataViewCount(dispensaryList.Count);
        var dispensaryListToShow = GetElementsToShow(dispensaryList, dataViewType, dataViewCount);
        Show(dispensaryListToShow, header);
    }

    private static DataViewType GetDataViewType()
    {
        ConsoleManager.WriteLine("Select view type (top / bottom):");
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
        ConsoleManager.WriteLine($"Select view count (1 - {countOfAll}) :");
        string? dataViewCountAsString = Console.ReadLine();
        
        if (dataViewCountAsString == null) { throw new ArgumentNullException(nameof(dataViewCountAsString)); }
        if (!int.TryParse(dataViewCountAsString, out int dataViewCount))
        {
            throw new FormatException("Wrong type of value");
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
}