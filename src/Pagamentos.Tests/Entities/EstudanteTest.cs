using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pagamentos.Domain.Entities;
using Pagamentos.Domain.ValueObjects;

namespace Pagamentos.Tests.Entities
{
    [TestClass]
    public class EstudanteTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var estudante = new Estudante(new Nome("Marcel", "Freire"),  "1234567890", "marcel@teste.com");
        }
    }
}