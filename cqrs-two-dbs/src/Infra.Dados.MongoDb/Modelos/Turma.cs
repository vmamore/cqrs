using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Infra.Dados.MongoDb.Modelos
{
    public class Turma
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public int QuantidadeDeVagas { get; set; }
        public IEnumerable<Aluno> Alunos { get; set; }
    }
}
