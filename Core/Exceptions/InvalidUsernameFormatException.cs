namespace Core.Exceptions;

public class InvalidUsernameFormatException : Exception
{
   public InvalidUsernameFormatException(string username) : base(username)
   {
   }

   public override string Message => $"{base.Message} is an invalid username";
}