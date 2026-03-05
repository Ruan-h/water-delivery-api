using WaterDelivery.Domain.Validation;
using WaterDelivery.Domain.Enums;

namespace WaterDelivery.Domain.Entities;

public sealed class User
{
    public int Id { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public UserRole Role { get; private set; }

    public Client? Client { get; private set; }



    public User(string email, string passwordHash, UserRole role)
    {
        ValidateDomain(email, passwordHash);
        
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }

    private void ValidateDomain(string email, string passwordHash)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email), "O e-mail é obrigatório.");
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(passwordHash), "A senha é obrigatória.");
    }
}