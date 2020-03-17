using Administrativo.Pessoas.Eventos;
using Administrativo.Pessoas.ObjetosDeValor;
using CQRS.Dominio;
using System;

namespace Administrativo.Pessoas
{
    public class PessoaFisica : Agregado
    {
        public Nome Nome { get; set; }
        public CPF CPF { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataDeNascimento { get; set; }

        protected PessoaFisica() { }

        public PessoaFisica(Nome nome, CPF cpf, string email, DateTime dataDeNascimento, Endereco endereco) : base(Guid.NewGuid())
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            Endereco = endereco;

            AdicionarEvento(new PessoaFisicaCriada(
                this.Id.Value,
                nome.Texto,
                Email,
                DataDeNascimento,
                Endereco.Logradouro,
                Endereco.Numero,
                Endereco.CEP));
        }
    }
}
