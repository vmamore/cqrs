using System;

namespace Administrativo.Pessoas.Interfaces
{
    public interface IPessoaFisicaFactory
    {
        PessoaFisica CriarNovaPessoa(string nome, string cpf, DateTime dataDeNascimento, string logradouro, string cep, string numero);
    }
}
