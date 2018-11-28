using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pagamentos.Domain.Enums;
using Pagamentos.Domain.ValueObjects;

namespace Pagamentos.Tests.ValuesObjects
{
    [TestClass]
    public class DocumentTests
    {
        //Red, Green, Refactor

        [TestMethod]
        public void RetornarErroCPNJInvalido()
        {
            var doc = new Documento("123", ETipoDocumento.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void RetornarSucessoCPNJValido()
        {
            var doc = new Documento("12345678912345", ETipoDocumento.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void RetornarErroCPFJInvalido()
        {
            var doc = new Documento("123", ETipoDocumento.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataRow("04274805581")]
        [DataRow("04274805582")]
        [DataRow("04274805583")]
        [DataRow("04274805584")]
        public void RetornarSucessoCPFValido(string cpf)
        {
            var doc = new Documento(cpf, ETipoDocumento.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
