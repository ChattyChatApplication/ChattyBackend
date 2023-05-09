using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.ValueObjects.Account;

public readonly struct PasswordHash
{
   public PasswordHash(string value)
   {
      if (!IsValid(value)) throw new InvalidPasswordHashFormatException(value);
      Value = value;
   }

   #region static
   // TODO update regex
   public static readonly Regex PasswordHashRegex = new Regex(".");

   public static bool IsValid(string value) => PasswordHashRegex.IsMatch(value);

   #endregion

   private string Value { get; init; }

   public override string ToString() => Value;

   public static explicit operator string(PasswordHash passwordHash) => passwordHash.Value;

   public static explicit operator PasswordHash(string passwordHashString) => new PasswordHash(passwordHashString);
}