using System;
using Pagamentos.Domain.ValueObjects;

namespace Pagamentos.Domain.Entities
{
    public class BoletoPagamento : Pagamento
    {
        public BoletoPagamento(
            string codigoBarras, 
            string nossoNumero,
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
            CodigoBarras = codigoBarras;
            NossoNumero = nossoNumero;
        }

        public string CodigoBarras { get; private set; }
        public string NossoNumero { get; private set; }
    }
}