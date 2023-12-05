namespace Solution.CustomExceptions;

public class DataViewTypeException : Exception
{
    public DataViewTypeException()
        : base("Incorrect option of view") {}
}