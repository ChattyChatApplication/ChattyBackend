using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.ValueObjects.Account;

public readonly struct Username
{
   public Username(string value)
   {
      if (!IsValid(value)) throw new InvalidUsernameException(value);
      Value = value;
   }

   #region static
   
   public static readonly Regex UsernameRegex = new Regex("^[a-zA-Z][a-zA-Z0-9_-]{2,30}$");
   
   public static bool IsValid(string value) => UsernameRegex.IsMatch(value);

   #endregion

   private string Value { get; init; }
   
   public override string ToString() => Value;

   public static explicit operator string(Username username) => username.Value;

   public static explicit operator Username(string usernameString) => new Username(usernameString);

   public static bool operator ==(Username usn1, Username uns2) => usn1.Value.Equals(uns2.Value);

   public static bool operator !=(Username usn1, Username uns2) => !usn1.Value.Equals(uns2.Value);
}
