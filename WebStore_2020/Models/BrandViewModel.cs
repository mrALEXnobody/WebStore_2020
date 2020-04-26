using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore_2020.Models
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Количество товаров.
        /// </summary>
        public int ProductsCount { get; set; }
    }
}