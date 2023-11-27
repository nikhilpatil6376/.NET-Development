using System;

/// <summary>
/// Represent User is aleady login
/// </summary>
public class UserAlreadyLoggedInException : Exception
{
    public UserAlreadyLoggedInException() : base() { }

    public UserAlreadyLoggedInException(string message):base(message) { }

    public UserAlreadyLoggedInException(string message, Exception innerException):base(message, innerException) { }
}

public class CustomeException
{
    public static void Main(string[] args)
    {
        try
        {
            throw new UserAlreadyLoggedInException("User is Logged in already: Duplicate session Not allowed");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}