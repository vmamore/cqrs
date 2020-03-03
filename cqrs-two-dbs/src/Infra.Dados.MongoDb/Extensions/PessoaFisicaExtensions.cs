namespace Infra.Dados.MongoDb.Extensions
{
    public static class PessoaFisicaExtensions
    {
        public static Infra.Dados.MongoDb.Modelos.PessoaFisica Converter(this Administrativo.Pessoas.PessoaFisica pessoaFisica)
        {
            return new Infra.Dados.MongoDb.Modelos.PessoaFisica
            {
                Id = pessoaFisica.Id.ToString(),
                Nome = pessoaFisica.Nome.Texto,
                Endereco = pessoaFisica.Endereco.ToString(),
                CPF = pessoaFisica.CPF.Numero,
                DataDeNascimento = pessoaFisica.DataDeNascimento
            };
        }
    }
}
