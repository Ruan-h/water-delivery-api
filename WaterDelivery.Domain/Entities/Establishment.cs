using WaterDelivery.Domain.Validation;

namespace WaterDelivery.Domain.Entities
{
    public sealed class Establishment
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public bool IsOpen { get; private set; }

        public Establishment(string name)
        {
            ValidateDomain(name);
            IsOpen = false; 
        }

        public void UpdateName(string name)
        {
            ValidateDomain(name);    
        }

        public void Open()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;    
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "O nome é obrigatório.");

            DomainExceptionValidation.When(name.Length < 3,
                "O nome deve ter no mínimo 3 caracteres.");
                
            DomainExceptionValidation.When(name.Length > 100,
                "O nome excedeu o limite de 100 caracteres.");

            Name = name;
        }
    }
}