using Flunt.Validations;
using Pagamentos.Domain.Enums;
using Pagamentos.Shared.ValueObjects;

namespace Pagamentos.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
        public Documento(string numero, ETipoDocumento tipo)
        {
            Numero = numero;
            Tipo = tipo;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Documento.Numero", "Documento inválido"));
        }

        public string Numero { get; private set; }
        public ETipoDocumento Tipo { get; set; }

        private bool Validate()
        {
            if (Tipo == ETipoDocumento.CNPJ && Numero.Length == 14)
                return true;

            if (Tipo == ETipoDocumento.CPF && Numero.Length == 11)
                return true;

            return false;
        }
    }
}