using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.ValueObjects.Account;

public readonly struct Email
{
   public Email(string value)
   {
      if (!IsValid(value))
      {
         throw new InvalidEmailException(value);
      }
      Value = value;
   }

   #region static

   public static readonly Regex EmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");

   public static bool IsValid(string value)
   {
      return EmailRegex.IsMatch(value);
   }

   #endregion

   private string Value { get; init; }

   public override string ToString()
   {
      return Value;
   }

   public static explicit operator string(Email email)
   {
      return email.Value;
   }

   public static explicit operator Email(string emailString)
   {
      return new Email(emailString);
   }

   public static bool operator ==(Email eml1, Email eml2)
   {
      return eml1.Value.Equals(eml2.Value);
   }

   public static bool operator !=(Email eml1, Email eml2)
   {
      return !(eml1.Value.Equals(eml2.Value));
   }
}