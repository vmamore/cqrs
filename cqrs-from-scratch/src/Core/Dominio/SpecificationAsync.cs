using System.Threading.Tasks;

namespace CQRS.Dominio
{
    public abstract class SpecificationAsync
    {
        public string Mensagem { get; }
        public abstract Task<bool> EstaValido();
    }
}
