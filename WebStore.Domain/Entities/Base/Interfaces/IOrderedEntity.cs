﻿namespace WebStore.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Сущность с порядком.
    /// </summary>
    public interface IOrderedEntity
    {
        /// <summary>
        /// Порядок.
        /// </summary>
        int Order { get; set; }
    }
}
