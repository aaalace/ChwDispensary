namespace Solution.CustomExceptions;

public class IncorrectRowElementsNumberException : IncorrectRowFormatException
{
    public IncorrectRowElementsNumberException(int rowNumber) 
        : base("Incorrect number of elements", rowNumber) { }
}