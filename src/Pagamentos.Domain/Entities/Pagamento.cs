using System;
using Flunt.Validations;
using Pagamentos.Domain.ValueObjects;
using Pagamentos.Shared.Entities;

namespace Pagamentos.Domain.Entities
{
    public abstract class Pagamento : Entity
    {
        protected Pagamento(DateTime dataPagamento, DateTime dataVencimento, decimal valorGerado, decimal valorPago, Endereco endereco, string pagador, Documento documento, Email email)
        {
            Numero = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            DataPagamento = dataPagamento;
            DataVencimento = dataVencimento;
            ValorGerado = valorGerado;
            ValorPago = valorPago;
            Endereco = endereco;
            Pagador = pagador;
            Documento = documento;
            Email = email;

            AddNotifications(new Contract()
                  .Requires()
                  .IsGreaterThan(0, ValorGerado, "Pagamento.ValorGerado", "O valor gerado não pode ser zero")
                  .IsGreaterOrEqualsThan(ValorGerado, ValorPago, "Pagamento.ValorPago", "O valor pago é menor que o valor do pagamento"));
        }

        public string Numero { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal ValorGerado { get; private set; }
        public decimal ValorPago { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Pagador { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
    }
}