using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pagamentos.Domain.Entities;
using Pagamentos.Domain.Enums;
using Pagamentos.Domain.ValueObjects;
using System;

namespace Pagamentos.Tests.Entities
{
    [TestClass]
    public class EstudanteTests
    {
        private readonly Estudante _estudante;
        private readonly Assinatura _assinatura;
        private readonly Nome _nome;
        private readonly Documento _documento;
        private readonly Endereco _endereco;
        private readonly Email _email;

        public EstudanteTests()
        {
            _nome = new Nome("Maria", "Bonita");
            _documento = new Documento("30030030030", ETipoDocumento.CPF);
            _endereco = new Endereco("Rua A", "1", "Calangos", "Aracaju", "SE", "Brasil", "4900000");
            _email = new Email("maria.bonita@cangaco.com");
            _estudante = new Estudante(_nome, _documento, _email);
            _assinatura = new Assinatura(null);
            
        }

        [TestMethod]
        public void RetornarErroAssinaturaAtiva()
        {
            var pagamento = new PaypalPagamento("12312313", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _endereco, "Cangaço Corp", _documento, _email);
            _assinatura.AdicionarPagamento(pagamento);
            _estudante.AdicionarAssinatura(_assinatura);
            _estudante.AdicionarAssinatura(_assinatura);

            Assert.IsTrue(_estudante.Invalid);
        }

        [TestMethod]
        public void RetornarSucessoAssinaturaAtiva()
        {
            var pagamento = new PaypalPagamento("12312313", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _endereco, "Cangaço Corp", _documento, _email);
            _assinatura.AdicionarPagamento(pagamento);
            _estudante.AdicionarAssinatura(_assinatura);

            Assert.IsTrue(_estudante.Valid);
        }

        [TestMethod]
        public void RetornarErroAssinaturaSemPagamento()
        {
            _estudante.AdicionarAssinatura(_assinatura);

            Assert.IsTrue(_estudante.Invalid);

        }
    }
}