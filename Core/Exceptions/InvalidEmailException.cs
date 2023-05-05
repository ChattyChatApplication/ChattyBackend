namespace Core.Exceptions;

public class InvalidEmailException : Exception
{
   public InvalidEmailException(string? email) : base(email)
   {
   }

   public override string Message => $"{base.Message} is an invalid email";
}