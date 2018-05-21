using System;
using System.Collections.Generic;

namespace Pagamentos.Domain.Entities
{
    public class Assinatura
    {
        private IList<Pagamento> _pagamentos;
        public Assinatura(DateTime? dataExpiracao)
        {
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
            DataExpiracao = dataExpiracao;
            Ativo = true;

            _pagamentos = new List<Pagamento>();
        }

        public DateTime DataCriacao { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public DateTime? DataExpiracao { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyCollection<Pagamento> Pagamentos { get; }

        public void AdicionarPagamentoAssinatura(Pagamento pagamento)
        {
            _pagamentos.Add(pagamento);
        }

        public void AtivarAssinatura()
        {
            Ativo = true;
            DataAtualizacao = DateTime.Now;
        }

        public void DesativarAssinatura()
        {
            Ativo = false;
            DataAtualizacao = DateTime.Now;
        }
    }
}