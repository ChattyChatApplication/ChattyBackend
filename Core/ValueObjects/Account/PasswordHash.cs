using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.ValueObjects.Account;

public readonly struct PasswordHash
{
   public PasswordHash(string value)
   {
      if (!IsValid(value))
      {
         throw new InvalidPasswordHashException(value);
      }
      Value = value;
   }

   #region static

   public static readonly Regex PasswordHashRegex = new Regex(".");

   public static bool IsValid(string value)
   {
      return PasswordHashRegex.IsMatch(value);
   }

   #endregion

   private string Value { get; init; }

   public override string ToString()
   {
      return Value;
   }

   public static explicit operator string(PasswordHash passwordHash)
   {
      return passwordHash.Value;
   }

   public static explicit operator PasswordHash(string passwordHashString)
   {
      return new PasswordHash(passwordHashString);
   }
}