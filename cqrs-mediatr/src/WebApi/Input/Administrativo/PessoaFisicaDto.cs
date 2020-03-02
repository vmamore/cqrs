using System;

namespace WebApi.Input.Administrativo
{
    public class PessoaFisicaDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
    }
}
