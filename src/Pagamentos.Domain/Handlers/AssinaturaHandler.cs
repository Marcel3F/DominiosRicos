using Flunt.Notifications;
using Pagamentos.Domain.Commands;
using Pagamentos.Domain.Entities;
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
    public class AssinaturaHandler : Notifiable, IHandler<CriarAssinaturaBoletoCommand>, IHandler<CriarAssinaturaPayPalCommand>, IHandler<CriarAssinaturaCartaoCommand>
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

            // Gerar as entidades
            var estudante = new Estudante(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new BoletoPagamento(command.CodigoBarras, command.NossoNumero, command.DataPagamento, command.DataVencimento, command.ValorGerado, command.ValorPago,
                endereco, command.Pagador, new Documento(command.PagadorDocumento, command.PagadorDocumentoTipo), email);

            // Relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            estudante.AdicionarAssinatura(assinatura);

            // Aplicar as validacoes
            AddNotifications(nome, documento, email, endereco, estudante, assinatura, pagamento);

            // Checar as notificacoes
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            // Salvar as informacoes
            _repository.CriarAssinatura(estudante);

            // Enviar e-mail de boas vindas
            // Chamar servico de e-mail

            // Retornar informacoes
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CriarAssinaturaPayPalCommand command)
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

            // Gerar as entidades
            var estudante = new Estudante(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new PaypalPagamento(command.CodigoTransacao, command.DataPagamento, command.DataVencimento, command.ValorGerado, command.ValorPago,
                endereco, command.Pagador, new Documento(command.PagadorDocumento, command.PagadorDocumentoTipo), email);

            // Relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            estudante.AdicionarAssinatura(assinatura);

            // Aplicar as validacoes
            AddNotifications(nome, documento, email, endereco, estudante, assinatura, pagamento);

            // Checar as notificacoes
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            // Salvar as informacoes
            _repository.CriarAssinatura(estudante);

            // Enviar e-mail de boas vindas
            // Chamar servico de e-mail

            // Retornar informacoes
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CriarAssinaturaCartaoCommand command)
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

            // Gerar as entidades
            var estudante = new Estudante(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new CartaoPagamento(command.NomeCartao, command.NumeroCartao, command.NumeroUltimaTransacao, command.DataPagamento, command.DataVencimento, command.ValorGerado, command.ValorPago,
                                                endereco, command.Pagador, new Documento(command.PagadorDocumento, command.PagadorDocumentoTipo), email);

            // Relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            estudante.AdicionarAssinatura(assinatura);

            // Aplicar as validacoes
            AddNotifications(nome, documento, email, endereco, estudante, assinatura, pagamento);

            // Checar as notificacoes
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            // Salvar as informacoes
            _repository.CriarAssinatura(estudante);

            // Enviar e-mail de boas vindas
            // Chamar servico de e-mail

            // Retornar informacoes
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
