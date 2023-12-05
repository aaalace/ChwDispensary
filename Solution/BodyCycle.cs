using Solution.CustomExceptions;

namespace Solution;

public static class BodyCycle
{
    public static void Run()
    {
        try
        {
            // Getting path -> opening file -> getting rows from file -> checking for its number.
            var fileLinesList = FileManager.GetFileLines();
            OriginalDataHandler.CheckRowsNumber(fileLinesList);

            // Getting header from rows -> checking for its format.
            string originalHeader = OriginalDataHandler.GetOriginalHeader(fileLinesList);
            OriginalDataHandler.CheckHeader(originalHeader);

            // Getting rows without header.
            var originalDataRowsList = OriginalDataHandler.GetOriginalDataRowsList(fileLinesList);

            // Converting rows List<string> to List<Dispensary> if rows are correctly formatted.
            var dispensaryList = DispensaryCollectionCreator.GetDispensaryObjectsList(originalDataRowsList);

            // TODO: Next program steps using dispensaryList.
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