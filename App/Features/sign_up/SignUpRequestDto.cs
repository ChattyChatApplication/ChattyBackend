﻿namespace App.Features;

public class SignUpRequestDto
{
   public string Username { get; set; } = null!;
   public string Email { get; set; } = null!;
   public string Password { get; set; } = null!;
}