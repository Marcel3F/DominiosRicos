using System;

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
            CodigoBarras = codigoBarras;
            NossoNumero = nossoNumero;
        }

        public string CodigoBarras { get; private set; }
        public string NossoNumero { get; private set; }
    }
}