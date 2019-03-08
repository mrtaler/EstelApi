namespace EstelApi.Core.Seedwork
{
    using EstelApi.Core.Seedwork.Interfaces;
    using System;
    using System.Reflection;

    /// <inheritdoc cref="Entity" />
    /// <summary>
    /// The entity string.
    /// </summary>
    public abstract class EntityString : Entity, IEntity<string>
    {
        /// <summary>
        /// The requested hash code.
        /// </summary>
        private int? requestedHashCode;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>t t
        /// </returns>
        public static bool operator ==(EntityString left, EntityString right)
        {
            if (object.Equals(left, null))
            {
                return (object.Equals(right, null)) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>t t
        /// </returns>
        public static bool operator !=(EntityString left, EntityString right)
        {
            return !(left == right);
        }

        /// <summary>
        /// The is transient.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsTransient()
        {
            return this.Id == null;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var entity = obj as EntityString;
            if (entity == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetRealObjectType(this) != this.GetRealObjectType(obj))
            {
                return false;
            }

            if (this.IsTransient())
            {
                return false;
            }

            return entity.Id == this.Id;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            if (!this.IsTransient())
            {
                if (!this.requestedHashCode.HasValue)
                {
                    this.requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                }

                return this.requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// The get real object type.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        private Type GetRealObjectType(object obj)
        {
            var retVal = obj.GetType();

            // because can be compared two object with same id and 'types' but one of it is EF dynamic proxy type)
            if (retVal.GetTypeInfo().BaseType != null && retVal.Namespace == "System.Data.Entity.DynamicProxies")
            {
                retVal = retVal.GetTypeInfo().BaseType;
            }

            return retVal;
        }
    }
}