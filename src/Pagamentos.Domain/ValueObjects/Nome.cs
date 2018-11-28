using Flunt.Validations;
using Pagamentos.Shared.ValueObjects;

namespace Pagamentos.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PrimeiroNome, 3, "Nome.PrimeiroNome", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(Sobrenome, 3, "Nome.Sobrenome", "Nome deve conter pelo menos 3 caracteres"));
        }

        public string PrimeiroNome { get; private set; } 
        public string Sobrenome { get; private set; }   
    }
}