namespace ChoiceContender.Db.exceptions;

public class UnfamiliarContenderException : Exception
{
    public UnfamiliarContenderException()
    {
    }

    public UnfamiliarContenderException(string? message) : base(message)
    {
    }

    public UnfamiliarContenderException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}