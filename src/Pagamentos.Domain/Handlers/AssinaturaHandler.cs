using Flunt.Notifications;
using Pagamentos.Domain.Commands;
using Pagamentos.Domain.Enums;
using Pagamentos.Domain.Repositories;
using Pagamentos.Domain.ValueObjects;
using Pagamentos.Shared.Commands;
using Pagamentos.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pagamentos.Domain.Handlers
{
    public class AssinaturaHandler : Notifiable, IHandler<CriarAssinaturaBoletoCommand>
    {
        private readonly IEstudanteRepository _repository;

        public AssinaturaHandler(IEstudanteRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CriarAssinaturaBoletoCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            // Verificar se documento já está cadastrado
            if (_repository.DocumentoExiste(command.Documento))
                AddNotification("Documemnto", "Este CPF já está em uso");

            // Verificar se e-mail já está cadastrado
            if (_repository.EmailExiste(command.Email))
                AddNotification("Documemnto", "Este E-mail já está em uso");

            // Gerar os VOs
            var nome = new Nome(command.PrimeiroNome, command.Sobrenome);
            var documento = new Documento(command.Documento, ETipoDocumento.CPF);
            var endereco = new Endereco(command.Logradouro, command.NumeroEndereco, command.Bairro, command.Cidade, command.Estado, command.Pais, command.CEP);
            var email = new Email(command.Email);


            _estudante = new Estudante(_nome, _documento, _email);
            _assinatura = new Assinatura(null);

            // Gerar as entidades

            // Aplicar as validacoes

            // Salvar as informacoes

            // Enviar e-mail de boas vindas

            // Retornar informacoes

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
