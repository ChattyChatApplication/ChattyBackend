namespace Core.Exceptions;

public class InvalidPasswordHashFormatException : Exception
{
   public InvalidPasswordHashFormatException(string? passwordHash) : base(passwordHash)
   {
   }

   public override string Message => $"{base.Message} is an invalid password hash";
}