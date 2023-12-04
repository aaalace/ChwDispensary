namespace Solution;

public static class BodyCycle
{
    public static void Run()
    {
        try
        {
            var initialDataList = FileManager.GetRowList();
            var dispensaryList = initialDataList.Select(DispensaryCreator.GetDispensaryObject).ToList();
        
            // Next program steps.
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}