using WaterDelivery.Domain.Validation;

namespace WaterDelivery.Domain.Entities;

public sealed class Client
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;

    public User? User { get; private set; }


    public Client(int userId, string name, string phone)
    {
        ValidateDomain(userId, name, phone);
        
        UserId = userId;
        Name = name;
        Phone = phone;
    }

    private void ValidateDomain(int userId, string name, string phone)
    {
        DomainExceptionValidation.When(userId <= 0, "Usuário de acesso inválido.");
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "O nome do cliente é obrigatório.");
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(phone), "O telefone é obrigatório.");
    }
}