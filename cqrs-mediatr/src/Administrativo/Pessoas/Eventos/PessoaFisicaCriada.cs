﻿using MediatR;
using System;

namespace Administrativo.Pessoas.Eventos
{
    public class PessoaFisicaCriada : INotification
    {
        public Guid PessoaId { get; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public PessoaFisicaCriada(
            Guid pessoaId,
            string nome,
            string email)
        {
            PessoaId = pessoaId;
            Nome = nome;
            Email = email;
        }
    }
}
