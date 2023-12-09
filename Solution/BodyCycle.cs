using Solution.Utils;
using Solution.CustomExceptions;

namespace Solution;

public static class BodyCycle
{
    public static void Run()
    {
        try
        {
            // Get data from file.
            var fileLinesList = FileOpener.GetFileLines();
            OriginalDataHandler.CheckRowsNumber(fileLinesList);

            // Get header.
            var originalHeader = OriginalDataHandler.GetOriginalHeader(fileLinesList);
            OriginalDataHandler.CheckHeader(originalHeader);

            // Get data without header.
            var originalDataRowsList = OriginalDataHandler.GetOriginalDataRowsList(fileLinesList);

            // Get list of Dispensary objects from list of original rows.
            var dispensaryList = DispensaryCollectionCreator.GetDispensaryObjectsList(originalDataRowsList);

            // Show N rows (formatted as objects) from top/bottom.
            DataToViewHandler.ParseAndShow(dispensaryList, originalHeader);

            // Get sorted/filtered objects.
            var formattedDispensaryList = SortFilterManager.GetFormattedDispensaryList(dispensaryList);

            // Show sorted/filtered objects to user.
            DataToViewHandler.Show(formattedDispensaryList, originalHeader);

            // Save sorted/filtered objects to file.
            FileSaver.Save(formattedDispensaryList, originalHeader);

        }
        catch (EmptyInputRowsException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (IncorrectHeaderFormatException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (IncorrectRowElementsNumberException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (IncorrectRowFormatException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (DataViewTypeException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (FormatException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (ArgumentOutOfRangeException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (ArgumentNullException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (ArgumentException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (FileNotFoundException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (IOException e)
        {
            ConsoleManager.WriteLine(e.Message, color: ConsoleColor.DarkRed);
        }
        catch (Exception)
        {
            Console.WriteLine("Unxpected error occured");
        }
    }
}