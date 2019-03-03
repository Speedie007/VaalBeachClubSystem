using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain;

namespace VaalBHCSSystem.Core.Events
{
    public class EntityUpdatedEvent<T> where T : BaseEntity
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="entity">Entity</param>
        public EntityUpdatedEvent(T entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Entity
        /// </summary>
        public T Entity { get; }
    }
}
