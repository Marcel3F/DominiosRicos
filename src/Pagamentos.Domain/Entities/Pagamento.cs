using System;

namespace Pagamentos.Domain.Entities
{
    public abstract class Pagamento
    {
        protected Pagamento(DateTime dataPagamento, DateTime dataVencimento, decimal valorGerado, decimal valorPago, string endereco, string pagador, string documento, string email)
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
        }

        public string Numero { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal ValorGerado { get; private set; }
        public decimal ValorPago { get; private set; }
        public string Endereco { get; private set; }
        public string Pagador { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
    }
}