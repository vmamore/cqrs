using CQRS.Dominio;

namespace Administrativo.Pessoas.ObjetosDeValor
{
    public class Endereco : ObjetoDeValor
    {
        public string Logradouro { get; }
        public string Numero { get; }
        public string CEP { get; }

        public Endereco(string logradouro, string numero, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            CEP = cep;
        }
    }
}
