using CQRS.Events;
using System;
using System.Collections.Generic;

namespace CQRS.Dominio
{
    public abstract class Agregado : Entidade
    {
        public Agregado(Guid? id = null) : base(id)
        {
        }

        private readonly List<IEvent> _eventos = new List<IEvent>();

        public IReadOnlyList<IEvent> Eventos => _eventos;

        protected void AdicionarEvento(IEvent @event)
        {
            _eventos.Add(@event);
        }

    }
}
