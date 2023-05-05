using Core.ValueObjects.Account;

namespace Domain.Exceptions;

public class DuplicatedEmailException : Exception
{
   public DuplicatedEmailException(Email email) : base(email.ToString())
   {
   }

   public override string Message => $"{base.Message} is already exist";
}