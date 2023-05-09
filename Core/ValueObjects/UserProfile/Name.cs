using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.ValueObjects.UserProfile;

public readonly struct Name
{
   public string Value { get; init; }

   public Name(string value)
   {
      if (!IsValid(value)) throw new InvalidNameFormatException();
      Value = value;
   }

   #region static
   
   /// <summary>
   /// - does not start with a character.
   /// - have at least one char.
   /// - does not contain number.
   /// </summary>
   public static readonly Regex NameRegex = new(@"^(?! )(?!\s$)[^\d\s]+$");

   public static bool IsValid(string value) => NameRegex.IsMatch(value);
   
   #endregion
   
   public static explicit operator string(Name name) => name.Value;

   public static explicit operator Name(string nameString) => new (nameString);
   
   public static bool operator ==(Name n1, Name n2) => n1.Value.Equals(n2.Value);

   public static bool operator !=(Name n1, Name n2) => !n1.Value.Equals(n2.Value);

   public override string ToString() => Value;
}