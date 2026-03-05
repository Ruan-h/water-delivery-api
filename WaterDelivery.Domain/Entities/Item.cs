using WaterDelivery.Domain.Validation;

namespace WaterDelivery.Domain.Entities;

public sealed class Item
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string ImageUrl { get; private set; } = string.Empty;

    public Item(string name, string description, decimal price, int stock, string imageUrl)
    {
        ValidateDomain(name, description, price, stock, imageUrl);
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string imageUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "O nome é obrigatório");

        DomainExceptionValidation.When(name.Length < 3,
            "O nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description),
            "A descrição é obrigatória");

        DomainExceptionValidation.When(price < 0,
            "O preço não pode ser negativo");

        DomainExceptionValidation.When(stock < 0,
            "O estoque não pode ser negativo");

        DomainExceptionValidation.When(imageUrl?.Length > 250,
            "O link da imagem é muito longo");
        
        DomainExceptionValidation.When(imageUrl == null,
            "O link da imagem é obrigatório");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        ImageUrl = imageUrl ?? string.Empty;
    }
}