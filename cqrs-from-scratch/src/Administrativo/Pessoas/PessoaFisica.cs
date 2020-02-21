using Administrativo.Pessoas.ObjetosDeValor;
using CQRS.Dominio;
using System;

namespace Administrativo.Pessoas
{
    public class PessoaFisica : Entidade
    {
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public CPF CPF { get; set; }
        public Endereco Endereco { get; set; }

        public PessoaFisica(Nome nome, CPF cpf, Endereco endereco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            Endereco = endereco;
        }
    }
}
