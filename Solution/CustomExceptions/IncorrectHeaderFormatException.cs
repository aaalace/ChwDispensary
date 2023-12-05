namespace Solution.CustomExceptions;

public class IncorrectHeaderFormatException : Exception
{
    public IncorrectHeaderFormatException()
        : base("Incorrect header format") {}
}