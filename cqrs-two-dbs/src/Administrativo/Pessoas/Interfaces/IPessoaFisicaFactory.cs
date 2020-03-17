using System;

namespace Administrativo.Pessoas.Interfaces
{
    public interface IPessoaFisicaFactory
    {
        PessoaFisica CriarNovaPessoa(string nome, string cpf, string email, DateTime dataDeNascimento, string logradouro, string cep, string numero);
    }
}
