using System;
using Pagamentos.Domain.ValueObjects;

namespace Pagamentos.Domain.Entities
{
    public class CartaoPagamento : Pagamento
    {
        public CartaoPagamento(
            string nomeCartao, 
            string numeroCartao, 
            string numeroUltimaTransacao,
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
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            NumeroUltimaTransacao = numeroUltimaTransacao;
        }

        public string NomeCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string NumeroUltimaTransacao { get; private set; }
    }
}