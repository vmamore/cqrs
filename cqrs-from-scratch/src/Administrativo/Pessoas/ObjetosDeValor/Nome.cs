using CQRS.Dominio;

namespace Administrativo.Pessoas.ObjetosDeValor
{
    public class Nome : ObjetoDeValor
    {
        public string Texto { get; }

        public Nome(string texto)
        {
            Texto = texto;
        }
    }
}
