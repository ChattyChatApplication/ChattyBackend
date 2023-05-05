using Core.ValueObjects.Account;

namespace Domain.Services.password_hash_service;

public interface IPasswordHashService
{
   public PasswordHash Hash(Password password);
}