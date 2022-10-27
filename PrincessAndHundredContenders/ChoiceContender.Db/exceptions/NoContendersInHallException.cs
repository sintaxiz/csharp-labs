namespace ChoiceContender.Db.exceptions;

public class NoContendersInHallException : Exception
{
    public NoContendersInHallException()
    {
        
    }

    public NoContendersInHallException(string message) : base(message)
    {
        
    }

    public NoContendersInHallException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}