namespace EstelApi.Core.Seedwork
{
    using System;

    using EstelApi.Core.Seedwork.Interfaces;

    /// <inheritdoc cref="IAuditableEntity" />
    public abstract class AuditableEntity : Entity, IAuditableEntity
    { 

        /// <inheritdoc/>
        public string CreatedBy { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }
        

        /// <inheritdoc/>
        public string LastModifiedBy { get; set; }

        /// <inheritdoc/>
        public DateTime LastModifiedAt { get; set; }
    }
}