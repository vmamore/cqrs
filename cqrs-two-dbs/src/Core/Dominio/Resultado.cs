namespace CQRS.Dominio
{
    public sealed class Resultado
    {
        public string MensagemDeErro { get; }
        public bool Sucesso
        {
            get
            {

                return string.IsNullOrEmpty(MensagemDeErro);
            }
        }
        public bool Falhou
        {
            get
            {
                return !Sucesso;
            }
        }
        private Resultado(string mensagemDeErro)
        {
            MensagemDeErro = mensagemDeErro;
        }

        private Resultado()
        {
        }

        public static Resultado Erro(string mensagemDeErro)
        {
            return new Resultado(mensagemDeErro);
        }

        public static Resultado OK()
        {
            return new Resultado();
        }
    }
}
