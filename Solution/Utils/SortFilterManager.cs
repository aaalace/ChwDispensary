using LibDispensary;

namespace Solution.Utils;

public static class SortFilterManager
{
    private enum FormattingMode
    {
        SortIncrease,
        SortDecrease,
        FilterSpecialization,
        FilterChiefPosition
    }
    
    /// <summary>
    /// Gets sorted/filtered list of Dispensary objects.
    /// </summary>
    /// <param name="dispensaryList">List of unformatted objects.</param>
    /// <returns>List of formatted objects.</returns>
    public static List<Dispensary> GetFormattedDispensaryList(List<Dispensary> dispensaryList)
    {
        var formattingMode = GetFormattingMode();

        var formattedDispensaryList = formattingMode switch
        {
            FormattingMode.SortIncrease => Sort(formattingMode, dispensaryList),
            FormattingMode.SortDecrease => Sort(formattingMode, dispensaryList),
            FormattingMode.FilterSpecialization => Filter(formattingMode, dispensaryList),
            FormattingMode.FilterChiefPosition => Filter(formattingMode, dispensaryList),
            _ => throw new ArgumentException("Error in formatting action")
        };

        return formattedDispensaryList;
    }

    /// <summary>
    /// Gets formatting mode.
    /// </summary>
    /// <returns>Formatting mode.</returns>
    private static FormattingMode GetFormattingMode()
    {
        ConsoleManager.WriteLine("Select number of option to format data");
        ConsoleManager.WriteLine("1 - sort by district (increase)", color: ConsoleColor.Green);
        ConsoleManager.WriteLine("2 - sort by district (decrease)", color: ConsoleColor.Green);
        ConsoleManager.WriteLine("3 - filter by specialization", color: ConsoleColor.Green);
        ConsoleManager.WriteLine("4 - filter by chief position", color: ConsoleColor.Green);
        string? inputType = Console.ReadLine();
        if (inputType == null) { throw new ArgumentNullException(nameof(inputType)); }

        var formattingMode = inputType switch
        {
            "1" => FormattingMode.SortIncrease,
            "2" => FormattingMode.SortDecrease,
            "3" => FormattingMode.FilterSpecialization,
            "4" => FormattingMode.FilterChiefPosition,
            _ => throw new ArgumentException("Wrong formatting option")
        };

        return formattingMode;
    }

    /// <summary>
    /// Sorts list of objects.
    /// </summary>
    /// <param name="order">Way of ordering.</param>
    /// <param name="dispensaryList">Unsorted list of objects.</param>
    /// <returns>Sorted list of objects.</returns>
    private static List<Dispensary> Sort(FormattingMode order , List<Dispensary> dispensaryList)
    {
        var result = order switch
        {
            FormattingMode.SortIncrease =>
                dispensaryList.OrderBy(disp => disp.Address.District).ToList(),
            FormattingMode.SortDecrease =>
                dispensaryList.OrderByDescending(disp => disp.Address.District).ToList(),
            _ => throw new ArgumentException("Error in sorting")
        };

        return result;
    }

    /// <summary>
    /// Filters list of objects.
    /// </summary>
    /// <param name="type">Formatting mode.</param>
    /// <param name="dispensaryList">Unfiltered list of objects.</param>
    /// <returns>Filtered list of objects.</returns>
    private static List<Dispensary> Filter(FormattingMode type, List<Dispensary> dispensaryList)
    {
        string filterValue = GetFilterValue();
        var result = type switch
        {
            FormattingMode.FilterSpecialization =>
                dispensaryList.Where(disp => disp.Specialization == filterValue).ToList(),
            FormattingMode.FilterChiefPosition =>
                dispensaryList.Where(disp => disp.ChiefPosition == filterValue).ToList(),
            _ => throw new ArgumentException("Error in filtering")
        };

        return result;
    }

    /// <summary>
    /// Gets value from user to filter by.
    /// </summary>
    /// <returns>Value to filter by.</returns>
    private static string GetFilterValue()
    {
        ConsoleManager.WriteLine("Еnter a value for filtering");
        string? inputValue = Console.ReadLine();
        if (inputValue == null) { throw new ArgumentNullException(nameof(inputValue)); }

        return inputValue;
    }
}