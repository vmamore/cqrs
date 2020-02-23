using CQRS.Dominio;

namespace Administrativo.Pessoas.ObjetosDeValor
{
    public class Nome : ObjetoDeValor
    {
        public string Texto { get; }

        protected Nome() {}

        public Nome(string texto)
        {
            Texto = texto;
        }
    }
}
