using System;
using Pagamentos.Domain.ValueObjects;

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
            Endereco endereco, 
            string pagador, 
            Documento documento, 
            Email email) : base(
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