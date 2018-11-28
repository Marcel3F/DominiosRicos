using Flunt.Validations;
using Pagamentos.Shared.ValueObjects;

namespace Pagamentos.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(endereco, "Email.Endereco", "E-mail inválido"));
        }

        public string Endereco { get; set; }
    }
}
