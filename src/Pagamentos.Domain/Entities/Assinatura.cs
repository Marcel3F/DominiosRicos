using Flunt.Validations;
using Pagamentos.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagamentos.Domain.Entities
{
    public class Assinatura : Entity
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
        public IReadOnlyCollection<Pagamento> Pagamentos { get { return _pagamentos.ToArray(); } }

        public void AdicionarPagamento(Pagamento pagamento)
        {
            AddNotifications(new Contract()
                   .Requires()
                   .IsGreaterThan(DateTime.Now, pagamento.DataPagamento, "Assinatura.Pagamentos", "A data do pagamento deve ser futura"));

            if (Valid)
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