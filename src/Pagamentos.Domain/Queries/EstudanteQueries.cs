using Pagamentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Pagamentos.Domain.Queries
{
    public static class EstudanteQueries
    {
        public static Expression<Func<Estudante, bool>> ObterEstudante(string documento)
        {
            return x => x.Documento.Numero == documento;
        }
    }
}
