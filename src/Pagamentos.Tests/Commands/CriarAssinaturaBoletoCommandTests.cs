using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pagamentos.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pagamentos.Tests.Commands
{
    [TestClass]
    public class CriarAssinaturaBoletoCommandTests
    {
        //Red, Green, Refactor

        [TestMethod]
        public void RetornarErroNomeInvalido()
        {
            var command = new CriarAssinaturaBoletoCommand
            {
                PrimeiroNome = ""
            };
            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }
    }
}
