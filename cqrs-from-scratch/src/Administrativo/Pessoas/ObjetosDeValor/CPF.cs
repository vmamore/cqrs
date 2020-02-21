using CQRS.Dominio;

namespace Administrativo.Pessoas.ObjetosDeValor
{
    public class CPF : ObjetoDeValor
    {
        public string Numero { get; }

        public CPF(string numero)
        {
            Numero = numero;
        }
    }
}
