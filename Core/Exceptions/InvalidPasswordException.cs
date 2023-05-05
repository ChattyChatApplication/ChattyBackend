namespace Core.Exceptions;

public class InvalidPasswordException : Exception
{
   public InvalidPasswordException(string password) : base(password)
   {
   }

   public override string Message => $"{base.Message} is an invalid password";
}
