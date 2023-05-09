﻿using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.ValueObjects.Account;

public readonly struct Password
{
   public Password(string value)
   {
      if (!IsValid(value)) throw new InvalidPasswordFormatException(value);
      Value = value;
   }

   #region static

   public static readonly Regex PasswordRegex = new (@"^.{6,}$");

   public static readonly string RegexMessage = "At least 8 characters long, containing at least one lowercase letter, one uppercase letter, and one digit";
   
   public static bool IsValid(string value) => PasswordRegex.IsMatch(value);

   #endregion

   private string Value { get; init; }

   public override string ToString() => Value;

   public static explicit operator string(Password password) => password.Value;

   public static explicit operator Password(string passwordString) => new(passwordString);
}