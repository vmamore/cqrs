using CQRS.Dominio;
using System;

namespace Atendimento.Matriculas
{
    public class Turma : Entidade
    {
        public string Nome { get; }
        public string Codigo { get; set; }
        public int QuantidadeDeVagas { get; set; }

        public Turma(
            string nome,
            string codigo,
            int quantidadeDeVagas)
        {
            Nome = nome;
            Codigo = codigo;
            QuantidadeDeVagas = quantidadeDeVagas;
        }

        public bool ContabilizarMatricula(Guid matriculaId)
        {
            if (Guid.Empty != matriculaId)
            {
                QuantidadeDeVagas = QuantidadeDeVagas - 1; 
                return true;
            }

            return false;
        }
    }
}
