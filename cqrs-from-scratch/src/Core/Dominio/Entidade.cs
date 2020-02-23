using System;

namespace CQRS.Dominio
{
    public abstract class Entidade {
        public Guid? Id { get; }

        public Entidade(Guid? id = null)
        {
            Id = id;
        }

        public override bool Equals(object entity)
        {
            if (!(entity is Entidade entityToBeCompared))
                return false;

            if (ReferenceEquals(this, entityToBeCompared))
                return true;

            if (GetType() != entityToBeCompared.GetType())
                return false;

            return Id == entityToBeCompared.Id;
        }

        public static bool operator ==(Entidade entityA, Entidade entityB)
        {
            if (ReferenceEquals(entityA, null) && ReferenceEquals(entityB, null))
                return true;

            if (ReferenceEquals(entityA, null) || ReferenceEquals(entityB, null))
                return false;

            return entityA.Equals(entityB);
        }

        public static bool operator !=(Entidade entityA, Entidade entityB)
        {
            return !(entityA == entityB);
        }

    }
}
