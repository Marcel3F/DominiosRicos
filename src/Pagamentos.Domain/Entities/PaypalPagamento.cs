using System;

namespace Pagamentos.Domain.Entities
{
    public class PaypalPagamento : Pagamento
    {
        public PaypalPagamento(
            string codigoTransacao,
            DateTime dataPagamento, 
            DateTime dataVencimento, 
            decimal valorGerado, 
            decimal valorPago, 
            string endereco, 
            string pagador, 
            string documento, 
            string email) : base(
                dataPagamento, 
                dataVencimento, 
                valorGerado, 
                valorPago, 
                endereco, 
                pagador, 
                documento, 
                email)
        {
            CodigoTransacao = codigoTransacao;
        }

        public string CodigoTransacao { get; private set; }
    }
}