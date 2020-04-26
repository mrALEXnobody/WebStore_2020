using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Сущность бренд.
    /// </summary>
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
