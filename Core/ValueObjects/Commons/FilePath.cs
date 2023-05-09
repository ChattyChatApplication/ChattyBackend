using System.Text.RegularExpressions;

namespace Core.ValueObjects.Commons;

public readonly struct FilePath
{
   public string Value { get; }

   public FilePath(string value) => Value = value;

   #region Static

   /// <summary>
   /// Validates the URI value.
   /// </summary>
   public static readonly Regex UriRegex = new(@"");

   public static bool IsValid(string value) => UriRegex.IsMatch(value);

   #endregion

   public static explicit operator string(FilePath filePath) => filePath.Value;

   public static explicit operator FilePath(string pathString) => new(pathString);

   public static bool operator ==(FilePath p1, FilePath p2) => p1.Value.Equals(p2.Value);

   public static bool operator !=(FilePath p1, FilePath p2) => !p1.Value.Equals(p2.Value);

   public override string ToString() => Value;
}