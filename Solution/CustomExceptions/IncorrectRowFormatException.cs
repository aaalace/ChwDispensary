namespace Solution.CustomExceptions;

public class IncorrectRowFormatException : Exception
{
    public IncorrectRowFormatException() {}
    public IncorrectRowFormatException(int rowNumber) 
        : base(message: $"Incorrect format in {rowNumber} row in file") {}
    protected IncorrectRowFormatException(string message, int rowNumber)
        : base(message: $"{message} in {rowNumber} row in file") { }
}