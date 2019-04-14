namespace EstelApi.Core.Seedwork
{
    using System;

    using EstelApi.Core.Seedwork.Interfaces;

    /// <inheritdoc cref="Entity" />
    /// <summary>
    /// The entity guid.
    /// </summary>
    public abstract class EntityGuid : Entity, IEntity<Guid>
    {
        /// <summary>
        /// The requested hash code.
        /// </summary>
        private int? requestedHashCode;

        private Guid id;

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the persistent object identifier
        /// </summary>
        public virtual Guid Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>true if equal
        /// </returns>
        public static bool operator ==(EntityGuid left, EntityGuid right)
        {
            if (object.Equals(left, null))
            {
                return object.Equals(right, null) ? true : false;
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
        /// <returns>true if not equal
        /// </returns>
        public static bool operator !=(EntityGuid left, EntityGuid right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Check if this entity is transient, ie, without identity at this moment
        /// </summary>
        /// <returns>True if entity is transient, else false</returns>
        public bool IsTransient()
        {
            return this.Id == Guid.Empty;
        }

        /// <summary>
        /// Generate identity for this entity
        /// </summary>
        public void GenerateNewIdentity()
        {
            if (this.IsTransient())
            {
                this.Id = IdentityGenerator.NewSequentialGuid();
            }
        }

        /// <summary>
        /// Change current identity for a new non transient identity
        /// </summary>
        /// <param name="identity">the new identity</param>
        public void ChangeCurrentIdentity(Guid identity)
        {
            if (identity != Guid.Empty)
            {
                this.Id = identity;
            }
        }

        /// <summary>
        /// <see cref="M:System.Object.Equals"/>
        /// </summary>
        /// <param name="obj"><see cref="M:System.Object.Equals"/>entity for equaling</param>
        /// <returns><see cref="M:System.Object.Equals"/>true if equal</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is EntityGuid))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var item = (EntityGuid)obj;

            if (item.IsTransient() || this.IsTransient())
            {
                return false;
            }
            else
            {
                return item.Id == this.Id;
            }
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
    }
}