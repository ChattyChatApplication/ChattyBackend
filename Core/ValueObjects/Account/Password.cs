﻿using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.ValueObjects.Account;

public readonly struct Password
{
   public Password(string value)
   {
      if (!IsValid(value))
      {
         throw new InvalidPasswordException(value);
      }
      Value = value;
   }

   #region static

   private static readonly Regex PasswordRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");

   public static bool IsValid(string value)
   {
      return PasswordRegex.IsMatch(value);
   }

   #endregion

   private string Value { get; init; }

   public override string ToString()
   {
      return Value;
   }

   public static explicit operator string(Password password)
   {
      return password.Value;
   }

   public static explicit operator Password(string passwordString)
   {
      return new Password(passwordString);
   }
}