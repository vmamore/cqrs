using Administrativo.Pessoas;
using Administrativo.Pessoas.Interfaces;
using Administrativo.Pessoas.ObjetosDeValor;
using System;

namespace Infra.Dados.SqlStorage
{
    public class PessoaFisicaFactory : IPessoaFisicaFactory
    {
        public PessoaFisica CriarNovaPessoa(string nome, string cpf, string email, DateTime dataDeNascimento, string logradouro, string cep, string numero)
        {
            return new PessoaFisica(
                new Nome(nome),
                new CPF(cpf),
                email,
                dataDeNascimento,
                new Endereco(logradouro, numero, cep));
        }
    }
}
