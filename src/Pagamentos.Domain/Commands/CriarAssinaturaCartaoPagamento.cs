﻿using Pagamentos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pagamentos.Domain.Commands
{
    public class CriarAssinaturaCartaoPagamento
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string NumeroUltimaTransacao { get; set; }

        public string NumeroPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorGerado { get; set; }
        public decimal ValorPago { get; set; }

        public string Logradouro { get; set; }
        public string NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }

        public string Pagador { get; set; }
        public string PagadorEmail { get; set; }
        public string PagadorDocumento { get; set; }
        public ETipoDocumento PagadorDocumentoTipo { get; set; }
    }
}
