using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.RabbitMQ.Worker.Consumidor
{
    public interface ISincronizador<T> where T : class
    {
        Task Sincronizar(T obj);
    }
}
