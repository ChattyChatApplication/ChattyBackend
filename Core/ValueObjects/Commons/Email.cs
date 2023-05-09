using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.ValueObjects.Commons;

public readonly struct Email
{
   public Email(string value)
   {
      if (!IsValid(value)) throw new InvalidEmailFormatException(value);
      Value = value;
   }

   #region static

   public static readonly Regex EmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");

   public static bool IsValid(string value) => EmailRegex.IsMatch(value);

   #endregion

   private string Value { get; init; }

   public override string ToString() => Value;

   public static explicit operator string(Email email) => email.Value;

   public static explicit operator Email(string emailString) => new Email(emailString);

   public static bool operator ==(Email eml1, Email eml2) => eml1.Value.Equals(eml2.Value);

   public static bool operator !=(Email eml1, Email eml2) => !eml1.Value.Equals(eml2.Value);
}