using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pagamentos.Domain.Entities;
using Pagamentos.Domain.Enums;
using Pagamentos.Domain.Queries;
using Pagamentos.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pagamentos.Tests.Queries
{
    [TestClass]
    public class EstudanteQueriesTests
    {
        private IList<Estudante> _estudantes;

        public EstudanteQueriesTests()
        {
            _estudantes = new List<Estudante>();
            for (var i = 0; i <= 10; i++)
            {
                _estudantes.Add(new Estudante(new Nome("Maria", $"Bonita-{i.ToString()}"), new Documento("12345678901", ETipoDocumento.CPF), new Email($"maria.bonita{i.ToString()}@cangaco.com")));
            }
        }

        [TestMethod]
        public void RetornarDocumentoNaoExiste()
        {
            var exp = EstudanteQueries.ObterEstudante("30030030030");
            var estudante = _estudantes.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, estudante);
        }

        [TestMethod]
        public void RetornarDocumentoExiste()
        {
            var exp = EstudanteQueries.ObterEstudante("12345678901");
            var estudante = _estudantes.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, estudante);
        }
    }
}
