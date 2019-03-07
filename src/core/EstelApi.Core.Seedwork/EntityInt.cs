namespace EstelApi.Core.Seedwork
{
    using System;

    using EstelApi.Core.Seedwork.Interfaces;

    public abstract class EntityInt : Entity, IEntity<int>
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as EntityInt);
        }

        private static bool IsTransient(EntityInt obj)
        {
            return obj != null && Equals(obj.Id, default(int));
        }

        private Type GetUnproxiedType()
        {
            return this.GetType();
        }

        public virtual bool Equals(EntityInt other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(this.Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = this.GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                       otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(this.Id, default(int)))
                return base.GetHashCode();
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityInt x, EntityInt y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(EntityInt x, EntityInt y)
        {
            return !(x == y);
        }
    }
}