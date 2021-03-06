﻿using CQRS;
using System;

namespace Administrativo.Pessoas.Eventos
{
    public class PessoaFisicaCriada : IEvent
    {
        public Guid PessoaId { get; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }

        public PessoaFisicaCriada(
            Guid pessoaId,
            string nome,
            string email,
            DateTime dataDeNascimento,
            string logradouro,
            string numero,
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
