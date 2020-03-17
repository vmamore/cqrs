using Infra.RabbitMQ.Consumidor.PessoaFisica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.RabbitMQ.Consumidor
{
    public static class Consumidor
    {
        public static void Main()
        {
            var pessoaFisicaConsumer = new RabbitMQConsumidor<PessoaFisicaData>("pessoa-fisica");

            pessoaFisicaConsumer.Subscribe((product) => Console.WriteLine(product.Name));

            Console.ReadLine();
        }
    }
}
