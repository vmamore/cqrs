using MediatR;
using System;
using System.Collections.Generic;

namespace CQRS.Dominio
{
    public abstract class Agregado : Entidade
    {
        public Agregado(Guid? id = null) : base(id)
        {
        }

        private readonly List<INotification> _eventos = new List<INotification>();

        public IReadOnlyList<INotification> Eventos => _eventos;

        protected void AdicionarEvento(INotification @event)
        {
            _eventos.Add(@event);
        }

    }
}
