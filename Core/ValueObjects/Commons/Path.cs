using System.Text.RegularExpressions;

namespace Core.ValueObjects.Commons;

public readonly struct Path
{
   public string Value { get; }

   public Path(string value) => Value = value;

   #region Static

   /// <summary>
   /// Validates the URI value.
   /// </summary>
   public static readonly Regex UriRegex = new(@"");

   public static bool IsValid(string value) => UriRegex.IsMatch(value);

   #endregion

   public static explicit operator string(Path path) => path.Value;

   public static explicit operator Path(string pathString) => new(pathString);

   public static bool operator ==(Path p1, Path p2) => p1.Value.Equals(p2.Value);

   public static bool operator !=(Path p1, Path p2) => !p1.Value.Equals(p2.Value);
}