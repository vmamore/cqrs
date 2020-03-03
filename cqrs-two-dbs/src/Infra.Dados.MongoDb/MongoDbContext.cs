using Infra.Dados.MongoDb.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infra.Dados.MongoDb
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<ConfigurationSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);

            if (mongoClient != null)
                _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<PessoaFisica> PessoasFisicas
        {
            get
            {
                return _database.GetCollection<PessoaFisica>("PessoasFisicas");
            }
        }
    }
}
