using Dapper.Contrib.Extensions;
using System;

namespace Infra.Dados.SqlStorage.Modelos
{
    [Table("matriculas")]
    public class Matricula
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public Guid TurmaId { get; set; }
    }
}
