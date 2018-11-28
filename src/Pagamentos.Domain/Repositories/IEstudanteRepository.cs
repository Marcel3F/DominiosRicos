using Pagamentos.Domain.Entities;

namespace Pagamentos.Domain.Repositories
{
    public interface IEstudanteRepository
    {
        bool DocumentoExiste(string documento);
        bool EmailExiste(string email);
        void CriarAssinatura(Estudante estudante);
    }
}
