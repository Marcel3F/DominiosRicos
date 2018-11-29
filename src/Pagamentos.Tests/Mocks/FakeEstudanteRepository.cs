using Pagamentos.Domain.Entities;
using Pagamentos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pagamentos.Tests.Mocks
{
    public class FakeEstudanteRepository : IEstudanteRepository
    {
        public void CriarAssinatura(Estudante estudante)
        {
            throw new NotImplementedException();
        }

        public bool DocumentoExiste(string documento)
        {
            if (documento == "12312312312")
                return true;
            return false;
        }

        public bool EmailExiste(string email)
        {
            if (email == "email@email.com")
                return true;
            return false;
        }
    }
}
