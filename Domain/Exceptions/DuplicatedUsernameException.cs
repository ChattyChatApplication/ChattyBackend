using Core.ValueObjects.Account;

namespace Domain.Exceptions;

public class DuplicatedUsernameException : Exception
{
   public DuplicatedUsernameException(Username username) : base(username.ToString())
   {
   }

   public override string Message => $"{base.Message} is already exist";
}