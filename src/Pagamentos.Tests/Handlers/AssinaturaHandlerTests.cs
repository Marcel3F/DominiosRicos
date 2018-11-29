using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pagamentos.Domain.Commands;
using Pagamentos.Domain.Enums;
using Pagamentos.Domain.Handlers;
using Pagamentos.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pagamentos.Tests.Handlers
{
    [TestClass]
    public class AssinaturaHandlerTests
    {
        [TestMethod]
        public void RetornarErroDocumentoExiste()
        {
            var handler = new AssinaturaHandler(new FakeEstudanteRepository());
            var command = new CriarAssinaturaBoletoCommand
            {
                PrimeiroNome = "Maria",
                Sobrenome = "Bonita",
                Documento = "30030030030",
                Email = "teste@teste.com",

                CodigoBarras = "1231231231",
                NossoNumero = "12313123123123131",

                NumeroPagamento = "3123123",
                DataPagamento = DateTime.Now,
                DataVencimento = DateTime.Now.AddMonths(1),
                ValorGerado = 60,
                ValorPago = 60,

                Logradouro = "Rua a",
                NumeroEndereco = "1",
                Bairro = "A",
                Cidade = "B",
                Estado = "C",
                Pais = "D",
                CEP = "49000000",

                Pagador = "Cangaço",
                PagadorEmail = "cangaco@cangaco.com",
                PagadorDocumento = "12312312312312",
                PagadorDocumentoTipo = ETipoDocumento.CNPJ
            };

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}
