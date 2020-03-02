using Administrativo.Pessoas;
using Administrativo.Pessoas.Interfaces;
using Administrativo.Pessoas.ObjetosDeValor;
using System;

namespace Dados.Factories
{
    public class PessoaFisicaFactory : IPessoaFisicaFactory
    {
        public PessoaFisica CriarNovaPessoa(string nome, string cpf, DateTime dataDeNascimento, string logradouro, string cep, string numero)
        {
            return new PessoaFisica(
                new Nome(nome),
                new CPF(cpf),
                dataDeNascimento,
                new Endereco(logradouro, numero, cep));
        }
    }
}
