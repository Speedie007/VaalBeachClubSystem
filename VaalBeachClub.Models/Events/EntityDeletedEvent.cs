using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain;

namespace VaalBeachClub.Models.Events
{
    public class EntityDeletedEvent<T> where T : BaseEntity
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="entity">Entity</param>
        public EntityDeletedEvent(T entity)
        {
            this.Entity = entity;
        }

        /// <summary>
        /// Entity
        /// </summary>
        public T Entity { get; }
    }
}
