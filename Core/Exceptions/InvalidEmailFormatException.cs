namespace Core.Exceptions;

public class InvalidEmailFormatException : Exception
{
   public InvalidEmailFormatException(string? email) : base(email)
   {
   }

   public override string Message => $"{base.Message} is an invalid email";
}