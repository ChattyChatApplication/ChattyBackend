using Core.ValueObjects.Account;
using Core.ValueObjects.Commons;

namespace Domain.Exceptions;

public class DuplicatedEmailException : Exception
{
   public DuplicatedEmailException(Email email) : base(email.ToString())
   {
   }

   public override string Message => $"{base.Message} is already exist";
}