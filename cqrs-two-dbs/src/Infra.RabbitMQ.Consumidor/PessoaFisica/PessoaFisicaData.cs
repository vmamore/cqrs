using System;

namespace Infra.RabbitMQ.Consumidor.PessoaFisica
{
    public class PessoaFisicaData
    {
        public Guid PessoaId { get; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }

        public PessoaFisicaData(
            Guid pessoaId,
            string nome,
            string email,
            DateTime dataDeNascimento,
            string logradouro,
            int numero,
            string cep)
        {
            PessoaId = pessoaId;
            Nome = nome;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            Logradouro = logradouro;
            Numero = numero;
            CEP = cep;
        }
    }
}
