using CQRS;
using System;

namespace Application.CasosDeUso.Administrativo.Commands
{
    public class CadastrarPessoaFisica : ICommand
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }

        public CadastrarPessoaFisica(string cpf, string nome, DateTime dataDeNascimento, string logradouro, string cep, string numero)
        {
            CPF = cpf;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Logradouro = logradouro;
            CEP = cep;
            Numero = numero;
        }
    }
}
