namespace Core.Exceptions;

public class InvalidPasswordFormatException : Exception
{
   public InvalidPasswordFormatException(string password) : base(password)
   {
   }

   public override string Message => $"{base.Message} is an invalid password";
}
