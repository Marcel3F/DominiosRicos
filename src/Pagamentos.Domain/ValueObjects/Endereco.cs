using Flunt.Validations;
using Pagamentos.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pagamentos.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string logradouro, string numero, string bairro, string cidade, string estado, string pais, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            CEP = cep;

            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(Logradouro, "Endereco.Logradouro", "Logradouro deve ter um valor")
               .IsNotNullOrEmpty(Bairro, "Endereco.Bairro", "Bairro deve ter um valor")
               .IsNotNullOrEmpty(Cidade, "Endereco.Cidade", "Cidade deve ter um valor")
               .IsNotNullOrEmpty(Estado, "Endereco.Estado", "Estado deve ter um valor")
               .IsNotNullOrEmpty(Pais, "Endereco.Pais", "Pais deve ter um valor"));
        }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string CEP { get; private set; }
    }
}
