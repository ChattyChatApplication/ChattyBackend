namespace Core.Exceptions;

public class InvalidUsernameException : Exception
{
   public InvalidUsernameException(string username) : base(username)
   {
   }

   public override string Message => $"{base.Message} is an invalid username";
}