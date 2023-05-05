using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.ValueObjects.Account;

public readonly partial struct Username
{
   public Username(string value)
   {
      if (!IsValid(value))
      {
         throw new InvalidUsernameException(value);
      }
      Value = value;
   }

   #region static

   [GeneratedRegex("^[a-zA-Z][a-zA-Z0-9_-]{2,30}$")]
   private static partial Regex MyRegex();

   private static Regex UsernameRegex { get; } = MyRegex();
   
   public static bool IsValid(string value)
   {
      return UsernameRegex.IsMatch(value);
   }

   #endregion

   private string Value { get; init; }
   
   public override string ToString()
   {
      return Value;
   }

   public static explicit operator string(Username username)
   {
      return username.Value;
   }

   public static explicit operator Username(string usernameString)
   {
      return new Username(usernameString);
   }
}
