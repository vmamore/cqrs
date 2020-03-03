using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infra.Dados.MongoDb.Modelos
{
    public class Aluno
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
