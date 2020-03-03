using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Infra.Dados.MongoDb.Modelos
{
    public class PessoaFisica
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
