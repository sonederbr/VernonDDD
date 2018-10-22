using System;
using FluentValidation;
using FluentValidation.Results;

namespace Common.Domain.Core.Models
{
    public abstract class Entity2<T, TID> : AbstractValidator<T> where T : Entity2<T, TID>
    {
        public TID Id { get; protected set; }

        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; protected set; }

        public override bool Equals(object obj)
        {
            Entity2<T, TID> entity = obj as Entity2<T, TID>;
            if ((object)this == (object)entity)
                return true;
            if ((object)entity == null)
                return false;
            return this.Id.Equals((object)entity.Id);
        }

        public static bool operator ==(Entity2<T, TID> a, Entity2<T, TID> b)
        {
            if ((object)a == null && (object)b == null)
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals((object)b);
        }

        public static bool operator !=(Entity2<T, TID> a, Entity2<T, TID> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode() * 907 + this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.GetType().Name + " [Id=" + (object)this.Id + "]";
        }
    }

    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }

        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (object.ReferenceEquals(this, compareTo)) return true;
            if (object.ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
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
