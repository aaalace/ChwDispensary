namespace Solution.CustomExceptions;

public class EmptyInputRowsException : Exception
{
    public EmptyInputRowsException()
        : base("File contains less than 1 row") {}
}