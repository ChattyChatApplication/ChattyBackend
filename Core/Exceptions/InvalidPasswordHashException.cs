namespace Core.Exceptions;

public class InvalidPasswordHashException : Exception
{
   public InvalidPasswordHashException(string? passwordHash) : base(passwordHash)
   {
   }

   public override string Message => $"{base.Message} is an invalid password hash";
}