using System;

namespace Common.Domain.Core
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (object.ReferenceEquals(this, compareTo)) return true;
            if (object.ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b){
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b){
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]"; 
        }
    }
}
