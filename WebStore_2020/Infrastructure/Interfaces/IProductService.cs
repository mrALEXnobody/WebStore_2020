using System.Collections.Generic;
using WebStore.DomainNew;
using WebStore.DomainNew.Entities;

namespace WebStore_2020.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter filter);
        Product GetProductById(int id);
    }
}