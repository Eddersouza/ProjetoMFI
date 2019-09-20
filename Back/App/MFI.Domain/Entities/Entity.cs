using edrsys.EventNotification.Entities;
using System;

namespace MFI.Domain.Entities
{
    /// <summary>
    /// Represents the entity base.
    /// </summary>
    public class Entity : EventNotificationEntity
    {
        /// <summary>
        /// Create new Entity.
        /// </summary>
        public Entity()
        {
            this.CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Date of entity creation.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// User to create entity.
        /// </summary>
        public string CreatedByUserId { get; set; }
    }
}