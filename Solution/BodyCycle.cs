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
            Console.WriteLine(e.Message);
        }
        catch (IncorrectHeaderFormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IncorrectRowElementsNumberException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IncorrectRowFormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (DataViewTypeException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Unxpected error occured");
        }
    }
}