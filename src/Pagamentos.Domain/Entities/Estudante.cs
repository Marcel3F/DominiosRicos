using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using Pagamentos.Domain.ValueObjects;
using Pagamentos.Shared.Entities;

namespace Pagamentos.Domain.Entities
{
    public class Estudante : Entity
    {
        private IList<Assinatura> _assinatura;

        public Estudante(Nome nome, Documento documento, Email email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;

            _assinatura = new List<Assinatura>();

            AddNotifications(nome, documento, email);
        }

        public Nome Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinatura.ToArray(); } }

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            var existeAssinaturaAtiva = false;

            foreach(var assi in Assinaturas)
            {
                if (assi.Ativo)
                    existeAssinaturaAtiva = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(existeAssinaturaAtiva, "Estudante.Assinaturas", "Você já tem uma assinatura ativa")
                .IsLowerThan(0, assinatura.Pagamentos.Count, "Estudante.Assinatura.Pagamentos", "Essa assinatura não possui pagamentos"));

            //if (existeAssinaturaAtiva)
            //    AddNotification("Estudante.Assinaturas", "Você já tem uma assinatura ativa");

            _assinatura.Add(assinatura);
        }
    }
}