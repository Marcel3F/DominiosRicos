using System.Collections.Generic;
using System.Linq;
using Pagamentos.Domain.ValueObjects;

namespace Pagamentos.Domain.Entities
{
    public class Estudante
    {
        private IList<Assinatura> _assinatura;
        public Estudante(Nome nome, string documento, string email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;

            _assinatura = new List<Assinatura>();
        }

        public Nome Nome { get; set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinatura.ToArray(); } }

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            foreach(var assi in Assinaturas)
                assi.DesativarAssinatura();
                
                _assinatura.Add(assinatura);

        }
    }
}